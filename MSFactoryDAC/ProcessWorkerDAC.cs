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
    public class ProcessWorkerDAC:SqlHelper
    {
        public DataTable ProseccWorkerGetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT c.corporation_name, f.factory_name, l.line_name, c.corporation_name , worker_id, e.employee_name, w.first_regist_time, w.first_regist_employee, w.final_regist_time, w.final_regist_employee
                                     FROM [dbo].[TBL_PROCESS_WORKER] w, [dbo].[TBL_PROCESS] p, [dbo].[TBL_LINE] l, [TBL_FACTORY] f, [dbo].[TBL_CORPORATION] c, TBL_EMPLOYEE e
                                    where w.process_id =p.process_id
                                      and p.line_id = l.line_id
                                      and l.factory_id = f.factory_id
                                      and f.corporation_id = c.corporation_id
                                      and w.employee_id = e.employee_id";

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

        public List<CorporationVO> CorporationCombm()
        {
            try
            {
                  using (SqlCommand cmd = new SqlCommand())
                  {
                      cmd.Connection = new SqlConnection(this.ConnectionString);
                      cmd.Connection.Open();
                      cmd.CommandText = @"SELECT corporation_id, corporation_name
                                            FROM TBL_CORPORATION
                                            where corporation_use ='Y'
                                            order by corporation_seq ASC;";

                      return SqlHelper.DataReaderMapToList<CorporationVO>(cmd.ExecuteReader());
                      
                  }

            }
            catch(Exception err)
            {
                throw err;
            }
        }

        public List<FactoryVO> FactoryCombo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    cmd.CommandText = @"Select F.corporation_id, F.factory_id, factory_name
                                          From TBL_FACTORY F
                                            INNER JOIN TBL_CORPORATION C
                                                ON F.corporation_id = C.corporation_id
                                         WHERE factory_use = 'Y'
                                           AND corporation_use = 'Y'
                                      Order by factory_seq ASC";

                    return SqlHelper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<LineVO> LineCombo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Select L.factory_id, L.line_id, line_name
                                          From TBL_LINE L
                                         inner join TBL_FACTORY F ON L.factory_id = F.factory_id
                                         inner join TBL_CORPORATION C ON F.corporation_id = C.corporation_id
                                         WHERE line_use = 'Y'
                                           AND factory_use = 'Y'
                                           AND corporation_use ='Y'
                                             Order by line_seq ASC";

                    cmd.Connection.Open();

                    return SqlHelper.DataReaderMapToList<LineVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<ProcessVO> ProcessCombo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @" Select p.line_id, p.process_id, p.process_name
                                               From TBL_PROCESS p
                                               inner join TBL_LINE l ON p.line_id = l.line_id
                                               inner join TBL_FACTORY F ON L.factory_id = F.factory_id
                                               inner join TBL_CORPORATION C ON F.corporation_id = C.corporation_id
                                               WHERE process_use = 'Y'
  	                                             AND line_use = 'Y'
                                                 AND factory_use = 'Y'
                                                 AND corporation_use ='Y'
                                            Order by process_seq ASC";
                    cmd.Connection.Open();

                    return SqlHelper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


    }
}
