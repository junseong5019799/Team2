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
        // GET: Order
        public ActionResult OrderList(string ProductName="")
        {
            OrderListDAC dac = new OrderListDAC();

            var SortedList = (from sorted in dac.AllOrderList()
                              where sorted.Product_Name.Contains(ProductName)
                              select sorted).ToList();

            OrderListViewModel Model = new OrderListViewModel();

            Model.OrderLists = SortedList;
            

            return View(Model);
        }

        public ActionResult ReleaseList(string ProductName = "")
        {
            OrderListDAC dac = new OrderListDAC();

            var SortedList = (from sorted in dac.AllReleaseList()
                              where sorted.Product_Name.Contains(ProductName)
                              select sorted).ToList();

            OrderListViewModel Model = new OrderListViewModel();
            Model.OrderLists = SortedList;
            return View(Model);
        }
    }
}