using MSFactoryDAC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebMSFactory
{
    public class PriceProductDAC
    {
        // 자재 단가 관리
        public List<PriceProductList> AllProductPriceList()
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBSettings"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SELECT  C.COMPANY_NAME, P.PRODUCT_NAME,  P.PRODUCT_INFORMATION, CONCAT(FORMAT(M.MATERIAL_CURRENT_PRICE,'#,0'),' 원') MATERIAL_CURRENT_PRICE_STRING, 
                                    CONVERT(INT,RANK() OVER (PARTITION BY COMPANY_NAME, PRODUCT_NAME ORDER BY M.MATERIAL_PRICE_CODE)) RANKNUM, PRODUCT_UNIT,
                                    CONVERT(NVARCHAR(100),START_DATE, 23) START_DATE_STRING,
                                    case when END_date is null then '-' else convert(nvarchar(100),END_DATE, 23) END END_DATE_STRING,
									CASE WHEN M.material_previous_price IS NULL THEN '-' ELSE
									CONCAT(FORMAT(M.MATERIAL_PREVIOUS_PRICE,'#,0'),' 원') END  MATERIAL_PREVIOUS_PRICE_STRING , M.NOTE
                                    FROM TBL_MATERIAL_PRICE_MANAGEMENT M INNER JOIN TBL_PRODUCT P ON M.PRODUCT_ID = P.PRODUCT_ID
	                               INNER JOIN TBL_COMPANY C ON C.company_id = M.COMPANY_ID
";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<PriceProductList>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<PriceProductList> TotalSales()
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBSettings"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // 2가지 고쳐야 할 점 : D.ORDER_REQUEST_QUANTITY => D.RELEASE_QUANTITY , '출고취소' => '출고취소', '출고예정'

                    string sql = @"SELECT P.PRODUCT_NAME, SUM(SELL_CURRENT_PRICE * D.ORDER_REQUEST_QUANTITY) TOTAL_PRICE
                                    FROM TBL_RELEASE_DETAIL D INNER JOIN TBL_PRODUCT P ON D.PRODUCT_ID = P.PRODUCT_ID
						                                      INNER JOIN TBL_SELLPRICE_MANAGEMENT S ON D.PRODUCT_ID = S.PRODUCT_ID		
		                            WHERE D.RELEASE_DATE BETWEEN S.START_DATE AND ISNULL(S.END_DATE,'9999-12-31')
				                            AND RELEASE_STATUS NOT IN ('출고취소')
		                            GROUP BY P.PRODUCT_NAME";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<PriceProductList>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        // 영업 단가 관리
        public List<PriceProductList> AllSellPriceList()
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBSettings"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SELECT P.product_id, product_name, G.PRODUCT_GROUP_NAME, product_information, product_unit, CONCAT(FORMAT(sell_current_price,'#,0'),' 원') SELL_CURRENT_PRICE_STRING, note, sellprice_code
		                            , Convert(int, RANK() OVER(PARTITION BY M.PRODUCT_GROUP_ID, M.PRODUCT_ID ORDER BY SELLPRICE_CODE ASC)) RANKNUM,
									CONVERT(NVARCHAR(100),START_DATE,23) START_DATE_STRING,
									CASE WHEN END_date is null then '-' else convert(nvarchar(100),END_DATE, 23) END END_DATE_STRING,
									CASE WHEN SELL_PREVIOUS_PRICE IS NULL THEN '-'
									ELSE CONCAT(FORMAT(sell_previous_price,'#,0'),' 원')END SELL_PREVIOUS_PRICE_STRING, sell_previous_price
		                            FROM TBL_SELLPRICE_MANAGEMENT M INNER JOIN TBL_PRODUCT P ON M.product_id = P.product_id
									INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT G ON P.product_group_id = G.product_group_id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<PriceProductList>(cmd.ExecuteReader());
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