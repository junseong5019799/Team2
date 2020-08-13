using Microsoft.Office.Interop.Excel;
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

namespace WinMSFactory.ManagePriceForm
{
    public partial class SellPriceDialogForm : PopUpDialogForm
    {
        ReleaseService releaseService = new ReleaseService();
        ProductService productService = new ProductService();
        SellPriceManageVO ManageVO;
        List<SellPriceManageVO> dgvList;
        int productGroupID;
        int productID;
        bool isInsert = true;
        string message;
        DateTime? PreviousTime;
        

        public SellPriceDialogForm(bool IsInsert,  SellPriceManageVO ManageVO = null, List<SellPriceManageVO> dgvList = null)
        {
            InitializeComponent();

            this.isInsert = IsInsert;
            this.dgvList = dgvList;

            if (!IsInsert)  //수정 
            {
                this.Text = message = "수정";
                this.ManageVO = ManageVO;
            }
            else
                this.Text = message = "등록";
                
        }

        private void SellPriceDialogForm_Load(object sender, EventArgs e)
        {
            cboProductGroup.ComboBinding(releaseService.SelectProductGroup(), "product_group_id", "product_group_name");
            txtPreviousPrice.Enabled = false;

            if (isInsert == false)
                ProductInfoModify();
        }
        
        private void cboProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            productGroupID = cboProductGroup.SelectedValue.ToInt();
            
            cboProduct.ComboBinding(releaseService.SelectProductByGroup(productGroupID), "Product_ID", "Product_Name");
        }

        private void ProductInfoModify()
        {

            cboProductGroup.SelectedIndex = cboProductGroup.FindString(ManageVO.Product_Group_Name);
            cboProduct.SelectedIndex = cboProduct.FindString(ManageVO.Product_Name);

            cboProduct.Enabled = cboProductGroup.Enabled = false;

            txtCurrentPrice.Text = string.Format("{0:#,0}", ManageVO.Sell_Current_Price_String);

            if (ManageVO.Sell_Previous_Price_String == "0")
                txtPreviousPrice.Text = "-";
            else
                txtPreviousPrice.Text = string.Format("{0:#,0}", ManageVO.Sell_Previous_Price_String);

            dtpStartDate.Value = ManageVO.Start_Date;
            txtNote.Text = ManageVO.Note;

        }

        private void Product_IndexChanged(object sender, EventArgs e)
        {
            int PreviousPrice = 0;

            productID = cboProduct.SelectedValue.ToInt();

            if (releaseService.IsUpperData(productGroupID, productID, ref PreviousPrice, ref PreviousTime) == true)
            {
                txtPreviousPrice.Text = PreviousPrice.ToString("#,0");
                dtpStartDate.Value = PreviousTime.Value.AddDays(1);
            }
                
            else
                txtPreviousPrice.Text = "-";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cboProduct.Text.Length < 1)
            {
                MessageBox.Show("물품을 선택해주세요");
                return;
            }
            else if (txtCurrentPrice.TextLength < 2 )
            {
                MessageBox.Show("현재 단가를 입력해주세요 10원부터 입력 가능합니다.");
                return;
            }
            

            if (isInsert == true) // 등록
                UpsertSettings(0);

            else // 수정
                UpsertSettings(ManageVO.Sellprice_Code);

        }

        private void UpsertSettings(int Code)
        {
            if (MessageBox.Show($"정말로 {message}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            SellPriceManageVO vo = new SellPriceManageVO
            {
                Sellprice_Code = Code,
                Product_Group_ID = cboProductGroup.SelectedValue.ToInt(),
                Product_ID = cboProduct.SelectedValue.ToInt(),
                Sell_Previous_Price = txtPreviousPrice.Text.Replace(",", "").Replace("-", "").ToInt(),
                Sell_Current_Price = txtCurrentPrice.Text.Replace(",", "").ToInt(),
                Start_Date = dtpStartDate.Value
            };

            if (txtNote.TextLength < 1)
                vo.Note = "";
            else
                vo.Note = txtNote.Text;

            if (productService.UpsertSellPrice(vo) == true)
            {
                MessageBox.Show($"{message}이 완료되었습니다.");
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
        private void txtCurrentPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (isInsert == false && ManageVO.RankNum != 1) // 수정
            {
                var DateItem = (from item in dgvList
                                where item.Product_Name == ManageVO.Product_Name && item.Product_Group_Name == ManageVO.Product_Group_Name
                                && item.RankNum < ManageVO.RankNum
                                orderby item.RankNum descending
                                select item.Start_Date).Take(1).ToList();

                
                if (dtpStartDate.Value <= DateItem[0])
                {
                    MessageBox.Show("날짜를 잘못 입력하셨습니다.");
                    dtpStartDate.Value = DateItem[0].AddDays(1);
                }
            }
            else if (isInsert == true && txtPreviousPrice.TextLength > 1)
            {
                if (dtpStartDate.Value <= PreviousTime.Value)
                {
                    MessageBox.Show("날짜를 잘못 입력하셨습니다.");
                    dtpStartDate.Value = PreviousTime.Value.AddDays(1);
                }
            }

        }
    }
}
