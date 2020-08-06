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
	public partial class ProgramPopupForm : WinMSFactory.PopUpDialogForm
	{
		EmployeeVO employeeVO;
		int prog_id;
		ProgramService programService = new ProgramService();

		public ProgramPopupForm(EmployeeVO employeeVO)
		{
			try
			{
				InitializeComponent();
				this.employeeVO = employeeVO;
				this.Text = prog_id > 0 ? "프로그램 수정" : "프로그램 등록";
				cboModule_id.ComboBinding(new ModuleService().GetModules(1), "MODULE_NAME", "MODULE_ID");
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		public ProgramPopupForm(EmployeeVO employeeVO, int prog_id) : this(employeeVO)
		{
			try
			{
				this.prog_id = prog_id;
				ProgramVO programVO = programService.GetProgram(prog_id);

				cboModule_id.SelectedValue = programVO.Module_id;
				txtProg_name.Text = programVO.Prog_name;
				nudProg_seq.Value = programVO.Prog_seq;
				txtProg_expl.Text = programVO.Prog_expl;

				if (programVO.Prog_use == "Y")
					rdoProg_useY.Checked = true;
				else
					rdoProg_useN.Checked = true;
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

				ProgramVO programVO = new ProgramVO
				{
					Prog_id = prog_id,
					Module_id = cboModule_id.SelectedValue.ToInt(),
					Prog_name = txtProg_name.Text,
					Prog_seq = (int)nudProg_seq.Value,
					Prog_use = rdoProg_useY.Checked ? "Y" : "N",
					Prog_expl = txtProg_expl.Text,
					Regist_employee = employeeVO.Employee_id
				};

				if (programService.SaveProgram(programVO))
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
