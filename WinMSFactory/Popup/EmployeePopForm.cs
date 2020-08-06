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
	public partial class EmployeePopForm : WinMSFactory.PopUpDialogForm
	{
		EmployeeVO employeeVO;
		EmployeeService employeeService = new EmployeeService();

		public EmployeePopForm(EmployeeVO employeeVO)
		{
			try
			{
				InitializeComponent();
				this.employeeVO = employeeVO;
				cboAth_grp_id.ComboBinding(new AuthorityService().GetAllAuthorityGroups(), "ATH_GRP_NAME", "ATH_GRP_ID", "선택");
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		public EmployeePopForm(EmployeeVO employeeVO, string employee_id) : this(employeeVO)
		{
			try
			{
				EmployeeVO employee =  employeeService.GetEmployee(employee_id);

				cboAth_grp_id.SelectedValue = employee.Ath_grp_id;
				txtEmployee_id.Enabled = false;
				txtEmployee_id.Text = employee.Employee_id;
				txtEmployee_name.Text = employee.Employee_name;

				if (employee.Employee_use == "Y")
					rdoEmployee_useY.Checked = true;
				else
					rdoEmployee_useN.Checked = true;
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			try
			{
				int ath_grp_id = cboAth_grp_id.SelectedValue.ToInt();
				if (ath_grp_id < 1)
				{
					MessageBox.Show("권한그룹을 선택해주세요.");
					return;
				}
				else if (this.HasEmptyTxt())
					return;
				else if (txtEmployee_pwd.Text.Trim().Length > 0 && txtEmployee_pwd.Text.Trim() != txtEmployee_pwd_confirm.Text.Trim())
				{
					MessageBox.Show("비밀번호와 비밀번호 확인이 일치 하지 않습니다.");
					txtEmployee_pwd.Focus();
					return;
				}

				EmployeeVO employee = new EmployeeVO
				{
					Ath_grp_id = ath_grp_id,
					Employee_id = txtEmployee_id.Text,
					Employee_name = txtEmployee_name.Text,
					Employee_pwd = txtEmployee_pwd.Text,
					Employee_use = rdoEmployee_useY.Checked ? "Y" : "N",
					Regist_employee = this.employeeVO.Employee_id,
					Corporation_id = 1
				};

				if (employeeService.SaveEmployee(employee))
				{
					MessageBox.Show("정상적으로 저장되었습니다.");
					this.DialogResult = DialogResult.OK;
					this.Close();
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
	}
}
