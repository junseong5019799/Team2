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

namespace WinMSFactory.ResultForm
{
    public partial class ResultMoveForm : ListListForm
    {
        StorageService service = new StorageService();
        public ResultMoveForm()
        {
            InitializeComponent();
        }

        private void ResultMoveForm_Load(object sender, EventArgs e)
        {

            dgv.AddNewColumns("재고번호", "Stock_No", 100, true);
            dgv.AddNewColumns("품목", "Product_Id", 150, false);
            dgv.AddNewColumns("품목 그룹", "Product_Group_Name", 150, true);
            dgv.AddNewColumns("품목명", "Product_Name", 200, true);
            dgv.AddNewColumns("재고수량", "Stock_Quantity", 100, true);
            dgv.AddNewColumns("등록일", "Stock_Regist_Date", 150, true);


            dgv2.AddNewColumns("재고번호", "Stock_No", 100, true);
            dgv2.AddNewColumns("창고명", "Storage_id", 100, false);
            dgv2.AddNewColumns("창고명", "Storage_Name", 100, true);                   // 다른 창고 물품들을 이동할 수도 있어서
            dgv2.AddNewColumns("품목 그룹", "Product_Group_Name", 150, true);
            dgv2.AddNewColumns("품목명", "Product_Name", 200, true);
            dgv2.AddNewColumns("재고수량", "Stock_Quantity", 100, true);          // dgv에서 입력한 이동 수량을 표시
            dgv2.AddNewColumns("등록일", "Stock_Regist_Date", 150, true);

            cboStorage.ComboBinding(service.GetStorage(), "Storage_ID", "Storage_Name");

        }

        private void buttonControl2_Click(object sender, EventArgs e) // 검색
        {
            int SelectStorage = cboStorage.SelectedValue.ToInt();

            dgv.DataSource = service.SelectProductAll(SelectStorage);
        }



        private void buttonControl1_Click(object sender, EventArgs e) // 재고 이동
        {
            ResultListForm frm = new ResultListForm();
            List<int> list = new List<int>();

            dgv.EndEdit();

            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[0].Value != null)
                {
                    bool IsCheck = (bool)dgv.Rows[i].Cells[0].Value;

                    if (IsCheck)
                    {
                        list.Add(Convert.ToInt32(dgv.Rows[i].Cells[0].Value));
                    }
                }
            }
            frm.ID = list;
            frm.Show();

        }


        //재고 detail 보여주기 
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int storage_id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);

            //DataTable dt = releaseService.GetReleasePlanDetail(storage_id);
            //dgv2.DataSource = dt;
        }
    }
}
