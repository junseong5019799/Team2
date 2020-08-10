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
    public partial class OrderPlanForm : ListForm
    {
        ReleaseService releaseService = new ReleaseService();
        OrderService orderService = new OrderService();

        private int release_no;

        public int Release_no
        {
            get { return release_no; }
            set { release_no = value; cboPlanID.SelectedValue = release_no; }
        }
        private DateTime dtpFrom;
                
        public DateTime DtpFrom
        {
            get { return dtpFrom; }
            set { dtpFrom = value; }
        }
        private DateTime dtpTo;

        public DateTime DtpTo
        {
            get { return dtpTo; }
            set { dtpTo = value; }
        }

        public OrderPlanForm()
        {
            InitializeComponent();
        }

        private void OrderPlanForm_Load(object sender, EventArgs e)
        {         
            fromToDateControl1.From = dtpFrom;
            fromToDateControl1.To = DtpTo;

            cboPlanID.ComboBinding(releaseService.SelectPlanID(), "release_no", "release_no");
            cboPlanID.SelectedValue = release_no;

            DataTable dt = orderService.Calculate_OrderPlan(release_no, dtpFrom, DtpTo);
            dgv.DataSource = dt;

            for (int i = 0; i < dgv.Rows.Count; i+=3)
            {
                dgv.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
            }
            
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderPopUpForm frm = new OrderPopUpForm();

            //SELECT RELEASE_NO AS 출고번호, RELEASE_SEQ AS 순서, p.PRODUCT_ID AS 품목, p.product_name AS 품명
            //FROM TBL_RELEASE_DETAIL rd INNER JOIN dbo.TBL_BOM B ON rd.product_id = B.high_product_id INNER JOIN TBL_PRODUCT p ON p.product_id = b.low_product_id
            frm.Show();
        }
    }
}
