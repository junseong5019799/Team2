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
        StringBuilder sb = new StringBuilder();
        StringBuilder ProdSB = new StringBuilder();
        StringBuilder ProdSBNum = new StringBuilder();
        // GET: SalesChart
        public ActionResult Chart(int Year = 2020)
        {
            PriceProductDAC dac = new PriceProductDAC();

            List<PriceProductList> SalesList = dac.TotalSales(Year);
            List<PriceProductList> ProductList = dac.TotalProducts(Year);

            sb.Append("[");
            //ProdSB.Append("[");
            ProdSBNum.Append("[");
            int j = 0;
            // 1월부터 12월까지 표시
            for (int i = 1; i <= 12; i++)
            {
                if (SalesList.Find(p => p.Mon == i) == null)
                    sb.Append(0 + ",");

                else if (SalesList.Find(p => p.Mon == i).Mon.Equals(i))
                {
                    sb.Append(SalesList[j].Total_Price + ",");
                    j++;
                }
            }

            for(int i = 0; i<ProductList.Count; i++)
            { 
                if(i == ProductList.Count-1)
                {
                    ProdSB.Append("" + ProductList[i].Product_Name + "");
                    ProdSBNum.Append(ProductList[i].Product_Count + "]");
                    break;
                }
                ProdSB.Append("" + ProductList[i].Product_Name + ",");
                ProdSBNum.Append(ProductList[i].Product_Count + ",");
            }

            int lastindex = sb.ToString().LastIndexOf(',');

            string Result = sb.ToString().Substring(0,lastindex) + "]";

            ChartModel model = new ChartModel
            {
                // 그래프 차트
                DataString = Result,
                MainString = "매출현황",
                Year = Year,
                // 도넛 차트
                DoughnutDataString = ProdSB.ToString(),
                Product_Count = ProdSBNum.ToString()
            };

            // ex) [0,0,0,1,3,4,5,8,9,1,3,7] 방식으로 나옴
            return View(model);
        }
    }
}