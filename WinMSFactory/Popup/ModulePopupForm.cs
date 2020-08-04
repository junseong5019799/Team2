using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;

namespace WinMSFactory
{
	public partial class ModulePopupForm : WinMSFactory.PopUpDialogForm
	{
		EmployeeVO employeeVO;
		int module_id;
		ModuleService moduleService = new ModuleService();

		public ModulePopupForm(EmployeeVO employeeVO)
		{
			try
			{
				
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		public ModulePopupForm(EmployeeVO employeeVO, int module_id = 0)
		{
			try
			{
				InitializeComponent();
				this.employeeVO = employeeVO;
				this.module_id = module_id;
				this.Text = module_id > 0 ? "모듈 수정" : "모듈 등록";
				cboApp_id.ComboBinding(new ApplicationService().GetAllApplications(true), "APP_NAME", "APP_ID");

				if (module_id > 0)
				{
					ModuleVO moduleVO = moduleService.GetModule(module_id);

					cboApp_id.SelectedItem = moduleVO.App_id;
					txtModule.Text = moduleVO.Module_name;
					nudModule_seq.Value = moduleVO.Module_seq;

					if (moduleVO.Module_use == "Y")
						rdoModule_useY.Checked = true;
					else
						rdoModule_useN.Checked = true;
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

				ModuleVO moduleVO = new ModuleVO
				{
					Module_id = module_id,
					App_id = cboApp_id.SelectedValue.ToInt(),
					Module_name = txtModule.Text.Trim(),
					Module_seq = (int)nudModule_seq.Value,
					Module_use = rdoModule_useY.Checked ? "Y" : "N",
					Regist_employee = employeeVO.Employee_id
				};

				if (moduleService.SaveModule(moduleVO))
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
