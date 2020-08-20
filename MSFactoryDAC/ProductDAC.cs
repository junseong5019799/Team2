using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
        public string SelectProductName(int codeNum)
        {
            try
            {
                string ProductName = string.Empty;
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SELECT PRODUCT_NAME FROM TBL_PRODUCT WHERE PRODUCT_ID = @PRODUCT_ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PRODUCT_ID", codeNum);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            ProductName = reader[0].ToString();
                        }
                    }

                    return ProductName;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<SellPriceManageVO> SelectAllPriceProducts()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT P.product_id, product_name, G.PRODUCT_GROUP_NAME, product_information, product_unit, CONCAT(FORMAT(sell_current_price,'#,0'),' 원') SELL_CURRENT_PRICE_STRING, start_date,end_date, note,sellprice_code
		                            , Convert(int, RANK() OVER(PARTITION BY M.PRODUCT_GROUP_ID, M.PRODUCT_ID ORDER BY SELLPRICE_CODE ASC)) RANKNUM,
									CASE WHEN SELL_PREVIOUS_PRICE IS NULL
									THEN '-'
									ELSE
									CONCAT(FORMAT(sell_previous_price,'#,0'),' 원')END SELL_PREVIOUS_PRICE_STRING, sell_previous_price
		                            FROM TBL_SELLPRICE_MANAGEMENT M INNER JOIN TBL_PRODUCT P ON M.product_id = P.product_id
									INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT G ON P.product_group_id = G.product_group_id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<SellPriceManageVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool IsBomExists(int productIDNum)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"Select count(*) from tbl_Bom where high_product_id = @product_id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@product_id", productIDNum);

                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
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

        public List<ProductPriceManageVO> DateSettings(int material_Price_Code)
        {
            //item.Product_Name == ManageVO.Product_Name && item.Company_Name == ManageVO.Company_Name
            //                    && item.RankNum < ManageVO.RankNum

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = @"SELECT PRODUCT_NAME, COMPANY_NAME, CONVERT(INT,RANK() OVER (PARTITION BY COMPANY_NAME, PRODUCT_NAME ORDER BY M.MATERIAL_PRICE_CODE)) RANKNUM, START_DATE
                                        FROM TBL_MATERIAL_PRICE_MANAGEMENT
                                        WHERE MATERIAL_PRICE_CODE = @MATERIAL_PRICE_CODE";

                    cmd.Parameters.AddWithValue("@MATERIAL_PRICE_CODE", material_Price_Code);

                    return SqlHelper.DataReaderMapToList<ProductPriceManageVO>(cmd.ExecuteReader());

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool IsUpperData(int companyID, int productID, ref int PreviousPrice, ref DateTime? PreviousTime )
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = @"SP_MATERIAL_PRICE_PREVIOUS_DATA_SELECT";

                    cmd.Parameters.AddWithValue("@P_COMPANY_ID", companyID);
                    cmd.Parameters.AddWithValue("@P_PRODUCT_ID", productID);

                    SqlParameter param = new SqlParameter("@P_PREVIOUS_PRICE", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    SqlParameter param2 = new SqlParameter("@P_PREVIOUS_DATE", SqlDbType.DateTime);
                    param2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param2);

                    cmd.ExecuteNonQuery();

                    if (param.Value != DBNull.Value)
                    {
                        PreviousPrice = Convert.ToInt32(param.Value);
                        PreviousTime = Convert.ToDateTime(param2.Value);
                        return true;
                    }


                    else
                    {
                        PreviousPrice = 0;
                        PreviousTime = null;
                        return false;
                    }


                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool DeleteSellPrice(int selectedRow)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();

                // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                string sql = @"SP_SELL_PRICE_DELETE";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_SELL_PRICE_CODE", selectedRow);

                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }

            }
        }

        public bool InsertMaterialPrice(ProductPriceManageVO insertData)
        {
            throw new NotImplementedException();
        }

        public bool UpsertSellPrice(SellPriceManageVO vo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = "SP_SELLPRICE_UPSERT";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@sell_price_code", vo.Sellprice_Code);
                        cmd.Parameters.AddWithValue("@product_group_id", vo.Product_Group_ID);
                        cmd.Parameters.AddWithValue("@product_id", vo.Product_ID);
                        cmd.Parameters.AddWithValue("@sell_current_price", vo.Sell_Current_Price);
                        cmd.Parameters.AddWithValue("@sell_previous_price", vo.Sell_Previous_Price);
                        cmd.Parameters.AddWithValue("@sell_start_date", vo.Start_Date);
                        cmd.Parameters.AddWithValue("@note", vo.Note);

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

        public bool DeleteMaterialPrice(int selectedRow)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SP_MATERIAL_PRICE_DELETE";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_MATERIAL_PRICE_CODE", selectedRow);

                        if (cmd.ExecuteNonQuery() > 0)
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

        public bool UpdateProducts(ProductInsertVO vo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"UPDATE TBL_PRODUCT SET [product_lead_time] = @LEAD_TIME, [product_tact_time] = @TACT_TIME, [product_group_id] = @GROUP_ID, [product_name] = @PRODUCT_NAME, 
                                [product_information] = @INFORMATION, [product_unit] = @UNIT, [product_standards] = @STANDARD, [product_note1] = @NOTE1, [product_note2] = @NOTE2, 
                                [product_seq] = @SEQ, [product_use] = @USE,  [final_regist_time] = @REGIST_TIME, [final_regist_employee] = @REGIST_EMPLOYEE
                                WHERE PRODUCT_ID = @PRODUCT_ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@LEAD_TIME", vo.Product_Lead_Time);
                        cmd.Parameters.AddWithValue("@Tact_time", vo.Product_Tact_Time);
                        cmd.Parameters.AddWithValue("@group_id", vo.Product_Group_ID);
                        cmd.Parameters.AddWithValue("@Product_Name", vo.Product_Name);
                        cmd.Parameters.AddWithValue("@Information", vo.Product_Information);
                        cmd.Parameters.AddWithValue("@Unit", vo.Product_Unit);
                        cmd.Parameters.AddWithValue("@standard", vo.Product_Standards);
                        cmd.Parameters.AddWithValue("@note1", vo.Product_Note1);
                        cmd.Parameters.AddWithValue("@note2", vo.Product_Note2);
                        cmd.Parameters.AddWithValue("@seq", vo.Product_Seq);
                        cmd.Parameters.AddWithValue("@use", vo.Product_Use);
                        cmd.Parameters.AddWithValue("@regist_time", vo.Final_Regist_Time);
                        cmd.Parameters.AddWithValue("@regist_employee", vo.Final_Regist_Employee);
                        cmd.Parameters.AddWithValue("@product_id", vo.Product_ID);

                        if (cmd.ExecuteNonQuery() > 0)
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

        public DataTable SelectAllProductsToTable()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것

                    string sql = @"SELECT PRODUCT_NAME, CONCAT((REPLICATE('0',4-LEN(CAST (PRODUCT_ID AS VARCHAR(5)))) + CAST(PRODUCT_ID AS VARCHAR(5))),bom_exists) PRODUCT_ID
                                    FROM  TBL_PRODUCT ORDER BY PRODUCT_SEQ ASC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter data = new SqlDataAdapter(cmd);
                        data.Fill(dt);

                        return dt;
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




        public bool UpsertMaterialPrice(ProductPriceManageVO UpsertData)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    // 로그인이 완성되면 회사 정보를 WHERE에 반드시 추가할 것
                    object EndDate;
                    string sql = @"SP_MATERIAL_PRICE_UPSERT";


                    if ((object)UpsertData.End_Date == null)
                        EndDate = DBNull.Value;

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_Material_Price_Code", UpsertData.Material_Price_Code);
                        cmd.Parameters.AddWithValue("@P_COMPANY_ID", UpsertData.Company_ID);
                        cmd.Parameters.AddWithValue("@P_Product_ID", UpsertData.Product_ID);
                        cmd.Parameters.AddWithValue("@P_Material_Current_Price", UpsertData.Material_Current_Price);
                        cmd.Parameters.AddWithValue("@P_material_previous_price", UpsertData.Material_Previous_Price);
                        cmd.Parameters.AddWithValue("@P_start_date", UpsertData.Start_Date);
                        //cmd.Parameters.AddWithValue("@P_end_date", UpsertData.End_Date);
                        cmd.Parameters.AddWithValue("@P_note", UpsertData.Note);
                        cmd.Parameters.AddWithValue("@P_CATEGORY", UpsertData.Category);

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

                    string sql = @"SELECT M.MATERIAL_PRICE_CODE, C.COMPANY_ID, C.COMPANY_NAME, P.PRODUCT_ID, P.PRODUCT_NAME, P.PRODUCT_UNIT, P.PRODUCT_INFORMATION, CONCAT(FORMAT(M.MATERIAL_CURRENT_PRICE,'#,0'),' 원') MATERIAL_CURRENT_PRICE_STRING, 
                                    CONVERT(INT,RANK() OVER (PARTITION BY COMPANY_NAME, PRODUCT_NAME ORDER BY M.MATERIAL_PRICE_CODE)) RANKNUM									,
									CASE WHEN M.material_previous_price IS NULL
									THEN '-' 
                                    ELSE
									CONCAT(FORMAT(M.MATERIAL_PREVIOUS_PRICE,'#,0'),' 원')END  MATERIAL_PREVIOUS_PRICE_STRING , M.START_DATE, M.END_DATE END_DATE, M.NOTE
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

                        cmd.Parameters.AddWithValue("@P_PRODUCT_ID", InsertData.Product_ID);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_GROUP_ID", InsertData.Product_Group_ID);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_NAME", InsertData.Product_Name);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_INFOMATION", InsertData.Product_Information);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_UNIT", InsertData.Product_Unit);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_STANDARD", InsertData.Product_Standards);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_NOTE1", InsertData.Product_Note1);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_NOTE2", InsertData.Product_Note2);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_USE", InsertData.Product_Use);
                        cmd.Parameters.AddWithValue("@P_FINAL_REGIST_TIME", InsertData.Final_Regist_Time);
                        cmd.Parameters.AddWithValue("@P_FINAL_REGIST_EMPLOYEE", InsertData.Final_Regist_Employee);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_TACT_TIME", InsertData.Product_Tact_Time);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_LEAD_TIME", InsertData.Product_Lead_Time);
                        cmd.Parameters.AddWithValue("@P_IS_BOM_COPY", IsBomCopy);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_SEQ", InsertData.Product_Seq);

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

        public DataTable GetProducts()
        {
            try
            {
                string sql = @"SELECT PRODUCT_ID, PRODUCT_LEAD_TIME, PRODUCT_TACT_TIME, PRODUCT_GROUP_ID, PRODUCT_NAME, PRODUCT_INFORMATION
		                            , PRODUCT_UNIT, PRODUCT_STANDARDS, PRODUCT_NOTE1, PRODUCT_NOTE2, PRODUCT_SEQ, PRODUCT_USE
                               FROM TBL_PRODUCT
                               WHERE PRODUCT_USE = 'Y'
                               AND PRODUCT_GROUP_ID NOT IN (2)
                               ORDER BY PRODUCT_SEQ";
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
