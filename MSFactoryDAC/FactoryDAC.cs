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
    public class FactoryDAC:SqlHelper
    {
        public DataTable SelectFactory()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"select c.corporation_name, factory_id,factory_name, factory_note1, factory_note2, factory_seq, factory_use, f.first_regist_time, f.first_regist_employee, f.final_regist_time, f.final_regist_employee
                                     From TBL_CORPORATION c, TBL_FACTORY f
                                    where c.corporation_id = f.corporation_id
                                 Order by factory_seq asc;";

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(dt);

                    return dt;
                }
          
            }
            catch(Exception err) 
            {
                throw err;
            }
        }

        public List<FactoryVO> CompanyComboBindings(int Corporation_ID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string addString = string.Empty;
                    if(Corporation_ID != 0)
                    {
                        addString = " and P.CORPORATION_ID = " + Corporation_ID.ToString();
                    }
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select factory_name, factory_id 
                                        from tbl_factory F INNER JOIN TBL_CORPORATION P ON F.CORPORATION_ID = P.CORPORATION_ID 
                                        where 1 = 1 "
                                        + addString + 
                                        " and factory_use='Y'";

                    cmd.Connection.Open();

                    
                    return SqlHelper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<CorporationVO> ComboGet()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Select corporation_id, corporation_name
                                          From TBL_CORPORATION";

                    //Select c.corporation_id, corporation_name
                    //                      From TBL_CORPORATION c
                    //                inner join TBL_FACTORY f on c.corporation_id = f.corporation_id
                    //                    group by c.corporation_id, corporation_name
                    cmd.Connection.Open();
                    return SqlHelper.DataReaderMapToList<CorporationVO>(cmd.ExecuteReader());

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataTable SearchName(FactoryVO vo)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    string sql = @"select c.corporation_name, factory_id,factory_name, factory_note1, factory_note2, factory_seq, factory_use, f.first_regist_time, f.first_regist_employee, f.final_regist_time, f.final_regist_employee
                                     From TBL_CORPORATION c, TBL_FACTORY f
                                    where c.corporation_id = f.corporation_id
                                      and (@corporation_id = 0 or  c.corporation_id = @corporation_id)
                                    Order by factory_seq asc;"; // and (@factory_name = '' or  f.factory_name = @factory_name)
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@corporation_id", vo.corporation_id);
                        //cmd.Parameters.AddWithValue("@factory_name", vo.factory_name);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        cmd.Connection.Open();
                        da.Fill(dt);
                        cmd.Connection.Close();

                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

            return dt;
        }

        public bool UseTypeChange(int factory_id, string isTypeUse)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"UPDATE TBL_FACTORY SET factory_use = @factory_use WHERE factory_id = @factory_id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@factory_use", isTypeUse);
                        cmd.Parameters.AddWithValue("@factory_id", factory_id);

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

        public bool SaveFactory(FactoryVO vo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_FACTORY";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_factory_id", vo.factory_id);
                        cmd.Parameters.AddWithValue("@P_factory_name", vo.factory_name);
                        cmd.Parameters.AddWithValue("@P_corporation_id", vo.corporation_id);
                        cmd.Parameters.AddWithValue("@P_factory_seq", vo.factory_seq);
                        cmd.Parameters.AddWithValue("@P_factory_use", vo.factory_use);
                        cmd.Parameters.AddWithValue("@P_factory_note1", vo.factory_note1);
                        cmd.Parameters.AddWithValue("@P_factory_note2", vo.factory_note2);
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


        public bool LineDelete(List<int> factory_idList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", factory_idList);

                    string sql = "Delete From TBL_FACTORY where factory_id in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

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

        public DataTable GetFactories(int corporation_id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string sql = @"SELECT F.CORPORATION_ID, F.FACTORY_ID, F.FACTORY_NAME
                               FROM TBL_FACTORY F
                                    INNER JOIN TBL_CORPORATION C
                                        ON F.CORPORATION_ID = C.CORPORATION_ID
                               WHERE 1 = 1";

                if (corporation_id > 0)
                { 
                    sql += " AND F.CORPORATION_ID = @CORPORATION_ID";
                    cmd.Parameters.AddWithValue("@CORPORATION_ID", corporation_id);
                }

                sql += @" AND FACTORY_USE = 'Y'
                          AND CORPORATION_USE = 'Y'
                          ORDER BY FACTORY_SEQ ASC";
                cmd.CommandText = sql;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

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
