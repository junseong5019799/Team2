using DevExpress.DataAccess.DataFederation;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory.BOM;

namespace WinMSFactory
{
    public partial class ProductInfoForm : PopUpDialogForm
    {
        ProductService pdSv = new ProductService();
        ProductGroupService pdgSv = new ProductGroupService();
        BOMManageForm frm = null;
        ProductVO vo;
        private char UseChar;
        string ProductNameText = null;
        bool EnabledProductName;
        bool IsUpdate = false;
        int Update_ProductID = 0;
        string employee;
        public ProductInfoForm(string employee, bool IsUpdate = true, ProductVO vo = null)
        {
            InitializeComponent();

            this.IsUpdate = IsUpdate;
            this.vo = vo;
            this.employee = employee;

            if (IsUpdate == true)
                Update_ProductID = vo.Product_ID;

            
        }
        public ProductInfoForm(BOMManageForm frm, string employee, string ProductNameText, bool EnabledProductName)
        {
            InitializeComponent();

            this.frm = frm;
            this.ProductNameText = ProductNameText;
            this.EnabledProductName = EnabledProductName;
            this.employee = employee;
        }

        private void ProductInfoForm_Load(object sender, EventArgs e)
        {
            if (EnabledProductName == true) // ProductName이 존재하는가
            {
                txtProductName.Text = ProductNameText;
                txtProductName.Enabled = false;
            }
                

            // 200/3 = 66.6666...
            txtProductName.MaxLength = 16;
            txtInformation.MaxLength = txtNote1.MaxLength = txtNote2.MaxLength = 66;
            radioButton1.Checked = true;
            txtUnit.MaxLength = 3;

            cboProductGroup.ComboBinding(pdgSv.ProductGroupComboBindingsNotAll(), "PRODUCT_GROUP_ID", "PRODUCT_GROUP_NAME");

            if(IsUpdate == true)
            {
                //vo.Product_ID
                UpdateFormSettings();
            }
        }

        private void UpdateFormSettings()
        {
            txtProductName.Text = vo.Product_Name;
            txtInformation.Text = vo.Product_Information;
            cboProductGroup.SelectedIndex = cboProductGroup.FindString(vo.Product_Group_Name);
            txtUnit.Text = vo.Product_Unit;
            numSEQ.Value = vo.Product_Seq;
            txtTactTime.Text = vo.Product_Tact_Time.ToString();
            txtLeadTime.Text = vo.Product_Lead_Time.ToString();
            numUnit.Value = vo.Product_Standards.ToInt();
            txtNote1.Text = vo.Product_Note1;
            txtNote2.Text = vo.Product_Note2;

            if (vo.Product_Use == "Y")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }

            else if (vo.Product_Use == "N")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtProductName.TextLength < 1 || txtInformation.TextLength < 1 || txtUnit.TextLength < 1 || txtLeadTime.TextLength<1 || txtTactTime.TextLength<1)
            {
                MessageBox.Show("전부 입력해주시기 바랍니다.");
                return;
            }

            

            ProductInsertVO ProductInsert = new ProductInsertVO
            {
                Product_ID = Update_ProductID,
                Product_Name = txtProductName.Text,
                Product_Group_ID = cboProductGroup.SelectedValue.ToInt(), // 그룹명 대신 그룹 ID를 넘겨줌
                Product_Information = txtInformation.Text,
                Product_Unit = txtUnit.Text,
                Product_Standards = Convert.ToInt32(numUnit.Value),
                Product_Note1 = txtNote1.Text,
                Product_Note2 = txtNote2.Text,
                Product_Use = UseChar,
                Final_Regist_Employee = employee,           // 나중에 직원 명을 가져올 것 (필수)
                Final_Regist_Time = DateTime.Now,
                Product_Tact_Time = txtTactTime.Text.ToInt(),
                Product_Lead_Time = txtLeadTime.Text.ToInt(),
                Product_Seq = numSEQ.Value.ToInt()
            };

            if(IsUpdate == false) // 등록
            {
                if (EnabledProductName == true) // BOM Copy에서 진행
                {
                    if (MessageBox.Show("정보 등록을 진행하시겠습니까?", "진행", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        frm.ProductInformation = ProductInsert;
                        this.Close();
                    }

                }

                else // 제품 등록 시 진행
                {
                    if (MessageBox.Show("정보 등록을 진행하시겠습니까?", "진행", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        // 등록 진행
                        if (pdSv.InsertProducts(ProductInsert, 'N'))
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            else if(IsUpdate == true) // 변경
            {
                if (MessageBox.Show("정보 등록을 진행하시겠습니까?", "진행", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    // 등록 진행
                    if (pdSv.UpdateProducts(ProductInsert))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                UseChar = 'Y';
            else
                UseChar = 'N';
        }

        private void txtTactTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
