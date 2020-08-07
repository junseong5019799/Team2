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
    public class DefectiveDAC : ConnectionAccess
    {
        public List<DefectiveVO> DefectiveSelectAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SP_DEFECTIVE_SELECT";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        return SqlHelper.DataReaderMapToList<DefectiveVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void DefectiveDelete(int defectiveNo)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();

                string sql = @"DELETE FROM TBL_DEFECTIVE_TYPE WHERE DEFECTIVE_TYPE_ID = @DefectiveNo";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DefectiveNo", defectiveNo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool UseTypeChange(int productID, string isTypeUse)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"UPDATE TBL_DEFECTIVE_TYPE SET DEFECTIVE_TYPE_USE = @TYPE_USE WHERE DEFECTIVE_TYPE_ID = @TYPE_ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TYPE_USE", isTypeUse);
                        cmd.Parameters.AddWithValue("@TYPE_ID", productID);

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

        public bool DefectiveTypeUpsert(DefectiveTypeVO typeVO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SP_DEFECTIVE_TYPE_UPSERT";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_Num", typeVO.Defective_Type_ID);
                        cmd.Parameters.AddWithValue("@P_Type_Name", typeVO.Defective_Type_Name);
                        cmd.Parameters.AddWithValue("@P_Type_Use", typeVO.Defective_Type_Use);
                        cmd.Parameters.AddWithValue("@P_Regist_Time", typeVO.Final_Regist_Time);
                        cmd.Parameters.AddWithValue("@P_Regist_Employee", typeVO.Final_Regist_Employee);
                        cmd.Parameters.AddWithValue("@P_CATEGORY", typeVO.P_Category);

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

        public List<DefectiveTypeVO> DefectiveTypeSelectAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT [defective_type_id], [defective_type_name], [defective_type_seq], [defective_type_use], [first_regist_time], [first_regist_employee], [final_regist_time], [final_regist_employee]
                                    FROM [dbo].[TBL_DEFECTIVE_TYPE]";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<DefectiveTypeVO>(cmd.ExecuteReader());
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
