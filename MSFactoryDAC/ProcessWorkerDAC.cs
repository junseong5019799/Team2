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
    public class ProcessWorkerDAC : SqlHelper
    {
        public DataTable ProseccWorkerGetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT c.corporation_name, f.factory_name, l.line_name, p.process_name , worker_id, e.employee_name, w.first_regist_time, w.first_regist_employee, w.final_regist_time, w.final_regist_employee
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
            catch (Exception err)
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
                                            INNER JOIN TBL_CORPORATION C ON F.corporation_id = C.corporation_id
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

        public List<FactoryVO> FactoryCombo(int corporation_id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Select factory_id, factory_name
                                          From TBL_FACTORY F
                                    inner join TBL_CORPORATION C ON F.corporation_id = C.corporation_id
                                         WHERE C.corporation_id =@corporation_id
                                           ANd factory_use = 'Y'
                                           AND corporation_use ='Y'
                                      Order by factory_seq ASC";

                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@corporation_id", corporation_id);
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

        public List<LineVO> LineCombo(int factory_id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    cmd.CommandText = @"Select L.factory_id, L.line_id, line_name
                                          From TBL_LINE L
                                         inner join TBL_FACTORY F ON L.factory_id = F.factory_id
                                         inner join TBL_CORPORATION C ON F.corporation_id = C.corporation_id
                                         WHERE F.factory_id = @factory_id
                                           AND line_use = 'Y'
                                           AND factory_use = 'Y'
                                           AND corporation_use ='Y'
                                             Order by line_seq ASC";
                    cmd.Parameters.AddWithValue("@factory_id", factory_id);


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

        public List<ProcessVO> ProcessCombo(int line_id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    cmd.CommandText = @" Select p.line_id, p.process_id, p.process_name
                                               From TBL_PROCESS p
                                               inner join TBL_LINE l ON p.line_id = l.line_id
                                               inner join TBL_FACTORY F ON L.factory_id = F.factory_id
                                               inner join TBL_CORPORATION C ON F.corporation_id = C.corporation_id
                                               WHERE l.line_id = @line_id
                                                 AND process_use = 'Y'
  	                                             AND line_use = 'Y'
                                                 AND factory_use = 'Y'
                                                 AND corporation_use ='Y'
                                            Order by process_seq ASC";
                    cmd.Parameters.AddWithValue("@line_id", line_id);

                    return SqlHelper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<EmployeeVO> EmployeeCombo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    cmd.CommandText = @"SELECT e.corporation_id, [employee_id], [employee_name]
                                          FROM [dbo].[TBL_EMPLOYEE] e
                                          inner join TBL_CORPORATION c on e.corporation_id = c.corporation_id
                                          WHERE employee_use = 'Y'
                                          AND corporation_use ='Y'";

                    return SqlHelper.DataReaderMapToList<EmployeeVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<EmployeeVO> EmployeeCombo(int corporation_id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    cmd.CommandText = @"SELECT [employee_id], [employee_name]
                                          FROM [dbo].[TBL_EMPLOYEE] e
                                          inner join TBL_CORPORATION c on e.corporation_id = c.corporation_id
                                          where c.corporation_id = @corporation_id
                                          AND employee_use = 'Y'
                                          AND corporation_use ='Y'";

                    cmd.Parameters.AddWithValue("@corporation_id", corporation_id);
                    return SqlHelper.DataReaderMapToList<EmployeeVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool ProcessWorker(ProcessWorkerVO vo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_PROCESSWORKER";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_worker_id", vo.worker_id);
                        cmd.Parameters.AddWithValue("@P_process_id", vo.process_id);
                        cmd.Parameters.AddWithValue("@P_employee_id", vo.employee_id);
                        cmd.Parameters.AddWithValue("@P_first_regist_employee", vo.first_regist_employee);
                        cmd.Parameters.AddWithValue("@P_final_regist_employee", vo.final_regist_employee);

                        cmd.ExecuteNonQuery();
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

        public bool ProcessWorkerDelete(List<int> worker_idList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", worker_idList);

                    string sql = "Delete From TBL_PROCESS_WORKER where worker_id in (" + selNum + ") ;";

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
        public DataTable ProcessWorkerSearch(ProcessWorkerVO vo)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    string sql = @"SELECT c.corporation_name, f.[factory_name], l.line_name, p.[process_name], e.employee_name, pw.[first_regist_time], pw.[first_regist_employee], pw.[final_regist_time], pw.[final_regist_employee]
                                     from  TBL_PROCESS_WORKER pw, [dbo].[TBL_PROCESS] p, [dbo].[TBL_LINE] l, [dbo].[TBL_FACTORY] f, [dbo].[TBL_CORPORATION] c, TBL_EMPLOYEE e
                                    where pw.process_id = p.process_id
								      AND p.line_id = l.line_id
                                      and l.factory_id = f.factory_id
                                      and f.corporation_id = c.corporation_id
									  and pw.employee_id = e.employee_id
                                      and (@corporation_id = 0 or  c.corporation_id = @corporation_id)
                                      and (@factory_id = 0 or f.factory_id = @factory_id)
                                      and (@line_id = 0 or l.line_id = @line_id)
									  and (@process_id = 0 or p.process_id =@process_id)
									  and (@employee_id is null or e.employee_id = @employee_id)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@corporation_id", vo.corporation_id);
                        cmd.Parameters.AddWithValue("@factory_id", vo.factory_id);
                        cmd.Parameters.AddWithValue("@line_id", vo.line_id);
                        cmd.Parameters.AddWithValue("@process_id", vo.process_id);
                        if (vo.employee_id.Length < 1)
                            cmd.Parameters.AddWithValue("@employee_id", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@employee_id", vo.employee_id);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        cmd.Connection.Open();
                        da.Fill(dt);
                        cmd.Connection.Close();

                    }

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

