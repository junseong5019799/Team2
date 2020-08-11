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
        SellPriceManageVO manageVO;
        
        bool IsInsert = true;


        public SellPriceDialogForm(bool IsInsert, SellPriceManageVO ManageVO = null)
        {
            InitializeComponent();

            this.IsInsert = IsInsert;

            if (!IsInsert)  //수정
            {               
                this.manageVO = ManageVO;
            }
        }

        private void SellPriceDialogForm_Load(object sender, EventArgs e)
        {
            cboProductGroup.ComboBinding(releaseService.SelectProductGroup(), "product_group_id", "product_group_name"); 
            cboProductGroup.SelectedIndexChanged += cboProductGroup_SelectedIndexChanged;
            cboProduct.ComboBinding(releaseService.SelectProductByGroup(cboProductGroup.SelectedValue.ToInt()), "Product_ID", "Product_Name");

            txtPreviousPrice.Enabled = false;
            txtEndDate.Enabled = false;

            dtpStartDate.MinDate = DateTime.Now;           

        }
        
        private void cboProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (cboProductGroup.SelectedIndex >= 0)
            {
                txtPreviousPrice.Text = "-";
                txtCurrentPrice.Text = "";
            }
            
            cboProduct.ComboBinding(releaseService.SelectProductByGroup(cboProductGroup.SelectedValue.ToInt()), "Product_ID", "Product_Name");
                        
        }
     

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            manageVO.start_date = dtpStartDate.Value;
            manageVO.sell_current_price = Convert.ToInt32(txtCurrentPrice.Text);
            manageVO.product_information = txtNote.Text;
            manageVO.product_group_id = Convert.ToInt32(cboProductGroup.SelectedValue);
            manageVO.product_id = Convert.ToInt32(cboProduct.SelectedValue);

            productService.InsertSellPrice(manageVO);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
