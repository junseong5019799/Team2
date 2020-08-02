using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryDAC
{
    public class StorageDAC:ConnectionAccess
    {
        /// <summary>
        /// 창고 ID 바인딩
        /// </summary>
        /// <returns></returns>
        public List<StorageVO> GetStorage()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT storage_id, storage_name FROM TBL_STORAGE";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<StorageVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<StorageVO> SelectProductAll(int selectStorage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT S.stock_no, ST.storage_name, M.product_Group_Name, P.product_name, CONCAT(S.stock_quantity, ' ',P.product_unit) stock_quantity, S.stock_regist_date
	                                FROM TBL_STOCK S INNER JOIN TBL_STORAGE ST ON S.storage_id = ST.storage_id
				                                 INNER JOIN TBL_PRODUCT P ON S.product_id = P.product_id
                                                 INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT M ON P.product_group_id = M.product_group_id
				 
	                                WHERE ST.storage_id = @STORAGE_ID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@STORAGE_ID", selectStorage);
                        return SqlHelper.DataReaderMapToList<StorageVO>(cmd.ExecuteReader());
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
