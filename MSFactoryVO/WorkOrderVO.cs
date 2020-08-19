using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
	public class WorkOrderVO : BaseVO
	{
		public int Work_order_no { get; set; }
		public int Worker_id { get; set; }
		public string Employee_name { get; set; }
		public int Product_id { get; set; }
		public string Product_name { get; set; }
		public int Release_no { get; set; }
		public int Release_seq { get; set; }
		public int Qty { get; set; }
		public DateTime Work_order_date { get; set; }
		public DateTime Work_date { get; set; }
		public int Work_order_quantity { get; set; }
		public int Result_quantity { get; set; }
		public int Defective_quantity { get; set; }
		public string Work_start_time { get; set; }
		public string Work_finish_time { get; set; }
		public string Work_order_status { get; set; }
		public int Process_id { get; set; }
		public string Process_name { get; set; }
		public int Line_id { get; set; }
		public string Line_name { get; set; }
		public int Factory_id { get; set; }
		public string Factory_name { get; set; }
	}
}
