using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
	public class AuthorityGroupVO : BaseVO
	{
		public int Ath_grp_id { get; set; }
		public string Ath_grp_name { get; set; }
		public string Ath_grp_expl { get; set; }
		public int Ath_grp_seq { get; set; }
		public string Ath_grp_use { get; set; }
	}
}
