using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;

namespace WinMSFactory
{
	public partial class AuthorityForm : WinMSFactory.ListListForm
	{
		AuthorityService AuthorityService = new AuthorityService();
		DataTable athGrpDt;
		DataTable ProgAthDt;
		int ath_grp_id;

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
				dataGridViewControl1.AddNewColumns("권한그룹 명칭", "ATH_GRP_NAME", 100, true, true);
				dataGridViewControl1.AddNewColumns("사용여부", "ATH_GRP_USE", 100);
				dataGridViewControl1.AddNewColumns("순번", "ATH_GRP_SEQ", 100);
				dataGridViewControl1.AddNewColumns("최초등록시간", "FIRST_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최초등록사원", "FIRST_REGIST_EMPLOYEE_NAME", 100);
				dataGridViewControl1.AddNewColumns("최종등록시간", "FINAL_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최종등록사원", "FINAL_REGIST_EMPLOYEE_NAME", 100);

				dataGridViewControl2.IsAllCheckColumnHeader = true;
				dataGridViewControl2.AddNewColumns("프로그램 코드", "PROG_ID", 100, false);
				dataGridViewControl2.AddNewColumns("모듈", "MODULE_NAME", 100, true, false);
				dataGridViewControl2.AddNewColumns("프로그램 명칭", "PROG_NAME", 100, true, false);
				dataGridViewControl2.AddNewColumns("조회", "PROG_SELECT", 100, true, false);
				dataGridViewControl2.AddNewColumns("추가", "PROG_INSERT", 100, true, false);
				dataGridViewControl2.AddNewColumns("삭제", "PROG_DELECT", 100, true, false);
				dataGridViewControl2.AddNewColumns("저장", "PROG_SAVE", 100, true, false);
				dataGridViewControl2.AddNewColumns("엑셀", "PROG_EXCEL", 100, true, false);

				LoadData();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void LoadData()
		{
			athGrpDt = AuthorityService.GetAllAuthorityGroups();
			dataGridViewControl1.DataSource = athGrpDt;
			dataGridViewControl2.DataSource = null;
			ath_grp_id = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			EmployeeVO employeeVO = new EmployeeVO { Employee_id = "A" };
			AuthorityGroupPopupForm frm = new AuthorityGroupPopupForm(employeeVO);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				string ath_grp_id = dataGridViewControl1.GetCheckIDs("ATH_GRP_ID");

				if (string.IsNullOrEmpty(ath_grp_id))
					return;

				if (AuthorityService.DeleteAuthorityGroup(ath_grp_id))
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			ProgramAthPopupForm frm = new ProgramAthPopupForm();

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				string prog_id = dataGridViewControl2.GetCheckIDs("PROG_ID");

				if (string.IsNullOrEmpty(prog_id))
					return;

				if (AuthorityService.DeleteProgramAth(ath_grp_id, prog_id))
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
				ProgAthDt = AuthorityService.GetProgramAths(ath_grp_id);
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

			EmployeeVO employeeVO = new EmployeeVO { Employee_id = "A" };
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
			ProgramAthPopupForm frm = new ProgramAthPopupForm(ath_grp_id, prog_id);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}
	}
}
