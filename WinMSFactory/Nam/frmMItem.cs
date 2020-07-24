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
            // 완제품만 나오도록 함 (반제품, 재료는 나오면 안됨)
            // 사용 여부 변경 가능, BOM 확인
            dgv.AddNewColumns("제품코드", "", 100, true);

            //dgv.AddNewColumns("제품그룹코드", "", 100, true);
            dgv.AddNewColumns("제품그룹명", "", 100, true);
            dgv.AddNewColumns("제품명", "", 100, true);
            dgv.AddNewColumns("제품스펙", "", 100, true);
            dgv.AddNewColumns("기본단위", "", 100, true);
            dgv.AddNewColumns("생산기준량", "", 100, true);
            dgv.AddNewColumns("제품타입", "", 100, true);
            dgv.AddNewColumns("순번", "", 100, true);
            dgv.AddNewColumns("비고 1", "", 100, true);
            dgv.AddNewColumns("비고 2", "", 100, true);
            dgv.AddNewBtnCol("사용 여부","사용", new Padding(1, 1, 1, 1));
            dgv.AddNewColumns("최초등록시각", "", 100, true);
            dgv.AddNewColumns("최초등록사원", "", 100, true);
            dgv.AddNewColumns("최종등록시각", "", 100, true);
            dgv.AddNewColumns("최종등록사원", "", 100, true);
        }

        private void buttonControl1_Click(object sender, EventArgs e)
        {
            ProductInfoForm frm = new ProductInfoForm(this);

            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
