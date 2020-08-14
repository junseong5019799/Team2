using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

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
        /// SELECT planID (날짜에 따라)
        /// </summary>
        /// <returns></returns>
        public List<ReleaseVO> GetReleasePlanByDate(string fromDate, string toDate)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT r.release_no, r.company_id, 
                                               (SELECT company_name FROM [dbo].[TBL_COMPANY] WHERE company_id = r.company_id) company_name
                                              ,release_plan_date, release_status			 
                                        FROM TBL_RELEASE_DETAIL rd INNER JOIN TBL_RELEASE r ON rd.release_no = r.release_no
                                        WHERE release_plan_date BETWEEN @FromDate AND @ToDate
                                        GROUP BY r.release_no, r.company_id, release_plan_date, release_status
                                        ORDER BY release_plan_date DESC";

                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = SqlHelper.DataReaderMapToList<ReleaseVO>(reader);
                    cmd.Connection.Close();

                    return list;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool IsUpperData(int ProductGroupID, int ProductID, ref int previousPrice, ref DateTime? previousTime)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open(); 

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = @"SP_SELLPRICE_PREVIOUS_DATA_SELECT";
                    
                    cmd.Parameters.AddWithValue("@P_GROUP_ID", ProductGroupID);
                    cmd.Parameters.AddWithValue("@P_PRODUCT_ID", ProductID);

                    SqlParameter param = new SqlParameter("@P_PREVIOUS_PRICE",SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    SqlParameter param2 = new SqlParameter("@P_PREVIOUS_TIME", SqlDbType.DateTime);
                    param2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param2);

                    cmd.ExecuteNonQuery();

                    if (param.Value != DBNull.Value)
                    {
                        previousPrice = Convert.ToInt32(param.Value);
                        previousTime = Convert.ToDateTime(param2.Value);
                        return true;
                    }
                        

                    else
                    {
                        previousPrice = 0;
                        previousTime = null;
                        return false;
                    }
                        
                         
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// 출고 DETAIL -> dataTable 바인딩
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
                        string sql = @"SELECT r.release_no, release_seq, company_id, release_plan_date, product_id
                                            , (SELECT product_name FROM [dbo].[TBL_PRODUCT] WHERE product_id = rd.product_id) AS product_name
                                            , order_request_quantity, release_status, release_date, release_request_date
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
        /// 수요계획 -> DataTable 바인딩
        /// </summary>
        /// <param name="release_no"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable Calculate_ReleasePlan(int release_no, DateTime from, DateTime to)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {                                             
                        da.SelectCommand = new SqlCommand("SP_CALCULATE_RELEASE", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        da.SelectCommand.Parameters.AddWithValue("@release_no", release_no);
                        da.SelectCommand.Parameters.AddWithValue("@From_date", from);
                        da.SelectCommand.Parameters.AddWithValue("@To_date", to);

                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        con.Close();

                        return dt;
                    }
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
        /// 품목 바인딩 
        /// </summary>
        /// <returns></returns>
        public List<ReleaseVO> SelectProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT PRODUCT_ID, PRODUCT_NAME
                                   FROM TBL_PRODUCT P INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT G ON P.product_group_id = G.product_group_id
                                   WHERE product_group_name NOT IN('재료')";
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
        /// 품목 그룹 바인딩 
        /// </summary>
        /// <returns></returns>
        public List<ReleaseVO> SelectProductGroup()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT G.product_group_id, product_group_name
                                   FROM TBL_PRODUCT_GROUP_MANAGEMENT G 
                                   WHERE product_group_name NOT IN('재료')";
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
        /// 품목 그룹에 따라 품목 바인딩 
        /// </summary>
        /// <returns></returns>
        public List<ReleaseVO> SelectProductByGroup(int groupID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    cmd.CommandText = @"SELECT P.product_id, P.product_name
                                FROM TBL_PRODUCT P INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT G ON P.product_group_id = G.product_group_id
                                WHERE P.product_group_id = @product_group_id";
                    cmd.Parameters.AddWithValue("@product_group_id", groupID);
                    return SqlHelper.DataReaderMapToList<ReleaseVO>(cmd.ExecuteReader());
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
                    string sql = @"SELECT DISTINCT release_no
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
                    cmd.Parameters.Add("@release_request_date", SqlDbType.DateTime);

                    foreach (DataRow dr in dgv.Rows)
                    {                                
                        cmd.Parameters["@release_seq"].Value = dr["release_seq"];
                        cmd.Parameters["@product_id"].Value = dr["product_id"];
                        cmd.Parameters["@release_plan_date"].Value = dr["release_plan_date"];
                        cmd.Parameters["@release_date"].Value = "";
                        cmd.Parameters["@order_request_quantity"].Value = dr["order_request_quantity"];
                        cmd.Parameters["@release_quantity"].Value = 0;
                        cmd.Parameters["@release_status"].Value = "출고예정";
                        cmd.Parameters["@release_request_date"].Value = dr["release_request_date"];

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
        

        /// <summary>
        /// 출고일 비교해서 출고일 취소하기 
        /// </summary>
        /// <returns></returns>
        public bool UpdateReleaseDateCancel(int release_no, int product_id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"UPDATE TBL_RELEASE_DETAIL
                                         SET release_status = '출고취소' 
                                         WHERE release_no = @release_no AND product_id = @product_id";

                    cmd.Parameters.AddWithValue("@release_no", release_no);
                    cmd.Parameters.AddWithValue("@product_id", product_id);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return true;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// 출고일 비교해서 출고일 완료 
        /// </summary>
        /// <returns></returns>
        public bool UpdateReleaseDate(int release_no, int product_id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"UPDATE TBL_RELEASE_DETAIL
                                         SET release_status = '출고예정' 
                                         WHERE release_no = @release_no AND product_id = @product_id";

                    cmd.Parameters.AddWithValue("@release_no", release_no);
                    cmd.Parameters.AddWithValue("@product_id", product_id);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return true;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// 품목ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
