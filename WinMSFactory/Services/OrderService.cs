﻿using System;
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

        public DataTable CheckBarcode()
        {
            return dac.CheckBarcode();
        }

        public List<InOutVO> GetInOutListBinding()
        {
            return dac.GetInOutListBinding();
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

        public DataTable GetWareHouseDetail(int order_no, int product_id)
        {
            return dac.GetWareHouseDetail(order_no, product_id);
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
