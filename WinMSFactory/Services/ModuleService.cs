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
	public class ModuleService
	{
		public DataTable GetAllModules()
		{
			using (ModuleDAC moduleDAC = new ModuleDAC())
			{
				return moduleDAC.GetAllModules();
			}
		}

		internal DataTable GetModules(int app_id)
		{
			using (ModuleDAC moduleDAC = new ModuleDAC())
			{
				return moduleDAC.GetModules(app_id);
			}
		}

		public ModuleVO GetModule(int module_id)
		{
			using (ModuleDAC moduleDAC = new ModuleDAC())
			{
				return moduleDAC.GetModule(module_id);
			}
		}

		public bool SaveModule(ModuleVO moduleVO)
		{
			using (ModuleDAC moduleDAC = new ModuleDAC())
			{
				return moduleDAC.SaveModule(moduleVO);
			}
		}

		public bool DeleteModule(string module_id)
		{
			using (ModuleDAC moduleDAC = new ModuleDAC())
			{
				return moduleDAC.DeleteModule(module_id);
			}
		}
	}
}
