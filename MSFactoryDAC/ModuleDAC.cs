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
	public class ModuleDAC : SqlHelper
	{
		public DataTable GetAllModules()
		{
			string sql = @"SELECT MODULE_ID, APP_ID, (SELECT APP_NAME FROM TBL_APPLICATION WHERE APP_ID = M.APP_ID) APP_NAME
									, MODULE_NAME, MODULE_SEQ, MODULE_USE
									, FIRST_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = FIRST_REGIST_EMPLOYEE) FIRST_REGIST_EMPLOYEE_NAME
									, FINAL_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = FINAL_REGIST_EMPLOYEE ) FINAL_REGIST_EMPLOYEE_NAME
						   FROM TBL_MODULE M             
						   ORDER BY MODULE_SEQ";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(dt);

			return dt;
		}

		public DataTable GetModules(int app_id)
		{
			string sql = @"SELECT MODULE_ID, APP_ID, (SELECT APP_NAME FROM TBL_APPLICATION WHERE APP_ID = M.APP_ID) APP_NAME
									, MODULE_NAME, MODULE_SEQ, MODULE_USE
									, FIRST_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = FIRST_REGIST_EMPLOYEE) FIRST_REGIST_EMPLOYEE_NAME
									, FINAL_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = FINAL_REGIST_EMPLOYEE ) FINAL_REGIST_EMPLOYEE_NAME
						   FROM TBL_MODULE M       
						   WHERE APP_ID = @APP_ID
						   AND MODULE_USE = 'Y'
						   ORDER BY MODULE_SEQ";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);
			da.SelectCommand.Parameters.AddWithValue("@APP_ID", app_id);

			da.Fill(dt);

			return dt;
		}

		public ModuleVO GetModule(int module_id)
		{
			string sql = @"SELECT MODULE_ID, APP_ID, MODULE_NAME, MODULE_SEQ, MODULE_USE
						   FROM TBL_MODULE
						   WHERE MODULE_ID = @MODULE_ID";
			return SqlExecutionJ<ModuleVO>(sql, new ModuleVO { Module_id = module_id })?[0];
		}

		public bool SaveModule(ModuleVO moduleVO)
		{
			return NotSelectSPJ<ModuleVO>("SP_SAVE_MODULE", moduleVO, "Module_id", "App_id", "Module_name", "Module_seq", "Module_use", "Regist_employee");
		}

		public bool DeleteModule(string module_id)
		{
			string sql = "DELETE FROM TBL_MODULE WHERE MODULE_ID IN (SELECT * FROM  SPLITSTRING(@MODULE_ID, '@'))";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@MODULE_ID", module_id);

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
