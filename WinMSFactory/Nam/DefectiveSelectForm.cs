using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class DefectiveSelectForm : ListForm
    {
        // 불량 현황
        DefectiveService service = new DefectiveService();
        List<DefectiveVO> DefectiveSelectAll;
        public DefectiveSelectForm()
        {
            InitializeComponent();
        }

        private void frmABad_Load(object sender, EventArgs e)
        {
            dgvColumnSettings();
        }

        private void dgvColumnSettings()
        {
            FromToDate.To = DateTime.Now;
            FromToDate.From = FromToDate.To.AddDays(-7);

            dgv.AddNewColumns("불량 번호", "defective_no", 80, false);
            dgv.AddNewColumns("제품명", "product_name", 100, true); // 불량 - 작업지시번호 - 품목코드 - 제품명
            dgv.AddNewColumns("불량명칭", "defective_name_type", 100, true);
            dgv.AddNewColumns("불량수량", "defective_quantity", 100, true);
            dgv.AddNewColumns("불량일자", "defective_date", 130, true);
            dgv.AddNewColumns("불량사용여부", "defective_type_use", 100, true);
            dgv.AddNewColumns("비고", "note", 200, true);
            dgv.AddNewColumns("최초등록시각", "first_regist_time", 130, true);
            dgv.AddNewColumns("최초등록사원", "first_regist_employee", 130, true);

            DefectiveSelectAll = service.DefectiveSelectAll();
            dgv.DataSource = DefectiveSelectAll;
        }
        
        private void Clear(object sender, EventArgs e)
        {
            dgv.DataSource = null;
            dgv.DataSource = DefectiveSelectAll;
        }
        private void Search(object sender, EventArgs e)
        {
            if (txtProductName.TextLength > 1)
            {
                var SortedData = (from sortedList in DefectiveSelectAll
                                  where sortedList.Defective_Date >= FromToDate.From && sortedList.Defective_Date <= FromToDate.To
                                        && sortedList.Product_Name.Contains(txtProductName.Text)
                                  select sortedList).ToList();

                dgv.DataSource = SortedData;
            }

            else
            {
                var SortedData = (from sortedList in DefectiveSelectAll
                                  where sortedList.Defective_Date >= FromToDate.From && sortedList.Defective_Date <= FromToDate.To
                                  select sortedList).ToList();

                dgv.DataSource = SortedData;
            }
        }
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(null, null);
        }
    }
}
