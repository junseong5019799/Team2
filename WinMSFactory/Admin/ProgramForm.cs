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
	public partial class ProgramForm : WinMSFactory.ListForm
	{
		ProgramService programService = new ProgramService();
		DataTable dt;

		public ProgramForm()
		{
			InitializeComponent();
		}

		private void ProgramForm_Load(object sender, EventArgs e)
		{
			try
			{
				dataGridViewControl1.IsAllCheckColumnHeader = true;
				dataGridViewControl1.AddNewColumns("프로그램 코드", "PROG_ID", 100, false);
				dataGridViewControl1.AddNewColumns("모듈", "MODULE_NAME", 100);
				dataGridViewControl1.AddNewColumns("프로그램 명칭", "PROG_NAME", 100);
				dataGridViewControl1.AddNewColumns("사용여부", "PROG_USE", 100);
				dataGridViewControl1.AddNewColumns("순번", "PROG_SEQ", 100);
				dataGridViewControl1.AddNewColumns("최초등록시간", "FIRST_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최초등록사원", "FIRST_REGIST_EMPLOYEE_NAME", 100);
				dataGridViewControl1.AddNewColumns("최종등록시간", "FINAL_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최종등록사원", "FINAL_REGIST_EMPLOYEE_NAME", 100);

				LoadData();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void LoadData()
		{
			dt = programService.GetAllPrograms();
			dataGridViewControl1.DataSource = dt;
			ProgClear();
		}

		private void Search(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				dt.CaseSensitive = false;
				DataView dv = dt.DefaultView;
				string search = txtSearch.Text.Trim();

				if (search.Length > 0)
					dv.RowFilter = $"PROG_NAME LIKE '%{search}%'";
				else
					dv.RowFilter = "";
			}
		}

		private void Add(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				EmployeeVO employeeVO = this.GetEmployee();
				ProgramPopupForm frm = new ProgramPopupForm(employeeVO);

				if (frm.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}

		private void Delete(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				try
				{
					string prog_id = dataGridViewControl1.GetCheckIDs("PROG_ID");

					if (string.IsNullOrEmpty(prog_id))
						return;

					if (programService.DeleteProgram(prog_id))
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

		private void ProgClear()
		{
			this.Clear();
		}

		private void dataGridViewControl1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			EmployeeVO employeeVO = this.GetEmployee();
			int prog_id = dataGridViewControl1["PROG_ID", e.RowIndex].Value.ToInt();
			ProgramPopupForm frm = new ProgramPopupForm(employeeVO, prog_id);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void txtProg_name_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				Search(null, null);
		}
	}
}
