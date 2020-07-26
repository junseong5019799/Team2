using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSFactoryDAC
{
    public class BomLogDAC : ConnectionAccess
    {
        public List<BomLogVO> SelectAllLogs(int CorporationID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open(); 
                
                    string sql = @"SP_BOM_LOG_SELECT";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_CORPORATION_ID", CorporationID);

                        return SqlHelper.DataReaderMapToList<BomLogVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void InsertLogs(BomLogVO AddLogs)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SP_BOM_LOG_INSERT";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_HIGH_PRODUCT_ID", AddLogs.High_Product_ID);
                        cmd.Parameters.AddWithValue("@P_BOM_ENROLL_DATE", AddLogs.Bom_Enroll_Date);
                        cmd.Parameters.AddWithValue("@P_EMPLOYEE_ID", AddLogs.Employee_ID);
                        cmd.Parameters.AddWithValue("@P_BOM_USE", AddLogs.Bom_Use);
                        cmd.Parameters.AddWithValue("@P_BOM_LOG_STATUS_CODE", AddLogs.Bom_Log_Status);
                        cmd.Parameters.AddWithValue("@P_BOM_EXISTS", AddLogs.Bom_Exists);

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
