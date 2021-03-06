﻿using System;
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
		private bool isSortIDCheck;

		public SystemCodeForm()
		{
			InitializeComponent();
		}

		private void SystemCodeForm_Load(object sender, EventArgs e)
		{
			try
			{
				dataGridViewControl1.IsAllCheckColumnHeader = true;
				dataGridViewControl1.AddNewColumns("업데이트 구분용", "FLAG", 100, false);
				dataGridViewControl1.AddNewColumns("*분류코드", "SORT_ID", 100, true, true);
				dataGridViewControl1.AddNewColumns("*분류명", "SORT_NAME", 100, true, false);
				dataGridViewControl1.AddNewColumns("순번", "SORT_SEQ", 100, true, false, false, DataGridViewContentAlignment.MiddleRight);
				dataGridViewControl1.AddNewColumns("비고", "NOTE", 100, true, false);

				LoadcmmGroupData();

				dataGridViewControl2.IsAllCheckColumnHeader = true;
				dataGridViewControl2.AddNewColumns("업데이트 구분용", "FLAG", 100, false);
				dataGridViewControl2.AddNewComCol("*분류명", "SORT_ID", commonGroupDt, "SORT_NAME", "SORT_ID");
				dataGridViewControl2.AddNewColumns("*코드", "COMMON_ID", 100, true, true);
				dataGridViewControl2.AddNewColumns("*코드명", "COMMON_NAME", 100, true, false);
				dataGridViewControl2.AddNewColumns("순번", "COMMON_SEQ", 100, true, false, false, DataGridViewContentAlignment.MiddleRight);
				dataGridViewControl2.AddNewColumns("비고", "NOTE", 100, true, false);

				LoadcmmData();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
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
			cboSearch.ComboBinding(commonCodeService.GetCommonCodes("SEARCH"), "Common_id", "Common_name", "전체", "");
		}

		private void LoadcmmData()
		{
			commonDt = ds.Tables[1];
			storeCmm = commonDt.Clone();
			dataGridViewControl2.DataSource = commonDt;
		}


		private void Search(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				commonGroupDt.CaseSensitive = false;
				DataView dv = commonGroupDt.DefaultView;
				string search = txtSearch.Text.Trim();

				if (search.Length > 0)
				{
					if (cboSearch.SelectedValue.Equals("SEARCH_CMM_1"))
						dv.RowFilter = $"SORT_ID LIKE '%{search}%'";
					else if (cboSearch.SelectedValue.Equals("SEARCH_CMM_2"))
						dv.RowFilter = $"SORT_NAME LIKE '%{search}%'";
					else
						dv.RowFilter = $"SORT_ID LIKE '%{search}%' OR SORT_NAME LIKE '%{search}%'";
				}
				else
					dv.RowFilter = "";
			}
		}

		private void Add(object sender, EventArgs e)
		{
			DataRow dr = commonGroupDt.NewRow();

			commonGroupDt.Rows.Add(dr);
			SetNewRowReadOnly(dataGridViewControl1, "SORT_ID");
		}

		private void Delete(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				try
				{
					dataGridViewControl1.EndEdit();

					string ids = dataGridViewControl1.GetCheckIDs("SORT_ID");

					if (string.IsNullOrEmpty(ids))
						return;

					if (commonCodeService.DeleteCommonGroup(ids))
					{
						MessageBox.Show("정상적으로 삭제 되었습니다.");
						LoadData();
					}
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}
		}

		private void Save(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				try
				{
					dataGridViewControl1.EndEdit();
					dataGridViewControl2.EndEdit();

					if (IsEmptys(storeCmmGroup, cmmGrpChks, dataGridViewControl1, "SORT_ID") || IsEmptys(storeCmm, cmmChks, dataGridViewControl2, "COMMON_ID"))
						return;

					if (commonCodeService.SaveCommonCodes(storeCmmGroup, storeCmm))
					{
						MessageBox.Show("정상적으로 저장 되었습니다.");
						LoadData();
					}

				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}
		}

		private void Clear(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				LoadData();
			}
		}

		private void CmmClear()
		{
			this.Clear();
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
			try
			{
				dataGridViewControl2.EndEdit();

				string ids = dataGridViewControl2.GetCheckIDs("COMMON_ID");

				if (string.IsNullOrEmpty(ids))
					return;

				if (commonCodeService.DeleteCommonCode(ids))
				{
					MessageBox.Show("정상적으로 삭제 되었습니다.");
					LoadData();
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
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
			if (e.ColumnIndex != 0)
			{
				SaveChangingDataRow(dataGridViewControl2.CurrentRow, commonDt, storeCmm, "COMMON_ID");
			}
		}

		private void dataGridViewControl2_Sorted(object sender, EventArgs e)
		{
			SetSortReadOnly(dataGridViewControl1, "COMMON_ID");
		}

		private void SaveChangingDataRow(DataGridViewRow dgvg, DataTable dt, DataTable storeDt, string id)
		{
			if (string.IsNullOrEmpty(dgvg.Cells[id].Value?.ToString()) && isSortIDCheck)
			{
				isSortIDCheck = false;
				return;
			}

			DataRow dr = dt.AsEnumerable().FirstOrDefault(item => item[id].Equals(dgvg.Cells[id].Value));

			if (dr != null)
			{
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

				if (storeDt.AsEnumerable().Where(item => !string.IsNullOrEmpty(item["FLAG"]?.ToString()) && item["FLAG"].Equals(dr[id])).Count() > 0 ||
					(!dgvg.Cells[id].ReadOnly && dt.AsEnumerable().Where(item => item[id].Equals(dr[id])).Count() > 1))
				{
					MessageBox.Show("코드를 확인해주세요.");
					isSortIDCheck = true;
					dgvg.Cells[id].Value = null;
					dgvg.DefaultCellStyle.BackColor = Color.White;
					return;
				}

				dr["FLAG"] = dr[id];
				storeDt.Rows.Add(dr.ItemArray);
				dgvg.DefaultCellStyle.BackColor = Color.AliceBlue;
			}

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
				else if (IsEmpty(dr, chks))
				{
					MessageBox.Show("필수값을 입력해주세요.");
					dgv.Rows.Cast<DataGridViewRow>().Last(item => item.Cells[id].Value.Equals(dr[id]) && !IsAllEmpty(item)).Selected = true;
					return true;
				}
			}

			return false;
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				Search(null, null);
		}
	}
}
