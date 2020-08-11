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
		public string SearchWord { get; set; }
		public string SearchFromDate { get; set; } = DateTime.Now.AddDays(-7).ToShortDateString();
		public string SearchToDate { get; set; } = DateTime.Now.ToShortDateString();

		//VO쉽게 만드는 쿼리 ㅋㅋ
		//SELECT 'public ' + CASE WHEN CHARINDEX('char', DATA_TYPE) > 0 OR CHARINDEX('text', DATA_TYPE) > 0 THEN 'string' ELSE DATA_TYPE END + ' ' + UPPER(SUBSTRING(COLUMN_NAME, 1, 1)) + LOWER(SUBSTRING(COLUMN_NAME, 2, LEN(COLUMN_NAME) - 1)) + ' { get; set; }'
		//FROM INFORMATION_SCHEMA.COLUMNS
		//WHERE TABLE_NAME = 'TBL_WORK_ORDER'
	}
}
