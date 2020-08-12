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
    public class ProcessDAC: SqlHelper
    {
        public DataTable GetAll()
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();

                string sql = @"SELECT c.corporation_name, f.[factory_name], l.line_name, [process_name], s.storage_name, [process_id], [process_note1], [process_note2], [process_seq], [process_use], p.[first_regist_time], p.[first_regist_employee], p.[final_regist_time], p.[final_regist_employee]
                                 from  [dbo].[TBL_PROCESS] p, [dbo].[TBL_LINE] l, [dbo].[TBL_FACTORY] f, [dbo].[TBL_CORPORATION] c, TBL_STORAGE s
                                where p.line_id = l.line_id
                                  and l.factory_id = f.factory_id
                                  and f.corporation_id = c.corporation_id
                                  and p.storage_id = s.storage_id  ";

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);

                return dt;
            }
        }

        public List<CorporationVO> CorporationCombo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select corporation_id, corporation_name
									   From TBL_CORPORATION
                                      WHERE  corporation_use = 'Y'
                                   Order by corporation_seq ASC";
                    
                    cmd.Connection.Open();
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
                    cmd.CommandText = @"Select F.corporation_id, factory_id, factory_name
                                          From TBL_FACTORY F
                                            INNER JOIN TBL_CORPORATION C
                                                ON F.corporation_id = C.corporation_id
                                         WHERE factory_use = 'Y'
                                           AND corporation_use = 'Y'
                                      Order by factory_seq ASC";

                    cmd.Connection.Open();

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
                    cmd.CommandText = @"Select L.factory_id, line_id, line_name
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

        public List<StorageVO> StorageCombo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Select S.factory_id, storage_id, storage_name
                                          From TBL_STORAGE S
                                         inner join TBL_FACTORY F on S.factory_id = F.factory_id
                                         inner join TBL_CORPORATION C ON  F.corporation_id = C.corporation_id
                                         WHERE storage_use = 'Y'
                                           AND storage_use = 'Y'
                                           AND corporation_use ='Y'
                                             Order by storage_seq ASC";

                    cmd.Connection.Open();

                    return SqlHelper.DataReaderMapToList<StorageVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataTable ProcessSearch(ProcessVO vo)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    string sql = @"SELECT c.corporation_name, f.[factory_name], l.line_name, [process_name], [process_id], [process_note1], [process_note2], [process_seq], [process_use], p.[first_regist_time], p.[first_regist_employee], p.[final_regist_time], p.[final_regist_employee]
                                     from  [dbo].[TBL_PROCESS] p, [dbo].[TBL_LINE] l, [dbo].[TBL_FACTORY] f, [dbo].[TBL_CORPORATION] c
                                    where p.line_id = l.line_id
                                      and l.factory_id = f.factory_id
                                      and f.corporation_id = c.corporation_id
                                      and (@corporation_id = 0 or  c.corporation_id = @corporation_id)
                                      and (@factory_id = 0 or f.factory_id = @factory_id)
                                      and (@line_id = 0 or p.line_id = @line_id)
                                    Order by process_seq asc;;";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@corporation_id", vo.corporation_id);
                        cmd.Parameters.AddWithValue("@factory_id", vo.factory_id);
                        cmd.Parameters.AddWithValue("@line_id", vo.line_id);

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

        public bool UseTypeChange(int process_id, string isTypeUse)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"UPDATE TBL_PROCESS SET process_use = @process_use WHERE process_id = @process_id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@process_use", isTypeUse);
                        cmd.Parameters.AddWithValue("@process_id", process_id);

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

        public bool ProcessDelete(List<int> process_idList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", process_idList);

                    string sql = "Delete From TBL_PROCESS where process_id in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

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
