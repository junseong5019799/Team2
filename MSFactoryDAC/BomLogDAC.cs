using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

namespace MSFactoryDAC
{
    public class BomLogDAC : ConnectionAccess
    {
        public List<BomLogVO> SelectAllLogs()
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

                        return SqlHelper.DataReaderMapToList<BomLogVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void ChangeBomStatus(int Product_id, char bom_Exists)
        {
            try
            {
                string sql;

                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string Product_Name = string.Empty;

                    if(bom_Exists == 'Y')
                    {
                        sql = @"select product_name from tbl_product where product_id = @product_ID";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@product_ID", Product_id);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                                Product_Name = reader[0].ToString();

                            reader.Close();
                        }
                    }
                    


                    sql = @"select COUNT(*) FROM TBL_BOM_PRODUCT_STATUS WHERE PRODUCT_ID = @P_HIGH_PRODUCT_ID";


                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@P_HIGH_PRODUCT_ID", Product_id);
                        if( Convert.ToInt32(cmd.ExecuteScalar())==0)
                        {
                            if(bom_Exists == 'Y')
                            {
                                cmd.CommandText = @"INSERT INTO TBL_BOM_PRODUCT_STATUS([product_id], product_Name, [IsBomExists])
                                                    VALUES(@P_HIGH_PRODUCT_ID, @product_Name,'Y')";

                                cmd.Parameters.AddWithValue("@product_Name", Product_Name);
                                cmd.ExecuteNonQuery();

                                return;
                            }
                        }
                        else
                        {
                            if (bom_Exists == 'N')
                            {
                                cmd.CommandText = @"UPDATE TBL_BOM_PRODUCT_STATUS SET IsBomExists = 'N'
		                                            WHERE PRODUCT_ID = @P_HIGH_PRODUCT_ID";
                                cmd.ExecuteNonQuery();
                                return;
                            }
                        }


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
                
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = new SqlConnection(ConnectionString);
                    cmd.Connection.Open();

                    if (AddLogs.High_Product_ID == 0) // BOM 복사를 진행하는 경우 HighProductID가 0이 됨
                    {
                        cmd.CommandText = @"SELECT PRODUCT_ID FROM TBL_PRODUCT WHERE PRODUCT_NAME = @PRODUCT_NAME";
                        cmd.Parameters.AddWithValue("@PRODUCT_NAME", AddLogs.Product_Name);

                        AddLogs.High_Product_ID = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.Clear();
                    }


                    cmd.CommandText = @"SP_BOM_LOG_INSERT";


                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@P_HIGH_PRODUCT_ID", AddLogs.High_Product_ID);
                    cmd.Parameters.AddWithValue("@P_BOM_ENROLL_DATE", AddLogs.Bom_Enroll_Date);
                    cmd.Parameters.AddWithValue("@P_EMPLOYEE_ID", AddLogs.Employee_ID);
                    cmd.Parameters.AddWithValue("@P_BOM_LOG_STATUS_CODE", AddLogs.Bom_Log_Status);
                    cmd.Parameters.AddWithValue("@P_BOM_EXISTS", AddLogs.Bom_Exists);
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
