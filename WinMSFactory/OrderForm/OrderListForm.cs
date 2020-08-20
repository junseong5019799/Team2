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
    public partial class OrderListForm : ListForm
    {
        OrderService orderService = new OrderService();

        public OrderListForm()
        {
            InitializeComponent();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            dgv.ColumnHeadersHeight = 30;
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;

            dgv.AddNewColumns("발주번호", "order_no", 80, true, false, false, RightAlign);             
            dgv.AddNewColumns("품명", "product_name", 130, true);
            dgv.AddNewColumns("발주량", "order_request_quantity", 100, true, false, false, RightAlign);
            dgv.AddNewColumns("발주 가격", "order_price", 100, true, false, false, RightAlign);
            dgv.AddNewColumns("거래처명", "company_name", 150, true);
            dgv.AddNewColumns("발주상태", "order_status", 100, true);
            dgv.AddNewColumns("발주일", "first_regist_time", 100, true);
            dgv.AddNewColumns("납기일", "order_request_date", 100, true);

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "납기일변경";
            btn.DefaultCellStyle.BackColor = Color.LightBlue;
            btn.Text = "변경";
            btn.Width = 100;
            btn.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            btn.UseColumnTextForButtonValue = true;
            dgv.Columns.Add(btn);

            dgv.AddNewColumns("최종등록사원", "final_regist_employee", 130, true);
            dgv.AddNewColumns("최종등록일", "final_regist_time", 150, true);
            dgv.AddNewColumns("품목", "product_id", 130, false);

            DataTable dt = orderService.GetOrderList();
            dgv.DataSource = dt;

            cboCompany.ComboBinding(orderService.SelectCompanyBindingByType(), "company_id", "company_name", "전체");              

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                DueDatePopUpForm frm = new DueDatePopUpForm();
                frm.Due_date = Convert.ToDateTime(dgv.SelectedRows[0].Cells["order_request_date"].Value.ToString());
                frm.Order_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
                frm.Product_no = Convert.ToInt32(dgv.SelectedRows[0].Cells["product_id"].Value);
                frm.Gubun = "발주";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgv.DataSource = orderService.GetOrderList();
                }
            }
        }


        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                List<OrderVO> pList;

                string fromDate = fromToDateControl1.From.ToShortDateString();
                string toDate = fromToDateControl1.To.ToShortDateString();
                int searchGubun = Convert.ToInt32(cboCompany.SelectedValue);                            

                if (searchGubun == 0)
                {
                    DataTable dt = orderService.GetOrderList();
                    dgv.DataSource = dt;
                    return;
                }
                if (searchGubun > 0)
                {
                    dgv.DataSource = orderService.GetOrderListByDate(fromDate, toDate, searchGubun);
                }
      
            }
        }

        public void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                cboCompany.SelectedIndex = 0;

                DataTable dt = orderService.GetOrderList();
                dgv.DataSource = dt;
            }
        }
    }
}
