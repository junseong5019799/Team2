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

        public List<CorporationVO> ComboGet()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Select c.corporation_id, corporation_name
                                          From TBL_CORPORATION c
                                    inner join TBL_FACTORY f on c.corporation_id = f.corporation_id";

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
                    conn.Open();
                    string sql = @"select c.corporation_name, factory_id,factory_name, factory_note1, factory_note2, factory_seq, factory_use, f.first_regist_time, f.first_regist_employee, f.final_regist_time, f.final_regist_employee
                                     From TBL_CORPORATION c, TBL_FACTORY f
                                    where c.corporation_id = f.corporation_id
                                      and (@corporation_id = 0 or  c.corporation_id = @corporation_id)
                                      and (@factory_name = '' or  f.factory_name = @factory_name)
                                    Order by factory_seq asc;";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@corporation_id", vo.corporation_id);
                        cmd.Parameters.AddWithValue("@factory_name", vo.factory_name);

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
    }
}
