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
				dataGridViewControl1.AddNewColumns("순번", "APP_SEQ", 100);
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
		}

		private void button1_Click(object sender, EventArgs e) //조회
		{

		}

		private void button2_Click(object sender, EventArgs e) //추가
		{
			EmployeeVO employeeVO = new EmployeeVO { Employee_id = "A" };
			ApplicationPopupForm frm = new ApplicationPopupForm(employeeVO);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void button3_Click(object sender, EventArgs e)  //삭제
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

		private void dataGridViewControl1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			EmployeeVO employeeVO = new EmployeeVO { Employee_id = "A" };
			int app_id = dataGridViewControl1["APP_ID", e.RowIndex].Value.ToInt();
			ApplicationPopupForm frm = new ApplicationPopupForm(employeeVO, app_id);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}
	}
}
