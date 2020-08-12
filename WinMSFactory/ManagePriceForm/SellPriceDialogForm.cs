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
        
        bool IsInsert = true;


        public SellPriceDialogForm(bool IsInsert, SellPriceManageVO ManageVO = null)
        {
            InitializeComponent();

            this.IsInsert = IsInsert;

            if (!IsInsert)  //수정
            {               
                this.ManageVO = ManageVO;
            }
        }

        private void SellPriceDialogForm_Load(object sender, EventArgs e)
        {
            cboProductGroup.ComboBinding(releaseService.SelectProductGroup(), "product_group_id", "product_group_name");

            //cboProductGroup.SelectedIndexChanged += cboProductGroup_SelectedIndexChanged;

            txtPreviousPrice.Enabled = false;
        }
        int productGroupID;
        int productID;
        private void cboProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            productGroupID = cboProductGroup.SelectedValue.ToInt();
            

            cboProduct.ComboBinding(releaseService.SelectProductByGroup(productGroupID), "Product_ID", "Product_Name");

           // cboProduct.SelectedIndexChanged += Product_IndexChanged;

            
        }

        private void Product_IndexChanged(object sender, EventArgs e)
        {
            int PreviousPrice = 0;

            productID = cboProduct.SelectedValue.ToInt();

            if (releaseService.IsUpperData(productGroupID, productID, ref PreviousPrice) == true)
                txtPreviousPrice.Text = PreviousPrice.ToString("#,0");
            else
                txtPreviousPrice.Text = "-";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtCurrentPrice.TextLength < 1)
            {
                MessageBox.Show("현재 단가를 입력해주세요");
                return;
            }

            if (IsInsert == true) // 등록
            {
                // 등록
                SellPriceManageVO vo = new SellPriceManageVO
                {
                    sellprice_code = 0,
                    product_group_id = cboProductGroup.SelectedValue.ToInt(),
                    product_id = cboProduct.SelectedValue.ToInt(),
                    sell_current_price = txtCurrentPrice.Text.Replace(",", "").ToInt(),
                    start_date = dtpStartDate.Value,
                    note = txtNote.Text
                };
                if(productService.UpsertSellPrice(vo) == true)
                {
                    MessageBox.Show("등록되었습니다.");
                }
            }
            else // 수정
            {
                //ManageVO.start_date = dtpStartDate.Value;
                //ManageVO.sell_current_price = Convert.ToInt32(txtCurrentPrice.Text);
                //ManageVO.product_information = txtNote.Text;
                //ManageVO.product_group_id = Convert.ToInt32(cboProductGroup.SelectedValue);
                //ManageVO.product_id = Convert.ToInt32(cboProduct.SelectedValue);
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
