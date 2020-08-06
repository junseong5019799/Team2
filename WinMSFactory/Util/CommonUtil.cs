using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
	/// <summary>
	// 확장 메서드
	/// </summary>
    public static class CommonUtil
    {
		// Convert.To~ 대신 사용

		public static int ToInt(this object obj)
		{
			return Convert.ToString(obj).ToInt();
		}

		public static int ToInt(this string str)
		{
			int n;

			if (!int.TryParse(str, out n))
				n = 0;

			return n;
		}

		public static bool ToBool(this object obj)
		{
			return Convert.ToString(obj).ToBool();
		}

		public static bool ToBool(this string str)
		{
			bool flag;

			return bool.TryParse(str, out flag) && flag;
		}
	}
}
