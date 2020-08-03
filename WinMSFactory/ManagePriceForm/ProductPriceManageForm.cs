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

namespace WinMSFactory.ManagePriceForm
{
    public partial class ProductPriceManageForm : ListForm
    {

        ProductService service = new ProductService();
        List<ProductPriceManageVO> SelectList;
        public ProductPriceManageForm()
        {
            InitializeComponent();
        }

        private void ProductPriceForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("업체명", "Product_Name", 250, true);
            dgv.AddNewColumns("품목명", "Product_Name", 250, true);
            dgv.AddNewColumns("품목 스펙(규격)", "Product_Information", 250, true);
            dgv.AddNewColumns("품목 단위", "Product_unit", 250, true);
            dgv.AddNewColumns("현재 단가", "Product_Current_Price", 250, true);
            dgv.AddNewColumns("이전 단가", "Product_Previous_Price", 250, true);
            dgv.AddNewColumns("시작일", "Start_Date", 250, true);
            dgv.AddNewColumns("종료일", "End_Date", 250, true);
            dgv.AddNewColumns("비고", "Note", 250, true);
            SelectList = service.ProductPriceSelect();
            dgv.DataSource = SelectList;
        }

        

        private void btn_Insert_Click(object sender, EventArgs e) // 등록
        {
            SettingFormOpen(true);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // 수정
        {
            if (e.RowIndex < 0)
                return;

            SettingFormOpen(false);
        }

        private void SettingFormOpen(bool IsInsert) // 등록 / 수정에 따른 폼 open
        {
            ProductPriceDialogForm frm = new ProductPriceDialogForm(IsInsert);

            if (frm.ShowDialog() == DialogResult.OK) // 정상적으로 실행 후 종료된 경우
            {
                dgv.Columns.Clear();
                dgv.DataSource = SelectList; // 데이터 갱신!!
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e) // 삭제
        {
            
        }
    }
}
