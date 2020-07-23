using MSFactoryVO;
using System;
using System.Collections.Generic;
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

        public List<GroupComboVO> SelectAllGroup()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT PRODUCT_GROUP_ID, PRODUCT_GROUP_NAME FROM TBL_PRODUCT_GROUP_MANAGEMENT WHERE PRODUCT_GROUP_USE='Y'" ;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<GroupComboVO>(cmd.ExecuteReader());
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
