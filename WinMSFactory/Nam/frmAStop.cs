using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class frmAStop : BasicForm
    {
        // 비가동 현황
        public frmAStop()
        {
            InitializeComponent();
        }

        private void frmAStop_Load(object sender, EventArgs e)
        {
            
            //dgv.AddNewColumns("법인코드", "", 100, true);
            dgv.AddNewColumns("법인명칭", "", 100, true);
            //dgv.AddNewColumns("공장코드", "", 100, true);
            dgv.AddNewColumns("공장명칭", "", 100, true);
            //dgv.AddNewColumns("라인코드", "", 100, true);
            dgv.AddNewColumns("라인명칭", "", 100, true);
            //dgv.AddNewColumns("공정코드", "", 100, true);
            dgv.AddNewColumns("공정명칭", "", 100, true);
            //dgv.AddNewColumns("비가동 코드", "", 100, true);
            dgv.AddNewColumns("비가동 명칭", "", 100, true);
            dgv.AddNewColumns("비가동 비고", "", 100, true);
            dgv.AddNewColumns("비가동 시작 시각", "", 100, true);
            dgv.AddNewColumns("비가동 종료 시각", "", 100, true);
            dgv.AddNewColumns("최초등록시각", "", 100, true);
            dgv.AddNewColumns("최초등록사원", "", 100, true);
            dgv.AddNewColumns("최종등록시각", "", 100, true);
            dgv.AddNewColumns("최종등록사원", "", 100, true);

        }
    }
}
