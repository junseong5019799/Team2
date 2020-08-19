using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMSFactory.Models
{
    public class OrderModel
   {
		//SELECT od.order_no, product_name, od.product_id
   
		//	, od.order_request_quantity
   
		//	, od.order_status , od.order_request_date , Convert(DATE, o.first_regist_time) first_regist_time
		//	, (SELECT company_name FROM TBL_COMPANY WHERE o.company_id = company_id) AS company_name
		//	 , o.final_regist_employee, o.final_regist_time
		//FROM TBL_ORDER_DETAIL od INNER JOIN TBL_ORDER o ON o.order_no = od.order_no
		//						 INNER JOIN TBL_PRODUCT p ON od.product_id = p.product_id


  //      public int Order_no { get; set; }
		//public string Product_name { get; set; }
		//public string order_request_quantity { get; set; }
  //      public string order_status { get; set; }
		//public DateTime order_request_date


    }
}