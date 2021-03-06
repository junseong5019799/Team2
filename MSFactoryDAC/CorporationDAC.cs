﻿using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryDAC
{
    public class CorporationDAC: SqlHelper
    {
        //테이블로 전체 가져오기
        //DataTable dt = new DataTable();
        //public DataTable Getall()
        //{
        //    try
        //    {
        //        string sql = @"SELECT corporation_id, corporation_name, corporation_note1, corporation_note2, corporation_seq, corporation_use, first_regist_time, first_regist_employee, final_regist_time, final_regist_employee
        //                          FROM TBL_CORPORATION";

        //        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //        da.Fill(dt);
        //        return dt;

        //    }
        //    catch (Exception err)
        //    {
        //        throw err;
        //    }
        //}

        public List<CorporationVO> GetSearch(string corporation_name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT corporation_id, corporation_name, corporation_note1, corporation_note2, corporation_seq, corporation_use, first_regist_time, first_regist_employee, final_regist_time, final_regist_employee
                                     FROM TBL_CORPORATION 
                                     Order by corporation_seq ASC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //cmd.Parameters.AddWithValue("@corporation_name", corporation_name);

                        return SqlHelper.DataReaderMapToList<CorporationVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool SaveCorporation(CorporationVO corporationvo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_CORPORATION";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_corporation_id", corporationvo.corporation_id);
                        cmd.Parameters.AddWithValue("@P_corporation_name", corporationvo.corporation_name);
                        cmd.Parameters.AddWithValue("@P_corporation_note1", corporationvo.corporation_note1);
                        cmd.Parameters.AddWithValue("@P_corporation_note2", corporationvo.corporation_note2);
                        cmd.Parameters.AddWithValue("@P_corporation_seq", corporationvo.corporation_seq);
                        cmd.Parameters.AddWithValue("@P_corporation_use", corporationvo.corporation_use);
                        cmd.Parameters.AddWithValue("@P_first_regist_employee", corporationvo.first_regist_employee);
                        cmd.Parameters.AddWithValue("@P_final_regist_employee", corporationvo.final_regist_employee);

                       
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

        public bool Delete(List<int> corporation_idList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", corporation_idList);

                    string sql = "Delete From TBL_CORPORATION where corporation_id in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

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

        public List<CorporationVO> CorporationComboBinding()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "select corporation_id, corporation_name from tbl_corporation"; //여러개의 값을 삭제하고온다.

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<CorporationVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataTable GetCorporations()
        {
            try
            {
                string sql = @"SELECT CORPORATION_ID, CORPORATION_NAME
                               FROM TBL_CORPORATION 
                               WHERE CORPORATION_USE = 'Y'                        
                               ORDER BY CORPORATION_SEQ ASC";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                da.Fill(dt);

                return dt;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
