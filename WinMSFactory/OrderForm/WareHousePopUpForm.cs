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

namespace WinMSFactory.OrderForm
{
    public partial class WareHousePopUpForm : PopUpDialogForm
    {
        private int order_no;

        public int Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }
        private int product_id;

        public int Product_id
        {
            get { return product_id; }
            set { product_id = value; }
        }

        private string product_name;

        public string Product_name
        {
            get { return product_name; }
            set { product_name = value; }
        }

        private int order_seq;

        public int Order_seq
        {
            get { return order_seq; }
            set { order_seq = value; }
        }



        public WareHousePopUpForm()
        {
            InitializeComponent();
        }

        private void WareHousePopUpForm_Load(object sender, EventArgs e)
        {
            ReleaseService releaseService = new ReleaseService();
            StorageService storageService = new StorageService();

            txtOrderID.Text = order_no.ToString();

            cboProduct.ComboBinding(releaseService.SelectProduct(), "Product_ID", "Product_Name");
            cboProduct.SelectedValue = product_id;

            cboStorage.ComboBinding(storageService.GetStorage(), "Storage_Id", "Storage_Name");

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            WareHouseVO vo = new WareHouseVO();

            vo.order_no = order_no;
            vo.product_id= product_id;
            vo.warehouse_date = Convert.ToDateTime(dtpIN.Value.ToShortDateString());
            vo.warehouse_quantity = Convert.ToInt32(txtquantity.Text);
            vo.storage_id = Convert.ToInt32(cboStorage.SelectedValue);

            OrderService service = new OrderService();
            if(service.InsertWareHouse(vo))
            {
                MessageBox.Show("입고 처리 되었습니다.");
                this.Close();
            }
            
        }
    }
}
