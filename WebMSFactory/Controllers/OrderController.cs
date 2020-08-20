using MSFactoryDAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace WebMSFactory.Controllers
{
    public class OrderController : Controller
    {
        List<OrderModel> SortedList = new List<OrderModel>();
        DateTime startDate = new DateTime();
        DateTime endDate = new DateTime();

        // GET: Order
        public ActionResult OrderList(string StartDate = "", string EndDate = "", string ProductName="")
        {
            if (StartDate != "")
                startDate = Convert.ToDateTime(StartDate);

            if (EndDate != "")
                endDate = Convert.ToDateTime(EndDate);

            OrderListDAC dac = new OrderListDAC();

            if (StartDate != "" || EndDate != "")
                SortedList = (from sorted in dac.AllOrderList()
                              where sorted.Product_Name.Contains(ProductName) && Convert.ToDateTime(sorted.Order_Request_Date_String).AddDays(-1) >= startDate
                                    && Convert.ToDateTime(sorted.Order_Request_Date_String) <= endDate
                              select sorted).ToList();
            else
                SortedList = (from sorted in dac.AllOrderList()
                              where sorted.Product_Name.Contains(ProductName)
                              select sorted).ToList();

            OrderListViewModel Model = new OrderListViewModel();

            Model.OrderLists = SortedList;
            

            return View(Model);
        }

        public ActionResult ReleaseList(string StartDate = "", string EndDate = "", string ProductName = "")
        {
            if (StartDate != "")
                 startDate = Convert.ToDateTime(StartDate);

            if(EndDate != "")
                endDate = Convert.ToDateTime(EndDate);

            OrderListDAC dac = new OrderListDAC();

            if(StartDate != "" || EndDate != "")
                SortedList = (from sorted in dac.AllReleaseList()
                              where sorted.Product_Name.Contains(ProductName) && Convert.ToDateTime(sorted.Release_Date).AddDays(-1) >= startDate 
                                    && Convert.ToDateTime(sorted.Release_Date) <= endDate
                              select sorted).ToList();

            else
                SortedList = (from sorted in dac.AllReleaseList()
                              where sorted.Product_Name.Contains(ProductName)
                              select sorted).ToList();

            OrderListViewModel Model = new OrderListViewModel();
            Model.OrderLists = SortedList;

            return View(Model);
        }
    }
}