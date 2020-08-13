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

        DataTable dt;

        private int release_no;
        public int Release_no
        {
            get { return release_no; }
            set { release_no = value; cboPlanID.SelectedValue = release_no; Search(null, null); } 
        }     

        public CalculateRatingForm()
        {
            InitializeComponent();
        }

        private void CalculateRatingForm_Load(object sender, EventArgs e)
        {
            cboPlanID.ComboBinding(releaseService.SelectPlanID(), "release_no", "release_no");

            release_no = Convert.ToInt32(cboPlanID.SelectedValue);
            from = Convert.ToDateTime(fromToDateControl2.From.ToShortDateString());
            to = Convert.ToDateTime(fromToDateControl2.To.ToShortDateString());

            dt = releaseService.Calculate_ReleasePlan(release_no, from, to);
            dgv.DataSource = dt;
        }


        //찾기 버튼
        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                release_no = Convert.ToInt32(cboPlanID.SelectedValue);

                from = Convert.ToDateTime(fromToDateControl2.From.ToShortDateString());
                to = Convert.ToDateTime(fromToDateControl2.To.ToShortDateString());

                dt = releaseService.Calculate_ReleasePlan(release_no, from, to);
                dgv.DataSource = null;
                dgv.DataSource = dt;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["PROG_NAME"] = "정규발주";
            dic["PROG_FORM_NAME"] = "OrderPlanForm";
            dic["Search"] = "Y";

            OrderPlanForm frm = (OrderPlanForm)this.GetMdiParent().MdiChildrenShow(dic);

            from = Convert.ToDateTime(fromToDateControl2.From.ToShortDateString());
            to = Convert.ToDateTime(fromToDateControl2.To.ToShortDateString());
            release_no = Convert.ToInt32(cboPlanID.SelectedValue);

            frm.Release_no = release_no;
            frm.DtpFrom = from;
            frm.DtpTo = to;
            frm.Show();
        }
    }
}
