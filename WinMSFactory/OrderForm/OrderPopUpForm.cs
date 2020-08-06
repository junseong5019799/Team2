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

namespace WinMSFactory
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
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            DataGridViewContentAlignment LeftAlign = DataGridViewContentAlignment.MiddleLeft;

            dgvCompany.AddNewColumns("업체코드", "company_id", 80, true);
            dgvCompany.AddNewColumns("발주업체", "company_name", 100, true);

            dgvCompany.DataSource = orderService.GetCompanyList();

            dgvOrder.AddNewColumns("PlanID", "release_no", 65, true, true, false, RightAlign);
            //dgvOrder.AddNewColumns("순서", "release_seq", 55, true, true, false, RightAlign);
            dgvOrder.AddNewColumns("업체코드", "company_id", 80, false);
            dgvOrder.AddNewColumns("거래처", "company_name", 80, true, true, false, LeftAlign);
            dgvOrder.AddNewColumns("품목", "product_id", 60, false);
            dgvOrder.AddNewColumns("품명", "product_name", 120, true, true, false, LeftAlign);
            dgvOrder.AddNewColumns("품목", "_product_id", 65, false);
            dgvOrder.AddNewColumns("품명", "_product_name", 120, true, true, false, LeftAlign);
            dgvOrder.AddNewColumns("발주제안 수량", "order_request_quantity", 100, true, true, false, RightAlign);
            dgvOrder.AddNewColumns("발주량", "", 70, true, true, false, RightAlign);
            dgvOrder.AddNewColumns("재고량", "stock_quantity", 70, true, true, false, RightAlign);
            dgvOrder.AddNewColumns("납기일", "release_plan_date", 110, true);
            

            DataTable dt = orderService.GetOrderPlanList();
            dgvOrder.DataSource = dt;            

            dgvOrder.Columns[11].DefaultCellStyle.BackColor = Color.AliceBlue;
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
                        orderVO.product_id = Convert.ToInt32(dgvOrder.Rows[i].Cells[6].Value);
                        orderVO.order_request_quantity = Convert.ToInt32(dgvOrder.Rows[i].Cells[11].Value);
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
