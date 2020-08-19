using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactoryPOP.Services
{
	public class WorkOrderService
	{
		public DataTable GetAllWorkOrders(WorkOrderVO workOrderVO = null)
		{
			using (WorkOrderDAC workOrderDAC = new WorkOrderDAC())
			{
				return workOrderDAC.GetAllWorkOrders(workOrderVO);
			}
		}

		public WorkOrderVO GetWorkOrder(int work_order_no)
		{
			using (WorkOrderDAC workOrderDAC = new WorkOrderDAC())
			{
				return workOrderDAC.GetWorkOrder(work_order_no);
			}
		}

		public DataTable GetToDoes()
		{
			using (WorkOrderDAC workOrderDAC = new WorkOrderDAC())
			{
				return workOrderDAC.GetToDoes();
			}
		}

		public bool SaveWorkOrder(WorkOrderVO workOrderVO)
		{
			using (WorkOrderDAC workOrderDAC = new WorkOrderDAC())
			{
				return workOrderDAC.SaveWorkOrder(workOrderVO);
			}
		}

		public bool DeleteWorkOrder(string work_order_no)
		{
			using (WorkOrderDAC workOrderDAC = new WorkOrderDAC())
			{
				return workOrderDAC.DeleteWorkOrder(work_order_no);
			}
		}
	}
}
