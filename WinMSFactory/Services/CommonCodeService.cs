using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
	public class CommonCodeService
	{
		public DataSet GetAllCommonCodes()
		{
			DataSet ds;

			using (CommonCodeDAC dac = new CommonCodeDAC())
			{
				ds = dac.GetAllCommonCodes();
			}

			return ds;
		}

		public List<CommonCodeVO> GetCommonCodes(string sort_ids)
		{
			List<CommonCodeVO> list;

			using (CommonCodeDAC dac = new CommonCodeDAC())
			{
				list = dac.GetCommonCodes(sort_ids);
			}

			return list;
		}

		public bool SaveCommonCodes(DataTable commonGroupDt, DataTable commonDt)
		{
			bool flag = false;

			using (CommonCodeDAC dac = new CommonCodeDAC())
			{
				if (dac.SaveCommonGroups(commonGroupDt) && dac.SaveCommonCodes(commonDt))
					flag = true;
			}

			return flag;
		}

		public bool DeleteCommonGroup(string sort_id)
		{
			using (CommonCodeDAC dac = new CommonCodeDAC())
			{
				return dac.DeleteCommonGroup(sort_id);
			}
		}

		public bool DeleteCommonCode(string common_id)
		{
			using (CommonCodeDAC dac = new CommonCodeDAC())
			{
				return dac.DeleteCommonCode(common_id);
			}
		}
	}
}
