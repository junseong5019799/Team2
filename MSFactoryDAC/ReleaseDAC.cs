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




        /// <summary>
        /// 품목명 바인딩
        /// </summary>
        /// <returns></returns>
        public List<BomVO> SelectProduct()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT product_id, product_name FROM TBL_PRODUCT";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<BomVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 품목 그룹 바인딩 
        /// </summary>
        /// <returns></returns>
        public List<GroupComboVO> SelectProductGroup()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT PRODUCT_GROUP_ID, PRODUCT_GROUP_NAME 
                                   FROM TBL_PRODUCT_GROUP_MANAGEMENT 
                                   WHERE product_group_name NOT IN('재료')";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<GroupComboVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// PlanID 바인딩
        /// </summary>
        /// <returns></returns>
        public List<GroupComboVO> SelectPlanID()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT release_no
                                   FROM TBL_RELEASE_DETAIL";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<GroupComboVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
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
                    cmd.CommandText = "SP_SAVE_RELEASE_PLAN";
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
        
        public int GetProductID(string name)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $@"SELECT product_id
                                         FROM TBL_PRODUCT
                                         WHERE product_name = @product_name ";
                  
                    cmd.Connection.Open();
                    int id = Convert.ToInt32(cmd.ExecuteScalar());                    
                    cmd.Connection.Close();

                    return id;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }    
}
