using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory
{
    public static class ControlConfig
    {
        // 체크박스
        public static void InitControlSettings(this Panel pnl)
        {
            foreach (var control in pnl.Controls)   
            {
                if (control is CheckBox)
                {
                    CheckBox chk = (CheckBox)control;
                    chk.Checked = true;
                }
            }
        }

        public static void initControlSettings(this TextBox text)
        {

        }

        public static void initControlSettings(this FromToDateControl dtp)
        {
            dtp.
        }

        
    }
}
