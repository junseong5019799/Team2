using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;

namespace WinMSFactory
{
    public partial class BOMSelectAllForm : BasicForm
    {
        BomService service = new BomService();

        bool IsBOMForward;
        public BOMSelectAllForm()
        {
            InitializeComponent();
        }

        private void BOMSelectAllForm_Load(object sender, EventArgs e)
        {
            // 콤보박스 바인딩
            cboSelect.ComboBinding(service.BOMDeployeeBinding(), "Combo_Value_Member", "Combo_Display_Member");
            dgv.IsAllCheckColumnHeader = true;

            dgv.AddNewColumns("제품명", "Product_Name", 250, true);
            dgv.AddNewColumns("제품 스펙", "Product_Information", 200, true);
            dgv.AddNewColumns("제품 수량", "Bom_Use_Quantity", 100, true);
            dgv.AddNewColumns("제품 사용여부", "Product_Use", 110, true);
            dgv.AddNewColumns("제품비고1", "Product_Note1", 160, true); 
            dgv.AddNewColumns("제품비고2", "Product_Note2", 160, true);
            dgv.AddNewColumns("최초 수정 시간", "First_Regist_Time", 130, true);
            dgv.AddNewColumns("최초 수정 직원", "First_Regist_Employee", 110, true);
            dgv.AddNewColumns("최종 수정 시간", "Final_Regist_Time", 130, true);
            dgv.AddNewColumns("최종 수정 직원", "Final_Regist_Employee", 110, true);

            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            // DB Select 진행할 것
            


        }

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if(cboSelect.SelectedIndex == 0)
                IsBOMForward = true;
                
            else
                IsBOMForward = false;

            cboSelectType.ComboBinding(service.BOMTypeBinding(IsBOMForward), "Combo_Value_Member", "Combo_Display_Member");
            cboSelectType.SelectedIndex = 1;
        }

        private void cboSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProductGroupNum = 0;

            if(IsBOMForward == true)
            {
                if (cboSelectType.SelectedIndex == 0) // 완제품
                    ProductGroupNum = 0;

                else// 반제품
                    ProductGroupNum = 1;
            }
            else
            {
                if (cboSelectType.SelectedIndex == 0) // 원재료
                    ProductGroupNum = 2;
                else // 반제품
                    ProductGroupNum = 1;
            }
            cboSelectName.ComboBinding(service.BOMProductBinding(ProductGroupNum), "PRODUCT_ID", "PRODUCT_NAME");
        }

        private void buttonControl1_Click(object sender, EventArgs e)
        {
            if (cboSelectName.Text.Length < 1)
                MessageBox.Show("재료를 선택한 후 진행해주세요");
            else
                dgv.DataSource = service.BOMDeployDGVBinding(cboSelect.SelectedValue.ToInt());
        }
    }
}
