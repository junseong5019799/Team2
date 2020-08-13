using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryDAC
{
    public class ProcessWorkerDAC:SqlHelper
    {
        public DataTable ProseccGetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT c.corporation_name, f.factory_name, l.line_name, c.corporation_name
                                    FROM [dbo].[TBL_PROCESS_WORKER] w, [dbo].[TBL_PROCESS] p, [dbo].[TBL_LINE] l, [TBL_FACTORY] f, [dbo].[TBL_CORPORATION] c
                                    where w.process_id =p.process_id
                                    and p.line_id = l.line_id
                                    and l.factory_id = f.factory_id
                                    and f.corporation_id = c.corporation_id";

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

        public DataTable EmployeeWorkerGetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT [worker_id], employee_name
                                    FROM [dbo].[TBL_PROCESS_WORKER] w, [dbo].[TBL_EMPLOYEE] e
                                   WHERE w.employee_id = e.employee_id";

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
    }
}
