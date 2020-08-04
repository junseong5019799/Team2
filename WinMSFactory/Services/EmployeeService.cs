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
	public class EmployeeService
	{
		public DataTable GetAllEmployees()
		{
			using (EmployeeDAC employeeDAC = new EmployeeDAC())
			{
				return employeeDAC.GetAllEmployees();
			}
		}

		public EmployeeVO GetEmployee(string employee_id)
		{
			using (EmployeeDAC employeeDAC = new EmployeeDAC())
			{
				return employeeDAC.GetEmployee(employee_id);
			}
		}

		public EmployeeVO GetLoginEmployee(string employee_id, string employee_pwd)
		{
			using (EmployeeDAC employeeDAC = new EmployeeDAC())
			{
				return employeeDAC.GetLoginEmployee(employee_id, employee_pwd);
			}
		}

		public bool SaveEmployee(EmployeeVO employeeVO)
		{
			using (EmployeeDAC employeeDAC = new EmployeeDAC())
			{
				return employeeDAC.SaveEmployee(employeeVO);
			}
		}

		public bool DeleteEmployee(string employee_id)
		{
			using (EmployeeDAC employeeDAC = new EmployeeDAC())
			{
				return employeeDAC.DeleteEmployee(employee_id);
			}
		}
	}
}
