using MSFactoryDAC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebMSFactory
{
    public class OrderListDAC
    {
        public List<OrderModel> AllOrderList()
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBSettings"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string sql = @"SELECT od.order_no, product_name , concat(od.order_request_quantity,' ',p.product_unit) order_request_quantity_string
		                         , od.order_status , od.order_request_date 
		                         ,(SELECT company_name FROM TBL_COMPANY WHERE o.company_id = company_id) AS company_name
	                            FROM TBL_ORDER_DETAIL od INNER JOIN TBL_ORDER o ON o.order_no = od.order_no				   
							    INNER JOIN TBL_PRODUCT p ON od.product_id = p.product_id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<OrderModel>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}