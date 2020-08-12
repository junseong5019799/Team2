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
        

        private int release_no;

        public int Release_no
        {
            get { return release_no; }
            set { release_no = value; }
        }

        private DateTime due_date;

        public DateTime Due_date
        {
            get { return due_date; }
            set { due_date = value; }
        }


        public OrderPopUpForm()
        {
            InitializeComponent();
        }

        private void OrderPopUpForm_Load(object sender, EventArgs e)
        {
            //dgvCompany.AddNewColumns("업체코드", "company_id", 80, true);
            //dgvCompany.AddNewColumns("납품업체", "company_name", 100, true);

            //dgvCompany.DataSource = orderService.GetCompanyList();

            dgvOrder.AddNewColumns("주문번호", "release_no", 80, false);
            dgvOrder.AddNewColumns("순서", "release_seq", 70, false);
            dgvOrder.AddNewColumns("거래처", "company_id", 100, false);
            dgvOrder.AddNewColumns("납품업체", "company_name", 120, true);
            dgvOrder.AddNewColumns("품목", "product_id", 80, false);
            dgvOrder.AddNewColumns("품명", "product_name", 120, true);
            dgvOrder.AddNewColumns("품목", "_product_id", 80, true);
            dgvOrder.AddNewColumns("자재", "_product_name", 120, true);
            dgvOrder.AddNewColumns("발주제안", "order_request_quantity", 80, true);
            dgvOrder.AddNewColumns("발주수량", "", 100, true, false);
            dgvOrder.AddNewColumns("재고량", "stock_quantity", 100, true);
            dgvOrder.AddNewColumns("납기일", "납기일", 100, true);

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "납기일변경";
            btn.Text = "변경";
            btn.Width = 100;
            btn.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            btn.UseColumnTextForButtonValue = true;
            dgvOrder.Columns.Add(btn);

            DataTable dt = orderService.GetOrderPlanList(release_no);
            dgvOrder.DataSource = dt;
            

            dgvOrder.Columns[10].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {            
            dgvOrder.EndEdit();

            List<OrderVO> olist = new List<OrderVO>();         
            
            for (int i = 0; i < dgvOrder.RowCount; i++)
            {
                if (dgvOrder.Rows[i].Cells[0].Value != null)
                {
                    bool IsCheck = (bool)dgvOrder.Rows[i].Cells[0].Value;
                    int cnt = 0;

                    if (IsCheck && dgvOrder.Rows[i].Cells[12].Value != null)
                    {
                        OrderVO orderVO = new OrderVO();

                        orderVO.company_id = Convert.ToInt32(dgvOrder.Rows[i].Cells[3].Value);
                        orderVO.first_regist_employee = "사원명";
                        orderVO.final_regist_employee = "사원명";
                        orderVO.product_id = Convert.ToInt32(dgvOrder.Rows[i].Cells[7].Value);
                        orderVO.order_request_quantity = Convert.ToInt32(dgvOrder.Rows[i].Cells[10].Value);
                        orderVO.order_status = "발주중";
                        orderVO.order_seq = 1;
                        orderVO.order_request_date = Convert.ToDateTime(dgvOrder.SelectedRows[0].Cells[12].Value);

                        olist.Add(orderVO);
                        cnt++;
                    }                    
                    else if(IsCheck && dgvOrder.Rows[i].Cells[12].Value != null)
                    {
                        MessageBox.Show("발주 수량을 입력하지 않았습니다.");
                        return;
                    }
                    else if(cnt < 1)
                    {
                        MessageBox.Show("발주 내역을 선택하지 않았습니다.");
                        return;
                    }
                }
            }

            if (olist.Count > 0)
            {
                orderService.InsertOrder(olist);

                MessageBox.Show("발주 되었습니다. ");
                this.Close();
            }
            else
            {
                MessageBox.Show("발주 실패");
            }
            

        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                DueDatePopUpForm frm = new DueDatePopUpForm();
                frm.Order_no = Convert.ToInt32(dgvOrder.SelectedRows[0].Cells[1].Value);
                frm.Due_date = Convert.ToDateTime(dgvOrder.SelectedRows[0].Cells[12].Value);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvOrder.DataSource = orderService.GetOrderPlanList(release_no);
                }
            }
        }



        
    }
}
