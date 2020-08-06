using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory
{
	public partial class AuthorityForm : WinMSFactory.ListListForm
	{
		AuthorityService authorityService = new AuthorityService();
		DataTable athGrpDt;
		DataTable ProgAthDt;
		int ath_grp_id;
		string ath_grp_name;

		public AuthorityForm()
		{
			InitializeComponent();
		}

		private void AuthorityForm_Load(object sender, EventArgs e)
		{
			try
			{
				
				dataGridViewControl1.IsAllCheckColumnHeader = true;
				dataGridViewControl1.AddNewColumns("권한그룹 코드", "ATH_GRP_ID", 100, false);
				dataGridViewControl1.AddNewColumns("권한그룹 명칭", "ATH_GRP_NAME", 100);
				dataGridViewControl1.AddNewColumns("사용여부", "ATH_GRP_USE", 100);
				dataGridViewControl1.AddNewColumns("순번", "ATH_GRP_SEQ", 100);
				dataGridViewControl1.AddNewColumns("최초등록시간", "FIRST_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최초등록사원", "FIRST_REGIST_EMPLOYEE_NAME", 100);
				dataGridViewControl1.AddNewColumns("최종등록시간", "FINAL_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최종등록사원", "FINAL_REGIST_EMPLOYEE_NAME", 100);

				dataGridViewControl2.IsAllCheckColumnHeader = true;
				dataGridViewControl2.AddNewColumns("프로그램 코드", "PROG_ID", 100, false);
				dataGridViewControl2.AddNewColumns("모듈", "MODULE_NAME", 100);
				dataGridViewControl2.AddNewColumns("프로그램 명칭", "PROG_NAME", 100);
				dataGridViewControl2.AddNewColumns("조회", "PROG_SEARCH", 100);
				dataGridViewControl2.AddNewColumns("추가", "PROG_ADD", 100);
				dataGridViewControl2.AddNewColumns("삭제", "PROG_DELETE", 100);
				dataGridViewControl2.AddNewColumns("저장", "PROG_SAVE", 100);
				dataGridViewControl2.AddNewColumns("엑셀", "PROG_EXCEL", 100);
				dataGridViewControl2.AddNewColumns("출력", "PROG_PRINT", 100);
				dataGridViewControl2.AddNewColumns("바코드", "PROG_BARCODE", 100);
				dataGridViewControl2.AddNewColumns("초기화", "PROG_CLEAR", 100);

				LoadData();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void LoadData()
		{
			athGrpDt = authorityService.GetAllAuthorityGroups();
			dataGridViewControl1.DataSource = athGrpDt;
			dataGridViewControl2.DataSource = null;
			ath_grp_id = 0;
			AuthClear();
		}

		private void Search(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				athGrpDt.CaseSensitive = false;
				DataView dv = athGrpDt.DefaultView;
				string search = txtSearch.Text.Trim();

				if (search.Length > 0)
					dv.RowFilter = $"ATH_GRP_NAME LIKE '%{search}%'";
				else
					dv.RowFilter = "";
			}
		}

		private void Add(object sender, EventArgs e)
		{
			EmployeeVO employeeVO = this.GetEmployee();
			AuthorityGroupPopupForm frm = new AuthorityGroupPopupForm(employeeVO);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void Delete(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				try
				{
					string ath_grp_id = dataGridViewControl1.GetCheckIDs("ATH_GRP_ID");

					if (string.IsNullOrEmpty(ath_grp_id))
						return;

					if (authorityService.DeleteAuthorityGroup(ath_grp_id))
					{
						MessageBox.Show("정상적으로 삭제되었습니다.");
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

		private void AuthClear()
		{
			this.Clear();
			ath_grp_id = 0;
			ath_grp_name = string.Empty;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (ath_grp_id > 0)
			{
				ProgramAthPopupForm frm = new ProgramAthPopupForm(ath_grp_id, ath_grp_name);

				if (frm.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
			else
				MessageBox.Show("권한 그룹을 먼저 선택해주세요.");
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				string prog_id = dataGridViewControl2.GetCheckIDs("PROG_ID");

				if (string.IsNullOrEmpty(prog_id))
					return;

				if (authorityService.DeleteProgramAth(ath_grp_id, prog_id))
				{
					MessageBox.Show("정상적으로 삭제되었습니다.");
					LoadData();
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void dataGridViewControl1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				ath_grp_id = dataGridViewControl1["ATH_GRP_ID", e.RowIndex].Value.ToInt();
				ath_grp_name = dataGridViewControl1["ATH_GRP_NAME", e.RowIndex].Value.ToString();
				ProgAthDt = authorityService.GetProgramAths(ath_grp_id);
				dataGridViewControl2.DataSource = ProgAthDt;
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void dataGridViewControl1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			EmployeeVO employeeVO = this.GetEmployee();
			AuthorityGroupPopupForm frm = new AuthorityGroupPopupForm(employeeVO, ath_grp_id);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void dataGridViewControl2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			int prog_id = dataGridViewControl2["PROG_ID", e.RowIndex].Value.ToInt();
			ProgramAthPopupForm frm = new ProgramAthPopupForm(ath_grp_id, ath_grp_name, prog_id);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void txtAth_grp_name_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				Search(null, null);
		}
	}
}
