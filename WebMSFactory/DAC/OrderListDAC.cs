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

                    string sql = @"SELECT od.order_no, product_name 
		                         , concat(od.order_request_quantity,' ',p.product_unit) order_request_quantity_string
		                         , od.order_status , convert(nvarchar(100), od.order_request_date, 23) order_request_date_string
		                         ,(SELECT company_name FROM TBL_COMPANY WHERE o.company_id = company_id) AS company_name
	                              FROM TBL_ORDER_DETAIL od INNER JOIN TBL_ORDER o ON o.order_no = od.order_no				   
							                               INNER JOIN TBL_PRODUCT p ON od.product_id = p.product_id
	                              ORDER BY OD.order_request_date DESC";

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

        public List<OrderModel> AllReleaseList()
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBSettings"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string sql = @"SELECT R.RELEASE_NO, COMPANY_NAME, PRODUCT_NAME, CONVERT(NVARCHAR(100),RELEASE_REQUEST_DATE,23) RELEASE_REQUEST_DATE, CONVERT(NVARCHAR(100),RELEASE_PLAN_DATE,23) RELEASE_PLAN_DATE,
                                   CASE WHEN RELEASE_DATE IS NULL THEN '-'
                                   ELSE CONVERT(NVARCHAR(100),RELEASE_DATE, 23) END RELEASE_DATE, CONCAT(ORDER_REQUEST_QUANTITY, ' ', PRODUCT_UNIT) RELEASE_REQUEST_QUANTITY, 
                                   CASE WHEN RELEASE_QUANTITY = 0 THEN '-'
                                   ELSE CONCAT(RELEASE_QUANTITY,' ',PRODUCT_UNIT) END RELEASE_QUANTITY, RELEASE_STATUS
                                   FROM TBL_RELEASE_DETAIL D INNER JOIN TBL_RELEASE R ON D.RELEASE_NO = R.RELEASE_NO
								                                       INNER JOIN TBL_PRODUCT P ON D.PRODUCT_ID = P.PRODUCT_ID
								                                       INNER JOIN TBL_COMPANY C ON R.COMPANY_ID = C.COMPANY_ID
                                   ORDER BY RELEASE_PLAN_DATE DESC, RELEASE_NO DESC";

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