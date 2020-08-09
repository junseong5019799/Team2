using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UserConfiguration;
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

namespace WinMSFactory
{
    public partial class ProductGroupInfoForm : PopUpDialogForm
    {
        private char UseChar = 'Y';
        ProductGroupService service = new ProductGroupService();
        bool IsUpdate;
        ProductGroupVO groupVO;
        string Status = string.Empty;
        public ProductGroupInfoForm(bool IsUpdate = false, ProductGroupVO groupVO = null)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;
            this.groupVO = groupVO;

            if (IsUpdate == true)
            {
                this.Text = "제품 그룹 수정";
                Status = "수정";
            }
            else
                Status = "등록";
                
        }
        private void ProductGroupInfoForm_Load(object sender, EventArgs e)
        {
            txtProductName.MaxLength = 16;
            txtNote1.MaxLength = txtNote2.MaxLength = 66;
            rdoUse.Checked = true;

            if (IsUpdate == true)
            {
                txtProductName.Text = groupVO.Product_Group_Name;
                numSEQ.Value = groupVO.Product_Group_Seq;
                txtNote1.Text = groupVO.Product_Group_Note1;
                txtNote2.Text = groupVO.Product_Group_Note2;

                if (groupVO.Product_Group_Use_String == "사용")
                {
                    rdoUse.Checked = true;
                    rdoUnUse.Checked = false;
                }
                else
                {
                    rdoUse.Checked = false;
                    rdoUnUse.Checked = true;
                }
            }
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtProductName.TextLength<1)
            {
                MessageBox.Show("등록할 그룹을 입력해주세요");
                return;
            }
            EmployeeVO employee = this.GetEmployee();
            ProductGroupVO list = new ProductGroupVO
            {
                Product_Group_Name = txtProductName.Text,
                Product_Group_Use = UseChar,
                Product_Group_Note1 = txtNote1.Text,
                Product_Group_Note2 = txtNote2.Text,
                Final_Regist_Employee = employee.Employee_name,                    // 회원가입이 완성되면 직업명 넣어줄 것
                Final_Regist_Time = DateTime.Now,
                Product_Group_Seq = numSEQ.Value.ToInt()
            };

            if(IsUpdate == false) // 등록
            {
                list.Category = "I";
                list.Product_Group_ID = 0;
                UpsertMethod(list);
            }
            else // 수정
            {
                list.Category = "U";
                list.Product_Group_ID = groupVO.Product_Group_ID;
                UpsertMethod(list);
            }

            
        }

        private void UpsertMethod(ProductGroupVO list)
        {
            if (MessageBox.Show($"그룹을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (service.UpsertGroup(list))
                {
                    MessageBox.Show($"그룹이 {Status}되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUse.Checked)
                UseChar = 'Y';

            else
                UseChar = 'N';
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
