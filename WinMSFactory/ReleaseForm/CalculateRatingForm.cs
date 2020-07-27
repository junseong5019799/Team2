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
using WinCoffeePrince2nd.Util;

namespace WinMSFactory
{
    public partial class CalculateRatingForm : ListForm
    {
        ReleaseService releaseService = new ReleaseService();
        List<ReleaseVO> releaseList = null;
        
        int date;

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
            DgvLoad();
            
            //cboPlanID.SelectedValue = release_no.ToString();
            cboPlanID.ComboBinding(releaseService.SelectPlanID(), "release_no", "release_no");
            //cboPlanID.DisplayMember = release_no;
        }

        private void DgvLoad()
        {
            dgv.AddNewColumns("출고예정 번호", "release_no", 100, true);
            dgv.AddNewColumns("거래처", "company_id", 100, true);
            dgv.AddNewColumns("품목 코드", "product_id", 100, true);

            
        }


        private void cboPlanID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<ReleaseVO> AllList = releaseService.GetReleasePlan();

            //releaseList = (from rlist in AllList
            //               where rlist.release_no == Convert.ToInt32(cboPlanID.SelectedValue)
            //               select rlist).ToList();

            //dgv.DataSource = null;
            //dgv.DataSource = releaseList;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgv.DataSource = null;

            TimeSpan cnt = fromToDateControl2.To - fromToDateControl2.From;
            date = cnt.Days;

            for (int i = 0; i < date; i++)
            {
                dgv.AddNewColumns(fromToDateControl2.From.AddDays(i).ToString("yyyy-MM-dd"), "release_plan_date", 100, true);
            }
        }
    }
}
