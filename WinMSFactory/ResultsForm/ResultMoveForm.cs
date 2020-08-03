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

namespace WinMSFactory.ResultForm
{
    public partial class ResultMoveForm : ListListForm
    {
        StorageService service = new StorageService();
        public ResultMoveForm()
        {
            InitializeComponent();
        }

        private void ResultMoveForm_Load(object sender, EventArgs e)
        {

            dgv.AddNewColumns("재고번호", "Stock_No", 100, true);
            dgv.AddNewColumns("품목 그룹", "Product_Group_Name", 150, true);
            dgv.AddNewColumns("품목명", "Product_Name", 200, true);
            dgv.AddNewColumns("총 재고수량", "Stock_Quantity", 100, true);
            dgv.AddNewColumns("등록일", "Stock_Regist_Date", 150, true);
            dgv.AddNewColumns("이동 수량", "", 100, true);

            dgv2.IsAllCheckColumnHeader = true;

            dgv2.AddNewColumns("재고번호", "Stock_No", 100, true);
            dgv2.AddNewColumns("창고명", "Stock_No", 100, true);                   // 다른 창고 물품들을 이동할 수도 있어서
            dgv2.AddNewColumns("품목 그룹", "Product_Group_Name", 150, true);
            dgv2.AddNewColumns("품목명", "Product_Name", 200, true);
            dgv2.AddNewColumns("이동 수량", "Stock_Quantity", 100, true);          // dgv에서 입력한 이동 수량을 표시
            dgv2.AddNewColumns("등록일", "Stock_Regist_Date", 150, true);

            cboStorage.ComboBinding(service.GetStorage(), "Storage_ID", "Storage_Name");

        }

        private void buttonControl2_Click(object sender, EventArgs e) // 검색
        {
            int SelectStorage = cboStorage.SelectedValue.ToInt();

            dgv.DataSource = service.SelectProductAll(SelectStorage);

            for (int i = 0; i < dgv.Rows.Count; i++)
                dgv[5,i].ReadOnly = false;
        }



        private void buttonControl1_Click(object sender, EventArgs e) // 재고 이동
        {
            // 희망 수량 체크
            foreach(DataGridViewRow row in dgv.Rows)
            {
                int dgvQuantity = dgv[3, row.Index].Value.ToString().Replace(" 개", "").ToInt();

                if (dgv[5, row.Index].Value == null)
                {
                    MessageBox.Show("희망 수량을 모두 입력해주세요");
                    return;
                }
                else if (dgvQuantity <= dgv[5, row.Index].Value.ToString().ToInt())
                {
                    MessageBox.Show("희망 수량을 잘못 입력하셨습니다.");
                    return;
                }
            }

            // 계속~~

        }
    }
}
