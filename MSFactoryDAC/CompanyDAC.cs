using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryDAC
{
    public class CompanyDAC : ConnectionAccess
    { 
        List<CompanyVO> list = null;

        public List<CompanyVO> GetCompanyList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select company_id, company_name, company_type, company_seq, first_regist_time, first_regist_employee, final_regist_time, final_regist_employee 
                                          FROM TBL_COMPANY";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = SqlHelper.DataReaderMapToList<CompanyVO>(reader);
                    cmd.Connection.Close();

                    return list;
                    
                }
            }
            catch (Exception err)
            {
                //ConnectionAccess.GetLogger().WriteError(err.Message, err);
                throw err;
            }
        }

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
        //                              Order by company_seq DESC";
        //            cmd.Connection.Open();
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        ConnectionAccess.GetLogger().WriteError(err.Message, err);
        //        throw err;
        //    }
        //}
    }
}
