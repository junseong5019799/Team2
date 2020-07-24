using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryDAC
{
    public class ProductGroupDAC : ConnectionAccess
    {
        public List<ProductGroupVO> SelectAllProductGroups()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT [product_group_id], [product_group_name], [product_group_use] Product_Group_Use_String, [product_group_note1], [product_group_note2], [product_group_seq], 
                                   [first_regist_time], [first_regist_employee], [final_regist_time], [final_regist_employee]
                                   FROM TBL_PRODUCT_GROUP_MANAGEMENT
                                   ORDER BY PRODUCT_GROUP_SEQ ASC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<ProductGroupVO>(cmd.ExecuteReader());
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
