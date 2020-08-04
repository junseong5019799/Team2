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
	public class ProgramDAC : SqlHelper
	{
		public DataTable GetAllPrograms()
		{
			string sql = @"SELECT PROG_ID, P.MODULE_ID, MODULE_NAME, PROG_NAME, PROG_EXPL, PROG_SEQ, PROG_USE
									, P.FIRST_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = P.FIRST_REGIST_EMPLOYEE) FIRST_REGIST_EMPLOYEE_NAME
									, P.FINAL_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = P.FINAL_REGIST_EMPLOYEE) FINAL_REGIST_EMPLOYEE_NAME
						   FROM TBL_PROGRAM P      
								INNER JOIN TBL_MODULE M
									ON P.MODULE_ID = M.MODULE_ID
						   ORDER BY MODULE_SEQ, PROG_SEQ";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(dt);

			return dt;
		}

		public DataTable GetPrograms(int module_id)
		{
			string sql = @"SELECT PROG_ID, MODULE_ID, (SELECT MODULE_NAME FROM TBL_MODULE WHERE MODULE_ID = P.MODULE_ID) MODULE_NAME
									, PROG_NAME, PROG_EXPL, PROG_SEQ, PROG_USE
									, FIRST_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = FIRST_REGIST_EMPLOYEE) FIRST_REGIST_EMPLOYEE_NAME
									, FINAL_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = FINAL_REGIST_EMPLOYEE ) FINAL_REGIST_EMPLOYEE_NAME
						   FROM TBL_PROGRAM P  
						   WHERE MODULE_ID = @MODULE_ID
						   AND PROG_USE = 'Y'
						   ORDER BY PROG_SEQ";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);
			da.SelectCommand.Parameters.AddWithValue("@MODULE_ID", module_id);

			da.Fill(dt);

			return dt;
		}

		public ProgramVO GetProgram(int prog_id)
		{
			string sql = @"SELECT PROG_ID, MODULE_ID, PROG_NAME, PROG_FORM_NAME, PROG_EXPL, PROG_SEQ, PROG_USE
						   FROM TBL_PROGRAM
						   WHERE PROG_ID = @PROG_ID";
			return SqlExecutionJ<ProgramVO>(sql, new ProgramVO { Prog_id = prog_id })?[0];
		}

		public bool SaveProgram(ProgramVO programVO)
		{
			return NotSelectSPJ<ProgramVO>("SP_SAVE_PROGRAM", programVO, "Prog_id", "Module_id", "Prog_name",
										   "Prog_form_name", "Prog_expl", "Prog_seq", "Prog_use", "Regist_employee");
		}

		public bool DeleteProgram(string prog_id)
		{
			string sql = "DELETE FROM TBL_PROGRAM WHERE PROG_ID IN (SELECT * FROM  SPLITSTRING(@PROG_ID, '@'))";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@PROG_ID", prog_id);

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
