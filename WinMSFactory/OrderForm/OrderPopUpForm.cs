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
    public partial class OrderPopUpForm : PopUpDialogForm
    {
        OrderService orderService = new OrderService();
        OrderVO orderVO = new OrderVO();

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
            

            dgvOrder.Columns[7].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvOrder.RowCount; i++)
            {            
                bool IsCheck = (bool)dgvOrder.Rows[i].Cells[0].Value;
           
                if (IsCheck)
                {
                    orderVO.company_id = Convert.ToInt32(dgvOrder.Rows[i].Cells[2].Value);
                    orderVO.first_regist_employee = "사원명";
                    orderVO.final_regist_employee = "사원명";
                    orderVO.product_id = Convert.ToInt32(dgvOrder.Rows[i].Cells[4].Value);
                    orderVO.order_request_quantity = Convert.ToInt32(dgvOrder.Rows[i].Cells[7].Value);
                    orderVO.order_status = "발주중";
                    orderVO.order_seq = 1;

                    if (orderService.InsertOrder(orderVO))
                        MessageBox.Show("등록");
                }                
            }
        
            
        }
    }
}
