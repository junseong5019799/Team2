using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;

namespace WinMSFactory
{
	public partial class SystemCodeForm : ListListForm
	{
		private CommonCodeService commonCodeService = new CommonCodeService();
		private List<DataRow> commonGroupList = new List<DataRow>();
		private List<DataRow> commonList = new List<DataRow>();
		private DataSet ds;
		private DataTable commonGroupDt;
		private DataTable commonDt;
		private string[] cmmGrpChks = { "SORT_ID", "SORT_NAME" };
		private string[] cmmChks = { "SORT_ID", "COMMON_ID", "COMMON_NAME" };

		public SystemCodeForm()
		{
			InitializeComponent();
		}

		private void SystemCodeForm_Load(object sender, EventArgs e)
		{
			dataGridViewControl1.AddNewColumns("업데이트 구분용", "FLAG", 100, false);
			dataGridViewControl1.AddNewColumns("*분류코드", "SORT_ID", 100, true, true);
			dataGridViewControl1.AddNewColumns("*분류명", "SORT_NAME", 100, true, false);
			dataGridViewControl1.AddNewColumns("비고", "NOTE", 100, true, false);

			LoadcmmGroupData();

			dataGridViewControl2.AddNewColumns("업데이트 구분용", "FLAG", 100, false);
			dataGridViewControl2.AddNewComCol("*분류명", "SORT_ID", commonGroupDt, "Sort_name", "Sort_id");
			dataGridViewControl2.AddNewColumns("*코드", "COMMON_ID", 100, true, false);
			dataGridViewControl2.AddNewColumns("*코드명", "COMMON_NAME", 100, true, false);
			dataGridViewControl2.AddNewColumns("비고", "NOTE", 100, true, false);

			LoadcmmData();
		}

		private void LoadData()
		{
			LoadcmmGroupData();
			LoadcmmData();
		}

		private void LoadcmmGroupData()
		{
			ds = commonCodeService.GetAllCommonCodes();
			commonGroupDt = ds.Tables[0];
			dataGridViewControl1.DataSource = commonGroupDt;
		}

		private void LoadcmmData()
		{
			commonDt = ds.Tables[1];
			dataGridViewControl2.DataSource = commonDt;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataRow dr = commonGroupDt.NewRow();
			
			commonGroupDt.Rows.Add(dr);
			commonGroupList.Add(dr);
			SetNewRowReadOnly(dataGridViewControl1, 1);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (dataGridViewControl1.SelectedRows.Count != 1 || dataGridViewControl1.SelectedRows[0].Index < 0)
				return;
			
			
		}

		private void dataGridViewControl1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow dgvg = dataGridViewControl1.CurrentRow;
			commonGroupList.Add(commonGroupDt.AsEnumerable().FirstOrDefault(item => item["SORT_ID"] == dgvg.Cells[1].Value));
			dgvg.DefaultCellStyle.BackColor = Color.AliceBlue;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			DataRow dr = commonDt.NewRow();

			commonDt.Rows.Add(dr);
			commonList.Add(dr);
			SetNewRowReadOnly(dataGridViewControl2, 1);
		}

		private void dataGridViewControl1_Sorted(object sender, EventArgs e)
		{
			foreach (DataGridViewRow dgvr in dataGridViewControl1.Rows)
			{
				if (!string.IsNullOrEmpty(dgvr.Cells[0].Value.ToString()))
					dgvr.Cells[1].ReadOnly = true;
			}
		}

		private void SetNewRowReadOnly(DataGridView dgv, int cellIndex)
		{
			dgv.Rows.Cast<DataGridViewRow>().FirstOrDefault(item => string.IsNullOrEmpty(item.Cells[0].Value?.ToString())).Cells[cellIndex].ReadOnly = false;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			for (int i = commonGroupList.Count - 1; i >= 0; i--)
			{
				DataRow dr = commonGroupList[i];

				if (IsAllEmpty(dr))
				{ 
					commonGroupList.RemoveAt(i);
					return;
				}
				else if (IsEmpty(dr, cmmGrpChks))
				{
					MessageBox.Show("필수값을 입력해주세요.");
					dataGridViewControl1.Rows.Cast<DataGridViewRow>().Last(item => item.Cells[1].Value == dr["SORT_ID"] && !IsAllEmpty(item)).Selected = true;
					return;
				}	
			}
		}

		//private void RemoveEmpty(DataTable dt)
		//{
		//	for (int i = dt.Rows.Count - 1; i >= 0; i--)
		//	{
		//		DataRow dr = dt.Rows[i];

		//		if (IsAllEmpty(dr))
		//			dt.Rows.RemoveAt(i);
		//	}
		//}

		private bool IsAllEmpty(DataRow dr)
		{
			foreach (var elem in dr.ItemArray)
			{
				if (!string.IsNullOrEmpty(elem?.ToString()))
					return false;
			}

			return true;
		}

		private bool IsAllEmpty(DataGridViewRow dgvr)
		{
			foreach (DataGridViewCell dgvc in dgvr.Cells)
			{
				if (!string.IsNullOrEmpty(dgvc.Value?.ToString()))
					return false;
			}

			return true;
		}

		private bool IsEmpty(DataRow dr, string[] chks)
		{
			foreach (string chk in chks)
			{
				if (string.IsNullOrEmpty(dr[chk].ToString()))
					return true;
			}

			return false;
		}
	}
}
