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
	public partial class ApplicationForm : WinMSFactory.ListForm
	{
		ApplicationService applicationService = new ApplicationService();
		DataTable dt;

		public ApplicationForm()
		{
			InitializeComponent();
		}

		private void ApplicationForm_Load(object sender, EventArgs e)
		{
			try
			{
				dataGridViewControl1.IsAllCheckColumnHeader = true;
				dataGridViewControl1.AddNewColumns("어플리케이션 코드", "APP_ID", 100, false);
				dataGridViewControl1.AddNewColumns("어플리케이션", "APP_NAME", 100);
				dataGridViewControl1.AddNewColumns("사용여부", "APP_USE", 100);
				dataGridViewControl1.AddNewColumns("순번", "APP_SEQ", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
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
			dt = applicationService.GetAllApplications();
			dataGridViewControl1.DataSource = dt;
			AppClear();
		}

		private void Search(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				string app_name = txtApp_name.Text.Trim();

				if (app_name.Length > 0)
				{
					dt.CaseSensitive = false;
					DataView dv = dt.DefaultView;
					dv.RowFilter = $"APP_NAME LIKE '%{app_name}%'";
				}
			}
		}

		private void Add(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				EmployeeVO employeeVO = this.GetEmployee();
				ApplicationPopupForm frm = new ApplicationPopupForm(employeeVO);

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
					string app_id = dataGridViewControl1.GetCheckIDs("APP_ID");

					if (string.IsNullOrEmpty(app_id))
						return;

					if (applicationService.DeleteApplication(app_id))
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

		private void AppClear()
		{
			this.Clear();
		}

		private void dataGridViewControl1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			EmployeeVO employeeVO = this.GetEmployee();
			int app_id = dataGridViewControl1["APP_ID", e.RowIndex].Value.ToInt();
			ApplicationPopupForm frm = new ApplicationPopupForm(employeeVO, app_id);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}
	}
}
