using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
	public class EmployeeVO : BaseVO
	{
		public string Employee_id { get; set; }
		public int Corporation_id { get; set; }
		public string Corporation_name { get; set; }
		public int Ath_grp_id { get; set; }
		public string Ath_grp_name { get; set; }
		public string Employee_name { get; set; }
		public string Employee_pwd { get; set; }
		public string Employee_use { get; set; }
	}
}
