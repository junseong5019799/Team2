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
	public partial class EmployeeForm : WinMSFactory.ListForm
	{
		EmployeeService employeeService = new EmployeeService();
		DataTable dt;

		public EmployeeForm()
		{
			InitializeComponent();
		}

		private void EmployeeForm_Load(object sender, EventArgs e)
		{
			try
			{
				dataGridViewControl1.IsAllCheckColumnHeader = true;
				dataGridViewControl1.AddNewColumns("프로그램 코드", "PROG_ID", 100, false);
				dataGridViewControl1.AddNewColumns("모듈", "MODULE_ID", 100);
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
			dt = employeeService.GetAllEmployees();
			dataGridViewControl1.DataSource = dt;
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{

		}
	}
}
