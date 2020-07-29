using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinMSFactory
{
	public partial class SystemCodeForm : ListListForm
	{
		private CommonCodeService commonCodeService = new CommonCodeService();
		private DataSet ds;
		private DataTable commonGroupDt;
		private DataTable commonDt;
		private DataTable storeCmmGroup;
		private DataTable storeCmm;
		private string[] cmmGrpChks = { "SORT_ID", "SORT_NAME" };
		private string[] cmmChks = { "SORT_ID", "COMMON_ID", "COMMON_NAME" };

		public SystemCodeForm()
		{
			InitializeComponent();
		}

		private void SystemCodeForm_Load(object sender, EventArgs e)
		{
			dataGridViewControl1.IsAllCheckColumnHeader = true;
			dataGridViewControl1.AddNewColumns("업데이트 구분용", "FLAG", 100, false);
			dataGridViewControl1.AddNewColumns("*분류코드", "SORT_ID", 100, true, true);
			dataGridViewControl1.AddNewColumns("*분류명", "SORT_NAME", 100, true, false);
			dataGridViewControl1.AddNewColumns("비고", "NOTE", 100, true, false);

			LoadcmmGroupData();

			dataGridViewControl2.IsAllCheckColumnHeader = true;
			dataGridViewControl2.AddNewColumns("업데이트 구분용", "FLAG", 100, false);
			dataGridViewControl2.AddNewComCol("*분류명", "SORT_ID", commonGroupDt, "SORT_NAME", "SORT_ID");
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
			storeCmmGroup = commonGroupDt.Clone();
			dataGridViewControl1.DataSource = commonGroupDt;
		}

		private void LoadcmmData()
		{
			commonDt = ds.Tables[1];
			storeCmm = commonDt.Clone();
			dataGridViewControl2.DataSource = commonDt;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataRow dr = commonGroupDt.NewRow();
			
			commonGroupDt.Rows.Add(dr);
			SetNewRowReadOnly(dataGridViewControl1, "SORT_ID");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (dataGridViewControl1.SelectedRows.Count != 1 || dataGridViewControl1.SelectedRows[0].Index < 0)
				return;

			commonCodeService.DeleteCommonGroup(dataGridViewControl1.SelectedRows[0].Cells["SORT_ID"].ToString());
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (IsEmptys(storeCmmGroup, cmmGrpChks, dataGridViewControl1, "SORT_ID") || IsEmptys(storeCmm, cmmChks, dataGridViewControl2, "COMMON_ID"))
				return;

			commonCodeService.SaveCommonCodes(storeCmmGroup, storeCmm);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (commonGroupDt.Rows.Count < 1)
			{
				MessageBox.Show("공통코드그룹 먼저 등록해주세요.");
				return;
			}

			DataRow dr = commonDt.NewRow();

			commonDt.Rows.Add(dr);
			SetNewRowReadOnly(dataGridViewControl2, "COMMON_ID");
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dataGridViewControl2.SelectedRows.Count != 1 || dataGridViewControl2.SelectedRows[0].Index < 0)
				return;

			commonCodeService.DeleteCommonCode(dataGridViewControl2.SelectedRows[0].Cells["COMMON_ID"].ToString());
		}

		private void dataGridViewControl1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != 0)
			{
				SaveChangingDataRow(dataGridViewControl1.CurrentRow, commonGroupDt, storeCmmGroup, "SORT_ID");
			}
		}

		private void dataGridViewControl1_Sorted(object sender, EventArgs e)
		{
			SetSortReadOnly(dataGridViewControl1, "SORT_ID");
		}

		private void dataGridViewControl2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			SaveChangingDataRow(dataGridViewControl2.CurrentRow, commonDt, storeCmm, "COMMON_ID");
		}

		private void dataGridViewControl2_Sorted(object sender, EventArgs e)
		{
			SetSortReadOnly(dataGridViewControl1, "COMMON_ID");
		}

		private void SaveChangingDataRow(DataGridViewRow dgvg, DataTable dt, DataTable storeDt, string id)
		{
			if (string.IsNullOrEmpty(dgvg.Cells[id].Value?.ToString()))
				return;

			DataRow dr = dt.AsEnumerable().FirstOrDefault(item => item[id] == dgvg.Cells[id].Value);

			if (dgvg.DefaultCellStyle.BackColor == Color.AliceBlue)
			{
				for (int i = storeDt.Rows.Count - 1; i >= 0; i--)
				{
					if (storeDt.Rows[i][id].Equals(dr["FLAG"]))
					{
						storeDt.Rows.RemoveAt(i);
						break;
					}
				}
			}

			if (storeDt.AsEnumerable().Where(item => item["FLAG"].Equals(dr[id])).Count() > 0)
			{
				MessageBox.Show("코드를 확인해주세요.");
				dgvg.Cells["FLAG"].Value = dgvg.Cells[id].Value = null;
				dgvg.DefaultCellStyle.BackColor = Color.White;
				return;
			}

			dr["FLAG"] = dr[id];
			storeDt.Rows.Add(dr.ItemArray);
			dgvg.DefaultCellStyle.BackColor = Color.AliceBlue;
			
		}

		private void SetSortReadOnly(DataGridView dgv, string id)
		{
			foreach (DataGridViewRow dgvr in dgv.Rows)
			{
				if (dgvr.Cells["FLAG"].Value != null && dgvr.Cells[id].Value != null && dgvr.Cells["FLAG"].Value.ToString() == dgvr.Cells[id].Value.ToString() + "Y")
					dgvr.Cells[id].ReadOnly = true;
			}
		}

		private void SetNewRowReadOnly(DataGridView dgv, string id)
		{
			dgv.Rows.Cast<DataGridViewRow>().FirstOrDefault(item => string.IsNullOrEmpty(item.Cells["FLAG"].Value?.ToString())).Cells[id].ReadOnly = false;
		}

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

		private bool IsEmptys(DataTable dt, string[] chks, DataGridView dgv, string id)
		{
			for (int i = dt.Rows.Count - 1; i >= 0; i--)
			{
				DataRow dr = dt.Rows[i];

				if (IsAllEmpty(dr))
				{
					dt.Rows.RemoveAt(i);
					continue;
				}
				else if (IsEmpty(dr, cmmGrpChks))
				{
					MessageBox.Show("필수값을 입력해주세요.");
					dgv.Rows.Cast<DataGridViewRow>().Last(item => item.Cells[id].Value.Equals(dr[id]) && !IsAllEmpty(item)).Selected = true;
					return true;
				}
			}

			return false;
		}
	}
}
