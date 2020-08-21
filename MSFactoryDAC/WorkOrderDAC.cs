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
			string sql = @"SELECT WO.WORK_ORDER_NO, WO.WORK_ORDER_DATE, WO.WORK_DATE, WO.RELEASE_NO, WO.RELEASE_SEQ, WO.QTY, PW.WORKER_ID
								, CONVERT(CHAR(5), WO.WORK_START_TIME, 108) WORK_START_TIME, CONVERT(CHAR(5), WO.WORK_FINISH_TIME, 108) WORK_FINISH_TIME
								, CASE WHEN DATEDIFF(DAY, WORK_DATE, GETDATE()) < 0 THEN '작업 전' 
									   WHEN DATEDIFF(DAY, WORK_DATE, GETDATE()) > 0 THEN '작업 완료' 
									   ELSE '작업 중' END WORK_ORDER_STATUS
								, WO.FIRST_REGIST_TIME, WO.FIRST_REGIST_EMPLOYEE
								, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = WO.FIRST_REGIST_EMPLOYEE) FIRST_REGIST_EMPLOYEE_NAME
								, WO.FINAL_REGIST_TIME, WO.FINAL_REGIST_EMPLOYEE
								, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = WO.FINAL_REGIST_EMPLOYEE ) FINAL_REGIST_EMPLOYEE_NAME
								, WO.WORKER_ID, E.EMPLOYEE_NAME, WO.PRODUCT_ID, PD.PRODUCT_NAME, WO.WORK_ORDER_QUANTITY, ISNULL(R.RESULT_QUANTITY, 0) RESULT_QUANTITY
								, ISNULL(D.DEFECTIVE_QUANTITY, 0) DEFECTIVE_QUANTITY, PC.PROCESS_ID, PC.PROCESS_NAME, L.LINE_ID, L.LINE_NAME, F.FACTORY_ID, F.FACTORY_NAME
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
			string sql = @"SELECT WO.WORK_ORDER_NO, WO.WORK_ORDER_DATE, WO.WORK_DATE, WO.RELEASE_NO, WO.RELEASE_SEQ, WO.QTY, PW.WORKER_ID
								, CONVERT(CHAR(5), WO.WORK_START_TIME, 108) WORK_START_TIME, CONVERT(CHAR(5), WO.WORK_FINISH_TIME, 108) WORK_FINISH_TIME
								, CASE WHEN DATEDIFF(DAY, WORK_DATE, GETDATE()) < 0 THEN '작업 전' 
									   WHEN DATEDIFF(DAY, WORK_DATE, GETDATE()) > 0 THEN '작업 완료' 
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
			string sql = $@"SELECT RD.RELEASE_NO, RD.RELEASE_SEQ, RD.PRODUCT_ID, P.PRODUCT_NAME, RD.ORDER_REQUEST_QUANTITY - ISNULL(WO.QTY, 0) ORDER_REQUEST_QUANTITY, RD.RELEASE_REQUEST_DATE
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
							AND RD.ORDER_REQUEST_QUANTITY - ISNULL(WO.QTY, 0) > 0
							ORDER BY RD.RELEASE_REQUEST_DATE, RD.RELEASE_NO, RD.RELEASE_SEQ";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(dt);

			return dt;
		}
		
		public bool SaveWorkOrder(WorkOrderVO workOrderVO)
		{
			return NotSelectSPJ<WorkOrderVO>("SP_SAVE_WORKORDER", workOrderVO, "Work_order_no", "Worker_id", "Product_id", "Release_no", "Release_seq", "Qty", "Work_date", "Work_order_quantity", "Regist_employee");
		}

		public bool DeleteWorkOrder(string work_order_no)
		{
			string sql = "DELETE FROM TBL_WORKORDE WHERE WORK_ORDER_NO IN (SELECT * FROM  SPLITSTRING(@WORK_ORDER_NO, '@'))";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@WORK_ORDER_NO", work_order_no);

			return cmd.ExecuteNonQuery() > 0;
		}

		public DataTable GetPOPWO(string date, int process_id = 0)
		{
			SqlCommand cmd = new SqlCommand();
			string sql = $@"SELECT WO.WORK_ORDER_NO, WO.WORK_ORDER_DATE, WO.WORK_DATE, WO.RELEASE_NO, WO.RELEASE_SEQ, WO.QTY, PW.WORKER_ID
								, CONVERT(CHAR(5), WO.WORK_START_TIME, 108) WORK_START_TIME, CONVERT(CHAR(5), WO.WORK_FINISH_TIME, 108) WORK_FINISH_TIME
								, WO.FIRST_REGIST_TIME, WO.FIRST_REGIST_EMPLOYEE
								, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = WO.FIRST_REGIST_EMPLOYEE) FIRST_REGIST_EMPLOYEE_NAME
								, WO.FINAL_REGIST_TIME, WO.FINAL_REGIST_EMPLOYEE
								, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = WO.FINAL_REGIST_EMPLOYEE ) FINAL_REGIST_EMPLOYEE_NAME
								, WO.WORKER_ID, E.EMPLOYEE_NAME, WO.PRODUCT_ID, PD.PRODUCT_NAME, PD.PRODUCT_TACT_TIME, WO.WORK_ORDER_QUANTITY, PC.PROCESS_ID, PC.PROCESS_NAME, L.LINE_ID, L.LINE_NAME, F.FACTORY_ID, F.FACTORY_NAME
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
						   WHERE NOT EXISTS (SELECT 1 FROM TBL_RESULT_LOG WHERE WORK_ORDER_NO = WO.WORK_ORDER_NO)		
						   AND WORK_DATE = @WORK_DATE";

			if (process_id > 0)
			{ 
				sql += " AND PC.PROCESS_ID = @PROCESS_ID";
				cmd.Parameters.AddWithValue("@PROCESS_ID", process_id);
			}

			sql += " ORDER BY WO.WORK_ORDER_NO DESC";
			
			cmd.Parameters.AddWithValue("@WORK_DATE", date);
			cmd.CommandText = sql;
			cmd.Connection = conn;
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(cmd);

			da.Fill(dt);

			return dt;
		}

		public DataTable CheckBarcode()
		{
			string sql = @" SELECT work_order_no, work_date, product_name, employee_name, work_order_quantity
							FROM 
							(SELECT work_order_no, work_date
								  ,(SELECT product_name FROM TBL_PRODUCT WHERE product_id = W.product_id) product_name
								  ,(SELECT employee_name FROM TBL_EMPLOYEE WHERE P.employee_id = employee_id) employee_name
								  , work_order_quantity
							 FROM TBL_WORK_ORDER W INNER JOIN TBL_PROCESS_WORKER P ON W.worker_id = P.worker_id 
							) A";

			DataTable dt = new DataTable();

			using (SqlConnection con = new SqlConnection(this.ConnectionString))
			{
				con.Open();
				SqlDataAdapter da = new SqlDataAdapter(sql, con);
				da.Fill(dt);
				con.Close();

				return dt;
			}
		}

		public bool SaveResultUse(WorkOrderVO workOrderVO)
		{
			return NotSelectSPJ<WorkOrderVO>("SP_SAVE_RESULT_USE", workOrderVO, "Work_order_no", "Result_quantity", "Defective_quantity");
		}
		
	}
}
