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
    public partial class BOMLogForm : BasicForm
    {
        // BOM 로그 (등록, 변경, 삭제 마다 로그 기록)
        // 테이블 생성할 것 
        public BOMLogForm()
        {
            InitializeComponent();
        }

        private void BOMLogForm_Load(object sender, EventArgs e)
        {
            // 제품과는 관련없이 BOM 정보
            dgv.AddNewColumns("로그 순번", "", 100, true);
            //dgv.AddNewColumns("활동 코드", "", 100, true);

            // ex. 1번이 등록, 2번이 삭제, 3번이 수정 일 경우 1번은 활동코드, 2번은 활동명이 된다.
            dgv.AddNewColumns("활동명 ", "", 100, true);      // 공통코드로 설정(FK)

            // dgv.AddNewColumns("제품그룹 코드", "", 100, true);     
            dgv.AddNewColumns("제품그룹 명칭", "", 100, true);
            // dgv.AddNewColumns("제품 코드", "", 100, true);    // 품목 코드
            dgv.AddNewColumns("제품명", "", 100, true);
            // 제품 사용 여부는 포함시키면 안됨
            dgv.AddNewColumns("재료 사용 여부", "", 100, true);
            dgv.AddNewColumns("변경내용", "", 100, true); // 변경내용을 적어줌
            dgv.AddNewColumns("최종등록시각", "", 100, true);
            dgv.AddNewColumns("최종등록사원", "", 100, true);

        }
    }
}
