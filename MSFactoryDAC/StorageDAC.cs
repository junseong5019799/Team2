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


        /// <summary>
        /// 수불 현황 (입출고)
        /// </summary>
        /// <returns></returns>
        public List<InOutVO> SelectInOut()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT S.stock_no, ST.storage_name, P.product_id, M.product_Group_Name, P.product_name, CONCAT(S.stock_quantity, ' ',P.product_unit) stock_quantity, S.stock_regist_date
	                                FROM TBL_STOCK S INNER JOIN TBL_STORAGE ST ON S.storage_id = ST.storage_id
				                                 INNER JOIN TBL_PRODUCT P ON S.product_id = P.product_id
                                                 INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT M ON P.product_group_id = M.product_group_id";				 
	                            
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        
                        return SqlHelper.DataReaderMapToList<InOutVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// SELECT 재고 현황 
        /// </summary>
        /// <param name="selectStorage"></param>
        /// <returns></returns>
        public List<StorageVO> SelectProductAll(int selectStorage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT S.stock_no, ST.storage_name, P.product_id, M.product_Group_Name, P.product_name, CONCAT(S.stock_quantity, ' ',P.product_unit) stock_quantity, S.stock_regist_date
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


        /// <summary>
        /// SELECT 이동할 재고 리스트
        /// </summary>
        /// <param name="stock_no"></param>
        /// <returns></returns>
        public DataTable MoveStockList(List<int> stock_no)
        {            
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    string strStock = string.Join(",", stock_no);
                    DataTable dt = new DataTable();

                    conn.Open();
                    string sql = $@"SELECT S.stock_no, ST.storage_name, P.product_id, M.product_Group_Name, P.product_name, CONCAT(S.stock_quantity, ' ',P.product_unit) stock_quantity, S.stock_regist_date
	                                FROM TBL_STOCK S INNER JOIN TBL_STORAGE ST ON S.storage_id = ST.storage_id
				                                     INNER JOIN TBL_PRODUCT P ON S.product_id = P.product_id
                                                     INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT M ON P.product_group_id = M.product_group_id
									WHERE s.stock_no in (" + strStock + ")";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {                                             
                        cmd.Parameters.AddWithValue("@stock_no", stock_no);

                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                        da.Fill(dt);
                        conn.Close();

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
        /// 재고 이동 
        /// </summary>
        /// <param name="storage_id"></param>
        /// <param name="stock_no"></param>
        /// <returns></returns>
        public bool MoveStorage(int storage_id, int stock_no)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
               
                try
                {
                    cmd.CommandText = @"UPDATE TBL_STOCK
                                       SET storage_id = @storage_id
                                       WHERE stock_no = @stock_no";
                   
                    cmd.Parameters.AddWithValue("@storage_id", storage_id);
                    cmd.Parameters.AddWithValue("@stock_no", stock_no);
                    cmd.ExecuteNonQuery();         

                    return true;
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }


        /// <summary>
        /// SELECT 재고 DETAIL
        /// </summary>
        /// <param name="storage_id"></param>
        /// <returns></returns>
        public List<StorageVO> GetStorageDetailList(int product_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT S.stock_no, ST.storage_name, P.product_id, M.product_Group_Name, P.product_name
                                   	    , CONCAT(S.stock_quantity, ' ',P.product_unit) stock_quantity, S.stock_regist_date
                                   FROM TBL_STOCK S INNER JOIN TBL_STORAGE ST ON S.storage_id = ST.storage_id
                                   				 INNER JOIN TBL_PRODUCT P ON S.product_id = P.product_id
                                                    INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT M ON P.product_group_id = M.product_group_id                                   				 
                                   WHERE  s.product_id = @product_id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@product_id", product_id);
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
