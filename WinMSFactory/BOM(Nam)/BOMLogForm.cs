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
        public BOMLogForm()
        {
            InitializeComponent();
        }

        private void BOMLogForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("로그 순번", "", 100, true);
            //dgv.AddNewColumns("활동 코드", "", 100, true);
            dgv.AddNewColumns("활동명 ", "", 100, true);      // ex. 1번이 등록, 2번이 삭제, 3번이 수정, 4번이 사용 여부 변경 일 경우 1번은 활동코드, 2번은 활동명이 된다.
            // dgv.AddNewColumns("제품그룹 코드", "", 100, true);     
            dgv.AddNewColumns("제품그룹 명칭", "", 100, true);
            // dgv.AddNewColumns("제품 코드", "", 100, true);    // 품목 코드
            dgv.AddNewColumns("제품명", "", 100, true);
            dgv.AddNewColumns("변경내용", "", 100, true); // 변경내용을 적어줌, ButtonColumn를 사용해도 됨.
            dgv.AddNewColumns("최초등록시간", "", 100, true);
            dgv.AddNewColumns("최초등록사원", "", 100, true);
            dgv.AddNewColumns("최종등록시간", "", 100, true);
            dgv.AddNewColumns("최종등록사원", "", 100, true);

        }
    }
}
