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
    public class OrderDAC:ConnectionAccess
    {

        /// <summary>
        /// SELECT 발주업체 
        /// </summary>
        /// <returns></returns>
        public List<OrderVO> GetCompanyList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT company_id, company_name FROM TBL_COMPANY
                                   WHERE company_type = 'Cop'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// SELECT 발주 제안 리스트
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrderPlanList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand("SP_ORDERPLAN_SELECT", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        con.Close();

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
        /// 발주 등록
        /// </summary>
        public void InsertOrder()
        {
//            SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//-- =============================================
//--Author:		< Author,,Name >
//--Create date: < Create Date,,>
//--Description:	< Description,,>
//-- =============================================
//CREATE PROCEDURE SP_ORDER_INSERT

//     @company_id INT
//    , @first_regist_employee     NVARCHAR(20)
//	,@final_regist_employee NVARCHAR(20)

//AS
//BEGIN

//    INSERT INTO TBL_ORDER(company_id, first_regist_employee, final_regist_employee)

//    VALUES(20, '황인성', '황인성')


//    INSERT INTO dbo.TBL_ORDER_DETAIL(order_no, order_seq, product_id, order_request_quantity, order_status)

//    VALUES(20, 1, 5, 100, '발주')
//END
//GO
        }

    }
}
