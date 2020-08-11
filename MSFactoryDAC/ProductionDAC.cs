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

        public List<ProductionVO> DowntimeSelect()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT Downtime_No, d.work_order_no, downtime_type_name, downtime_note, downtime_start_time, downtime_finish_time, DATEDIFF(hour, downtime_start_time, downtime_finish_time) downDowntime_Hour, downtime_type_use, downtime_type_calculation 
                                    FROM TBL_DOWNTIME D INNER JOIN TBL_DOWNTIME_TYPE DT ON D.downtime_type_id = DT.downtime_type_id
					                INNER JOIN TBL_WORK_ORDER O ON O.work_order_no = D.work_order_no";

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
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT defective_no, O.work_order_no, defective_type_name, defective_quantity, defective_date
                                    FROM TBL_DEFECTIVE D INNER JOIN TBL_DEFECTIVE_TYPE DT ON D.defective_type_id = DT.defective_type_id
					                INNER JOIN TBL_WORK_ORDER O ON O.work_order_no = D.work_order_no
					                ORDER BY O.work_order_no";

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
