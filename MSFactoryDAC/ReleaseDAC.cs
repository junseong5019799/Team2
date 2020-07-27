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
        /// dataTable 바인딩
        /// </summary>
        /// <param name="release_no"></param>
        /// <returns></returns>
        public DataTable GetReleasePlanDetail(int release_no)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        string sql = @"SELECT r.release_no, release_seq, company_id, release_plan_date, product_id, order_request_quantity, release_status, release_date
                                       	 , r.first_regist_time, r.first_regist_employee, r.final_regist_time, r.final_regist_employee
                                       FROM TBL_RELEASE_DETAIL rd INNER JOIN TBL_RELEASE r ON rd.release_no = r.release_no
                                       WHERE r.release_no = @release_no
                                       ORDER BY release_plan_date";
                        
                        da.SelectCommand = new SqlCommand(sql, con);
                        da.SelectCommand.Parameters.AddWithValue("@release_no", release_no);
                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);                   
                        con.Close();

                        return dt;
                    }
                }
            }
            catch (Exception err)
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
        public List<ReleaseVO> SelectPlanID()
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
                        return SqlHelper.DataReaderMapToList<ReleaseVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// 저장하기 
        /// </summary>
        /// <param name="release"></param>
        /// <returns></returns>
        public bool SaveReleasePlan(DataTable dgv, ReleaseVO release)
        {            
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();
                try
                {

                    cmd.CommandText = "SP_SAVE_RELEASE_PLAN";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;

                    cmd.Parameters.AddWithValue("@release_no", release.release_no);
                    cmd.Parameters.AddWithValue("@company_id", release.company_id);
                    cmd.Parameters.AddWithValue("@first_regist_time", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@first_regist_employee", "사원명");
                    cmd.Parameters.AddWithValue("@final_regist_time", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@final_regist_employee", "사원명");
                                            
                    int num = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.CommandText = "SP_SAVE_RELEASEDETAIL";
                    cmd.Parameters.Clear();
                    
                    cmd.Parameters.AddWithValue("@release_no", num);
                    cmd.Parameters.Add("@release_seq", SqlDbType.Int);
                    cmd.Parameters.Add("@product_id", SqlDbType.Int);
                    cmd.Parameters.Add("@release_plan_date", SqlDbType.DateTime);
                    cmd.Parameters.Add("@release_date", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@order_request_quantity", SqlDbType.Int);
                    cmd.Parameters.Add("@release_quantity", SqlDbType.Int);
                    cmd.Parameters.Add("@release_status", SqlDbType.NVarChar);

                    foreach (DataRow dr in dgv.Rows)
                    {                                
                        cmd.Parameters["@release_seq"].Value = dr["release_seq"];
                        cmd.Parameters["@product_id"].Value = dr["product_id"];
                        cmd.Parameters["@release_plan_date"].Value = dr["release_plan_date"];
                        cmd.Parameters["@release_date"].Value = "";
                        cmd.Parameters["@order_request_quantity"].Value = dr["order_request_quantity"];
                        cmd.Parameters["@release_quantity"].Value = 0;
                        cmd.Parameters["@release_status"].Value = "출고예정";
                              
                        cmd.ExecuteNonQuery();
                    }                    
                    
                    
                    tran.Commit();
                    cmd.Connection.Close();
                                        
                    return true;
                }
                
                catch (Exception err)
                {
                    tran.Rollback();
                    throw err;
                }
            }
            
        }        
        

        public int GetProductID(string name)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"SELECT product_id
                                         FROM TBL_PRODUCT
                                         WHERE product_name = @product_name ";

                    cmd.Parameters.AddWithValue("@product_name", name);
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
