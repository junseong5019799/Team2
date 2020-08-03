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
        private int storageID;

        public int StorageID
        {
            get { return storageID; }
            set { storageID = value; }
        }

        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }


        public ResultListForm()
        {
            InitializeComponent();
        }

        private void ResultListForm_Load(object sender, EventArgs e)
        {
            lblStorageID.Text = storageID.ToString();

            ReleaseService releaseService = new ReleaseService();
            cboProduct.ComboBinding(releaseService.SelectProduct(), "Product_ID", "Product_Name");
            cboProduct.SelectedValue = productID;

            StorageService storageService = new StorageService();
            cboStorage.ComboBinding(storageService.GetStorage(), "Storage_ID", "Storage_Name");

            txtQuantity.Text = quantity.ToString();
        }
    }
}
