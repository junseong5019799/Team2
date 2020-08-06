using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
	public class ProgramVO : BaseVO
	{
		public int Prog_id { get; set; }
		public int Module_id { get; set; }
		public string Module_name { get; set; }
		public string Prog_name { get; set; }
		public string Prog_expl { get; set; }
		public int Prog_seq { get; set; }
		public string Prog_use { get; set; }
	}
}
