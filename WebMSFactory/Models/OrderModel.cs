using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMSFactory
{
    public class OrderModel
   {
		public int Order_No { get; set; }
		public string Product_Name { get; set; }
		public string Order_Request_Quantity_string { get; set; }
		public string Order_Status { get; set; }
		public string Order_Request_Date_String { get; set; }
		public string Company_Name { get; set; }
		public int Release_No { get; set; }
		public string Release_Request_Date { get; set; }
		public string Release_Plan_Date { get; set; }
		public string Release_Date { get; set; }
		public string Release_Request_Quantity { get; set; }
		public string Release_Quantity { get; set; }
		public string Release_Status { get; set; }
	}
}