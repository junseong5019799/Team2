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
    public partial class BOMMaterialForm : BasicForm
    {
        // 재료 목록 조회 및 역전개 실시
        public BOMMaterialForm()
        {
            InitializeComponent();
        }

        private void BOMForm_Load(object sender, EventArgs e)
        {
            // BOMListForm 참고

            // 상위, 하위 품목 코드는 제품관리의 품목코드와 Inner join 할 것
            //dgv.AddNewColumns("상위 품목 코드", "", 100, true);
            dgv.AddNewColumns("상위 품목 명칭", "", 100, true);
            //dgv.AddNewColumns("하위 품목 코드", "", 100, true);
            dgv.AddNewColumns("하위 품목 명칭", "", 100, true);
            dgv.AddNewColumns("필요 수량", "", 100, true);
            dgv.AddNewColumns("순번", "", 100, true);
            dgv.AddNewColumns("사용 여부", "", 100, true);
            dgv.AddNewColumns("최초등록시각", "", 100, true);
            dgv.AddNewColumns("최초등록사원", "", 100, true);
            dgv.AddNewColumns("최종등록시각", "", 100, true);
            dgv.AddNewColumns("최종등록사원", "", 100, true);

            //for(int i= 1; i<dgv.Columns.Count; i++)
            //{
            //    for(int j = 0; j<dgv.Rows.Count; j++)
            //    {
            //        dgv[i, j].ReadOnly = true;
            //    }
            //}

            
        }
    }
}
