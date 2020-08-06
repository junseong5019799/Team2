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
	public class EmployeeDAC : SqlHelper
	{
		public DataTable GetAllEmployees()
		{
			string sql = @"SELECT E.EMPLOYEE_ID, E.CORPORATION_ID, C.CORPORATION_NAME, E.EMPLOYEE_NAME, E.EMPLOYEE_USE
									, E.ATH_GRP_ID, ISNULL((SELECT ATH_GRP_NAME FROM TBL_AUTHORITY_GROUP WHERE ATH_GRP_ID = E.ATH_GRP_ID), '권한그룹 없음') ATH_GRP_NAME
									, E.FIRST_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = E.FIRST_REGIST_EMPLOYEE) FIRST_REGIST_EMPLOYEE_NAME
									, E.FINAL_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = E.FINAL_REGIST_EMPLOYEE) FINAL_REGIST_EMPLOYEE_NAME
						   FROM TBL_EMPLOYEE E
								INNER JOIN TBL_CORPORATION C
									ON E.CORPORATION_ID = C.CORPORATION_ID
						   ORDER BY E.EMPLOYEE_ID";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(dt);

			return dt;
		}

		public EmployeeVO GetEmployee(string employee_id)
		{
			string sql = @"SELECT EMPLOYEE_ID, CORPORATION_ID, ATH_GRP_ID, EMPLOYEE_NAME, EMPLOYEE_USE
						   FROM TBL_EMPLOYEE
						   WHERE EMPLOYEE_ID = @EMPLOYEE_ID";
			return SqlExecutionJ<EmployeeVO>(sql, new EmployeeVO { Employee_id = employee_id })?[0];
		}

		public EmployeeVO GetLoginEmployee(string employee_id, string employee_pwd)
		{
			string sql = @"SELECT EMPLOYEE_ID, CORPORATION_ID, ATH_GRP_ID, EMPLOYEE_NAME, EMPLOYEE_USE
						   FROM TBL_EMPLOYEE
						   WHERE EMPLOYEE_ID = @EMPLOYEE_ID
						   AND EMPLOYEE_PWD = @EMPLOYEE_PWD";
			EmployeeVO employeeVO = null;
			var list = SqlExecutionJ<EmployeeVO>(sql, new EmployeeVO { Employee_id = employee_id, Employee_pwd = employee_pwd });

			if (list?.Count > 0)
				employeeVO = list[0];

			return employeeVO;
		}

		public bool SaveEmployee(EmployeeVO employeeVO)
		{
			return NotSelectSPJ<EmployeeVO>("SP_SAVE_EMPLOYEE", employeeVO, "Employee_id", "Corporation_id", "Ath_grp_id", "Employee_name", "Employee_pwd", "Employee_use", "Regist_employee");
		}

		public bool DeleteEmployee(string employee_id)
		{
			string sql = "DELETE FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID IN (SELECT * FROM  SPLITSTRING(@EMPLOYEE_ID, '@'))";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@EMPLOYEE_ID", employee_id);

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
