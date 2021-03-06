﻿using MSFactoryVO;
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
	public partial class ModuleForm : WinMSFactory.ListForm
	{
		ModuleService moduleService = new ModuleService();
		DataTable dt;

		public ModuleForm()
		{
			InitializeComponent();
		}

		private void ModuleForm_Load(object sender, EventArgs e)
		{
			try
			{
				dataGridViewControl1.IsAllCheckColumnHeader = true;
				dataGridViewControl1.AddNewColumns("모듈 코드", "MODULE_ID", 100, false);
				dataGridViewControl1.AddNewColumns("어플리케이션", "APP_NAME", 100);
				dataGridViewControl1.AddNewColumns("모듈 명칭", "MODULE_NAME", 100);
				dataGridViewControl1.AddNewColumns("사용여부", "MODULE_USE", 100);
				dataGridViewControl1.AddNewColumns("순번", "MODULE_SEQ", 100);
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
			dt = moduleService.GetAllModules();
			dataGridViewControl1.DataSource = dt;
			ModuleClear();
		}

		private void Search(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				dt.CaseSensitive = false;
				DataView dv = dt.DefaultView;
				string search = txtSearch.Text.Trim();

				if (search.Length > 0)
					dv.RowFilter = $"MODULE_NAME LIKE '%{search}%'";
				else
					dv.RowFilter = "";
			}
		}

		private void Add(object sender, EventArgs e)
		{
			EmployeeVO employeeVO = this.GetEmployee();
			ModulePopupForm frm = new ModulePopupForm(employeeVO);

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
					string module_id = dataGridViewControl1.GetCheckIDs("MODULE_ID");

					if (string.IsNullOrEmpty(module_id))
						return;

					if (moduleService.DeleteModule(module_id))
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

		private void ModuleClear()
		{
			this.Clear();
		}

		private void dataGridViewControl1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			EmployeeVO employeeVO = this.GetEmployee();
			int module_id = dataGridViewControl1["MODULE_ID", e.RowIndex].Value.ToInt();
			ModulePopupForm frm = new ModulePopupForm(employeeVO, module_id);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void txtModule_name_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				Search(null, null);
		}
	}
}
