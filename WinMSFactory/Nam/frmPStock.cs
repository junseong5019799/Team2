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
    public partial class frmPStock : BasicForm
    {
        // 재고 현황
        public frmPStock()
        {
            InitializeComponent();
        }

        private void frmPStock_Load(object sender, EventArgs e)
        {
            //dgv.AddNewColumns("재고번호", "", 100, false);
            dgv.AddNewColumns("창고명칭", "", 100, true);
            dgv.AddNewColumns("품목명칭", "", 100, true);
            dgv.AddNewColumns("수량", "", 100, true);
            dgv.AddNewColumns("구분코드", "", 100, true);
            dgv.AddNewColumns("등록일", "", 100, true);
        }
    }
}
