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
    public partial class frmAWoHis : BasicForm
    {
        // 생산 실적 현황
        public frmAWoHis()
        {
            InitializeComponent();
        }

        private void frmAWoHis_Load(object sender, EventArgs e)
        {
            // 일부는 팝업창을 따로 만들어 보여줄 것
            dgv.AddNewColumns("작업지시 번호", "", 100, true);
            dgv.AddNewColumns("생산일자", "", 100, true);
            //dgv.AddNewColumns("법인코드", "", 100, true);
            dgv.AddNewColumns("법인명칭", "", 100, true);
            //dgv.AddNewColumns("공장코드", "", 100, true);
            dgv.AddNewColumns("공장명칭", "", 100, true);
            //dgv.AddNewColumns("라인코드", "", 100, true);
            dgv.AddNewColumns("라인명칭", "", 100, true);
            //dgv.AddNewColumns("공정코드", "", 100, true);
            dgv.AddNewColumns("공정명칭", "", 100, true);
            //dgv.AddNewColumns("품목코드", "", 100, true);
            dgv.AddNewColumns("품목명칭", "", 100, true);
            dgv.AddNewColumns("지시수량", "", 100, true);
            dgv.AddNewColumns("양품수량", "", 100, true);
            dgv.AddNewColumns("불량수량", "", 100, true);
            dgv.AddNewColumns("작업자", "", 100, true);
            dgv.AddNewColumns("작업시작시간", "", 100, true);
            dgv.AddNewColumns("작업종료시간", "", 100, true);
        }
    }
}
