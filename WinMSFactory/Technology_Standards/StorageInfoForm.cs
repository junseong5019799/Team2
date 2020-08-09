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
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class StorageInfoForm : Form
    {
        CorporationService cs = new CorporationService();
        FactoryService fs = new FactoryService();
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
            cboCorporation.ComboBinding(cs.CorporationComboBinding(), "coporation_id", "corporation_name");
            if (IsUpdate == false)
            {
                
                cboCorporation.SelectedIndexChanged += CorporationChange;
            }
            

            if(IsUpdate == true)
            {

                cboCorporation.Enabled = false;
                cboFactory.Text = vo.Factory_Name;
                cboCorporation.Text = vo.Corporation_Name;
                txtStorage.Text = vo.Storage_Name;

                if (vo.Storage_Use == "Y")
                {
                    rdoUse.Checked = true;
                    rdoUnUse.Checked = false;
                }
                    
                else
                {
                    rdoUse.Checked = false;
                    rdoUnUse.Checked = true;
                }
                    
            }
            
        }

        private void CorporationChange(object sender, EventArgs e)
        {
            cboFactory.ComboBinding(fs.FactoryComboBindings(cboCorporation.SelectedIndex), "factory_id", "factory_name");
            if (IsUpdate == false)
            {
                
            }
            
        }
    }
}
