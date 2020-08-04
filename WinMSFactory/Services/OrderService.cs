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

        public DataTable GetInOutList()
        {
            return dac.GetInOutList();
        }

        public List<InOutVO> GetInOutListBinding()
        {
            return dac.GetInOutListBinding();
        }

        public DataTable GetWareHouseList()
        {
            return dac.GetWareHouseList();
        }

        public DataTable GetWareHouseDetail(int order_no)
        {
            return dac.GetWareHouseDetail(order_no);
        }

        public bool InsertOrder(OrderVO order)
        {
            return dac.InsertOrder(order);
        }

        public bool UpdateOrderDate(DateTime dt, int release_no)
        {
            return dac.UpdateOrderDate(dt, release_no);
        }

        public bool InsertWareHouse(WareHouseVO vo)
        {
            return dac.InsertWareHouse(vo);
        }

     
    }
}
