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
    public partial class OrderPopUpForm : PopUpDialogForm
    {
        OrderService orderService = new OrderService();
        public OrderPopUpForm()
        {
            InitializeComponent();
        }

        private void OrderPopUpForm_Load(object sender, EventArgs e)
        {
            dgvCompany.AddNewColumns("업체코드", "company_id", 80, true);
            dgvCompany.AddNewColumns("발주업체", "company_name", 100, true);

            dgvCompany.DataSource = orderService.GetCompanyList();

            DataTable dt = orderService.GetOrderPlanList();
            dgvOrder.DataSource = dt;

            dgvOrder.Columns[8].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

            //orderService.InsertOrderQuantity();
        }
    }
}
