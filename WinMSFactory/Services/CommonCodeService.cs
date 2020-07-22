using MSFactoryDAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
	public class CommonCodeService
	{
		public DataSet GetCommonCodes()
		{
			DataSet ds;

			using (CommonCodeDAC dac = new CommonCodeDAC())
			{
				ds = dac.GetCommonCodes();
			}

			return ds;
		}
	}
}
