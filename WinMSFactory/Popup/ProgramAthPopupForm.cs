﻿using MSFactoryVO;
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
	public partial class ProgramAthPopupForm : WinMSFactory.PopUpDialogForm
	{
		ModuleService moduleService = new ModuleService();
		ProgramService programService = new ProgramService();
		AuthorityService authorityService = new AuthorityService();
		int ath_grp_id;

		public ProgramAthPopupForm(int ath_grp_id, string ath_grp_name, int prog_id = 0)
		{
			try
			{
				InitializeComponent();
				this.ath_grp_id = ath_grp_id;
				lblAth_grp_name.Text = ath_grp_name;
				this.Text = prog_id > 0 ? "권한그룹 프로그램 수정" : "권한그룹 프로그램 저장";
				cboModule_id.ComboBinding(new ModuleService().GetModules(1), "MODULE_NAME", "MODULE_ID", "선택", 0);

				if (prog_id > 0)
				{
					ProgramAthVO programAthVO = authorityService.GetProgramAth(ath_grp_id, prog_id);

					SetProgCombo(programAthVO.Module_id);
					cboModule_id.SelectedValue = programAthVO.Module_id;
					cboProg_id.SelectedValue = programAthVO.Prog_id;
					chkProg_search.Checked = programAthVO.Prog_search == "Y";
					chkProg_add.Checked = programAthVO.Prog_add == "Y";
					chkProg_delete.Checked = programAthVO.Prog_delete == "Y";
					chkProg_save.Checked = programAthVO.Prog_save == "Y";
					chkProg_excel.Checked = programAthVO.Prog_excel == "Y";
					chkProg_print.Checked = programAthVO.Prog_print == "Y";
					chkProg_barcode.Checked = programAthVO.Prog_barcode == "Y";
					chkProg_clear.Checked = programAthVO.Prog_clear == "Y";
					cboModule_id.Enabled = false;
				}

				cboProg_id.Enabled = false;
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
				if (cboProg_id.SelectedValue.ToInt() < 1)
				{
					MessageBox.Show("프로그램을 선택해주세요.");
					return;
				}
				else if (this.HasEmptyTxt())
					return;

				ProgramAthVO programAthVO = new ProgramAthVO
				{
					Ath_grp_id = ath_grp_id,
					Prog_id = cboProg_id.SelectedValue.ToInt(),
					Prog_search = chkProg_search.Checked ? "Y" : "N",
					Prog_add = chkProg_add.Checked ? "Y" : "N",
					Prog_delete = chkProg_delete.Checked ? "Y" : "N",
					Prog_save = chkProg_save.Checked ? "Y" : "N",
					Prog_excel = chkProg_excel.Checked ? "Y" : "N",
					Prog_print = chkProg_print.Checked ? "Y" : "N",
					Prog_barcode = chkProg_barcode.Checked ? "Y" : "N",
					Prog_clear = chkProg_clear.Checked ? "Y" : "N"
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

		private void cboModule_id_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetProgCombo(cboModule_id.SelectedValue.ToInt());
		}

		private void SetProgCombo(int module_id)
		{
			if (module_id > 0)
			{
				cboProg_id.Enabled = true;
				cboProg_id.ComboBinding(programService.GetPrograms(module_id), "PROG_NAME", "PROG_ID");
			}
		}
	}
}
