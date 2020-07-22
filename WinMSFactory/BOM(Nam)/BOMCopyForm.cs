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
    public partial class BOMCopyForm : BasicForm
    {
        // BOM 복사
        public BOMCopyForm()
        {
            InitializeComponent();
        }

        private void BOMCopyForm_Load(object sender, EventArgs e)
        {
            // 제품 목록은 완재품, 반제품 의 목록만 나온다.

            // 복사 목록은 완제품, 반제품 의 재료의 목록만 나온다.

            // 제품 목록, 재료 목록의 사용여부가 N일 경우 나오지 않는다.



            // 제품 그룹 명칭이 완제품, 반제품 인 경우에만 나온다.

            dgv.AddNewColumns("제품 순번", "", 100, true);
            //dgv.AddNewColumns("제품 그룹 코드", "", 100, true);
            //dgv.AddNewColumns("제품 그룹 명칭", "", 100, true);
            //dgv.AddNewColumns("품목 코드", "", 100, true);
            dgv.AddNewColumns("품명", "", 100, true);
            dgv.AddNewColumns("품명 스펙", "", 100, true);
            dgv.AddNewColumns("기본 단위", "", 100, true);
            dgv.AddNewColumns("품목 타입", "", 100, true);
            dgv.AddNewColumns("비고 1", "", 100, true);
            dgv.AddNewColumns("비고 2", "", 100, true);

            // 제품 그룹 명칭이 재료인 경우에만 나온다.
            dgv2.AddNewColumns("제품 순번", "", 100, true);
            //dgv2.AddNewColumns("제품 그룹 명칭", "", 100, true);
            dgv2.AddNewColumns("품명", "", 100, true);
            dgv2.AddNewColumns("품명 스펙", "", 100, true);
            dgv2.AddNewColumns("기본 단위", "", 100, true);
            dgv2.AddNewColumns("품목 타입", "", 100, true);
            dgv2.AddNewColumns("비고 1", "", 100, true);
            dgv2.AddNewColumns("비고 2", "", 100, true);

        }
    }
}
