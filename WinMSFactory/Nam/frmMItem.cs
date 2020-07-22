using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class frmMItem : ListForm
    {
        // 제품 관리
        public frmMItem()
        {
            InitializeComponent();
        }

        private void frmMItem_Load(object sender, EventArgs e)
        {

            dgv.AddNewColumns("제품코드", "", 100, true);

            //dgv.AddNewColumns("제품그룹코드", "", 100, true);
            dgv.AddNewColumns("제품명", "", 100, true);
            dgv.AddNewColumns("제품스펙", "", 100, true);
            dgv.AddNewColumns("기본단위", "", 100, true);
            dgv.AddNewColumns("생산기준량", "", 100, true);
            dgv.AddNewColumns("제품타입", "", 100, true);
            dgv.AddNewColumns("순번", "", 100, true);
            dgv.AddNewColumns("비고 1", "", 100, true);
            dgv.AddNewColumns("비고 2", "", 100, true);
            dgv.AddNewColumns("사용여부", "", 100, true);
            dgv.AddNewColumns("최초등록시각", "", 100, true);
            dgv.AddNewColumns("최초등록사원", "", 100, true);
            dgv.AddNewColumns("최종등록시각", "", 100, true);
            dgv.AddNewColumns("최종등록사원", "", 100, true);
        }
    }
}
