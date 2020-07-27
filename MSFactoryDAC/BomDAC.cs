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
        public List<BomVO> SelectMaterialSettings(string category1, string category2)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT p.PRODUCT_ID, G.PRODUCT_GROUP_NAME, p.PRODUCT_NAME, p.PRODUCT_INFORMATION, p.PRODUCT_UNIT, p.PRODUCT_NOTE1, p.PRODUCT_NOTE2
                                   FROM TBL_PRODUCT P INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT G ON P.PRODUCT_GROUP_ID = G.PRODUCT_GROUP_ID
                                   WHERE G.PRODUCT_GROUP_NAME IN(@CATEGORY1, @CATEGORY2) AND PRODUCT_USE = 'Y'";
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CATEGORY1", category1);
                        cmd.Parameters.AddWithValue("@CATEGORY2", category2);

                        return SqlHelper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
                    }
                    
                }
            }
            catch(Exception err)
            {
                throw err;
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
                catch (Exception err)
                {
                    return false;
                    throw err;
                }
            }
            
        }

        
    }
}
