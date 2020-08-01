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

        public DataTable GetOrderList()
        {
            return dac.GetOrderList();
        }

        public bool InsertOrder(OrderVO order)
        {
            return dac.InsertOrder(order);
        }

        public bool UpdateOrderDate(DateTime dt, int release_no)
        {
            return dac.UpdateOrderDate(dt, release_no);
        }
    }
}
