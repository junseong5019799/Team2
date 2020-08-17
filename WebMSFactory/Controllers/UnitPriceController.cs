using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace WebMSFactory.Controllers
{
    public class UnitPriceController : Controller
    {
        PriceListViewModel model = new PriceListViewModel();

        // 자재 단가 관리
        public ActionResult ProductPrice(string Name, string Category="전체")
        {
            PriceProductDAC dac = new PriceProductDAC();

            // 몇개 없으니 직접 추가함.
            List<string> comboList = new List<string>();
            comboList.Add("전체");
            comboList.Add("업체명");
            comboList.Add("제품명");

            model.comboList = comboList;

            if (Category == "전체")
                model.ProductPrice = (from items in dac.AllProductPriceList()
                                      where items.Product_Name.Contains(Name) || items.Company_Name.Contains(Name)
                                      select items).ToList();

            else if (Category == "업체명")
                model.ProductPrice = (from items in dac.AllProductPriceList()
                                      where items.Company_Name.Contains(Name)
                                      select items).ToList();

            else if (Category == "제품명")
                model.ProductPrice = (from items in dac.AllProductPriceList()
                                      where items.Product_Name.Contains(Name)
                                      select items).ToList();

            return View(model);
        }
        // 영업 단가 관리
        public ActionResult SellPrice(string Name)
        {
            PriceProductDAC dac = new PriceProductDAC();

            model.SellPrice = (from items in dac.AllSellPriceList()
                               where items.Product_Name.Contains(Name)
                               select items).ToList();

            return View(model);
        }
    }
}