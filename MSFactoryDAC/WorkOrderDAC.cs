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
	public class WorkOrderDAC : SqlHelper
	{
		public DataTable GetAllWorkOrdes(WorkOrderVO workOrderVO)
		{
			string sql = @"SELECT WO.WORK_ORDER_NO, WO.WORK_ORDER_DATE, WO.WORK_DATE, WO.WORK_START_TIME, WO.WORK_FINISH_TIME, WO.WORK_ORDER_STATUS
								, WO.WORKER_ID, E.EMPLOYEE_NAME, WO.PRODUCT_ID, P.PRODUCT_NAME, WO.WORK_ORDER_QUANTITY, R.RESULT_QUANTITY, D.DEFECTIVE_QUANTITY
						   FROM TBL_WORK_ORDER WO
								INNER JOIN TBL_PROCESS_WORKER PW
									ON WO.WORKER_ID = PW.WORKER_ID
								INNER JOIN TBL_EMPLOYEE E
									ON PW.EMPLOYEE_ID = E.EMPLOYEE_ID
								INNER JOIN TBL_PRODUCT P
									ON WO.PRODUCT_ID = P.PRODUCT_ID
								LEFT OUTER JOIN TBL_RESULT R
									ON WO.WORK_ORDER_NO = R.WORK_ORDER_NO
								LEFT OUTER JOIN TBL_DEFECTIVE D
									ON WO.WORK_ORDER_NO = D.WORK_ORDER_NO
						   WHERE 1 = 1
						   ORDER BY WORK_ORDER_NO DESC";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(dt);

			return dt;
		}

		public WorkOrderVO GetWorkOrde(int work_order_no)
		{
			string sql = @"SELECT WORK_ORDER_NO, WORKER_ID, PRODUCT_ID, WORK_ORDER_DATE, WORK_DATE, WORK_ORDER_QUANTITY, WORK_START_TIME, WORK_FINISH_TIME, WORK_ORDER_STATUS
						   FROM TBL_WORKORDE
						   WHERE WORK_ORDER_NO = @WORK_ORDER_NO";
			return SqlExecutionJ<WorkOrderVO>(sql, new WorkOrderVO { Work_order_no = work_order_no })?[0];
		}

		public bool SaveWorkOrde(WorkOrderVO workOrderVO)
		{
			return NotSelectSPJ<WorkOrderVO>("SP_SAVE_WORKORDE", workOrderVO, "Work_order_no", "Worker_id", "Product_id", "Work_order_date", "Work_date", 
											 "Work_order_quantity", "Work_start_time", "Work_finish_time", "Regist_employee");
		}

		public bool DeleteWorkOrde(string work_order_no)
		{
			string sql = "DELETE FROM TBL_WORKORDE WHERE WORK_ORDER_NO IN (SELECT * FROM  SPLITSTRING(@WORK_ORDER_NO, '@'))";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@WORK_ORDER_NO", work_order_no);

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
