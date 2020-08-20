using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.PivotGrid.OLAP;
using DevExpress.XtraEditors.Designer.Utils;
using MSFactoryDAC;
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
        DataTable comDt;
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
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            dgvOrder.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
            dgvOrder.ColumnHeadersHeight = 30;

            comDt = new CompanyService().GetCompanyByProducts();

            dgvOrder.AddNewColumns("주문번호", "release_no", 80, false);
            dgvOrder.AddNewColumns("순서", "release_seq", 70, true, false, false, RightAlign);
            dgvOrder.AddNewComCol("납품업체", "company_id", comDt, "company_name", "company_id", 200);
            dgvOrder.AddNewColumns("품목", "product_id", 80, false);
            dgvOrder.AddNewColumns("품명", "product_name", 120, false);
            dgvOrder.AddNewColumns("품목", "_product_id", 80, false);
            dgvOrder.AddNewColumns("자재", "_product_name", 120, true);
            dgvOrder.AddNewColumns("자재 단가", "material_current_price", 100, true, false, false, RightAlign);
            dgvOrder.AddNewColumns("소요량", "order_request_quantity", 80, true, false, false, RightAlign);
            dgvOrder.AddNewColumns("발주제안 수량", "order_quantity", 100, true, false, false, RightAlign);            
            dgvOrder.AddNewColumns("발주 가격", "order_product_price", 100, true, false, false, RightAlign);
            dgvOrder.AddNewColumns("재고량", "stock_quantity", 100, true, false, false, RightAlign);
            dgvOrder.AddNewColumns("납기일", "due_date", 100, true);
           
            DataTable dt = orderService.GetOrderPlanList(release_no);
            dgvOrder.DataSource = dt;

            dgvOrder.Columns["order_quantity"].DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvOrder.Columns["order_quantity"].DefaultCellStyle.ForeColor = Color.Red;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {            
            dgvOrder.EndEdit();

            List<OrderVO> olist = new List<OrderVO>();
            List<int> cnt = new List<int>();

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvOrder[0, row.Index];

                if (chk.Value == null)
                    continue;

                else if ((bool)chk.Value == true)
                    cnt.Add(1);
            }

            if (cnt.Count < 1)
            {
                MessageBox.Show("발주 할 내역을 선택해주세요.");
                return;
            }

            //dgvOrder.Sort(dgvOrder.Columns["company_id"], ListSortDirection.Ascending);
            HashSet<int> companySet = new HashSet<int>();
            string employee_id = "admin";

            for (int i = 0; i < dgvOrder.RowCount; i++)
            {
                if (dgvOrder.Rows[i].Cells[0].Value != null)
                {
                    bool IsCheck = (bool)dgvOrder.Rows[i].Cells[0].Value;

                    if (IsCheck && dgvOrder.Rows[i].Cells["order_quantity"].Value != null)
                    {
                        int c_id = Convert.ToInt32(dgvOrder.Rows[i].Cells[3].Value);

                        OrderVO orderVO = new OrderVO();

                        orderVO.company_id = c_id;
                        orderVO.product_id = Convert.ToInt32(dgvOrder.Rows[i].Cells["_product_id"].Value);
                        orderVO.order_request_quantity = Convert.ToInt32(dgvOrder.Rows[i].Cells["order_quantity"].Value);
                        orderVO.order_status = "발주중";
                        orderVO.order_seq = 1;
                        orderVO.order_request_date = DateTime.Now;                     
                        orderVO.order_price = Convert.ToDecimal(dgvOrder.Rows[i].Cells["order_product_price"].Value);

                        olist.Add(orderVO);
                        companySet.Add(c_id);
                    }                    
                    else if(IsCheck && dgvOrder.Rows[i].Cells["order_quantity"].Value != null)
                    {
                        MessageBox.Show("발주 수량을 입력하지 않았습니다.");
                        return;
                    }             
                }
            }

            if (olist.Count > 0)
            {
                orderService.InsertOrder(olist, companySet, employee_id);

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
            if (e.ColumnIndex == 3)
            {
                dgvOrder.EndEdit();
                DataGridViewComboBoxCell cbxV = (DataGridViewComboBoxCell)dgvOrder.Rows[e.RowIndex].Cells[3];

                if (cbxV.Value != null)
                {
                    int value = Convert.ToInt32(cbxV.Value);
                    int product_id = Convert.ToInt32(dgvOrder.SelectedRows[0].Cells["_product_id"].Value);
                    dgvOrder.SelectedRows[0].Cells["material_current_price"].Value = orderService.GetCurrentPriceByCompany(value, product_id);
                }
            }         
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvOrder.Rows)
            {
                int product_id = dgvr.Cells["_product_id"].Value.ToInt();
                IEnumerable<DataRow> query = (from item in comDt.AsEnumerable()
                                              where item.Field<int>("product_id") == product_id
                                              select item);
               ((DataGridViewComboBoxCell)dgvr.Cells["company_id"]).DataSource = query.Count() > 0 ? query.CopyToDataTable<DataRow>() : null;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvOrder.RowCount; i++)
            {
                int price = Convert.ToInt32(dgvOrder.Rows[i].Cells[8].Value);
                int quantity = Convert.ToInt32(dgvOrder.Rows[i].Cells[10].Value);

                dgvOrder.Rows[i].Cells[11].Value = price * quantity;
            }
        }
    }
}
