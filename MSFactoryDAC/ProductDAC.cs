using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Management.Instrumentation;

namespace MSFactoryDAC
{
    public class ProductDAC : ConnectionAccess
    {
        public List<ProductVO> SelectAllProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SP_SELECT_ALL_PRODUCTS";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        return SqlHelper.DataReaderMapToList<ProductVO>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        

        public bool DeleteProducts(int ProductNo)
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SP_DELETE_PRODUCTS";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_PRODUCT_NO", ProductNo);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                            
                        else
                            return false;
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public bool InsertProducts(ProductInsertVO InsertData)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SP_PRODUCT_INSERT";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_PRODUCT_GROUP_ID", InsertData.Product_Group_ID);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_NAME", InsertData.Product_Name);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_INFOMATION", InsertData.Product_Information);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_UNIT", InsertData.Product_Unit);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_STANDARD", InsertData.Product_Standards);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_NOTE1", InsertData.Product_Note1);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_NOTE2",InsertData.Product_Note2);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_USE", InsertData.Product_Use);
                        cmd.Parameters.AddWithValue("@P_FINAL_REGIST_TIME", InsertData.Final_Regist_Time);
                        cmd.Parameters.AddWithValue("@P_FINAL_REGIST_EMPLOYEE", InsertData.Final_Regist_Employee);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_TACT_TIME", InsertData.Product_Tact_Time);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_LEAD_TIME", InsertData.Product_Lead_Time);

                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void UpdateStatus(int ItemNum, int StatusNum)
        {
            string sql = @"SP_PRODUCT_STATUS_CHANGE";
            ProductAndGroupsStatusUpdate(ItemNum, StatusNum, sql);
        }

        public void ProductAndGroupsStatusUpdate(int ItemNum, int StatusNum, string sql)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_ITEM_NUM", ItemNum);
                        cmd.Parameters.AddWithValue("@P_STATUS_NUM", StatusNum);
                        cmd.ExecuteNonQuery();
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
