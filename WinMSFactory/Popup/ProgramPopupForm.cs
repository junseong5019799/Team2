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
	public partial class ProgramPopupForm : WinMSFactory.PopUpDialogForm
	{
		EmployeeVO employeeVO;
		int prog_id;
		ProgramService programService = new ProgramService();

		public ProgramPopupForm(EmployeeVO employeeVO, int prog_id = 0)
		{
			try
			{
				InitializeComponent();
				this.employeeVO = employeeVO;
				this.prog_id = prog_id;
				this.Text = prog_id > 0 ? "프로그램 수정" : "프로그램 등록";
				cboModule_id.ComboBinding(new ModuleService().GetModules(1), "MODULE_NAME", "MODULE_ID");

				if (prog_id > 0)
				{
					ProgramVO programVO = programService.GetProgram(prog_id);

					cboModule_id.SelectedValue = programVO.Module_id;
					txtProg_name.Text = programVO.Prog_name;
					txtProg_form_name.Text = programVO.Prog_form_name;
					nudProg_seq.Value = programVO.Prog_seq;
					txtProg_expl.Text = programVO.Prog_expl;

					if (programVO.Prog_use == "Y")
						rdoProg_useY.Checked = true;
					else
						rdoProg_useN.Checked = true;
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

				ProgramVO programVO = new ProgramVO
				{
					Prog_id = prog_id,
					Module_id = cboModule_id.SelectedValue.ToInt(),
					Prog_name = txtProg_name.Text.Trim(),
					Prog_form_name = txtProg_form_name.Text.Trim(),
					Prog_seq = (int)nudProg_seq.Value,
					Prog_use = rdoProg_useY.Checked ? "Y" : "N",
					Prog_expl = txtProg_expl.Text.Trim(),
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
