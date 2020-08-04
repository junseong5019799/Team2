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
	public class AuthorityDAC : SqlHelper
	{
		public DataTable GetAllAuthorityGroups()
		{
			string sql = @"SELECT ATH_GRP_ID, ATH_GRP_NAME, ATH_GRP_EXPL, ATH_GRP_SEQ, ATH_GRP_USE, FIRST_REGIST_EMPLOYEE, FINAL_REGIST_EMPLOYEE							
									, FIRST_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = AG.FIRST_REGIST_EMPLOYEE) FIRST_REGIST_EMPLOYEE_NAME
									, FINAL_REGIST_TIME, (SELECT EMPLOYEE_NAME FROM TBL_EMPLOYEE WHERE EMPLOYEE_ID = AG.FINAL_REGIST_EMPLOYEE ) FINAL_REGIST_EMPLOYEE_NAME
						   FROM TBL_AUTHORITY_GROUP AG
						   ORDER BY ATH_GRP_SEQ";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(dt);

			return dt;
		}

		public AuthorityGroupVO GetAuthorityGroup(int ath_grp_id)
		{
			string sql = @"SELECT ATH_GRP_ID, ATH_GRP_NAME, ATH_GRP_EXPL, ATH_GRP_SEQ, ATH_GRP_USE
						   FROM TBL_AUTHORITY_GROUP
						   WHERE ATH_GRP_ID = @ATH_GRP_ID";
			return SqlExecutionJ<AuthorityGroupVO>(sql, new AuthorityGroupVO { Ath_grp_id = ath_grp_id })?[0];
		}

		public DataTable GetProgramAths(int ath_grp_id)
		{
			string sql = @"SELECT PA.ATH_GRP_ID, AG.ATH_GRP_NAME, PA.PROG_ID, P.PROG_NAME, P.PROG_FORM_NAME, M.MODULE_ID, M.MODULE_NAME
									, PA.PROG_SEARCH, PA.PROG_ADD, PA.PROG_DELECT, PA.PROG_SAVE, PA.PROG_EXCEL, PROG_PRINT, PROG_CLEAR
						   FROM TBL_PROGRAM_ATH PA
								INNER JOIN TBL_AUTHORITY_GROUP AG
									ON AG.ATH_GRP_ID = PA.ATH_GRP_ID
								INNER JOIN TBL_PROGRAM P
									ON P.PROG_ID = PA.PROG_ID
								INNER JOIN TBL_MODULE M
									ON M.MODULE_ID = P.MODULE_ID
						   WHERE PA.ATH_GRP_ID = @ATH_GRP_ID   
						   ORDER BY M.MODULE_SEQ, P.PROG_SEQ";
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);
			da.SelectCommand.Parameters.AddWithValue("@ATH_GRP_ID", ath_grp_id);

			da.Fill(dt);

			return dt;
		}

		public ProgramAthVO GetProgramAth(int ath_grp_id, int prog_id)
		{
			string sql = @"SELECT PA.ATH_GRP_ID, PA.PROG_ID, PA.PROG_SEARCH, PA.PROG_ADD, PA.PROG_DELECT
								, PA.PROG_SAVE, PA.PROG_EXCEL, PA.PROG_PRINT, PA.PROG_CLEAR, P.MODULE_ID
						   FROM TBL_PROGRAM_ATH PA
								INNER JOIN TBL_PROGRAM P
									ON P.PROG_ID = PA.PROG_ID
						   WHERE PA.ATH_GRP_ID = @ATH_GRP_ID
						   AND PA.PROG_ID = @PROG_ID";
			return SqlExecutionJ<ProgramAthVO>(sql, new ProgramAthVO { Ath_grp_id = ath_grp_id, Prog_id = prog_id })?[0];
		}

		public bool SaveAuthorityGroup(AuthorityGroupVO authorityGroupVO)
		{
			return NotSelectSPJ<AuthorityGroupVO>("SP_SAVE_AUTHORITY_GROUP", authorityGroupVO, "Ath_grp_id", "Ath_grp_name", "Ath_grp_expl", "Ath_grp_seq", "Ath_grp_use", "Regist_employee");
		}

		public bool SaveProgramAth(ProgramAthVO programAthVO)
		{
			return NotSelectSPJ<ProgramAthVO>("SP_SAVE_PROGRAM_ATH", programAthVO, "Ath_grp_id", "Prog_id", "Prog_search", "Prog_add", "Prog_delect", "Prog_save", "Prog_excel", "Prog_print", "Prog_clear");
		}

		public bool DeleteAuthorityGroup(string ath_grp_id)
		{
			string[] ath_grp_ids = ath_grp_id?.TrimEnd('@')?.Split('@');

			if (ath_grp_ids?.Length > 0)
			{
				SqlTransaction sTran = null;

				try
				{
					sTran = conn.BeginTransaction();
					string sql1 = "DELETE FROM TBL_AUTHORITY_GROUP WHERE ATH_GRP_ID = @ATH_GRP_ID";
					string sql2 = "DELETE FROM TBL_PROGRAM_ATH WHERE ATH_GRP_ID = @ATH_GRP_ID";
					SqlCommand cmd = new SqlCommand();
					cmd.Connection = conn;
					cmd.Transaction = sTran;
					cmd.Parameters.Add("@ATH_GRP_ID", SqlDbType.Int);

					foreach (var elem in ath_grp_ids)
					{
						cmd.Parameters["@ATH_GRP_ID"].Value = int.Parse(elem);
						cmd.CommandText = sql1;
						cmd.ExecuteNonQuery();

						cmd.CommandText = sql2;
						cmd.ExecuteNonQuery();
					}

					sTran.Commit();
					return true;
				}
				catch (Exception err)
				{
					sTran?.Rollback();
					throw err;
				}
			}

			return false;
		}

		public bool DeleteProgramAth(int ath_grp_id, string prog_id)
		{
			string sql = "DELETE FROM TBL_PROGRAM WHERE ATH_GRP_ID = @ATH_GRP_ID AND PROG_ID IN (SELECT * FROM  SPLITSTRING(@PROG_ID, '@'))";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@ATH_GRP_ID", ath_grp_id);
			cmd.Parameters.AddWithValue("@PROG_ID", prog_id);

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
