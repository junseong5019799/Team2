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
		public DataSet GetCommonCodes()
		{
			string sql = @"SELECT SORT_ID, SORT_NAME, NOTE, 'Y' FLAG FROM TBL_COMMON_GROUP;
						   SELECT COMMON_ID, SORT_ID, COMMON_NAME, NOTE, 'Y' FLAG FROM TBL_COMMON";
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.Fill(ds);

			return ds;
		}
	}
}
