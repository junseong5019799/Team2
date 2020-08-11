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
    public partial class ProductionStatusForm : BasicForm
    {
        ProductionService service = new ProductionService();
        // 생산 실적 현황
        List<ProductionVO> ProductionData;
        List<ProductionVO> DefectiveData;
        List<ProductionVO> DowntimeData;
        public ProductionStatusForm()
        {
            InitializeComponent();
        }

        private void frmAWoHis_Load(object sender, EventArgs e)
        {
            // 일부는 팝업창을 따로 만들어 보여줄 것 (보류)
            FirstGridViewColumns();
            SecondGridViewColumns();
            ThirdGridViewColumns();

            ProductionData = service.ProductionStatusSelect();
            dgv.DataSource = ProductionData;

            DefectiveData = service.DefectiveSelect();

            DowntimeData = service.DowntimeSelect();
        }
        private void Clear(object sender, EventArgs e)
        {
            dgv.DataSource = service.ProductionStatusSelect();
            dgv2.DataSource = null;
            dgv3.DataSource = null;
        }

        private void Search(object sender, EventArgs e)
        {
            if (txtProductName.TextLength < 1)
            {
                dgv.DataSource = (from SortedList in ProductionData
                                  where SortedList.Work_Date >= FromToDate.From.AddDays(-1) && SortedList.Work_Date <= FromToDate.To
                                  select SortedList).ToList();
            }
            else
            {
                var List = (from SortedList in ProductionData
                            where SortedList.Work_Date >= FromToDate.From.AddDays(-1) && SortedList.Work_Date <= FromToDate.To
                                        && SortedList.Product_Name.Contains(txtProductName.Text)
                            select SortedList).ToList();

                dgv.DataSource = List;
            }

            dgv2.DataSource = null;
            dgv3.DataSource = null;
        }

        private void ThirdGridViewColumns()
        {
            dgv3.AddNewColumns("비가동 번호", "Downtime_No", 100, true);
            dgv3.AddNewColumns("작업지시번호", "work_order_no", 100, false);
            dgv3.AddNewColumns("비가동 명칭", "downtime_type_name", 150, true);
            dgv3.AddNewColumns("비가동 비고", "downtime_note", 200, true);
            dgv3.AddNewColumns("비가동 시작시간", "downtime_start_time", 150, false);
            dgv3.AddNewColumns("비가동 종료시간", "downtime_finish_time", 150, false);
            dgv3.AddNewColumns("비가동 총 시간", "Downtime_Hour", 150, true); // 비가동 종료 시간 - 비가동 시작시간
            dgv3.AddNewColumns("비가동 사용여부", "downtime_type_use", 130, true);
            dgv3.AddNewColumns("시간 계산 적용 여부", "downtime_type_calculation", 150, true);
        }

        private void SecondGridViewColumns()
        {
            dgv2.AddNewColumns("불량코드", "defection_code", 100, false);
            dgv2.AddNewColumns("작업지시번호", "work_order_no", 100, false);
            dgv2.AddNewColumns("불량명", "defection_type_name", 150, true);
            dgv2.AddNewColumns("불량 수량", "defective_quantity", 100, true);
            dgv2.AddNewColumns("불량 일자", "defective_date", 150, true);
        }

        private void FirstGridViewColumns()
        {
            dgv.AddNewColumns("작업지시 번호", "Work_order_no", 120, true);
            dgv.AddNewColumns("작업일자", "Work_date", 150, true);
            dgv.AddNewColumns("품목명칭", "Product_Name", 150, true);
            dgv.AddNewColumns("지시수량", "Work_Order_Quantity", 80, true);
            dgv.AddNewColumns("양품수량", "Good_Quantity", 80, true);
            dgv.AddNewColumns("불량수량", "Defective_Quantity", 80, true);
            dgv.AddNewColumns("작업자", "Employee_Name", 100, true);
            dgv.AddNewColumns("작업시작시간", "Work_Start_Time", 150, true);
            dgv.AddNewColumns("작업종료시간", "Work_Finish_Time", 150, true);
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(null, null);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderNo = dgv[0, e.RowIndex].Value.ToInt();

            dgv2.DataSource = (from item in DefectiveData
                               where item.Work_Order_No == orderNo
                               select item).ToList();

            dgv3.DataSource = (from item in DowntimeData
                               where item.Work_Order_No == orderNo
                               select item).ToList();
        }
    }
}
