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

        public List<CompanyVO> SelectProductBindings(int Company_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SELECT P.PRODUCT_ID, P.PRODUCT_NAME
                                    FROM TBL_COMPANY_PRODUCT CP INNER JOIN TBL_PRODUCT P ON CP.product_id = P.PRODUCT_ID
                                    WHERE CP.COMPANY_ID = @COMPANY_ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@COMPANY_ID", Company_id);

                        return SqlHelper.DataReaderMapToList<CompanyVO>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool InsertMaterialPrice(ProductPriceManageVO insertData)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"Insert into [TBL_MATERIAL_PRICE_MANAGEMENT]([company_id], [product_id], [material_current_price], [material_previous_price], [start_date], [end_date], [note])
                                    values([company_id], [product_id], [material_current_price], [material_previous_price], [start_date], [end_date], [note])";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@COMPANY_ID", insertData);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
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

        public List<ProductPriceManageVO> ProductPriceSelect()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SELECT C.COMPANY_ID, C.COMPANY_NAME, P.PRODUCT_ID, P.PRODUCT_NAME, P.PRODUCT_UNIT, P.PRODUCT_INFORMATION, M.MATERIAL_CURRENT_PRICE, M.MATERIAL_PREVIOUS_PRICE, M.START_DATE, M.END_DATE, M.NOTE
                                    FROM TBL_MATERIAL_PRICE_MANAGEMENT M INNER JOIN TBL_PRODUCT P ON M.PRODUCT_ID = P.PRODUCT_ID
	                               INNER JOIN TBL_COMPANY C ON C.company_id = M.COMPANY_ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<ProductPriceManageVO>(cmd.ExecuteReader());
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

        public bool InsertProducts(ProductInsertVO InsertData, char IsBomCopy)
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
                        cmd.Parameters.AddWithValue("@P_IS_BOM_COPY", IsBomCopy);

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
