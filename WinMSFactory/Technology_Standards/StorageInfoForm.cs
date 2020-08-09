using DevExpress.Utils.Behaviors.Common;
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

namespace WinMSFactory
{
    public partial class StorageInfoForm : Form
    {
        StorageVO vo;
        bool IsUpdate;
        public StorageInfoForm(bool IsUpdate, StorageVO vo)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;
            this.vo = vo;
        }

        private void StorageInfoForm_Load(object sender, EventArgs e)
        {
            

            if(IsUpdate == true)
            {
                txtFactory.Text = vo.Factory_Name;
                cboCorporation.Text = vo.Corporation_Name;
                txtStorage.Text = vo.Storage_Name;

                if (vo.Storage_Use == "Y")
                    rdoUse.Checked = true;
                else
                    rdoUnUse.Checked = false;
            }
            
        }
    }
}
