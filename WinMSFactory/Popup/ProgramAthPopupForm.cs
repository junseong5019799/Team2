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
	public partial class ProgramAthPopupForm : WinMSFactory.PopUpDialogForm
	{
		ModuleService moduleService = new ModuleService();
		ProgramService programService = new ProgramService();
		AuthorityService authorityService = new AuthorityService();
		int ath_grp_id;
		int prog_id;

		public ProgramAthPopupForm()
		{
			try
			{
				InitializeComponent();
				cboModule_id.ComboBinding(moduleService.GetAllModules(), "MODULE_NAME", "MODULE_ID");
				cboProg_id.ComboBinding(programService.GetAllPrograms(), "PROG_NAME", "PROG_ID");
				this.Text = ath_grp_id > 0 && prog_id > 0 ? "권한그룹 프로그램 수정" : "권한그룹 프로그램 저장";
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		public ProgramAthPopupForm(int ath_grp_id, int prog_id) : this()
		{
			try
			{
				this.ath_grp_id = ath_grp_id;
				this.prog_id = prog_id;
				ProgramAthVO programAthVO = authorityService.GetProgramAth(ath_grp_id, prog_id);

				cboModule_id.SelectedValue = programAthVO.Module_id;
				cboProg_id.SelectedValue = programAthVO.Prog_id;
				chkProg_select.Checked = programAthVO.Prog_select == "Y";
				chkProg_insert.Checked = programAthVO.Prog_insert == "Y";
				chkProg_delect.Checked = programAthVO.Prog_delect == "Y";
				chkProg_save.Checked = programAthVO.Prog_save == "Y";
				chkProg_excel.Checked = programAthVO.Prog_excel == "Y";
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

				ProgramAthVO programAthVO = new ProgramAthVO
				{
					Module_id = cboModule_id.SelectedValue.ToInt(),
					Prog_id = cboProg_id.SelectedValue.ToInt(),
					Prog_select = chkProg_select.Checked ? "Y" : "N",
					Prog_insert = chkProg_insert.Checked ? "Y" : "N",
					Prog_delect = chkProg_delect.Checked ? "Y" : "N",
					Prog_save = chkProg_save.Checked ? "Y" : "N",
					Prog_excel = chkProg_excel.Checked ? "Y" : "N",
				};

				if (authorityService.SaveProgramAth(programAthVO))
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
