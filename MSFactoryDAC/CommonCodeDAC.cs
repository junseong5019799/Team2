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
			string sql = @"SELECT SORT_ID, SORT_NAME, NOTE, 'Y' FLAG FROM TBL_COMMON_GROUP;
						   SELECT COMMON_ID, SORT_ID, COMMON_NAME, NOTE, 'Y' FLAG FROM TBL_COMMON";
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
	}
}
