using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class frmABad : ListForm
    {
        // 불량 현황
        public frmABad()
        {
            InitializeComponent();
        }

        private void frmABad_Load(object sender, EventArgs e)
        {
            dgvColumnSettings();
            // 체크 박스 모두 체크
             // 초기 컨트롤 세팅
        }

        private void dgvColumnSettings()
        {
            dgv.AddNewColumns("불량 번호", "", 100, false);
            dgv.AddNewColumns("불량일자", "", 100, true);
            dgv.AddNewColumns("법인명칭", "", 100, true);
            dgv.AddNewColumns("공장명칭", "", 100, true);
            dgv.AddNewColumns("라인명칭", "", 100, true);
            dgv.AddNewColumns("공정명칭", "", 100, true);
            dgv.AddNewColumns("제품명", "", 100, true); // 불량 - 작업지시번호 - 품목코드 - 제품명
            dgv.AddNewColumns("불량명칭", "", 100, true);
            dgv.AddNewColumns("불량수량", "", 100, true);
            dgv.AddNewColumns("불량일자", "", 100, true);
            dgv.AddNewColumns("비고", "", 100, true);
            dgv.AddNewColumns("최초등록시각", "", 100, true);
            dgv.AddNewColumns("최초등록사원", "", 100, true);
        }
    }
}
