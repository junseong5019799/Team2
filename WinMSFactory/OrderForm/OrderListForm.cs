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

namespace WinMSFactory
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
            dgv.AddNewColumns("발주번호", "order_no", 100, true);             
            dgv.AddNewColumns("품명", "product_name", 100, true);
            dgv.AddNewColumns("발주량", "order_request_quantity", 100, true);
            dgv.AddNewColumns("발주상태", "order_status", 100, true);
            dgv.AddNewColumns("발주일", "order_request_date", 100, true);
            dgv.AddNewColumns("납기일", "release_plan_date", 100, true);
            dgv.AddNewColumns("거래처명", "company_name", 100, true);

            DataTable dt = orderService.GetOrderList();
            dgv.DataSource = dt;

            cboCompany.ComboBinding(orderService.SelectCompanyBindingByType(), "company_id", "company_name", "");              

        }

        private void btnDueDate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 1 )
            {
                DueDatePopUpForm frm = new DueDatePopUpForm();
                frm.Release_plan_date = Convert.ToDateTime(dgv.SelectedRows[0].Cells[6].Value.ToString());
                frm.Release_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[1].Value); 
                frm.Show();
            }
            else if(dgv.SelectedRows[0].Cells[4].Value.ToString() == "입고")
            {
                MessageBox.Show("이미 입고 된 상품 입니다.");
                return;
            }
        }
    }
}
