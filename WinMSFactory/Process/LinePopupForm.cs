using DevExpress.Charts.Model;
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
    public partial class LinePopupForm : PopUpDialogForm
    {
        LineService service = new LineService();
        LineVO vo;
        bool IsUpdate;
        public LinePopupForm(bool IsUpdate, LineVO vo)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;
            if (IsUpdate == true)
            {
                this.vo = vo;
            }
        }
    }
}
