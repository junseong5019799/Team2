using DevExpress.XtraCharts.Native;
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
    public partial class ProcessPopupForm : PopUpDialogForm
    {
        ProcessService service = new ProcessService();
        ProcessVO vo;
        bool IsUpdate;
        public ProcessPopupForm(bool IsUpdate, ProcessVO vo)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;
            if (IsUpdate == true)
            {
                this.vo = vo;
            }
        }

        private void ProcessPopupForm_Load(object sender, EventArgs e)
        {

        }
    }
}
