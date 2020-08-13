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
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class BOMLogForm : BasicForm
    {
        BomLogService service = new BomLogService();
        List<BomLogVO> SelectLists;
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
            dgv.AddNewColumns("제품 이름", "Product_Name", 300, true); // 상위 제품 코드 - 품목코드 - 품명
            dgv.AddNewColumns("활동명", "Bom_Log_Status", 150, true);
            dgv.AddNewColumns("로그 순번", "Bom_SEQ", 140, false);
            dgv.AddNewColumns("로그 발생 일자", "BOM_Enroll_Date", 200, true);
            dgv.AddNewColumns("사원명", "Employee_ID", 200, true);

            SelectLists = service.SelectAllLogs();
            dgv.DataSource = SelectLists;
        }

        private void Search(object sender, EventArgs e)
        {
            if(((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                var SearchData = (from SortedList in SelectLists
                                  where SortedList.Bom_Enroll_Date.Date.AddDays(1) >= fromToDate.From && SortedList.Bom_Enroll_Date.Date <= fromToDate.To
                                  select SortedList).ToList();

                dgv.DataSource = SearchData;
            }
            
        }
        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
                dgv.DataSource = SelectLists;
        }
    }
}
