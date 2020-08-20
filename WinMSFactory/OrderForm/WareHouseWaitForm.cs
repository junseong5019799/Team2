using DevExpress.XtraReports.UI;
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
using WinMSFactory.Barcode;
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class WareHouseWaitForm : ListListForm
    {
        OrderService orderService = new OrderService();
        string orderString = "";
        string productString = "";

        public WareHouseWaitForm()
        {
            InitializeComponent();
        }

        private void WareHouseWaitForm_Load(object sender, EventArgs e)
        {
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
            dgv.ColumnHeadersHeight = 30;

            dgvDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
            dgvDetail.ColumnHeadersHeight = 30;

            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            DataGridViewContentAlignment LeftAlign = DataGridViewContentAlignment.MiddleLeft;

            dgv.AddNewColumns("발주번호", "order_no", 80, true, true, false, RightAlign);
            dgv.AddNewColumns("순서", "order_seq", 55, false, true, false, RightAlign);
            dgv.AddNewColumns("납품업체", "company_name", 200, true, true, false, LeftAlign);
            dgv.AddNewColumns("품목", "product_id", 55, false, true, false, RightAlign);
            dgv.AddNewColumns("품명", "product_name", 120, false, true, false, LeftAlign);
            dgv.AddNewColumns("발주량", "order_request_quantity", 90, false, true, false, RightAlign);
            dgv.AddNewColumns("발주일", "order_request_date", 100, true, true, false, LeftAlign);
           
            dgv.DataSource = orderService.GetWareHouseList();            

            dgvDetail.AddNewColumns("발주번호", "order_no", 80, false, true, false, RightAlign);
            dgvDetail.AddNewColumns("순서", "order_seq", 55, true, true, false, RightAlign);
            dgvDetail.AddNewColumns("창고", "storage_name", 100, true, true, false, LeftAlign);
            dgvDetail.AddNewColumns("품목", "product_id", 55, true, true, false, RightAlign);
            dgvDetail.AddNewColumns("품명", "product_name", 120, true, true, false, LeftAlign);
            dgvDetail.AddNewColumns("발주상태", "order_status", 90, true, true, false, LeftAlign);
            dgvDetail.AddNewColumns("입고일", "due_date", 100, true, true, false, LeftAlign);
            dgvDetail.AddNewColumns("입고량", "warehouse_quantity", 90, true, true, false, RightAlign);
            dgvDetail.AddNewColumns("발주량", "order_request_quantity", 90, true, true, false, RightAlign);
            dgvDetail.AddNewColumns("최종등록시간", "final_regist_time", 100, true, true, false, LeftAlign);
            dgvDetail.AddNewColumns("최종등록사원", "final_regist_employee", 100, true, true, false, LeftAlign);

            CompanyService comService = new CompanyService();
            cboCompany.ComboBinding(comService.GetCompanyByType("cop"), "company_id", "company_name", "전체");
           
        }

        /// <summary>
        /// 바코드 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Readed(object sender, ReadEventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {                
                string barID = e.ReadMsg;
                barID = barID.Replace("%O", "-");
                string[] str = barID.Split('-');

                orderString = str[0];
                productString = str[1];

                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if(dgv.Rows[i].Cells[0].Value.ToString() == orderString)
                    {
                        if(dgv.Rows[i].Cells[3].Value.ToString() == productString)
                        {
                            dgv.Rows[i].Selected = true;
                            btnWarehouse.PerformClick();                            
                        }
                    }                    
                }     
                ((MainForm)this.MdiParent).ClearStrs();           
            }
        }


        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int order_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            int product_id = Convert.ToInt32(dgv.SelectedRows[0].Cells[3].Value);
            DataTable dt = orderService.GetWareHouseDetail(order_no, product_id);
            dgvDetail.DataSource = dt;
        }



        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                List<WareHouseVO> pList;
                OrderService service = new OrderService();

                string fromDate = fromToDateControl1.From.ToShortDateString();
                string toDate = fromToDateControl1.To.ToShortDateString();

                pList = service.GetWareHouseByDate(fromDate, toDate);
                              
                if (cboCompany.SelectedIndex == 0)
                    dgv.DataSource = pList; 
                else if (!string.IsNullOrEmpty(cboCompany.SelectedText))
                {
                    pList = (from item in pList
                             where item.company_name.Contains(cboCompany.SelectedText.ToString())
                             select item).ToList();
                }               
                dgv.DataSource = null;
                dgv.DataSource = pList;
            }
        }


        private void Barcode(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                DataTable dt = orderService.CheckBarcode();
                BarcodeOrder rpt = new BarcodeOrder();
                rpt.DataSource = dt;

                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
        }


        /// <summary>
        /// 입고 처리하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            dgvDetail.EndEdit();
            List<int> cnt = new List<int>();

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvDetail[0, row.Index];

                if (chk.Value == null)
                    continue;

                else if ((bool)chk.Value == true)
                    cnt.Add(1);
            }

            if (cnt.Count < 1)
            {
                MessageBox.Show("입고 할 항목을 선택하세요");
                return;
            }
            else if (cnt.Count > 1)
            {
                MessageBox.Show("입고 할 항목 하나만 선택하세요");
                return;
            }

            for (int i = 0; i < dgvDetail.RowCount; i++)
            {
                if (dgvDetail.Rows[i].Cells[6].Value.ToString() == "입고")
                {
                    MessageBox.Show("이미 입고 처리 된 목록입니다.");
                    return;
                }
                else
                {
                    WareHousePopUpForm frm = new WareHousePopUpForm();
                    frm.Order_no = Convert.ToInt32(dgvDetail.Rows[i].Cells["order_no"].Value);
                    frm.Product_id = Convert.ToInt32(dgvDetail.Rows[i].Cells[4].Value);
                    frm.Product_name = dgvDetail.Rows[i].Cells[5].Value.ToString();
                    frm.Order_seq = Convert.ToInt32(dgvDetail.Rows[i].Cells[2].Value);
                    frm.Product_quantity = Convert.ToInt32(dgvDetail.Rows[i].Cells["order_request_quantity"].Value);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        int order_no = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);
                        int product_id = Convert.ToInt32(dgv.Rows[i].Cells[3].Value);

                        dgvDetail.DataSource = orderService.GetWareHouseDetail(order_no, product_id);
                    }
                }
            }             
        }


        public void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                cboCompany.SelectedIndex = 0;
                dgv.DataSource = orderService.GetWareHouseList();
            }
        }
    }                               
}
    

