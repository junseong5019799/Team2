using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSFactoryDAC;
using MSFactoryVO;

namespace WinMSFactory.Services
{  
    public class OrderService
    {
        OrderDAC dac = new OrderDAC();

        public List<OrderVO> GetCompanyList()
        {
            return dac.GetCompanyList();
        }

        public DataTable GetOrderPlanList()
        {
            return dac.GetOrderPlanList();
        }
    }
}
