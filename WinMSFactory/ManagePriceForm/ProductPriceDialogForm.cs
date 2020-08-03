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
        bool IsInsert;
        string Message = string.Empty;

        // Insert = 1, Update, Delete
        public ProductPriceDialogForm(bool IsInsert)
        {
            InitializeComponent();
            this.IsInsert = IsInsert;

            if (IsInsert == true)
                Message = "등록";
            else
                Message = "수정";

        }

        private void ProductPriceDialogForm_Load(object sender, EventArgs e)
        {
            cboCompany.ComboBinding(cpsv.SelectCompanyBindings(), "COMPANY_ID", "COMPANY_Name");
            cboCompany.SelectedIndexChanged += cboCompany_SelectedIndexChanged;
            cboCompany.SelectedIndex = 0;

            txtPreviousPrice.Enabled = false;
            txtEndDate.Enabled = false;

            
            
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProduct.ComboBinding(pdsv.SelectProductBindings(cboCompany.SelectedValue.ToInt()), "Product_ID", "Product_Name");


        }

        private void btnConfirm_Click(object sender, EventArgs e) // 확인
        {
            if(cboProduct.Text.Length<1)
            {
                MessageBox.Show("물품을 선택해주세요");
                return;
            }

            if (IsInsert == true) // Insert
            {
                if(MessageBox.Show($"정말로 {Message}하시겠습니까?","",MessageBoxButtons.YesNo) == DialogResult.No)
                    return;


                ProductPriceManageVO InsertData = new ProductPriceManageVO
                {
                    // Insert
                    Company_ID = cboCompany.SelectedValue.ToInt(),
                    Product_ID = cboProduct.SelectedValue.ToInt(),
                    Product_Previous_Price = txtPreviousPrice.Text.ToInt(),
                    Product_Current_Price = txtCurrentPrice.Text.ToInt(),
                    Start_Date = dtpStartDate.Value
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

            }
            
        }
        private void btnCancel_Click(object sender, EventArgs e) // 취소
        {
            this.Close();
        }
    }
}
