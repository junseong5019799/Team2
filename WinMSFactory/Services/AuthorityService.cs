using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
	public class AuthorityService
	{
		public DataTable GetAllAuthorityGroups()
		{
			using (AuthorityDAC authorityDAC = new AuthorityDAC())
			{
				return authorityDAC.GetAllAuthorityGroups();
			}
		}

		public AuthorityGroupVO GetAuthorityGroup(int ath_grp_id)
		{
			using (AuthorityDAC authorityDAC = new AuthorityDAC())
			{
				return authorityDAC.GetAuthorityGroup(ath_grp_id);
			}
		}

		public DataTable GetProgramAths(int ath_grp_id)
		{
			using (AuthorityDAC authorityDAC = new AuthorityDAC())
			{
				return authorityDAC.GetProgramAths(ath_grp_id);
			}
		}

		public ProgramAthVO GetProgramAth(int ath_grp_id, int prog_id)
		{
			using (AuthorityDAC authorityDAC = new AuthorityDAC())
			{
				return authorityDAC.GetProgramAth(ath_grp_id, prog_id);
			}
		}

		public bool SaveAuthorityGroup(AuthorityGroupVO authorityGroupVO)
		{
			using (AuthorityDAC authorityDAC = new AuthorityDAC())
			{
				return authorityDAC.SaveAuthorityGroup(authorityGroupVO);
			}
		}

		public bool SaveProgramAth(ProgramAthVO programAthVO)
		{
			using (AuthorityDAC authorityDAC = new AuthorityDAC())
			{
				return authorityDAC.SaveProgramAth(programAthVO);
			}
		}

		public bool DeleteAuthorityGroup(string ath_grp_id)
		{
			using (AuthorityDAC authorityDAC = new AuthorityDAC())
			{
				return authorityDAC.DeleteAuthorityGroup(ath_grp_id);
			}
		}

		public bool DeleteProgramAth(int ath_grp_id, string prog_id)
		{
			using (AuthorityDAC authorityDAC = new AuthorityDAC())
			{
				return authorityDAC.DeleteProgramAth(ath_grp_id, prog_id);
			}
		}
	}
}
