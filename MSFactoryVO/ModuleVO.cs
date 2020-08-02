using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
	public class ModuleVO : BaseVO
	{
		public int Module_id { get; set; }
		public int App_id { get; set; }
		public string App_name { get; set; }
		public string Module_name { get; set; }
		public int Module_seq { get; set; }
		public string Module_use { get; set; }
	}
}
