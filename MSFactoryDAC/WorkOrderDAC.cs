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
		public DataTable GetAllWorkOrders(WorkOrderVO workOrderVO = null)
		{
			string sql = @"SELECT WO.WORK_ORDER_NO, WO.WORK_ORDER_DATE, WO.WORK_DATE, PW.WORKER_ID
								, CONVERT(CHAR(5), WO.WORK_START_TIME, 108) WORK_START_TIME, CONVERT(CHAR(5), WO.WORK_FINISH_TIME, 108) WORK_FINISH_TIME
								, CASE WHEN DATEDIFF(DAY, WORK_DATE, GETDATE()) > 0 THEN '작업 전' 
									   WHEN DATEDIFF(DAY, WORK_DATE, GETDATE()) < 0 THEN '작업 완료' 
									   ELSE '작업 중' END WORK_ORDER_STATUS
								, WO.WORKER_ID, E.EMPLOYEE_NAME, WO.PRODUCT_ID, PD.PRODUCT_NAME, WO.WORK_ORDER_QUANTITY, R.RESULT_QUANTITY, D.DEFECTIVE_QUANTITY
								, PC.PROCESS_ID, PC.PROCESS_NAME, L.LINE_ID, L.LINE_NAME, F.FACTORY_ID, F.FACTORY_NAME
						   FROM TBL_WORK_ORDER WO
								INNER JOIN TBL_PROCESS_WORKER PW
									ON WO.WORKER_ID = PW.WORKER_ID
								INNER JOIN TBL_EMPLOYEE E
									ON PW.EMPLOYEE_ID = E.EMPLOYEE_ID
								INNER JOIN TBL_PROCESS PC
									ON PW.PROCESS_ID = PC.PROCESS_ID
								INNER JOIN TBL_LINE L
									ON PC.LINE_ID = L.LINE_ID
								INNER JOIN TBL_FACTORY F
									ON F.FACTORY_ID = L.FACTORY_ID
								INNER JOIN TBL_PRODUCT PD
									ON WO.PRODUCT_ID = PD.PRODUCT_ID
								LEFT OUTER JOIN TBL_RESULT R
									ON WO.WORK_ORDER_NO = R.WORK_ORDER_NO
								LEFT OUTER JOIN TBL_DEFECTIVE D
									ON WO.WORK_ORDER_NO = D.WORK_ORDER_NO
						   WHERE 1 = 1";

			if (workOrderVO != null)
			{
				if (workOrderVO.Line_id > 0)
					sql += " AND L.LINE_ID = @LINE_ID";
				if (workOrderVO.Process_id > 0)
					sql += " AND PC.PROCESS_ID = @PROCESS_ID";
				if (workOrderVO.Product_id > 0)
					sql += " AND PD.PRODUCT_ID = @PRODUCT_ID";
				if (!string.IsNullOrEmpty(workOrderVO.SearchFromDate) && !string.IsNullOrEmpty(workOrderVO.SearchToDate))
					sql += " AND WO.WORK_DATE BETWEEN @SEARCHFROMDATE AND @SEARCHTODATE";
			}

			sql += " ORDER BY WORK_ORDER_NO DESC";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);
			ParametersJ(da.SelectCommand, workOrderVO);

			da.Fill(dt);

			return dt;
		}

		public WorkOrderVO GetWorkOrder(int work_order_no)
		{
			string sql = @"SELECT WO.WORK_ORDER_NO, WO.WORK_ORDER_DATE, WO.WORK_DATE, PW.WORKER_ID
								, CONVERT(CHAR(5), WO.WORK_START_TIME, 108) WORK_START_TIME, CONVERT(CHAR(5), WO.WORK_FINISH_TIME, 108) WORK_FINISH_TIME
								, CASE WHEN DATEDIFF(DAY, WORK_DATE, GETDATE()) > 0 THEN '작업 전' 
									   WHEN DATEDIFF(DAY, WORK_DATE, GETDATE()) < 0 THEN '작업 완료' 
									   ELSE '작업 중' END WORK_ORDER_STATUS
								, WO.WORKER_ID, E.EMPLOYEE_NAME, WO.PRODUCT_ID, PD.PRODUCT_NAME, WO.WORK_ORDER_QUANTITY
								, PC.PROCESS_ID, PC.PROCESS_NAME, L.LINE_ID, L.LINE_NAME, F.FACTORY_ID, F.FACTORY_NAME
						   FROM TBL_WORK_ORDER WO
								INNER JOIN TBL_PROCESS_WORKER PW
									ON WO.WORKER_ID = PW.WORKER_ID
								INNER JOIN TBL_EMPLOYEE E
									ON PW.EMPLOYEE_ID = E.EMPLOYEE_ID
								INNER JOIN TBL_PROCESS PC
									ON PW.PROCESS_ID = PC.PROCESS_ID
								INNER JOIN TBL_LINE L
									ON PC.LINE_ID = L.LINE_ID
								INNER JOIN TBL_FACTORY F
									ON F.FACTORY_ID = L.FACTORY_ID
								INNER JOIN TBL_PRODUCT PD
									ON WO.PRODUCT_ID = PD.PRODUCT_ID
						   WHERE WORK_ORDER_NO = @WORK_ORDER_NO";
			return SqlExecutionJ<WorkOrderVO>(sql, new WorkOrderVO { Work_order_no = work_order_no })?[0];
		}

		public DataTable GetToDoes()
		{
			string sql = $@"SELECT RD.RELEASE_NO, RD.RELEASE_SEQ, RD.PRODUCT_ID, P.PRODUCT_NAME, RD.ORDER_REQUEST_QUANTITY - ISNULL(WO.QTY, 0) ORDER_REQUEST_QUANTITY, RD.RELEASE_PLAN_DATE
									, (SELECT CASE WHEN MIN(SUM_QTY / B2.BOM_USE_QUANTITY) < RD.ORDER_REQUEST_QUANTITY - ISNULL(WO.QTY, 0) THEN MIN(SUM_QTY / B2.BOM_SEQ) ELSE RD.ORDER_REQUEST_QUANTITY - ISNULL(WO.QTY, 0) END
									   FROM TBL_BOM B2
											INNER JOIN (SELECT ISNULL(SUM(S2.STOCK_QUANTITY), 0) SUM_QTY, B.HIGH_PRODUCT_ID, B.LOW_PRODUCT_ID
														FROM TBL_STOCK S2 
															RIGHT OUTER JOIN TBL_BOM B ON S2.PRODUCT_ID = B.LOW_PRODUCT_ID
														WHERE B.HIGH_PRODUCT_ID = RD.PRODUCT_ID
														GROUP BY B.HIGH_PRODUCT_ID, B.LOW_PRODUCT_ID) T ON B2.HIGH_PRODUCT_ID = T.HIGH_PRODUCT_ID AND B2.LOW_PRODUCT_ID = T.LOW_PRODUCT_ID) MAX_QTY
							FROM TBL_RELEASE_DETAIL RD
								INNER JOIN TBL_PRODUCT P ON RD.PRODUCT_ID = P.PRODUCT_ID
								LEFT OUTER JOIN TBL_WORK_ORDER WO ON RD.RELEASE_NO = WO.RELEASE_NO AND RD.RELEASE_SEQ = WO.RELEASE_SEQ
							WHERE RD.RELEASE_STATUS = '출고예정'
							ORDER BY RD.RELEASE_PLAN_DATE, RD.RELEASE_NO, RD.RELEASE_SEQ";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(dt);

			return dt;
		}

		public bool SaveWorkOrder(WorkOrderVO workOrderVO)
		{
			return NotSelectSPJ<WorkOrderVO>("SP_SAVE_WORKORDER", workOrderVO, "Work_order_no", "Worker_id", "Product_id", "Work_date", 
											 "Work_order_quantity", "Work_start_time", "Work_finish_time", "Regist_employee");
		}

		public bool DeleteWorkOrder(string work_order_no)
		{
			string sql = "DELETE FROM TBL_WORKORDE WHERE WORK_ORDER_NO IN (SELECT * FROM  SPLITSTRING(@WORK_ORDER_NO, '@'))";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@WORK_ORDER_NO", work_order_no);

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
