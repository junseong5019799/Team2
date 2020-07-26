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
//using WinMSFactory.Services;

namespace WinMSFactory.ResultForm
{
    public partial class ResultListForm : ListForm
    {
        ReleaseService releaseService = new ReleaseService();
        //StorageService storageService = new StorageService();

        public ResultListForm()
        {
            InitializeComponent();
        }

        private void ResultListForm_Load(object sender, EventArgs e)
        {
            cboProduct.ComboBinding(releaseService.SelectProduct(), "Product_ID", "Product_Name");
            //cboStorage.ComboBinding(storageService.GetStorage(), "storage_id", "storage_name");
            
        }
    }
}
