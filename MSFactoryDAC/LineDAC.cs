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
    public class LineDAC : SqlHelper
    {
        public DataTable GetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT c.corporation_name, f.factory_name,[line_id], [line_note1], [line_note2], [line_name], [line_seq], [line_use], l.[first_regist_time], l.[first_regist_employee], l.[final_regist_time], l.[final_regist_employee] 
                                 from [dbo].[TBL_LINE] l, [dbo].[TBL_FACTORY] f, [dbo].[TBL_CORPORATION] c
                                where l.factory_id = f.factory_id
                                  and   f.corporation_id = c.corporation_id";

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

        public List<CorporationVO> CorporationCombo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT corporation_id, corporation_name
                                          FROM TBL_CORPORATION 
                                         WHERE corporation_use = 'Y'
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
        public List<FactoryVO> FactoryAllCombo()
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


        public List<FactoryVO> FactoryCombo(int corporation_id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Select factory_id, factory_name
                                          From TBL_FACTORY
                                         WHERE corporation_id =@corporation_id
                                           ANd factory_use = 'Y'
                                      Order by factory_seq ASC";

                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@corporation_id", corporation_id);
                    return SqlHelper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());
                }
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        public DataTable LineSearch(LineVO vo)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    string sql = @"select c.corporation_name, f.factory_name,[line_id], [line_note1], [line_note2], [line_name], [line_seq], [line_use], l.[first_regist_time], l.[first_regist_employee], l.[final_regist_time], l.[final_regist_employee] 
                                     From [dbo].[TBL_LINE] l, TBL_CORPORATION c, TBL_FACTORY f
                                    where l.factory_id = f.factory_id 
									  and c.corporation_id = f.corporation_id
                                      and (@corporation_id = 0 or  c.corporation_id = @corporation_id)
                                      and (@factory_id = 0 or f.factory_id = @factory_id)
                                    Order by line_seq asc;;"; 
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@corporation_id", vo.corporation_id);
                        cmd.Parameters.AddWithValue("@factory_id", vo.factory_id);

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

        public bool UseTypeChange(int line_id, string isTypeUse)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"UPDATE [dbo].[TBL_LINE] SET line_use = @line_use WHERE line_id = @line_id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@line_use", isTypeUse);
                        cmd.Parameters.AddWithValue("@line_id", line_id);

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

        public bool LineDelete(List<int> line_idList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", line_idList);

                    string sql = "Delete From TBL_LINE where line_id in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

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

        public bool SaveLine(LineVO vo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_LINE";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_line_id", vo.line_id);
                        cmd.Parameters.AddWithValue("@P_line_name", vo.line_name);
                        cmd.Parameters.AddWithValue("@P_factory_id", vo.factory_id);
                        cmd.Parameters.AddWithValue("@P_line_seq", vo.line_seq);
                        cmd.Parameters.AddWithValue("@P_line_use", vo.line_use);
                        cmd.Parameters.AddWithValue("@P_line_note1", vo.line_note1);
                        cmd.Parameters.AddWithValue("@P_line_note2", vo.line_note2);
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

        public DataTable GetLines(int factory_id)
        {
            try
            {
                string sql = @"SELECT F.FACTORY_ID, L.LINE_ID, L.LINE_NAME
                               FROM TBL_LINE L
	                               INNER JOIN TBL_FACTORY F
		                               ON L.FACTORY_ID = F.FACTORY_ID
	                               INNER JOIN TBL_CORPORATION C
		                               ON F.CORPORATION_ID = C.CORPORATION_ID
                               WHERE FACTORY_ID = @FACTORY_ID
                               AND LINE_USE = 'Y'
                               AND FACTORY_USE = 'Y'
                               AND CORPORATION_USE = 'Y'
                               ORDER BY LINE_SEQ ASC";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@FACTORY_ID", factory_id);

                da.Fill(dt);

                return dt;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
