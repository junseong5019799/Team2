using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
	public class BaseVO
	{
		public string Regist_employee { get; set; }
		public DateTime First_regist_time { get; set; }
		public string First_regist_employee { get; set; }
		public string First_regist_employee_name { get; set; }
		public DateTime Final_regist_time { get; set; }
		public string Final_regist_employee { get; set; }
		public string Final_regist_employee_name { get; set; }
	}
}
