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

        public List<StorageVO> SelectStorage(int? CorporationID = null, int? FactoryID = null)
        {
            try
            {
                string AddString = string.Empty;
                    
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();

                    StringBuilder sb = new StringBuilder();
                    
                    if(CorporationID == 0 && FactoryID > 0)
                    {
                        sb.Append(" WHERE F.FACTORY_ID = @FID");
                        cmd.Parameters.AddWithValue("@FID", FactoryID);
                    
                    }

                    if (CorporationID != null && CorporationID != 0 )
                    {
                        sb.Append(" Where C.CORPORATION_ID = @ID");
                        cmd.Parameters.AddWithValue("@ID", CorporationID);
                        if(FactoryID != null && FactoryID != 0)
                        {
                            sb.Append(" AND F.FACTORY_ID = @FID");
                            cmd.Parameters.AddWithValue("@FID", FactoryID);
                        }
                    }

                    cmd.CommandText = @"select C.corporation_name, S.[storage_id], F.factory_name, [storage_name], [storage_seq], [storage_use], S.[first_regist_time], S.[first_regist_employee], S.[final_regist_time], S.[final_regist_employee]
                                        from tbl_storage S INNER JOIN TBL_FACTORY F ON S.factory_id = F.factory_id
                                                           INNER JOIN TBL_CORPORATION C ON F.corporation_id = C.corporation_id" + sb.ToString() +
                                        " order by storage_seq asc";

                    return SqlHelper.DataReaderMapToList<StorageVO>(cmd.ExecuteReader());
                }
                
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public int GetStockByProduct(int product_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ISNULL(SUM(stock_quantity), 0)
                                   FROM TBL_STOCK ST 
                                   WHERE product_id = @product_id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@product_id", product_id);
                        int num = Convert.ToInt32(cmd.ExecuteScalar());

                        return num;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public List<StorageVO> StorageComboBindings(int corpValue, int facValue)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"select storage_id, storage_name
                                    from tbl_storage S INNER JOIN TBL_FACTORY F ON S.factory_id = F.factory_id
													   INNER JOIN TBL_CORPORATION C ON F.corporation_id = C.corporation_id
										WHERE C.CORPORATION_ID = @CORPVALUE AND F.factory_id = @FACVALUE";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CORPVALUE", corpValue);
                        cmd.Parameters.AddWithValue("@FACVALUE", facValue);
                        return SqlHelper.DataReaderMapToList<StorageVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void UpdateStatus(int storage_ID, string storage_Status)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"update tbl_storage set storage_use = @storage_status where storage_id = @storage_ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@storage_ID", storage_ID);
                        cmd.Parameters.AddWithValue("@storage_status", storage_Status);
                        cmd.ExecuteNonQuery();
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
                    string sql = @"SELECT ST.storage_name, P.product_id, M.product_Group_Name, P.product_name
                                   	    , CONCAT((SELECT SUM(stock_quantity) FROM TBL_PRODUCT WHERE product_id = S.product_id) , '  ',P.product_unit) stock_quantity
                                   FROM TBL_STOCK S INNER JOIN TBL_STORAGE ST ON S.storage_id = ST.storage_id
                                                    INNER JOIN TBL_PRODUCT P ON S.product_id = P.product_id
                                                    INNER JOIN TBL_PRODUCT_GROUP_MANAGEMENT M ON P.product_group_id = M.product_group_id				 
                                   WHERE ST.storage_id = @storage_id		
                                   GROUP BY ST.storage_name, P.product_id, M.product_Group_Name, P.product_name, S.product_id, product_unit";
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
        /// <summary>
        /// 창고 등록, 수정관리
        /// </summary>
        /// <param ID="storage_id"></param>
        /// <returns></returns>
        public bool SaveStorage(StorageVO vo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_STORAGE";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_storage_id", vo.Storage_Id);
                        cmd.Parameters.AddWithValue("@P_storage_name", vo.Storage_Name);
                        cmd.Parameters.AddWithValue("@P_factory_id", vo.Factory_id);
                        cmd.Parameters.AddWithValue("@P_storage_seq", vo.Storage_Seq);
                        cmd.Parameters.AddWithValue("@P_storage_use", vo.Storage_Use);
                        cmd.Parameters.AddWithValue("@P_first_regist_employee", vo.First_regist_employee);
                        cmd.Parameters.AddWithValue("@P_final_regist_employee", vo.Final_regist_employee);

                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception err)
            {
                return false;
                throw err;
            }
        }

        public bool StorageDelete(List<int> storage_idList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", storage_idList);

                    string sql = "Delete From TBL_STORAGE where storage_id in (" + selNum + ") ;"; 

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return cmd.ExecuteNonQuery() > 0;
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
