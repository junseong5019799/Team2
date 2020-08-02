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
using WinCoffeePrince2nd.Util;
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

            //cboCompany.ComboBinding();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int order_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);

            DataTable dt = orderService.GetWareHouseDetail(order_no);
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
