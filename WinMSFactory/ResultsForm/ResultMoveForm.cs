﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class ResultMoveForm : ListListForm
    {
        StorageService service = new StorageService();
        int SelectStorage;
        int product_id = 0;

        public ResultMoveForm()
        {
            InitializeComponent();
        }

        private void ResultMoveForm_Load(object sender, EventArgs e)
        {
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
            dgv.ColumnHeadersHeight = 30;

            dgv.AddNewColumns("창고", "Storage_Name", 150, false);
            dgv.AddNewColumns("품목", "Product_Id", 150, false);
            dgv.AddNewColumns("품목 그룹", "Product_Group_Name", 150, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("품목명", "Product_Name", 200, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("재고수량", "Stock_Quantity", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);

            dgv2.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
            dgv2.ColumnHeadersHeight = 30;

            dgv2.AddNewColumns("재고번호", "Stock_No", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("창고명", "Storage_id", 100, false);
            dgv2.AddNewColumns("창고명", "Storage_Name", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);                   // 다른 창고 물품들을 이동할 수도 있어서
            dgv2.AddNewColumns("품목 그룹", "Product_Group_Name", 150, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("품목명", "Product_Name", 200, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("재고수량", "Stock_Quantity", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);          // dgv에서 입력한 이동 수량을 표시
            dgv2.AddNewColumns("등록일", "Stock_Regist_Date", 150, true, true, false, DataGridViewContentAlignment.MiddleLeft);

            cboStorage.ComboBinding(service.GetStorage(), "Storage_ID", "Storage_Name");

            SelectStorage = Convert.ToInt32(cboStorage.SelectedValue);
            dgv.DataSource = service.SelectProductAll(SelectStorage);
        }

        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                SelectStorage = Convert.ToInt32(cboStorage.SelectedValue);

                dgv.DataSource = service.SelectProductAll(SelectStorage);
            }
        }


        //재고 detail 보여주기 
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            product_id = Convert.ToInt32(dgv.SelectedRows[0].Cells[1].Value);
                                  
            dgv2.DataSource = service.GetStorageDetailList(product_id);

        }

        /// <summary>
        /// 재고 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMove_Click(object sender, EventArgs e)
        {
            ResultListForm frm = new ResultListForm();
            List<int> list = new List<int>();
            List<int> cnt = new List<int>();

            dgv2.EndEdit();

            foreach (DataGridViewRow row in dgv2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv2[0, row.Index];

                if (chk.Value == null)
                    continue;

                else if ((bool)chk.Value == true)
                    cnt.Add(1);
            }

            if (cnt.Count < 1)
            {
                MessageBox.Show("재고 할 품목을 선택해주세요.");
                return;
            }


            for (int i = 0; i < dgv2.RowCount; i++)
            {
                if (dgv2.Rows[i].Cells[0].Value != null)
                {
                    bool IsCheck = (bool)dgv2.Rows[i].Cells[0].Value;

                    if (IsCheck)
                    {
                        int num = Convert.ToInt32(dgv2.Rows[i].Cells[1].Value);
                        list.Add(num);
                    }
                }
            }
            frm.ID = list;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgv2.DataSource = service.GetStorageDetailList(product_id);
            }
        }
    }
}
