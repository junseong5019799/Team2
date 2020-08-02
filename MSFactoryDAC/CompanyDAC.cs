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
    public class CompanyDAC : ConnectionAccess
    { 
        List<CompanyVO> list = null;

        public List<CompanyVO> ProductBinding(string selectedItem)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    
                    string sql = @"SP_COMPANY_PRODUCT_BINDINGS";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_SELECTED_ITEM", selectedItem);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        return SqlHelper.DataReaderMapToList<CompanyVO>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 콤보박스바인딩
        /// </summary>
        //public List<CommonCodeVO> GetCommonCodeList(string type)
        //{
        //    using (SqlConnection conn = new SqlConnection(this.ConnectionString))
        //    {
        //        conn.Open();
        //        try
        //        {
        //            string sql = @"SELECT common_id, CM.sort_id, sort_name, CM.note, common_name FROM TBL_COMMON CM
        //                       INNER JOIN TBL_COMMON_GROUP CG ON CM.sort_id = CG.sort_id 
        //                       WHERE CM.sort_id= @sort_id";

        //            using (SqlCommand cmd = new SqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@sort_id", type);
        //                SqlDataReader reader = cmd.ExecuteReader();

        //                return SqlHelper.DataReaderMapToList<CommonCodeVO>(reader);
        //            }
        //        }
        //        catch (Exception err)
        //        {
        //            throw err;
        //        }
        //    }
        //}
        /// <returns></returns>


        /// <summary>
        /// 전체데이타그리드뷰에 바인딩
        /// </summary>
        public DataTable GetCompany(string type)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT company_id, company_name, C.COMMON_NAME, company_seq, first_regist_time, first_regist_employee, final_regist_time, final_regist_employee
                                          FROM TBL_COMPANY CM INNER JOIN TBL_COMMON C ON CM.company_type = C.common_id
                                         WHERE company_type = isnull(company_type, @company_type) or company_type = @company_type 
                                         ORDER BY company_seq";

                    cmd.Parameters.AddWithValue("@company_type", type);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    cmd.Connection.Open();
                    da.Fill(dt);
                    cmd.Connection.Close();

                    return dt; 
                }
            }
            catch (Exception err)
            {
                //ConnectionAccess.GetLogger().WriteError(err.Message, err);
                throw err;
            }
        }
        /// <returns></returns>

        ///<summary>
        /// 저장하기
        /// </summary
        public bool SaveCompany(CompanyVO company)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SP_SAVE_COMPANY";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_company_id", company.company_id);
                        cmd.Parameters.AddWithValue("@P_company_name", company.company_name);
                        cmd.Parameters.AddWithValue("@P_company_type", company.company_type);
                        cmd.Parameters.AddWithValue("@P_first_regist_time", company.first_regist_time);
                        cmd.Parameters.AddWithValue("@P_first_regist_employee", company.first_regist_employee);
                        cmd.Parameters.AddWithValue("@P_final_regist_time", company.final_regist_time);
                        cmd.Parameters.AddWithValue("@P_final_regist_employee", company.final_regist_employee);
                        cmd.Parameters.AddWithValue("@P_product_id", company.Product_ID);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
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
        /// <returns></returns>
    }
}
