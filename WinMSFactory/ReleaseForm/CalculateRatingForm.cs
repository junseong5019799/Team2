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
using WinMSFactory.OrderForm;

namespace WinMSFactory
{
    public partial class CalculateRatingForm : ListForm
    {
        ReleaseService releaseService = new ReleaseService();
        ReleaseVO releaseVO = new ReleaseVO();

        List<ReleaseVO> releaseList = null;
        DateTime from;
        DateTime to;

        private int release_no;
        public int Release_no
        {
            get { return release_no; }
            set { release_no = value; }
        }     

        public CalculateRatingForm()
        {
            InitializeComponent();
        }

        private void CalculateRatingForm_Load(object sender, EventArgs e)
        {
            cboPlanID.ComboBinding(releaseService.SelectPlanID(), "release_no", "release_no");
            cboPlanID.SelectedValue = release_no;
        }


        private void cboPlanID_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            release_no = Convert.ToInt32(cboPlanID.SelectedValue);

            from = Convert.ToDateTime(fromToDateControl2.From.ToShortDateString());
            to = Convert.ToDateTime(fromToDateControl2.To.ToShortDateString());           

            DataTable dt = releaseService.Calculate_ReleasePlan(release_no, from, to);
            dgv.DataSource = dt;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            OrderPlanForm frm = new OrderPlanForm();
            frm.Release_no = release_no;
            frm.DtpFrom = from;
            frm.DtpTo = to;
            frm.Show();
        }
    }
}
