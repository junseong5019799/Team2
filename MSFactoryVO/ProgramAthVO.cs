using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
	public class ProgramAthVO
	{
		public int Ath_grp_id { get; set; }
		public string Ath_grp_name { get; set; }
		public int Prog_id { get; set; }
		public string Prog_name { get; set; }
		public int Module_id { get; set; }
		public string Module_name { get; set; }
		public string Prog_search { get; set; }
		public string Prog_add { get; set; }
		public string Prog_delete { get; set; }
		public string Prog_save { get; set; }
		public string Prog_excel { get; set; }
		public string Prog_print { get; set; }
		public string Prog_barcode { get; set; }
		public string Prog_clear { get; set; }
	}
}
