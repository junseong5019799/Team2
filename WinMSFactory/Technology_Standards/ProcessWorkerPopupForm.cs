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
    public partial class ProcessWorkerPopupForm : PopUpDialogForm
    {
        ProcessWorkerService service = new ProcessWorkerService();
        ProcessWorkerVO vo;
        bool IsUpdate;
        string employeeName;
        public ProcessWorkerPopupForm(string employeeName, bool IsUpdate, ProcessWorkerVO vo)
        {
            InitializeComponent();

            this.IsUpdate = IsUpdate;

            this.employeeName = employeeName;
            if (IsUpdate == true)
            {
                this.vo = vo;
            }
        }

        private void ProcessWorkerPopupForm_Load(object sender, EventArgs e)
        {

        }
    }
}
