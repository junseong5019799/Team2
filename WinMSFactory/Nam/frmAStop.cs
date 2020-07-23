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
            
            //dgv.AddNewColumns("법인코드", "", 100, true); // 로그인한 사원의 법인 코드를 가져옴 // 법인, 공장, 라인, 공정 모두 가져옴
            dgv.AddNewColumns("법인명칭", "", 100, true);
            //dgv.AddNewColumns("공장코드", "", 100, true);
            dgv.AddNewColumns("공장명칭", "", 100, true);
            //dgv.AddNewColumns("라인코드", "", 100, true);
            dgv.AddNewColumns("라인명칭", "", 100, true);
            //dgv.AddNewColumns("공정코드", "", 100, true);
            dgv.AddNewColumns("공정명칭", "", 100, true);
            //dgv.AddNewColumns("비가동 코드", "", 100, true);
            dgv.AddNewColumns("비가동 명칭", "", 100, true);
            dgv.AddNewColumns("작업자 이름", "", 100, true); // 비가동 - 작업지시번호 - 작업자 코드 - 사번 - 사원이름
            dgv.AddNewColumns("제품명", "", 100, true); // 비가동 - 작업지시번호 - 품목 코드 - 제품명
            dgv.AddNewColumns("비가동 비고", "", 100, true);
            dgv.AddNewColumns("비가동 시작 시간", "", 100, true);
            dgv.AddNewColumns("비가동 종료 시각", "", 100, true);
            dgv.AddNewBtnCol("비가동 사용여부",new Padding(1,1,1,1)); // 비가동 - 비가동 코드 - 비가동 사용여부
            dgv.AddNewColumns("비가동 총 시간", "", 100, true); // 비가동 - 비가동 코드 - 시간계산 적용
            dgv.AddNewColumns("최초등록시각", "", 100, true);
            dgv.AddNewColumns("최초등록사원", "", 100, true);
            dgv.AddNewColumns("최종등록시각", "", 100, true);
            dgv.AddNewColumns("최종등록사원", "", 100, true);

        }
    }
}
