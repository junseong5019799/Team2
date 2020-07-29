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

        public List<BomVO> BOMTypeBinding(bool IsBomForward)
        {
            string SelectCode = string.Empty;

            if (IsBomForward == true)
                SelectCode = "PRO,MPR";

            else
                SelectCode = "MPR,MTR";

            string[] sp_SelectCode = SelectCode.Split(',');
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"Select  sort_name Combo_Display_Member, sort_id Combo_Value_Member
                                    from tbl_common_group
                                    where sort_id = @CODE1 or sort_id = @CODE2";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CODE1", sp_SelectCode[0]);
                        cmd.Parameters.AddWithValue("@CODE2", sp_SelectCode[1]);

                        return SqlHelper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<BomVO> BomDeployDGVBinding(int SelectedValue)
        {
            try
            {
                string sql = string.Empty;
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    sql = @"SP_BOM_SELECT";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_SELECTED_VALUE", SelectedValue);
                        return SqlHelper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<BomVO> BOMProductBinding(int productGroupNum)
        {
            try
            {
                string sql = string.Empty;
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    
                    if(productGroupNum == 0)
                        sql = @"SELECT PRODUCT_NAME, PRODUCT_ID FROM TBL_PRODUCT WHERE PRODUCT_GROUP_ID <> 1 AND PRODUCT_GROUP_ID <> 2";
                    else
                        sql = @"SELECT PRODUCT_NAME, PRODUCT_ID FROM TBL_PRODUCT WHERE PRODUCT_GROUP_ID = @GROUP_ID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@GROUP_ID", productGroupNum);
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
