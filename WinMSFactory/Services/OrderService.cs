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

        public DataTable GetOrderPlanList(int release_no)
        {
            return dac.GetOrderPlanList(release_no);
        }

        public List<OrderVO> GetOrderListByDate(string fromDate, string toDate)
        {
            return dac.GetOrderListByDate(fromDate, toDate);
        }
           
        public DataTable GetOrderList()
        {
            return dac.GetOrderList();
        }

        public DataTable GetInOutList()
        {
            return dac.GetInOutList();
        }

        public DataTable CheckBarcode()
        {
            return dac.CheckBarcode();
        }

        public List<InOutVO> GetInOutListBinding()
        {
            return dac.GetInOutListBinding();
        }

        public DataTable GetInOutListByGubun(string gubun)
        {
            return dac.GetInOutListByGubun(gubun);
        }

        public List<InOutVO> GetInOutByDate(string FromDate, string ToDate)
        {
            return dac.GetInOutByDate(FromDate, ToDate);
        }
         
        public List<CompanyVO> SelectCompanyBindingByType()
        {
            return dac.SelectCompanyBindingByType();
        }

        public DataTable Calculate_OrderPlan(int release_no, DateTime from, DateTime to)
        {
            return dac.Calculate_OrderPlan(release_no, from, to);
        }
        
        public DataTable GetWareHouseList()
        {
            return dac.GetWareHouseList();
        }
        public List<WareHouseVO> GetWareHouseByDate(string fromDate, string toDate)
        {
            return dac.GetWareHouseByDate(fromDate, toDate);
        }
        
        public DataTable GetWareHouseDetail(int order_no, int product_id)
        {
            return dac.GetWareHouseDetail(order_no, product_id);
        }

        public bool InsertOrder(List<OrderVO> olist, HashSet<int> companySet, string employee_id)
        {
            return dac.InsertOrder(olist, companySet, employee_id);
        }

        public bool UpdateOrderDate(DateTime dt, int release_no)
        {
            return dac.UpdateOrderDate(dt, release_no);
        }

        public bool UpdateReleaseRequestDate(DateTime dt, int release_no)
        {
            return dac.UpdateReleaseRequestDate(dt, release_no);
        }

        public bool InsertWareHouse(WareHouseVO vo)
        {
            return dac.InsertWareHouse(vo);
        }

     
    }
}
