using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class ProductPriceDialogForm : PopUpDialogForm
    {
        ProductService pdsv = new ProductService();
        CompanyService cpsv = new CompanyService();
        ProductPriceManageVO ManageVO;
        List<ProductPriceManageVO> dgvList;
        int companyID;
        int productID;
        bool isInsert = true;
        string message;
        DateTime? PreviousTime;


        public ProductPriceDialogForm(bool IsInsert,  ProductPriceManageVO ManageVO = null, List<ProductPriceManageVO> dgvList = null)
        {
            InitializeComponent();
            this.isInsert = IsInsert;
            this.dgvList = dgvList;

            if (!IsInsert)
            {
                this.Text = message = "수정";
                this.ManageVO = ManageVO;
            }
            else
                this.Text = message = "등록";
        }

        private void ProductPriceDialogForm_Load(object sender, EventArgs e)
        {
            cboCompany.ComboBinding(cpsv.SelectCompanyBindings(), "COMPANY_ID", "COMPANY_Name");            
            txtPreviousPrice.Enabled = false;

            if (isInsert == false) // 수정
                ProductInfoModify();
        }

        private void ProductInfoModify() // 수정 메인
        {
            cboCompany.SelectedIndex = cboCompany.FindString(ManageVO.Company_Name);
            cboProduct.SelectedIndex = cboProduct.FindString(ManageVO.Product_Name);

            cboCompany.Enabled = cboProduct.Enabled = false;

            txtCurrentPrice.Text = string.Format("{0:#,0}",ManageVO.Material_Current_Price_String);

            if (ManageVO.Material_Previous_Price_String == "0")
                txtPreviousPrice.Text = "-";

            else
                txtPreviousPrice.Text = string.Format("{0:#,0}",ManageVO.Material_Previous_Price_String);

            dtpStartDate.Value= ManageVO.Start_Date;
            txtNote.Text = ManageVO.Note;
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyID = cboCompany.SelectedValue.ToInt();

            cboProduct.ComboBinding(pdsv.SelectProductBindings(companyID), "Product_ID", "Product_Name");
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PreviousPrice = 0;

            productID = cboProduct.SelectedValue.ToInt();

            if (pdsv.IsUpperData(companyID, productID, ref PreviousPrice, ref PreviousTime) == true)
                txtPreviousPrice.Text = PreviousPrice.ToString("#,0");
                
            else
                txtPreviousPrice.Text = "-";
            
        }

        private void btnConfirm_Click(object sender, EventArgs e) // 확인
        {
            if(cboProduct.Text.Length<1)
            {
                MessageBox.Show("물품을 선택해주세요");
                return;
            }

            else if (txtCurrentPrice.TextLength < 2)
            {
                MessageBox.Show("현재 단가를 입력해주세요 10원부터 입력 가능합니다.");
                return;
            }

            if (isInsert == true) // Insert
                UpsertSettings(0, "I"); // Insert의 I

            else if (isInsert == false) // Update , // 삭제는 다르게 함
                UpsertSettings(ManageVO.Material_Price_Code, "U"); // Update의 U

        }

        private void UpsertSettings(int Code, string Category)
        {
            if (MessageBox.Show($"정말로 {message}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            ProductPriceManageVO vo = new ProductPriceManageVO
            {
                // Update 목록 수정할 것
                Material_Price_Code = Code,
                Company_ID = cboCompany.SelectedValue.ToInt(),
                Product_ID = cboProduct.SelectedValue.ToInt(),
                Material_Previous_Price = txtPreviousPrice.Text.Replace(",", "").Replace("-", "").ToInt(),
                Material_Current_Price = txtCurrentPrice.Text.Replace(",", "").ToInt(),
                Start_Date = dtpStartDate.Value,
                Note = txtNote.Text,
                Category = Category
            };

            if (pdsv.UpsertMaterialPrice(vo) == true)
            {
                MessageBox.Show($"{message}이 완료되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) // 취소
        {
            this.Close();
        }

        private void txtCurrentPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtCurrentPrice.Text.Length > 0)
            {
                string ValueNum = txtCurrentPrice.Text.Replace(",", "");

                int InputData = Convert.ToInt32(ValueNum);

                txtCurrentPrice.Text = string.Format("{0:#,0}", InputData);
                txtCurrentPrice.SelectionStart = txtCurrentPrice.TextLength;
            }
        }
        private void txtCurrentPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (isInsert == false && ManageVO.RankNum != 1) // 수정
            {
                var DateItem = (from item in dgvList
                                where item.Product_Name == ManageVO.Product_Name && item.Company_Name == ManageVO.Company_Name
                                && item.RankNum < ManageVO.RankNum
                                orderby item.RankNum descending
                                select item.Start_Date).Take(1).ToList();

                if (dtpStartDate.Value <= DateItem[0])
                {
                    MessageBox.Show("날짜를 잘못입력하셨습니다.");
                    dtpStartDate.Value = DateItem[0].AddDays(1);
                }

            }
            else if(isInsert == true && txtPreviousPrice.TextLength > 1)
            {
                if (dtpStartDate.Value <= PreviousTime.Value)
                {
                    MessageBox.Show("날짜를 잘못입력하셨습니다.");
                    dtpStartDate.Value = PreviousTime.Value.AddDays(1);
                }
            }

        }
    }
}
