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
            MainColumns();

            SelectList = service.ProductPriceSelect();
            dgv.DataSource = SelectList;
        }

        private void MainColumns()
        {
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
           
            dgv.AddNewColumns("업체명", "Company_Name", 150, true);
            dgv.AddNewColumns("품목명", "Product_Name", 200, true);
            dgv.AddNewColumns("품목 스펙(규격)", "Product_Information", 200, true);
            dgv.AddNewColumns("품목 단위", "Product_unit", 80, true);
            dgv.AddNewColumns("현재 단가", "Material_Current_Price_String", 120, true, true, false, RightAlign);
            dgv.AddNewColumns("이전 단가", "Material_Previous_Price_String", 120, true, true, false, RightAlign);
            dgv.AddNewColumns("시작일", "Start_Date", 80, true);
            dgv.AddNewColumns("종료일", "End_Date", 80, true);
            dgv.AddNewColumns("비고", "Note", 300, true);
            dgv.AddNewColumns("코드번호", "Material_Price_Code", 150, false);    // 코드 번호
            dgv.AddNewColumns("수정 가능 여부", "IsReadOnly", 150, false); // 10
        }


        private void btn_Insert_Click(object sender, EventArgs e) // 등록
        {
            SettingFormOpen(true);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // 수정
        {
            if (e.RowIndex < 0)
                return;

            if (dgv[10, e.RowIndex].Value.ToString() == "N")
            {
                MessageBox.Show("가장 최근에 등록한 데이터만 수정이 가능합니다.");
                return;
            }
                

            string EndDate = string.Empty;

            if (dgv[7, e.RowIndex].Value == null)
                EndDate = null;

            ProductPriceManageVO ManageVO = new ProductPriceManageVO
            {
                Company_Name = dgv[0, e.RowIndex].Value.ToString(),
                Product_Name = dgv[1, e.RowIndex].Value.ToString(),
                Product_Information = dgv[2, e.RowIndex].Value.ToString(),
                Material_Current_Price_String = dgv[4, e.RowIndex].Value.ToString().Replace(" 원", ""),
                Material_Previous_Price_String = dgv[5, e.RowIndex].Value.ToString().Replace(" 원", ""),
                Start_Date_String = Convert.ToDateTime(dgv[6, e.RowIndex].Value).ToShortDateString(),
                End_Date_String = EndDate,
                Note = dgv[8, e.RowIndex].Value.ToString(),
                Material_Price_Code = dgv[9, e.RowIndex].Value.ToInt()
            };

            SettingFormOpen(false, ManageVO);
        }

        private void SettingFormOpen(bool IsInsert, ProductPriceManageVO ManageVO = null) // 등록 / 수정에 따른 폼 open
        {
            ProductPriceDialogForm frm = new ProductPriceDialogForm(IsInsert, ManageVO);

            if (frm.ShowDialog() == DialogResult.OK) // 정상적으로 실행 후 종료된 경우
            {
                ReView(); // 데이터 갱신!!
            }
        }

        private void ReView()
        {
            dgv.Columns.Clear();
            MainColumns();
            SelectList = service.ProductPriceSelect();
            dgv.DataSource = SelectList;
        }

        private void btn_Delete_Click(object sender, EventArgs e) // 삭제
        {
            
        }
    }
}
