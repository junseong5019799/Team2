using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory.BOM
{
    public partial class BOMManageForm : BasicForm
    {
        public BOMManageForm()
        {
            InitializeComponent();
        }

        private void BOMManageForm_Load(object sender, EventArgs e)
        {
            //dgv.AddNewColumns("품목 코드", "", 100, true);
            //dgv.AddNewColumns("제품 그룹 코드", "", 100, true);
            dgv.AddNewColumns("제품 순번", "", 100, true);
            dgv.AddNewColumns("품명", "", 100, true);
            dgv.AddNewColumns("제품 사용 여부", "", 100, true);
            dgv.AddNewColumns("품명 스펙", "", 100, true);
            dgv.AddNewColumns("기본 단위", "", 100, true);
            dgv.AddNewColumns("안전 재고량", "", 100, true);
            dgv.AddNewColumns("품목 타입", "", 100, true);
            dgv.AddNewColumns("비고 1", "", 100, true);
            dgv.AddNewColumns("비고 2", "", 100, true);
            dgv.AddNewColumns("최초등록시각", "", 100, true);
            dgv.AddNewColumns("최초등록사원", "", 100, true);
            dgv.AddNewColumns("최종등록시각", "", 100, true);
            dgv.AddNewColumns("최종등록사원", "", 100, true);
        }
    }
}
