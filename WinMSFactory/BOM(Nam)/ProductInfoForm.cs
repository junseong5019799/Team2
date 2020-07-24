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
using WinMSFactory.BOM;

namespace WinMSFactory
{
    public partial class ProductInfoForm : Form
    {

        private char UseChar;

        BomForm frm;
        SendInfoVO vo;
        public ProductInfoForm(BomForm frm, SendInfoVO vo)
        {
            InitializeComponent();

            this.frm = frm;
            this.vo = vo;

            lblProductName.Text = vo.ProductName;
            lblGroupName.Text = vo.ProductGroup;
            lblGroupNum.Text = vo.ProductGroupNum.ToString();
            if(vo.UseCheck == true)
            {
                UseChar = 'Y';
                lblUsable.Text = "사용";
            }
            else
            {
                UseChar = 'N';
                lblUsable.Text = "미사용";
            }
        }

        private void ProductInfoForm_Load(object sender, EventArgs e)
        {
            // 200/3 = 66.6666...
            txtInformation.MaxLength = txtNote1.MaxLength = txtNote2.MaxLength = 66;

            txtUnit.MaxLength = 3;
        }

        private void buttonControl1_Click(object sender, EventArgs e)
        {
            if(txtInformation.TextLength<1 || txtUnit.TextLength<1)
            {
                MessageBox.Show("전부 입력해주시기 바랍니다.");
                return;
            }
            if(MessageBox.Show("정보 등록을 진행하시겠습니까?","진행",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProductInsertVO ProductInsert = new ProductInsertVO
                {
                    Product_Name = vo.ProductName,
                    Product_Group_ID = vo.ProductGroupNum, // 그룹명 대신 그룹 ID를 넘겨줌
                    Product_Information = txtInformation.Text,
                    Product_Unit = txtUnit.Text,
                    Product_Standards = Convert.ToInt32(numUnit.Value),
                    Product_Note1 = txtNote1.Text,
                    Product_Note2 = txtNote2.Text,
                    // Product_Seq                       // 물어볼 것
                    Product_Use = UseChar
                };

                frm.ProductInfo = ProductInsert;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
