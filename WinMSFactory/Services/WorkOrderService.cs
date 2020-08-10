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
	public class WorkOrderService
	{
		public DataTable GetAllWorkOrdes(WorkOrderVO workOrderVO)
		{
			using (WorkOrderDAC workOrderDAC = new WorkOrderDAC())
			{
				return workOrderDAC.GetAllWorkOrdes(workOrderVO);
			}
		}

		public WorkOrderVO GetWorkOrde(int work_order_no)
		{
			using (WorkOrderDAC workOrderDAC = new WorkOrderDAC())
			{
				return workOrderDAC.GetWorkOrde(work_order_no);
			}
		}

		public bool SaveWorkOrde(WorkOrderVO workOrderVO)
		{
			using (WorkOrderDAC workOrderDAC = new WorkOrderDAC())
			{
				return workOrderDAC.SaveWorkOrde(workOrderVO);
			}
		}

		public bool DeleteWorkOrde(string work_order_no)
		{
			using (WorkOrderDAC workOrderDAC = new WorkOrderDAC())
			{
				return workOrderDAC.DeleteWorkOrde(work_order_no);
			}
		}
	}
}
