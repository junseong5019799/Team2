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
using WinMSFactory.Services;

namespace WinMSFactory.OrderForm
{
    public partial class WareHouseWaitForm : ListListForm
    {
        OrderService orderService = new OrderService();

        public WareHouseWaitForm()
        {
            InitializeComponent();
        }

        private void WareHouseWaitForm_Load(object sender, EventArgs e)
        {
            DataTable dt = orderService.GetWareHouseList();
            dgv.DataSource = dt;

            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            DataGridViewContentAlignment LeftAlign = DataGridViewContentAlignment.MiddleLeft;

            dgvDetail.AddNewColumns("발주번호", "order_no", 80, true, true, false, RightAlign);
            dgvDetail.AddNewColumns("순서", "order_seq", 55, true, true, false, RightAlign);
            dgvDetail.AddNewColumns("창고", "storage_name", 100, true, true, false, LeftAlign);
            dgvDetail.AddNewColumns("품목", "product_id", 55, true, true, false, RightAlign);
            dgvDetail.AddNewColumns("품명", "product_name", 120, true, true, false, LeftAlign);
            dgvDetail.AddNewColumns("입고일", "due_date", 100, true, true, false, LeftAlign);
            dgvDetail.AddNewColumns("입고량", "warehouse_quantity", 90, true, true, false, RightAlign);
            dgvDetail.AddNewColumns("재고량", "stock_quantity", 90, true, true, false, RightAlign);
            dgvDetail.AddNewColumns("최종등록시간", "final_regist_time", 100, true, true, false, LeftAlign);
            dgvDetail.AddNewColumns("최종등록사원", "final_regist_employee", 100, true, true, false, LeftAlign);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int order_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            int product_id = Convert.ToInt32(dgv.SelectedRows[0].Cells[4].Value);
            DataTable dt = orderService.GetWareHouseDetail(order_no, product_id);
            dgvDetail.DataSource = dt;
        }


        /// <summary>
        /// 입고 처리하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("출고 할 목록을 선택하세요");
                return;
            }
            else if(dgv.SelectedCells[7].Value.ToString() == "입고")
            {
                MessageBox.Show("이미 입고 처리 된 목록입니다.");
                return;
            }
            else
            {
                WareHousePopUpForm frm = new WareHousePopUpForm();
                frm.Order_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
                frm.Product_id = Convert.ToInt32(dgv.SelectedRows[0].Cells[4].Value);
                frm.Product_name = dgv.SelectedRows[0].Cells[5].Value.ToString();
                frm.Order_seq = Convert.ToInt32(dgv.SelectedRows[0].Cells[1].Value);

                frm.Show();
            }
        }
    }
}
