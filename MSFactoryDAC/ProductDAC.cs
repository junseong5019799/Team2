﻿using MSFactoryVO;
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

        public bool UpdateMaterialPrice(ProductPriceManageVO insertData)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SP_MATERIAL_PRICE_UPDATE";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@P_MATERIAL_PRICE_CODE", insertData.Material_Price_Code);
                        cmd.Parameters.AddWithValue("@P_COMPANY_ID", insertData.Company_ID);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_ID", insertData.Product_ID);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_CURRENT_PRICE", insertData.Material_Current_Price);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_PREVIOUS_PRICE", insertData.Material_Previous_Price);
                        cmd.Parameters.AddWithValue("@P_START_DATE", insertData.Start_Date);
                        cmd.Parameters.AddWithValue("@P_NOTE", insertData.Note);
                        cmd.Parameters.AddWithValue("@P_CATEGORY", insertData.Category);

                        int cnt = cmd.ExecuteNonQuery();

                        if (cnt > 0)
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

        public bool SelectPriceData(int CompanyID, int ProductID, ref ProductPriceManageVO vo)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();

                // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                string sql = @"select TOP 1 material_price_code, material_current_price, start_date, end_date from TBL_MATERIAL_PRICE_MANAGEMENT 
                                where company_id = @CompanyID and product_id = @ProductID
                                order by material_price_code desc";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    

                    
                    if (reader.Read()) // 데이터가 존재하는 경우 데이터를 불러옴
                    {
                        vo = new ProductPriceManageVO
                        {
                            Material_Price_Code = Convert.ToInt32(reader[0]),
                            Material_Current_Price = Convert.ToInt32(reader[1]),
                            Start_Date = Convert.ToDateTime(reader[2]),
                            End_Date_String = reader[3].ToString()
                        };
                        
                        return true;
                    }
                    // 데이터가 없을 경우 null, false 처리
                    vo = null;
                    return false; 
                }

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
                    object EndDate;
                    string sql = @"SP_MATERIAL_PRICE_UPSERT";
                    

                    if (insertData.End_Date_String == "-")
                        EndDate = DBNull.Value;
                    else
                        EndDate = insertData.End_Date.Value;

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_MATERIAL_PRICE_CODE", insertData.Material_Price_Code);
                        cmd.Parameters.AddWithValue("@P_COMPANY_ID", insertData.Company_ID);
                        cmd.Parameters.AddWithValue("@P_Product_ID", insertData.Product_ID);
                        cmd.Parameters.AddWithValue("@P_Material_Current_Price", insertData.Material_Current_Price);
                        cmd.Parameters.AddWithValue("@P_material_previous_price", insertData.Material_Previous_Price);
                        cmd.Parameters.AddWithValue("@P_start_date", insertData.Start_Date);
                        cmd.Parameters.AddWithValue("@P_End_date", EndDate);
                        cmd.Parameters.AddWithValue("@P_note", insertData.Note);
                        cmd.Parameters.AddWithValue("@P_Category", insertData.Category);
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

                    string sql = @"SELECT material_price_code, company_name, product_name, product_unit, product_information, MATERIAL_CURRENT_PRICE_STRING, MATERIAL_PREVIOUS_PRICE_STRING, START_DATE, END_DATE, NOTE
	                                , CASE RANKS WHEN 1 THEN 'Y'  ELSE 'N' END AS ISREADONLY
	                                FROM
	                                (
	                                SELECT M.MATERIAL_PRICE_CODE, C.COMPANY_ID, C.COMPANY_NAME, P.PRODUCT_ID, P.PRODUCT_NAME, P.PRODUCT_UNIT, P.PRODUCT_INFORMATION, CONCAT(FORMAT(M.MATERIAL_CURRENT_PRICE,'#,0'),' 원') MATERIAL_CURRENT_PRICE_STRING, 
			                                CASE WHEN M.material_previous_price IS NULL
			                                THEN '-' 
			                                ELSE
			                                CONCAT(FORMAT(M.MATERIAL_PREVIOUS_PRICE,'#,0'),' 원') END  MATERIAL_PREVIOUS_PRICE_STRING , M.START_DATE, M.END_DATE END_DATE, M.NOTE
			                                , RANK() OVER (PARTITION BY C.COMPANY_ID, P.PRODUCT_ID ORDER BY MATERIAL_PRICE_CODE DESC) RANKS	
	                                FROM TBL_MATERIAL_PRICE_MANAGEMENT M INNER JOIN TBL_PRODUCT P ON M.PRODUCT_ID = P.PRODUCT_ID
	                                INNER JOIN TBL_COMPANY C ON C.company_id = M.COMPANY_ID
	                                ) TBL
                                      ORDER BY RANKS DESC  ";

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
