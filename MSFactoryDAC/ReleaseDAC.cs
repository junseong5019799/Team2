using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSFactoryDAC
{
    public class ReleaseDAC: ConnectionAccess
    {
        List<ReleaseVO> list = null;

        public List<ReleaseVO> GetReleasePlan()
        {
            try
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_SELECT_RELEASE_PLAN";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = SqlHelper.DataReaderMapToList<ReleaseVO>(reader);
                    cmd.Connection.Close();

                    return list;
                }
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        public bool SaveReleasePlan(ReleaseVO release)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SP_SELECT_RELEASE_PLAN";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = SqlHelper.DataReaderMapToList<ReleaseVO>(reader);
                    cmd.Connection.Close();

                    return true;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
