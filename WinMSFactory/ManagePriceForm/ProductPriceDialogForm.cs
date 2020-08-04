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
        bool IsFirstProductSelect = true;
        int? MaterialPriceCode = null;


        // Insert = 1, Update, Delete

        // 진행중... 5일까지 완료할 것


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
            dtpStartDate.MinDate = DateTime.Now;
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
                txtPreviousPrice.Text = vo.Material_Current_Price.ToString();
                txtEndDate.Text = vo.End_Date.ToString();

                dtpStartDate.Value = vo.Start_Date.AddDays(1);
                dtpStartDate.MinDate = vo.Start_Date.AddDays(1);
                MaterialPriceCode = vo.Material_Price_Code;

                if (IsInsert == true)
                    txtEndDate.Text = "-";
            }
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

                string EndDate = string.Empty;

                if (txtEndDate.TextLength < 1)
                    EndDate = null;

                else
                    EndDate = txtEndDate.Text;

                ProductPriceManageVO InsertData = new ProductPriceManageVO
                {
                    // Insert
                    Company_ID = cboCompany.SelectedValue.ToInt(),
                    Product_ID = cboProduct.SelectedValue.ToInt(),
                    Material_Previous_Price = txtPreviousPrice.Text.ToInt(),
                    Material_Current_Price = txtCurrentPrice.Text.ToInt(),
                    Start_Date = dtpStartDate.Value,
                    End_Date = EndDate,
                    Note = txtNote.Text
                };

                if(pdsv.InsertMaterialPrice(InsertData,MaterialPriceCode) == true)
                {
                    MessageBox.Show("등록이 완료되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }


            }

            else if (IsInsert == false) // Update , // 삭제는 다르게 함
            {
                
                ProductPriceManageVO InsertData = new ProductPriceManageVO
                {
                    // Update 목록 수정할 것
                    Company_ID = cboCompany.SelectedValue.ToInt(),
                    Product_ID = cboProduct.SelectedValue.ToInt(),
                    Material_Previous_Price = txtPreviousPrice.Text.ToInt(),
                    Material_Current_Price = txtCurrentPrice.Text.ToInt(),
                    Start_Date = dtpStartDate.Value
                };

                //if (pdsv.UpdateMaterialPrice(InsertData,) == true)
                //{
                //    MessageBox.Show("수정이 완료되었습니다.");
                //    this.DialogResult = DialogResult.OK;
                //    this.Close();
                //}
            }
            
        }
        private void btnCancel_Click(object sender, EventArgs e) // 취소
        {
            this.Close();
        }

        
    }
}
