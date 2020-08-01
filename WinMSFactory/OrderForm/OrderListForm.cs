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
    public partial class OrderListForm : ListForm
    {
        OrderService orderService = new OrderService();

        public OrderListForm()
        {
            InitializeComponent();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            DataTable dt = orderService.GetOrderList();
            dgv.DataSource = dt;
        }

        private void btnDueDate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                DueDatePopUpForm frm = new DueDatePopUpForm();
                frm.Release_plan_date = Convert.ToDateTime(dgv.SelectedRows[0].Cells[6].Value.ToString());
                frm.Release_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[1].Value); 
                frm.Show();
            }
        }

    }
}
