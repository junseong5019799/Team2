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
            dgvCompany.AddNewColumns("납품업체", "company_name", 100, true);

            dgvCompany.DataSource = orderService.GetCompanyList();

            dgvOrder.AddNewColumns("출고번호", "release_no", 80, true);
            dgvOrder.AddNewColumns("순서", "release_seq", 70, true);
            dgvOrder.AddNewColumns("거래처", "company_id", 100, false);
            dgvOrder.AddNewColumns("납품업체", "company_name", 120, true);
            dgvOrder.AddNewColumns("품목", "product_id", 80, false);
            dgvOrder.AddNewColumns("품명", "product_name", 120, true);
            dgvOrder.AddNewColumns("품목", "_product_id", 80, false);
            dgvOrder.AddNewColumns("자재", "_product_name", 120, true);
            dgvOrder.AddNewColumns("발주제안", "order_request_quantity", 80, true);
            dgvOrder.AddNewColumns("발주수량", "", 100, true, false);
            dgvOrder.AddNewColumns("재고량", "stock_quantity", 100, true);
            dgvOrder.AddNewColumns("납기일", "due_date", 100, true);

            DataTable dt = orderService.GetOrderPlanList();
            dgvOrder.DataSource = dt;
            

            dgvOrder.Columns[10].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            dgvOrder.EndEdit();

            for (int i = 0; i < dgvOrder.RowCount; i++)
            {
                if (dgvOrder.Rows[i].Cells[0].Value != null)
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
 
                        orderService.InsertOrder(orderVO);
                    }
                }
            }
            MessageBox.Show("발주 되었습니다. ");
            this.Close();
        
            
        }
    }
}
