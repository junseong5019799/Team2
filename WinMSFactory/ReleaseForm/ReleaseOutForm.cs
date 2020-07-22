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
    public partial class ReleaseOutForm : ListForm
    {
        public ReleaseOutForm()
        {
            InitializeComponent();
        }

        private void ReleaseOutForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("출고예정 번호", "", 100, true);
            dgv.AddNewColumns("거래처", "", 100, true);
            dgv.AddNewColumns("출고 계획일", "", 100, true);
            dgv.AddNewColumns("품목 코드", "", 100, true);
            dgv.AddNewColumns("요청 수량", "", 100, true);
            dgv.AddNewColumns("출고 수량", "", 100, true);
            dgv.AddNewColumns("출고 상태", "", 100, true);
            dgv.AddNewColumns("출고일", "", 100, true);
            dgv.AddNewColumns("최초등록 시각", "", 100, true);
            dgv.AddNewColumns("최종등록 시각", "", 100, true);
            dgv.AddNewColumns("최초등록 시각", "", 100, true);
            dgv.AddNewColumns("최종등록 사원", "", 100, true);
        }
    }
}
