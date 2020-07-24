using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class frmMItemGrp : ListForm
    {
        ProductGroupService service = new ProductGroupService();
        // 제품 그룹 관리
        public frmMItemGrp()
        {
            InitializeComponent();
        }

        private void frmMItemGrp_Load(object sender, EventArgs e)
        {
            
            dgv.AddNewColumns("제품그룹 코드", "Product_Group_ID", 100, true); // identity
            dgv.AddNewColumns("제품그룹 명칭", "Product_Group_Name", 100, true);
            dgv.AddNewBtnCol("","사용 여부",new Padding(1,1,1,1)); // 제품 그룹의 사용 여부를 결정
            dgv.AddNewColumns("비고1", "Product_Group_Note1", 100, true);
            dgv.AddNewColumns("비고2", "Product_Group_Note2", 100, true);
            dgv.AddNewColumns("최초등록시각", "First_Regist_Time", 100, true);
            dgv.AddNewColumns("최초등록사원", "First_Regist_Employee", 100, true);
            dgv.AddNewColumns("최종등록시각", "Final_Regist_Time", 100, true);
            dgv.AddNewColumns("최종등록사원", "Final_Regist_Employee", 100, true);
            dgv.AddNewColumns("순번", "Product_Group_Seq", 100, true);
            dgv.AddNewColumns("사용여부", "Product_Group_Use_String", 100, false); // 이 값에 따라 사용 여부 버튼 텍스트가 달라짐

            dgv.DataSource = service.SelectAllProductGroups();
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow row in dgv.Rows)
            {
                if (dgv[10, row.Index].Value.ToString() == "Y")
                    dgv[1, row.Index].Value = "사용";
                else 
                    dgv[1, row.Index].Value = "미사용";
            }
        }
    }
}
