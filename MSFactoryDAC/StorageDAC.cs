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
        /// SELECT 재고 DETAIL
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public List<StorageVO> GetStorageDetailList(int product_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT stock_no
                                         , P.product_id, product_name
                                         , S.storage_id
                                         , (SELECT factory_name FROM TBL_FACTORY WHERE factory_id = S.factory_id) factory_name
                                         , storage_name
                                         , CONCAT(ST.stock_quantity, ' ',P.product_unit) stock_quantity, stock_regist_date
                                    FROM dbo.TBL_STORAGE S INNER JOIN dbo.TBL_STOCK ST ON S.storage_id = ST.storage_id 
                                    					   INNER JOIN dbo.TBL_PRODUCT P ON P.product_id = ST.product_id
                                    WHERE p.product_id = @product_id";
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


        /// <summary>
        /// 품목에 따른 재고 SELECT
        /// </summary>
        /// <param name="stock_id"></param>
        /// <returns></returns>
        public List<StorageVO> SelectStockID(List<int> IDList)
        {
            List<StorageVO> list = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string selID = string.Join(",", IDList);
                    string sql = @"SELECT stock_no, S.product_id, product_name, CONCAT(S.stock_quantity, ' ',P.product_unit) stock_quantity, S.storage_id, storage_name
                                   FROM TBL_STOCK S INNER JOIN TBL_PRODUCT P ON P.product_id = S.product_id
                                   				 INNER JOIN TBL_STORAGE ST ON S.storage_id = ST.storage_id
                                   WHERE S.product_id in (" + selID + ") ";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        list = SqlHelper.DataReaderMapToList<StorageVO>(reader);
                    }

                    return list;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// UPDATE 재고의 창고이동 
        /// </summary>
        /// <returns></returns>
        public bool UpdateStorageID(List<int> IDList, int storage_id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
               
                try
                {
                    string selID = string.Join(",", IDList);

                    cmd.CommandText = @"UPDATE TBL_STOCK
                                        SET storage_id = @storage_id
                                        WHERE product_id IN ("+ selID + ")";                   

                    cmd.Parameters.AddWithValue("@storage_id", storage_id);
                    cmd.Parameters.AddWithValue("@product_id", selID);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception err)
                {                   
                    throw err;
                }
            }
        }
    }



}
