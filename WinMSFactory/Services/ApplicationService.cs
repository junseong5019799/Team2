using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
	public class ApplicationService
	{
		public DataTable GetAllApplications(bool isUse = false)
		{
			using (ApplicationDAC applicationDAC = new ApplicationDAC())
			{
				return applicationDAC.GetAllApplications(isUse);
			}
		}

		public ApplicationVO GetApplication(int app_id)
		{
			using (ApplicationDAC applicationDAC = new ApplicationDAC())
			{
				return applicationDAC.GetApplication(app_id);
			}
		}

		public bool SaveApplication(ApplicationVO applicationVO)
		{
			using (ApplicationDAC applicationDAC = new ApplicationDAC())
			{
				return applicationDAC.SaveApplication(applicationVO);
			}
		}

		public bool DeleteApplication(string app_id)
		{
			using (ApplicationDAC applicationDAC = new ApplicationDAC())
			{
				return applicationDAC.DeleteApplication(app_id);
			}
		}
	}
}
