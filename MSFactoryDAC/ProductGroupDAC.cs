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
    public class ProductGroupDAC : ConnectionAccess
    {
        public List<GroupComboVO> ProductGroupComboBindingsNotAll()
        {
            return ComboBinding();
        }

        

        public List<GroupComboVO> ProductGroupComboBindings()
        {
            List<GroupComboVO> list = ComboBinding();
            list.Insert(0, new GroupComboVO(0, "전체"));
            return list;
        }

        private List<GroupComboVO> ComboBinding()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT PRODUCT_GROUP_ID, PRODUCT_GROUP_NAME FROM TBL_PRODUCT_GROUP_MANAGEMENT WHERE PRODUCT_GROUP_USE='Y'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<GroupComboVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool DeleteGroups(int deleteNum)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"DELETE FROM TBL_PRODUCT_GROUP_MANAGEMENT WHERE PRODUCT_GROUP_ID = @GROUP_ID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@GROUP_ID", deleteNum);
                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
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

        public void UpdateStatus(int itemNum, int statusNum)
        {
            ProductDAC dac = new ProductDAC();
            string sql = "SP_PRODUCT_GROUP_STATUS_CHANGE";
            dac.ProductAndGroupsStatusUpdate(itemNum, statusNum, sql);
        }

        public bool UpsertGroup(ProductGroupVO pdgVO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SP_PRODUCT_GROUP_INSERT";
                                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_PRODUCT_GROUP_ID", pdgVO.Product_Group_ID);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_GROUP_NAME", pdgVO.Product_Group_Name);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_NOTE1", pdgVO.Product_Group_Note1);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_NOTE2", pdgVO.Product_Group_Note2);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_USE", pdgVO.Product_Group_Use);
                        cmd.Parameters.AddWithValue("@P_FINAL_REGIST_TIME", pdgVO.Final_Regist_Time);
                        cmd.Parameters.AddWithValue("@P_FINAL_REGIST_EMPLOYEE", pdgVO.Final_Regist_Employee);
                        cmd.Parameters.AddWithValue("@P_PRODUCT_SEQ", pdgVO.Product_Group_Seq);
                        cmd.Parameters.AddWithValue("@P_Category", pdgVO.Category);

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
