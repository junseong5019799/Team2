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
        // BOM 등록 및 수정
        public BOMManageForm()
        {
            InitializeComponent();
        }

        private void BOMManageForm_Load(object sender, EventArgs e)
        {
            // 왼쪽 그리드 뷰에는 반재품, 재료 만 조회 가능

            //dgv.AddNewColumns("품목 코드", "", 100, true);
            //dgv.AddNewColumns("제품 그룹 코드", "", 100, true);
            dgv.AddNewColumns("제품 순번", "", 100, true);
            dgv.AddNewColumns("제품 그룹 명칭", "", 100, true);
            dgv.AddNewColumns("제품명", "", 100, true);
            dgv.AddNewColumns("품명 스펙", "", 100, true);
            dgv.AddNewColumns("기본 단위", "", 100, true);
            dgv.AddNewColumns("품목 타입", "", 100, true);
            dgv.AddNewColumns("비고 1", "", 100, true);
            dgv.AddNewColumns("비고 2", "", 100, true);
        }
    }
}
