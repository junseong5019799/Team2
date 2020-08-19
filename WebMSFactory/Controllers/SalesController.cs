using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebMSFactory.Models;

namespace WebMSFactory.Controllers
{
    public class SalesController : Controller
    {
        // GET: SalesChart
        public ActionResult Chart(int Year = 2020)
        {
            PriceProductDAC dac = new PriceProductDAC();

            List<PriceProductList> lists = dac.TotalSales(Year);

            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            int j = 0;
            // 1월부터 12월까지 표시
            for(int i = 1; i<=12; i++)
            {
                if(lists.Find(p => p.Mon == i) == null) 
                    sb.Append(0 + ",");

                else if (lists.Find(p => p.Mon == i).Mon.Equals(i))
                {
                    sb.Append(lists[j].Total_Price + ",");
                    j++;
                }
                    
            }
            int lastindex = sb.ToString().LastIndexOf(',');

            string Result = sb.ToString().Substring(0,lastindex) + "]";

            ChartModel model = new ChartModel
            {
                DataString = Result,
                MainString = "매출현황",
                Year = Year
            };

            // ex) [0,0,0,1,3,4,5,8,9,1,3,7] 방식으로 나옴
            return View(model);
        }
    }
}