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
	public partial class ApplicationPopupForm : WinMSFactory.PopUpDialogForm
	{
		EmployeeVO employeeVO;
		int app_id;
		ApplicationService applicationService = new ApplicationService();

		public ApplicationPopupForm(EmployeeVO employeeVO, int app_id = 0)
		{
			try
			{
				InitializeComponent();
				this.employeeVO = employeeVO;
				this.app_id = app_id;
				this.Text = app_id > 0 ? "어플리케이션 수정" : "어플리케이션 등록";

				if (app_id > 0)
				{
					ApplicationVO applicationVO = applicationService.GetApplication(app_id);

					txtApp_name.Text = applicationVO.App_name;
					nudApp_seq.Value = applicationVO.App_seq;

					if (applicationVO.App_use == "Y")
						rdoApp_useY.Checked = true;
					else
						rdoApp_useN.Checked = true;
				}
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
				if (this.HasEmptyTxt())
					return;

				ApplicationVO applicationVO = new ApplicationVO
				{
					App_id = app_id,
					App_name = txtApp_name.Text.Trim(),
					App_seq = (int)nudApp_seq.Value,
					App_use = rdoApp_useY.Checked ? "Y" : "N",
					Regist_employee = employeeVO.Employee_id
				};

				if (applicationService.SaveApplication(applicationVO))
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
