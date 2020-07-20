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
    public partial class ButtonControl : Button
    {
        public ButtonControl()
        {
            InitializeComponent();

            this.TextAlign= ContentAlignment.MiddleCenter;

            this.ForeColor = Color.Black;            
            this.BackColor = Color.White;            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
