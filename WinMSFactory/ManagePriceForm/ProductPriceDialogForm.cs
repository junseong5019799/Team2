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
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;

namespace WinMSFactory.ManagePriceForm
{
    public partial class ProductPriceDialogForm : PopUpDialogForm
    {
        ProductService pdsv = new ProductService();
        CompanyService cpsv = new CompanyService();
        ProductPriceManageVO ManageVO;
        bool IsInsert;
        string Message = string.Empty;
        bool IsFirstProductSelect = true;
        int? MaterialPriceCode = null;


        // Insert = 1, Update, Delete

        // 진행중... 5일까지 완료할 것


        public ProductPriceDialogForm(bool IsInsert, ProductPriceManageVO ManageVO = null)
        {
            InitializeComponent();
            this.IsInsert = IsInsert;

            if (IsInsert == true)
            {
                Message = "등록";
            }
                
            else
            {
                Message = "수정";
                this.ManageVO = ManageVO;
                
            }
                

        }

        private void ProductPriceDialogForm_Load(object sender, EventArgs e)
        {
            LoadSettings();

            ProductIndexChange();

            if (IsInsert == true)// 등록
            {
                txtEndDate.Text = "-";
            }
            else // 수정
            {
                DataUpdateLoad();
            }


        }

        private void DataUpdateLoad() // 수정 시 폼에 표시되는 데이터
        {
            cboCompany.SelectedIndex = cboCompany.FindString(ManageVO.Company_Name);
            cboProduct.SelectedIndex = cboProduct.FindString(ManageVO.Product_Name);
            txtCurrentPrice.Text = ManageVO.Material_Current_Price_String;
            txtPreviousPrice.Text = ManageVO.Material_Previous_Price_String;
            dtpStartDate.Value = Convert.ToDateTime(ManageVO.Start_Date_String);
            txtNote.Text = ManageVO.Note;
        }

        private void LoadSettings()
        {
            cboCompany.ComboBinding(cpsv.SelectCompanyBindings(), "COMPANY_ID", "COMPANY_Name");

            cboCompany.SelectedIndexChanged += cboCompany_SelectedIndexChanged;
            cboCompany.SelectedIndex = 0;

            txtPreviousPrice.Enabled = false;
            txtEndDate.Enabled = false;
            dtpStartDate.MinDate = DateTime.Now;
            this.Text = Message;
        }

        

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsFirstProductSelect = true;

            txtPreviousPrice.Text = "-";
            txtCurrentPrice.Text = "";

            cboProduct.SelectedIndexChanged += cboProduct_SelectedIndexChanged;
            cboProduct.ComboBinding(pdsv.SelectProductBindings(cboCompany.SelectedValue.ToInt()), "Product_ID", "Product_Name");
            
            if(IsFirstProductSelect == true)
            {
                ProductIndexChange();
                IsFirstProductSelect = false;
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductIndexChange();
        }

        private void ProductIndexChange()
        {
            txtPreviousPrice.Text = "-";
            txtCurrentPrice.Text = "";

            ProductPriceManageVO vo = null;

            bool dataCheck = pdsv.SelectPriceData(cboCompany.SelectedValue.ToInt(), cboProduct.SelectedValue.ToInt(), ref vo);

            if (dataCheck == true)
            {
                txtPreviousPrice.Text = vo.Material_Current_Price.ToString("#,0");

                if (vo.End_Date == null)
                    txtEndDate.Text = "-";
                else
                    txtEndDate.Text = vo.End_Date.Value.ToString();

                
                MaterialPriceCode = vo.Material_Price_Code;

                if (IsInsert == true)
                {
                    dtpStartDate.Value = vo.Start_Date.AddDays(1);
                    dtpStartDate.MinDate = vo.Start_Date.AddDays(1);
                    txtEndDate.Text = "-";
                }
                    
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e) // 확인
        {
            if(cboProduct.Text.Length<1)
            {
                MessageBox.Show("물품을 선택해주세요");
                return;
            }

            if(txtCurrentPrice.Text.Length<1)
            {
                MessageBox.Show("금액을 입력해주세요");
                return;
            }

            if (IsInsert == true) // Insert 완료
            {
                if(MessageBox.Show($"정말로 {Message}하시겠습니까?","",MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                ProductPriceManageVO InsertData = new ProductPriceManageVO
                {
                    // Insert
                    Material_Price_Code = 0,
                    Company_ID = cboCompany.SelectedValue.ToInt(),
                    Product_ID = cboProduct.SelectedValue.ToInt(),
                    Material_Previous_Price = txtPreviousPrice.Text.Replace(",","").ToInt(),
                    Material_Current_Price = txtCurrentPrice.Text.Replace(",","").ToInt(),
                    Start_Date = dtpStartDate.Value,
                    End_Date_String = txtEndDate.Text,
                    Note = txtNote.Text,
                    Category = 'I'
                };

                if(pdsv.InsertMaterialPrice(InsertData) == true)
                {
                    MessageBox.Show("등록이 완료되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }


            }

            else if (IsInsert == false) // Update , // 삭제는 다르게 함
            {
                ProductPriceManageVO UpdateData = new ProductPriceManageVO
                {
                    // Update 목록 수정할 것
                    Material_Price_Code = ManageVO.Material_Price_Code,
                    Company_ID = cboCompany.SelectedValue.ToInt(),
                    Product_ID = cboProduct.SelectedValue.ToInt(),
                    Material_Previous_Price = txtPreviousPrice.Text.Replace(",", "").ToInt(),
                    Material_Current_Price = txtCurrentPrice.Text.Replace(",", "").ToInt(),
                    Start_Date = dtpStartDate.Value,
                    Note = txtNote.Text,
                    Category = 'U'
                };

                if (pdsv.UpdateMaterialPrice(UpdateData) == true)
                {
                    MessageBox.Show("수정이 완료되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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
    }
}
