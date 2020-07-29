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
                    cmd.CommandText = @"SELECT company_id, company_name, company_type, company_seq, first_regist_time, first_regist_employee, final_regist_time, final_regist_employee
                                          FROM TBL_COMPANY
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

        //public List<CompanyVO> GetCompanyType(int companyId, string companyType)
        //{
        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.Connection = new SqlConnection(this.ConnectionString);
        //            cmd.CommandText = @"select company_id, company_name, company_type, company_seq, first_regist_time, first_regist_employee, final_regist_time, final_regist_employee 
        //                                  From TBL_COMPANY
        //                                 where companyId =@companyId
        //                                   AND companyType =@companyType
        //                                Order by company_seq ";
        //            cmd.Connection.Open();
        //        }
        //    }
        //    catch (Exception err)
        //    {
                
        //        throw err;
        //    }
        //}
    }
}
