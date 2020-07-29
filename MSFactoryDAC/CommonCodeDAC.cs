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
	public class CommonCodeDAC : SqlHelper
	{
		public DataSet GetAllCommonCodes()
		{
			string sql = @"SELECT SORT_ID + 'Y' FLAG, SORT_ID, SORT_NAME, NOTE FROM TBL_COMMON_GROUP WHERE SORT_ID = '';
						   SELECT COMMON_ID + 'Y' FLAG, COMMON_ID, SORT_ID, COMMON_NAME, NOTE FROM TBL_COMMON WHERE SORT_ID = ''";
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(ds);

			return ds;
		}

		public List<CommonCodeVO> GetCommonCodes(string sort_ids)
		{
			List<CommonCodeVO> list;
			string sql = @"SELECT C.COMMON_ID, C.SORT_ID, C.COMMON_NAME, C.NOTE, CG.SORT_NAME
						   FROM TBL_COMMON C
							   INNER JOIN TBL_COMMON_GROUP CG
								ON C.SORT_ID = CG.SORT_ID
						   WHERE C.SORT_ID IN (SELECT * FROM  SPLITSTRING(@SORT_IDS, '@'))";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@SORT_IDS", sort_ids);

			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				list = DataReaderMapToList<CommonCodeVO>(reader);
			}

			return list;
		}

		public bool SaveCommonGroups(DataTable commonGroupDt)
		{
			SqlCommand cmd = new SqlCommand("SP_SAVE_COMMON_GROUP", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@P_SORT_ID", SqlDbType.NVarChar, 20);
			cmd.Parameters.Add("@P_SORT_NAME", SqlDbType.NVarChar, 20);
			cmd.Parameters.Add("@P_NOTE", SqlDbType.NVarChar, 200);

			foreach (DataRow dr in commonGroupDt.Rows)
			{
				cmd.Parameters["@P_SORT_ID"].Value = dr["SORT_ID"].ToString();
				cmd.Parameters["@P_SORT_NAME"].Value = dr["SORT_NAME"].ToString();
				cmd.Parameters["@P_NOTE"].Value = dr["NOTE"].ToString();

				if (cmd.ExecuteNonQuery() == 0)
					return false;
			}

			return true;
		}

		public bool SaveCommonCodes(DataTable commonDt)
		{
			SqlCommand cmd = new SqlCommand("SP_SAVE_COMMON", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@P_COMMON_ID", SqlDbType.NVarChar, 20);
			cmd.Parameters.Add("@P_SORT_ID", SqlDbType.NVarChar, 20);
			cmd.Parameters.Add("@P_COMMON_NAME", SqlDbType.NVarChar, 20);
			cmd.Parameters.Add("@P_NOTE", SqlDbType.NVarChar, 200);

			foreach (DataRow dr in commonDt.Rows)
			{
				cmd.Parameters["@P_COMMON_ID"].Value = dr["COMMON_ID"].ToString();
				cmd.Parameters["@P_SORT_ID"].Value = dr["SORT_ID"].ToString();
				cmd.Parameters["@P_COMMON_NAME"].Value = dr["COMMON_NAME"].ToString();
				cmd.Parameters["@P_NOTE"].Value = dr["NOTE"].ToString();

				if (cmd.ExecuteNonQuery() == 0)
					return false;
			}

			return true;
		}

		public bool DeleteCommonGroup(string sort_id)
		{
			string sql = "DELETE FROM TBL_COMMON_GROUP WHERE SORT_ID = @SORT_ID";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@SORT_ID", sort_id);

			return cmd.ExecuteNonQuery() > 0;
		}

		public bool DeleteCommonCode(string common_id)
		{
			string sql = "DELETE FROM TBL_COMMON WHERE COMMON_ID = @COMMON_ID";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@COMMON_ID", common_id);

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
