using MSFactoryDAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebMSFactory
{
    public class ProductDAC
    {
        string connStr = string.Empty;
        public ProductDAC()
        {
            connStr = WebConfigurationManager.ConnectionStrings["DBSettings"].ConnectionString;
        }
        

        public DataTable SelectAllProducts(string Category, int Page_No, int Page_Size)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = "SP_WEB_ALLPRODUCT_SEARCH";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_PAGE_NO", Page_No);
                        cmd.Parameters.AddWithValue("@P_PAGE_SIZE", Page_Size);

                        if (Category == "전체")
                            cmd.Parameters.AddWithValue("@P_CATEGORY", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@P_CATEGORY", Category);

                        SqlDataAdapter data = new SqlDataAdapter(cmd);
                        data.Fill(dt);
                    }

                    return dt;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public ProductList DetailProduct(string productName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"select product_id, product_group_name, PRODUCT_NAME, PRODUCT_INFORMATION, PRODUCT_UNIT, CONCAT(PRODUCT_STANDARDS,' ',PRODUCT_UNIT) PRODUCT_STANDARDS, PRODUCT_NOTE1, PRODUCT_NOTE2, PRODUCT_LEAD_TIME, PRODUCT_TACT_TIME
                                    from TBL_PRODUCT P INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT G ON P.product_group_id = G.product_group_id
                                    where product_name = @P_PAGE_NO";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@P_PAGE_NO", productName);

                        return SqlHelper.DataReaderMapToList<ProductList>(cmd.ExecuteReader())[0];
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<string> GetComboList()
        {
            List<string> list = new List<string>();
            list.Add("전체");
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(connStr);
                cmd.Connection.Open();
                cmd.CommandText = @"select product_group_name from tbl_product_group_management";

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                    list.Add(reader[0].ToString());

                return list;
            }
        }

        public int GetTotalCount(string category)
        {
            int iResult = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(connStr);
                cmd.CommandText = @"select count(*) from TBL_PRODUCT_GROUP_MANAGEMENT
                where (PRODUCT_GROUP_NAME = @P_CATEGORY or isnull(@P_CATEGORY, '') = '')";

                if (category == null)
                    cmd.Parameters.AddWithValue("@P_CATEGORY", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@P_CATEGORY", category);

                cmd.Connection.Open();

                iResult = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Connection.Close();
            }
            return iResult;
        }
    }
}