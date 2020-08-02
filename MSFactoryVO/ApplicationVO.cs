using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
	public class ApplicationVO : BaseVO
	{
		public int App_id { get; set; }
		public string App_name { get; set; }
		public int App_seq { get; set; }
		public string App_use { get; set; }
	}
}
