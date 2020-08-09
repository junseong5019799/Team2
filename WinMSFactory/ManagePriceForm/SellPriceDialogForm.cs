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
        SellPriceManageVO ManageVO;
        bool IsFirstProductSelect = true;
        bool IsInsert = true;


        public SellPriceDialogForm(bool IsInsert, SellPriceManageVO ManageVO = null)
        {
            InitializeComponent();

            this.IsInsert = IsInsert;

            if (!IsInsert)  //수정
            {
                ProductInfoModify();
                this.ManageVO = ManageVO;
            }
        }

        private void SellPriceDialogForm_Load(object sender, EventArgs e)
        {
            cboProductGroup.ComboBinding(releaseService.SelectProductGroup(), "product_group_id", "product_group_name"); 
            cboProductGroup.SelectedIndexChanged += cboProductGroup_SelectedIndexChanged;
            

            txtPreviousPrice.Enabled = false;
            txtEndDate.Enabled = false;

            dtpStartDate.MinDate = DateTime.Now;
            

        }

        private void cboProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsFirstProductSelect = true;

            txtPreviousPrice.Text = "-";
            txtCurrentPrice.Text = "";

            cboProduct.SelectedIndexChanged += cboProduct_SelectedIndexChanged;
            cboProduct.ComboBinding(releaseService.SelectProductByGroup(cboProductGroup.SelectedValue.ToInt()), "Product_ID", "Product_Name");

            if (IsFirstProductSelect == true)
            {
                //ProductIndexChange();
                IsFirstProductSelect = false;
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ProductInfoModify() 
        {
            dtpStartDate.MinDate = DateTime.Now.AddDays(-2);
            cboProductGroup.SelectedIndex = cboProductGroup.FindString(ManageVO.product_group_name);
            cboProduct.SelectedIndex = cboProduct.FindString(ManageVO.product_name);
            txtCurrentPrice.Text = string.Format("{0:#,0}", ManageVO.sell_current_price);

            if (ManageVO.sell_previous_price.ToString() == "-")
                txtPreviousPrice.Text = "-";

            else
                txtPreviousPrice.Text = string.Format("{0:#,0}", ManageVO.sell_previous_price.ToString());

            dtpStartDate.Text = ManageVO.start_date.ToString();

            if (ManageVO.end_date.ToString() == null)
                txtEndDate.Text = "-";

            else
                txtEndDate.Text = Convert.ToDateTime(ManageVO.end_date.ToString()).ToString("yyyy-MM-dd");


            txtNote.Text = ManageVO.note;
        }
    }
}
