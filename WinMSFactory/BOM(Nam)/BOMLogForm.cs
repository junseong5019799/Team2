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

        // BOM 로그 (등록, 변경, 삭제 마다 로그 기록)
        // 테이블 생성할 것 
        public BOMLogForm()
        {
            InitializeComponent();
        }

        private void BOMLogForm_Load(object sender, EventArgs e)
        {
            // 제품과는 관련없이 BOM 정보
            dgv.AddNewColumns("로그 번호", "Log_no", 100, true);
            dgv.AddNewColumns("제품 ID", "HIGH_PRODUCT_ID", 100, true); // 상위 제품 코드 - 품목코드 - 품명
            //dgv.AddNewColumns("제품 이름")
            dgv.AddNewColumns("활동명", "Bom_Log_Status", 100, true);
            dgv.AddNewColumns("로그 순번", "Bom_SEQ", 100, true);
            dgv.AddNewColumns("등록일", "BOM_Enroll_Date", 100, true);
            dgv.AddNewColumns("등록 사원", "Employee_ID", 100, true);

            dgv.DataSource = service.SelectAllLogs();
        }
    }
}
