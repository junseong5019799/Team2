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
		public string Orer_Request_Quantity_string { get; set; }
		public string Order_Status { get; set; }
		public DateTime Order_Request_Date { get; set; }
		public string Company_Name { get; set; }
	}
}