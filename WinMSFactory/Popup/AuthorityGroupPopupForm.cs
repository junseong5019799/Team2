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
	public partial class AuthorityGroupPopupForm : WinMSFactory.PopUpDialogForm
	{
		EmployeeVO employeeVO;
		int ath_grp_id;
		AuthorityService authorityService = new AuthorityService();

		public AuthorityGroupPopupForm(EmployeeVO employeeVO)
		{
			InitializeComponent();
			this.employeeVO = employeeVO;
			this.Text = ath_grp_id > 0 ? "권한그룹 수정" : "권한그룹 등록";
		}

		public AuthorityGroupPopupForm(EmployeeVO employeeVO, int ath_grp_id) : this(employeeVO)
		{
			try
			{
				this.ath_grp_id = ath_grp_id;
				AuthorityGroupVO AuthorityGroupVO = authorityService.GetAuthorityGroup(ath_grp_id);

				txtAth_grp_name.Text = AuthorityGroupVO.Ath_grp_name;
				nudAth_grp_seq.Value = AuthorityGroupVO.Ath_grp_seq;
				txtAth_grp_expl.Text = AuthorityGroupVO.Ath_grp_expl;

				if (AuthorityGroupVO.Ath_grp_use == "Y")
					rdoAth_grp_useY.Checked = true;
				else
					rdoAth_grp_useN.Checked = true;
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

				AuthorityGroupVO AuthorityGroupVO = new AuthorityGroupVO
				{
					Ath_grp_name = txtAth_grp_name.Text,
					Ath_grp_seq = (int)nudAth_grp_seq.Value,
					Ath_grp_expl = txtAth_grp_expl.Text,
					Ath_grp_use = rdoAth_grp_useY.Checked ? "Y" : "N",
				};

				if (authorityService.SaveAuthorityGroup(AuthorityGroupVO))
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
