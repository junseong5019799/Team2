using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSFactoryDAC
{
    public class BomDAC : ConnectionAccess
    {
        public List<BomVO> SelectMaterialSettings(string category1, string category2, int ProductID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT p.PRODUCT_ID, G.PRODUCT_GROUP_NAME, p.PRODUCT_NAME, p.PRODUCT_INFORMATION, p.PRODUCT_UNIT, p.PRODUCT_NOTE1, p.PRODUCT_NOTE2
                                   FROM TBL_PRODUCT P INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT G ON P.PRODUCT_GROUP_ID = G.PRODUCT_GROUP_ID
                                   WHERE G.PRODUCT_GROUP_NAME IN(@CATEGORY1, @CATEGORY2) AND PRODUCT_USE = 'Y' AND PRODUCT_ID <> @PRODUCTID";
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CATEGORY1", category1);
                        cmd.Parameters.AddWithValue("@CATEGORY2", category2);
                        cmd.Parameters.AddWithValue("@PRODUCTID", ProductID);

                        return SqlHelper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
                    }
                    
                }
            }
            catch(Exception err)
            {
                throw err;
            }
        }

       

        public DataTable BomDeployDGVBinding(bool IsBOMForward, int SelectedValue)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = string.Empty;
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    if (IsBOMForward)
                        sql = @"SP_BOM_FORWARD_SELECT";
                    else
                        sql = @"SP_BOM_REVERSE_SELECT";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_SELECTED_VALUE", SelectedValue);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool BomDelete(int deleteBomNum)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"DELETE FROM TBL_BOM WHERE HIGH_PRODUCT_ID = @PRODUCT_ID OR LOW_PRODUCT_ID = @PRODUCT_ID
                                   update tbl_product set bom_exists = 'N' where product_id = @PRODUCT_ID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PRODUCT_ID", deleteBomNum);

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

        public bool InsertUpdateProductByBomCopy(List<BOMInsertUpdateVO> insertBOMLists, string Product_Name)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                try
                {
                    string sql = "SP_BOM_INSERT_BY_BOM_COPY";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var voList in insertBOMLists)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@P_HIGHER_PRODUCT_NAME", Product_Name);
                            cmd.Parameters.AddWithValue("@P_LOWER_PRODUCTID", voList.Lower_Product_ID);
                            cmd.Parameters.AddWithValue("@P_QUANTITY", voList.Bom_Use_Quantity);
                            cmd.Parameters.AddWithValue("@P_FINAL_REGIST_TIME", voList.Final_Regist_Time);
                            cmd.Parameters.AddWithValue("@P_FINAL_REGIST_EMPLOYEE", voList.Final_Regist_Employee);
                            cmd.Parameters.AddWithValue("@P_BOM_ENROLL_STATUS", voList.Bom_Status);

                            int count = cmd.ExecuteNonQuery();


                            if (count == 0)
                                throw new Exception();
                        }
                        return true;
                    }
                }
                catch
                {
                    return false;
                    
                }
            }
        }

        public List<BomVO> BOMProductBinding(string ValueMember)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SP_BOM_PRODUCT_BINDING";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_VALUE_MEMBER", ValueMember);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        return SqlHelper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<BomVO> BomTypeBinding(bool IsBomForward)
        {
            try
            {
                string sql = string.Empty;
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    if(IsBomForward == true)
                    {
                        sql = @"Select sort_name Combo_Display_Member, sort_id Combo_Value_Member
                                    from tbl_common_group
                                    where sort_id in ('MPR',  'PRO')
                                    order by note asc";
                    }
                    else
                    {
                        sql = @"Select sort_name Combo_Display_Member, sort_id Combo_Value_Member
                                    from tbl_common_group
                                    where sort_id in ('MPR', 'MTR')
                                    order by note desc";
                    }
                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<BomVO> BOMDeployeeBinding()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"Select  G.sort_name Combo_Display_Member, G.sort_id Combo_Value_Member
                                    from tbl_common C INNER JOIN TBL_COMMON_GROUP G ON C.SORT_ID = G.SORT_ID
                                    where COMMON_ID BETWEEN 'BOMDEPLOYEESTATUS001' AND 'BOMDEPLOYEESTATUS002'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataTable SelectAllBomProducts(char IsBomStatusForward)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                try
                {
                    string sql = "SP_BOM_ALL_SELECT";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_DEPLOY_METHOD", IsBomStatusForward);

                        SqlDataAdapter data = new SqlDataAdapter(cmd);
                        data.Fill(dt);
                        return dt;
                    }
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }

        public List<BomVO> BOMEnrolledMaterial(int ProductID)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                try
                {
                    string sql = @"SELECT P.product_id, PRODUCT_NAME, G.PRODUCT_GROUP_NAME, PRODUCT_INFORMATION, B.BOM_USE_QUANTITY
                                    FROM TBL_BOM B INNER JOIN TBL_PRODUCT P ON B.low_product_id = P.product_id
                                                   INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT G ON P.PRODUCT_GROUP_ID = G.PRODUCT_GROUP_ID
                                    WHERE HIGH_PRODUCT_ID = @PRODUCTID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PRODUCTID", ProductID);
                        return SqlHelper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
                    }
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }
        public List<BomVO> BOMEnrolledMaterial(List<int> ProductIDs)
        {
            List<BomVO> returnList = new List<BomVO>();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                try
                {
                    string sql = @"SELECT P.product_id, PRODUCT_NAME, G.PRODUCT_GROUP_NAME, PRODUCT_INFORMATION, B.BOM_USE_QUANTITY
                                    FROM TBL_BOM B INNER JOIN TBL_PRODUCT P ON B.low_product_id = P.product_id
                                                   INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT G ON P.PRODUCT_GROUP_ID = G.PRODUCT_GROUP_ID
                                    WHERE HIGH_PRODUCT_ID = @PRODUCTID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        

                        foreach(int listCount in ProductIDs)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@PRODUCTID", listCount);

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);

                            for(int i = 0; i<dt.Rows.Count; i++)
                            {
                                if (returnList.FindAll(p => p.Product_ID == Convert.ToInt32(dt.Rows[i][0])).Count > 0)
                                    continue;

                                returnList.Add(new BomVO
                                {
                                    Product_ID = Convert.ToInt32(dt.Rows[i][0]),
                                    Product_Name = dt.Rows[i][1].ToString(),
                                    Product_Group_Name = dt.Rows[i][2].ToString(),
                                    Product_Information = dt.Rows[i][3].ToString(),
                                    Bom_Use_Quantity = Convert.ToInt32(dt.Rows[i][4])
                                });
                            }
                        }


                        return returnList;
                    }
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }

        public bool InsertProducts(List<BOMInsertUpdateVO> lists)
        {
            
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                try
                {
                    string sql = "SP_BOM_INSERT_UPDATE";
                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        int numCount = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        foreach (var voList in lists)
                        { 
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@P_HIGHER_PRODUCTID", voList.Higher_Product_ID);
                            cmd.Parameters.AddWithValue("@P_LOWER_PRODUCTID", voList.Lower_Product_ID);
                            cmd.Parameters.AddWithValue("@P_QUANTITY", voList.Bom_Use_Quantity);
                            cmd.Parameters.AddWithValue("@P_FINAL_REGIST_TIME", voList.Final_Regist_Time);
                            cmd.Parameters.AddWithValue("@P_FINAL_REGIST_EMPLOYEE", voList.Final_Regist_Employee);
                            cmd.Parameters.AddWithValue("@P_BOM_ENROLL_STATUS", voList.Bom_Status);
                            cmd.Parameters.AddWithValue("@P_DATA_COUNT", numCount);

                            int count = cmd.ExecuteNonQuery();

                            numCount++;

                            if(count==0)
                                throw new Exception();
                        }

                        return true;
                    }
                }
                catch
                {
                    return true;
                }
            }
            
        }

        
    }
}
