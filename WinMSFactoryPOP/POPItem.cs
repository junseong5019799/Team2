using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactoryPOP
{
	public class POPItem
	{
		public string TaskID { get; set; }
		public int Task_proc_id { get; set; }
		public BackgroundWorker Worker { get; set; }
		public frmATLTask Frm { get; set; }
		public int Work_order_no { get; set; }
		public string Product_name { get; set; }
		public string Employee_name { get; set; }
		public int Qty { get; set; }
		public int ResultQty { get; set; }
		public int BadQty { get; set; }
		public string Process_name { get; set; }
	}
}
