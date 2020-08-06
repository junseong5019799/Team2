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
//using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class ResultListForm : PopUpDialogForm
    {
        public List<int> ID { get; set; }
        StorageService service = new StorageService();

        public ResultListForm()
        {
            InitializeComponent();
        }

        private void ResultListForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("재고번호", "Stock_No", 100, true);
            dgv.AddNewColumns("품목", "Product_Id", 150, false);
            dgv.AddNewColumns("품목명", "Product_Name", 200, true);
            dgv.AddNewColumns("재고수량", "Stock_Quantity", 100, true);
            dgv.AddNewColumns("창고", "Storage_id", 100, false);
            dgv.AddNewColumns("현 창고", "Storage_Name", 100, true);


            dgv.DataSource = service.MoveStockList(ID);
        

            cboStorage.ComboBinding(service.GetStorage(), "Storage_ID", "Storage_Name");
        }

        //재고이동
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int storage_id = Convert.ToInt32(cboStorage.SelectedValue);
            int stock_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);

            if(service.MoveStorage(storage_id, stock_no))
            {
                MessageBox.Show($"재고가 {cboStorage.SelectedItem}으로 이동합니다.");
                btnCancel.PerformClick();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
