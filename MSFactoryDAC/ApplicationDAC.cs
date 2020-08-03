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
	public class ApplicationDAC : SqlHelper
	{
		public DataTable GetAllApplications(bool isUse = false)
		{
			string sql = @"SELECT APP_ID, APP_NAME, APP_SEQ, APP_USE
									, FIRST_REGIST_TIME, FIRST_REGIST_EMPLOYEE
									, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = FIRST_REGIST_EMPLOYEE) FIRST_REGIST_EMPLOYEE_NAME
									, FINAL_REGIST_TIME, FINAL_REGIST_EMPLOYEE
									, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = FINAL_REGIST_EMPLOYEE ) FINAL_REGIST_EMPLOYEE_NAME
						   FROM TBL_APPLICATION";

			if (isUse)
				sql += "WHERE APP_USE = 'Y'"

			sql += " ORDER BY APP_SEQ";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(dt);

			return dt;
		}
		
		public ApplicationVO GetApplication(int app_id)
		{
			string sql = @"SELECT APP_ID, APP_NAME, APP_SEQ, APP_USE
						   FROM TBL_APPLICATION
						   WHERE APP_ID = @APP_ID";
			return SqlExecutionJ<ApplicationVO>(sql, new ApplicationVO { App_id = app_id })?[0];
		}

		public bool SaveApplication(ApplicationVO applicationVO)
		{
			return NotSelectSPJ<ApplicationVO>("SP_SAVE_APPLICATION", applicationVO, "App_id", "App_name", "App_seq", "App_use", "Regist_employee");
		}

		public bool DeleteApplication(string app_id)
		{
			string sql = "DELETE FROM TBL_APPLICATION WHERE APP_ID IN (SELECT * FROM  SPLITSTRING(@APP_ID, '@'))";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@APP_ID", app_id);

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
