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

namespace WinMSFactory.BOM_Nam_
{
    public partial class BOMSelectAllForm : BasicForm
    {
        BomService service = new BomService();

        public BOMSelectAllForm()
        {
            InitializeComponent();
        }

        private void BOMSelectAllForm_Load(object sender, EventArgs e)
        {
            dgv.IsAllCheckColumnHeader = true;

            dgv.AddNewColumns("상위 제품번호", "High_Product_ID", 100, true);
            dgv.AddNewColumns("하위 제품번호", "Low_Product_ID", 100, true); 
            dgv.AddNewColumns("제품명", "Product_Name", 100, true);
            dgv.AddNewColumns("제품명", "Product_Information", 100, true);
            dgv.AddNewColumns("제품 수량", "Bom_Use_Quantity", 100, true);
            dgv.AddNewColumns("기본 단위", "Product_Unit", 100, true);
            dgv.AddNewColumns("사용 여부", "Product_Use", 100, true);
            dgv.AddNewColumns("제품비고1", "Product_Note1", 100, true); 
            dgv.AddNewColumns("제품비고2", "Product_Note2", 100, true);
            dgv.AddNewColumns("최초 수정 시간", "First_Regist_Time", 100, true);
            dgv.AddNewColumns("최초 수정 직원", "First_Regist_Employee", 100, true);
            dgv.AddNewColumns("최종 수정 시간", "Final_Regist_Time", 100, true);
            dgv.AddNewColumns("최종 수정 직원", "Final_Regist_Employee", 100, true);

            // DB Select 진행할 것
            dgv.DataSource = service.SelectAllBomProducts();


        }
    }
}
