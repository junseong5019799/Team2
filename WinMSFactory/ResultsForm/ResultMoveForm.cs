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
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            DataGridViewContentAlignment LeftAlign = DataGridViewContentAlignment.MiddleLeft;

            dgv.AddNewColumns("재고번호", "Stock_No", 100, true, true, false, RightAlign);
            dgv.AddNewColumns("품목", "Product_Id", 150, false);
            dgv.AddNewColumns("품목 그룹", "Product_Group_Name", 150, true);
            dgv.AddNewColumns("품목명", "Product_Name", 200, true, true, false, LeftAlign);
            dgv.AddNewColumns("재고수량", "Stock_Quantity", 100, true, true, false, RightAlign);
            dgv.AddNewColumns("등록일", "Stock_Regist_Date", 150, true, true, false, LeftAlign);


            dgv2.AddNewColumns("재고번호", "Stock_No", 100, true, true, false, RightAlign);
            dgv2.AddNewColumns("품목 코드", "product_id", 150, false);
            dgv2.AddNewColumns("품명", "Product_Name", 200, true, true, false, LeftAlign);
            dgv2.AddNewColumns("공장", "Factory_name", 100, true, true, false, LeftAlign);
            dgv2.AddNewColumns("창고 코드", "Storage_id", 100, false);
            dgv2.AddNewColumns("창고명", "Storage_Name", 100, true, true, false, LeftAlign);                      
            dgv2.AddNewColumns("재고수량", "Stock_Quantity", 100, true, true, false, RightAlign);
            dgv2.AddNewColumns("등록일", "Stock_Regist_Date", 150, true, true, false, LeftAlign);

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
                        list.Add(Convert.ToInt32(dgv.Rows[i].Cells[2].Value));
                    }
                }
            }
            frm.IDList = list;
            frm.Show();

        }


        //재고 detail 보여주기 
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int product_id = Convert.ToInt32(dgv.SelectedRows[0].Cells[2].Value);
            dgv2.DataSource = service.GetStorageDetailList(product_id);            
        }
    }
}
