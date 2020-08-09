using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryDAC
{
    public class DowntimeTypeDAC:SqlHelper
    {
        public DataTable GetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"select [downtime_type_id], [downtime_type_name], [downtime_type_calculation], [downtime_type_seq], [downtime_type_use], [first_regist_time], [first_regist_employee], [final_regist_time], [final_regist_employee]
                                     from [dbo].[TBL_DOWNTIME_TYPE]
                                 Order by downtime_type_seq";

                    DataTable dt = new DataTable();
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

        public bool UseTypeChange(int downtime_type_id, string isTypeUse = null, string isTimeuse = null)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();

                    if (isTimeuse == null)
                    {
                        cmd.CommandText = @"UPDATE TBL_DOWNTIME_TYPE 
                                        SET downtime_type_use = @downtime_type_use
                                    WHERE downtime_type_id = @downtime_type_id";
                            cmd.Parameters.AddWithValue("@downtime_type_use", isTypeUse);
                    }
                    else if(isTypeUse == null)
                    {
                        cmd.CommandText = @"UPDATE TBL_DOWNTIME_TYPE 
                                        SET downtime_type_calculation  = @downtime_type_calculation
                                    WHERE downtime_type_id = @downtime_type_id";
                        cmd.Parameters.AddWithValue("@downtime_type_calculation", isTimeuse);
                    }

                    cmd.Parameters.AddWithValue("@downtime_type_id", downtime_type_id);

                    if (cmd.ExecuteNonQuery() > 0)
                        return true;

                    else
                        return false;
                }
                
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool SaveDowntimeType(DowntimeTypeVO vo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_DOWNTIMETYPE";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_downtime_type_id", vo.downtime_type_id);
                        cmd.Parameters.AddWithValue("@P_downtime_type_name", vo.downtime_type_name);
                        cmd.Parameters.AddWithValue("@P_downtime_type_calculation", vo.downtime_type_calculation);
                        cmd.Parameters.AddWithValue("@P_downtime_type_seq", vo.downtime_type_seq);
                        cmd.Parameters.AddWithValue("@P_downtime_type_use", vo.downtime_type_use);
                        cmd.Parameters.AddWithValue("@P_first_regist_employee", vo.first_regist_employee);
                        cmd.Parameters.AddWithValue("@P_final_regist_employee", vo.final_regist_employee);
                       
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool DowntimeTypeDelete(List<int> DowntimeType_idList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", DowntimeType_idList);

                    string sql = "Delete From TBL_DOWNTIME_TYPE where downtime_type_id in (" + selNum + ") ;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return cmd.ExecuteNonQuery() > 0;
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
