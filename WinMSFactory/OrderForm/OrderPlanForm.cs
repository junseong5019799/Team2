using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory.OrderForm;
using WinMSFactory.Services;

namespace WinMSFactory
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
                 
        public DateTime DtpFrom
        {
            get { return fromToDateControl1.From; }
            set { fromToDateControl1.From = value; }
        }
        
        public DateTime DtpTo
        {
            get { return fromToDateControl1.To; }
            set { fromToDateControl1.To = value; }
        }

        public OrderPlanForm()
        {
            InitializeComponent();
        }

        private void OrderPlanForm_Load(object sender, EventArgs e)
        {         
            fromToDateControl1.From = DtpFrom;
            fromToDateControl1.To = DtpTo;

            cboPlanID.ComboBinding(releaseService.SelectPlanID(), "release_no", "release_no");
            cboPlanID.SelectedValue = release_no;

            DataTable dt = orderService.Calculate_OrderPlan(release_no, DtpFrom, DtpTo);
            dgv.DataSource = dt;

            for (int i = 0; i < dgv.Rows.Count; i+=3)
            {
                dgv.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
            }
            
        }

        //찾기 버튼
        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                release_no = Convert.ToInt32(cboPlanID.SelectedValue);

                DateTime from = Convert.ToDateTime(fromToDateControl1.From.ToShortDateString());
                DateTime to = Convert.ToDateTime(fromToDateControl1.To.ToShortDateString());

                DataTable dt = orderService.Calculate_OrderPlan(release_no, from, to);
                dgv.DataSource = null;
                dgv.DataSource = dt;
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderPopUpForm frm = new OrderPopUpForm();
            frm.Release_no = release_no;

            frm.Show();
        }
    }
}
