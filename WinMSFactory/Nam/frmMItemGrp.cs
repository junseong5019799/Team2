using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class frmMItemGrp : ListForm
    {
        // 제품 그룹 관리
        public frmMItemGrp()
        {
            InitializeComponent();
        }

        private void frmMItemGrp_Load(object sender, EventArgs e)
        {
            //dgv.AddNewColumns("제품그룹 코드", "", 100, false);
            dgv.AddNewColumns("제품그룹 명칭", "", 100, true);
            dgv.AddNewColumns("사용여부", "", 100, true);
            dgv.AddNewColumns("비고1", "", 100, true);
            dgv.AddNewColumns("비고2", "", 100, true);
            dgv.AddNewColumns("최초등록시각", "", 100, true);
            dgv.AddNewColumns("최초등록사원", "", 100, true);
            dgv.AddNewColumns("최종등록시각", "", 100, true);
            dgv.AddNewColumns("최종등록사원", "", 100, true);
        }
    }
}
