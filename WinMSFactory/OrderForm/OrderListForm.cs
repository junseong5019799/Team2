using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory.OrderForm
{
    public partial class OrderListForm : ListForm
    {
        public OrderListForm()
        {
            InitializeComponent();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("발주 번호", "release_no", 100, true);
            dgv.AddNewColumns("출고 번호", "company_id", 100, true);
            dgv.AddNewColumns("납품업체", "company_name", 100, true);
            dgv.AddNewColumns("주문 상태", "release_plan_date", 100, true);
            dgv.AddNewColumns("품명", "release_status", 100, true);
            dgv.AddNewColumns("납기일", "release_status", 100, true);
            dgv.AddNewColumns("발주량", "release_status", 100, true);
            dgv.AddNewColumns("발주일", "release_status", 100, true);
        }
        
        private void btnDueDate_Click(object sender, EventArgs e)
        {
            DueDatePopUpForm frm = new DueDatePopUpForm();
            frm.Show();
        }


    }
}
