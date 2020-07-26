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
        
        public CalculateRatingForm()
        {
            InitializeComponent();
        }

        private void CalculateRatingForm_Load(object sender, EventArgs e)
        {
            fromToDateControl2.From = DateTime.Now.AddDays(-3);
            dgv.AddNewColumns("출고예정 번호", "", 100, true);
            dgv.AddNewColumns("거래처", "", 100, true);
            dgv.AddNewColumns("품목 코드", "", 100, true);

            TimeSpan cnt = fromToDateControl2.To.Date - fromToDateControl1.From.Date;
            int date = cnt.Days;

            for (int i = 0; i < date; i++)
            {
                dgv.AddNewColumns(fromToDateControl2.From.AddDays(i).ToString("yyyy-MM-dd"),"",100,true);
            }

            cboPlanID.ComboBinding(releaseService.SelectPlanID(),"release_no","release_no");

        }

        private void cboPlanID_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ReleaseVO> AllList = releaseService.GetReleasePlan();

            releaseList = (from rlist in AllList
                           where rlist.release_no == Convert.ToInt32(cboPlanID.SelectedItem)
                           select rlist).ToList();

            dgv.DataSource = releaseList;
        }
    }
}
