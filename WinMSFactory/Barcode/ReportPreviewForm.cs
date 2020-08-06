using DevExpress.XtraReports.UI;
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
    public partial class ReportPreviewForm : Form
    {
        XtraReport xtr;
        public ReportPreviewForm(XtraReport xtr)
        {
            InitializeComponent();
            this.xtr = xtr;

            using (ReportPrintTool pTool = new ReportPrintTool(xtr))
            {
                xtr.ShowPreviewDialog();
            }
        }
    }
}
