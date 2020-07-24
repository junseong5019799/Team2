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
	}
}
