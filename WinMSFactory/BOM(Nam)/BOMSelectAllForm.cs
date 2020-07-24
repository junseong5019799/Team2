using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory.BOM_Nam_
{
    public partial class BOMSelectAllForm : BasicForm
    {
        public BOMSelectAllForm()
        {
            InitializeComponent();
        }

        private void BOMSelectAllForm_Load(object sender, EventArgs e)
        {
            // 제품이 완제품인 경우 하위 목록에만 나옴(재료, 반제품)
            // 제품이 반제품인 경우 상위 (완제품), 하위 (재료) 목록만 나옴
            // 제품이 재료인 경우 상위 목록에만 나옴(반제품, 완제품)

            dgv.AddNewColumns("제품그룹명", "", 100, true);
            dgv.AddNewColumns("제품명", "", 100, true); 
            dgv.AddNewColumns("기본단위", "", 100, true); 
            dgv.AddNewColumns("품목스펙", "", 100, true); 
            dgv.AddNewColumns("품목타입", "", 100, true); 
            dgv.AddNewColumns("제품비고1", "", 100, true); 
            dgv.AddNewColumns("제품비고2", "", 100, true); 

            dgv2.AddNewColumns("제품그룹명", "", 100, true);
            dgv2.AddNewColumns("제품명", "", 100, true); 
            dgv2.AddNewColumns("기본단위", "", 100, true); 
            dgv2.AddNewColumns("품목스펙", "", 100, true); 
            dgv2.AddNewColumns("품목타입", "", 100, true); 
            dgv2.AddNewColumns("제품비고1", "", 100, true); 
            dgv2.AddNewColumns("제품비고2", "", 100, true); 

            dgv3.AddNewColumns("제품그룹명", "", 100, true);
            dgv3.AddNewColumns("제품명", "", 100, true);
            dgv3.AddNewColumns("기본단위", "", 100, true); 
            dgv3.AddNewColumns("품목스펙", "", 100, true); 
            dgv3.AddNewColumns("품목타입", "", 100, true); 
            dgv3.AddNewColumns("제품비고1", "", 100, true); 
            dgv3.AddNewColumns("제품비고2", "", 100, true);


            //dgv.AddNewColumns("하위 품목 명칭", "", 100, false);
            //dgv.AddNewColumns("제품그룹명", "", 100, true); // BOM - 하위품목코드 - 제품그룹 코드 - 제품그룹명칭
            //dgv.AddNewColumns("제품명", "", 100, true); // BOM - 하위품목코드 - 제품그룹 코드 - 제품그룹명칭
            //dgv.AddNewColumns("기본단위", "", 100, true); // BOM - 하위 품목 코드 - 기본단위
            //dgv.AddNewColumns("품목스펙", "", 100, true); // BOM - 하위 품목 코드 - 품목스펙
            //dgv.AddNewColumns("품목타입", "", 100, true); // BOM - 하위 품목 코드 - 품목타입
            //dgv.AddNewColumns("제품비고1", "", 100, true); // BOM - 하위 품목 코드 - 제품비고1
            //dgv.AddNewColumns("제품비고2", "", 100, true); // BOM - 하위 품목 코드 - 제품비고2

            //dgv2.AddNewColumns("제품그룹명", "", 100, true);// BOM - 상위품목코드 - 제품그룹 코드 - 제품그룹명칭
            //dgv2.AddNewColumns("제품명", "", 100, true); // BOM - 상위 품목 코드 - 품명
            //dgv2.AddNewColumns("기본단위", "", 100, true); // BOM - 상위 품목 코드 - 기본단위
            //dgv2.AddNewColumns("품목스펙", "", 100, true); // BOM - 상위 품목 코드 - 품목스펙
            //dgv2.AddNewColumns("품목타입", "", 100, true); // BOM - 상위 품목 코드 - 품목타입
            //dgv2.AddNewColumns("제품비고1", "", 100, true); // BOM - 상위 품목 코드 - 제품비고1
            //dgv2.AddNewColumns("제품비고2", "", 100, true); // BOM - 상위 품목 코드 - 제품비고2

            // 상위, 하위 품목 코드는 제품관리의 품목코드와 Inner join 할 것






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
