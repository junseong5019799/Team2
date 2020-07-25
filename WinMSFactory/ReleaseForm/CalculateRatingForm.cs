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
        public CalculateRatingForm()
        {
            InitializeComponent();
        }

        private void CalculateRatingForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("출고예정 번호", "", 100, true);
            dgv.AddNewColumns("품목 코드", "", 100, true);
            dgv.AddNewColumns("Plan ID", "", 100, true);
            dgv.AddNewColumns("카테고리", "", 100, true);

            cboPlanID.ComboBinding(releaseService.SelectPlanID(),"","");

        }
    }
}
