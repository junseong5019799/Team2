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
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;
//using WinMSFactory.Services;

namespace WinMSFactory.ResultForm
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
            dgv.AddNewColumns("창고명", "Storage_id", 100, false);
            dgv.AddNewColumns("현 창고", "Storage_Name", 100, true);

            for (int i = 0; i < ID.Count; i++)
            {
                dgv.DataSource = service.SelectProductAll(i);
            }
            
        }
    }
}
