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
        public ProductGroupInfoForm()
        {
            InitializeComponent();
        }
        private void ProductGroupInfoForm_Load(object sender, EventArgs e)
        {
            txtProductName.MaxLength = 16;
            txtNote1.MaxLength = txtNote2.MaxLength = 66;
            rdoUse.Checked = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtProductName.TextLength<1)
            {
                MessageBox.Show("등록할 그룹을 입력해주세요");
                return;
            }

            ProductGroupVO list = new ProductGroupVO
            {
                Product_Group_Name = txtProductName.Text,
                Product_Group_Use = UseChar,
                Product_Group_Note1 = txtNote1.Text,
                Product_Group_Note2 = txtNote2.Text,
                Final_Regist_Employee = "직원명",                    // 회원가입이 완성되면 직업명 넣어줄 것
                Final_Regist_Time = DateTime.Now
            };

            if(service.InsertGroup(list))
            {
                MessageBox.Show("그룹이 등록되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("중복된 그룹이름입니다. 다른 이름을 입력해주세요");
                return;
            }

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUse.Checked)
                UseChar = 'Y';
            else
                UseChar = 'N';
        }

        
    }
}
