using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryDAC
{
    public class ProductionDAC : ConnectionAccess
    {
        public List<ProductionVO> ProductionStatusSelect()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT W.work_order_no, W.work_date, P.product_name, W.work_order_quantity, D.defective_quantity, 
                                   (W.work_order_quantity - D.defective_quantity) Good_Quantity, E.employee_name, W.work_start_time, W.work_finish_time
                                   FROM TBL_WORK_ORDER W INNER JOIN TBL_PRODUCT P ON W.product_id = P.product_id
				                        INNER JOIN TBL_DEFECTIVE D ON W.work_order_no = D.work_order_no
				                        INNER JOIN TBL_PROCESS_WORKER PW ON W.worker_id = PW.worker_id
				                        INNER JOIN TBL_EMPLOYEE E ON PW.worker_id = E.employee_id
				                        ORDER BY W.work_start_time DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<ProductionVO>(cmd.ExecuteReader());
                    }

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<ProductionVO> DefectiveSelect()
        {
            //dgv2.AddNewColumns("불량코드", "", 100, false);
            //dgv2.AddNewColumns("불량명", "", 100, true);
            //dgv2.AddNewColumns("불량 수량", "", 100, true);
            //dgv2.AddNewColumns("불량 일자", "", 100, true);
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT * ";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return SqlHelper.DataReaderMapToList<ProductionVO>(cmd.ExecuteReader());
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
