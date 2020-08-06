using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory.Popup
{
	public partial class LoginForm : Form
	{
		EmployeeService employeeService = new EmployeeService();

		public EmployeeVO Employee { get; set; }

		public LoginForm()
		{
			InitializeComponent();
		}


		private void btnLogin_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.HasEmptyTxt())
					return;

				string employee_id = txtEmployee_id.Text.Trim();
				string employee_pwd = txtEmployee_pwd.Text.Trim().GetSHA256();

				Employee = employeeService.GetLoginEmployee(employee_id, employee_pwd);

				if (Employee != null)
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					MessageBox.Show("로그인에 실패했습니다. ID혹은 비밀번호를 확인해주세요.");
					txtEmployee_pwd.Focus();
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			txtEmployee_id.Text = "admin";
			txtEmployee_pwd.Text = "1234";
			btnLogin.PerformClick();
		}
	}
}
