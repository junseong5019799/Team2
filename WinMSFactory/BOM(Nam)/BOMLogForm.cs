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
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class BOMLogForm : BasicForm
    {
        BomLogService service = new BomLogService();

        private int CorporationID = 1;                            // 로그인한 사용자의 법인 ID, 임시로 설정해놓았으므로 로그인 완성 시 반드시 삭제할 것
        // BOM 로그 (등록, 변경, 삭제 마다 로그 기록)
        // 테이블 생성할 것 
        public BOMLogForm()
        {
            InitializeComponent();
        }

        private void BOMLogForm_Load(object sender, EventArgs e)
        {
            // 제품과는 관련없이 BOM 정보
            dgv.AddNewColumns("로그 번호", "", 100, true);
            dgv.AddNewColumns("상위 제품 명", "", 100, true); // 상위 제품 코드 - 품목코드 - 품명
            dgv.AddNewColumns("하위 제품코드", "", 100, true); // 하위 제품 코드 - 품목 코드 - 품명
            dgv.AddNewColumns("활동명", "", 100, true);
            dgv.AddNewColumns("사용여부 변경", "", 100, true);
            dgv.AddNewColumns("로그 순번", "", 100, true);
            dgv.AddNewColumns("등록일", "", 100, true);
            dgv.AddNewColumns("등록 사원", "", 100, true);

            dgv.DataSource = service.SelectAllLogs(CorporationID);
        }
    }
}
