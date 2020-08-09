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

        public List<CorporationVO> LineComboGet()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select corporation_id, corporation_name
									   From TBL_CORPORATION";
                    //Select c.corporation_id, corporation_name
                    //                      From TBL_CORPORATION c
                    //                inner join TBL_FACTORY f on c.corporation_id = f.corporation_id
                    //                inner join TBL_LINE l on f.factory_id = l.factory_id

                    //                where c.corporation_id = f.corporation_id
                    //                   group by c.corporation_id, corporation_name;

                    cmd.Connection.Open();
                    return SqlHelper.DataReaderMapToList<CorporationVO>(cmd.ExecuteReader());

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<FactoryVO> LineCombo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Select factory_id, factory_name
                                          From TBL_FACTORY";

                    //Select l.factory_id, factory_name
                    //                      From TBL_CORPORATION c
                    //                inner join TBL_FACTORY f on c.corporation_id = f.corporation_id
                    //                inner join TBL_LINE l on f.factory_id = l.factory_id
                    //                    group by l.factory_id, factory_name
                    cmd.Connection.Open();

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
    }
}
