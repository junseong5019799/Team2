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

        char IsBomStatusForward = 'Y';
        public BOMSelectAllForm()
        {
            InitializeComponent();
        }

        private void BOMSelectAllForm_Load(object sender, EventArgs e)
        {
            
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
            if (cboSelect.SelectedIndex == 0)
                IsBomStatusForward = 'Y';

            else
                IsBomStatusForward = 'N';

            dgv.DataSource = service.SelectAllBomProducts(IsBomStatusForward);
        }
    }
}
