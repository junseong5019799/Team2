using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebMSFactory.DAC
{
	public class EmployeeDAC
	{
		string connStr = WebConfigurationManager.ConnectionStrings["DBSettings"].ConnectionString;

		public EmployeeVO GetLoginEmployee(string employee_id, string employee_pwd)
		{
			EmployeeVO employeeVO = null;
			string sql = @"SELECT EMPLOYEE_ID, CORPORATION_ID, ATH_GRP_ID, EMPLOYEE_NAME, EMPLOYEE_USE
						   FROM TBL_EMPLOYEE
						   WHERE EMPLOYEE_ID = @EMPLOYEE_ID
						   AND EMPLOYEE_PWD = @EMPLOYEE_PWD";
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = new SqlConnection(connStr);
			cmd.CommandText = sql;
			cmd.Parameters.AddWithValue("@EMPLOYEE_ID", employee_id);
			cmd.Parameters.AddWithValue("@EMPLOYEE_PWD", employee_pwd);

			cmd.Connection.Open();
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				employeeVO = new EmployeeVO
				{
					Employee_id = reader["EMPLOYEE_ID"].ToString(),
					Corporation_id = Convert.ToInt32(reader["CORPORATION_ID"]),
					Ath_grp_id = Convert.ToInt32(reader["ATH_GRP_ID"]),
					Employee_name = reader["EMPLOYEE_NAME"].ToString(),
					Employee_use = reader["EMPLOYEE_USE"].ToString()
				};
			}

			cmd.Connection.Close();

			return employeeVO;
		}
	}
}