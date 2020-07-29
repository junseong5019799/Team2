using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;

namespace WinMSFactory.OrderForm
{
    public partial class OrderPlanForm : ListForm
    {
        ReleaseService releaseService = new ReleaseService();
        private int release_no;

        public int Release_no
        {
            get { return release_no; }
            set { release_no = value; }
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
            dgv.AddNewColumns("출고예정 번호", "release_no", 100, true);
            dgv.AddNewColumns("순서", "release_seq", 100, false);
            dgv.AddNewColumns("품목", "product_id", 100, true);
            dgv.AddNewColumns("품명", "product_name", 100, true);
            dgv.AddNewColumns("카테고리", "category", 100, true);

            cboPlanID.ComboBinding(releaseService.SelectPlanID(), "release_no", "release_no");
            cboPlanID.SelectedValue = release_no;

            DataTable dt = releaseService.Calculate_ReleasePlan(release_no, dtpFrom, DtpTo);
            dgv.DataSource = dt;
            
        }
    }
}
