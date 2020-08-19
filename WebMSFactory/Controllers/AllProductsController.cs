using MSFactoryDAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
namespace WebMSFactory.Controllers
{
    public class AllProductsController : Controller
    {
        ProductDAC dac = new ProductDAC();
        List<ProductList> NullList = new List<ProductList>();
        [HttpGet]
        public ActionResult Search(string Category = "전체", string ProductName = "", int page = 1)
        {
            int pageSize = 10000;
            
            DataTable dt = dac.SelectAllProducts(Category, page, pageSize);

            List<ProductList> list = SqlHelper.ConvertDataTableToList<ProductList>(dt);

            var SortedList = (from items in list
                              where items.Product_Name.Contains(ProductName)
                              select items).ToList();


            ProductListViewModel model = new ProductListViewModel
            {
                ComboList = dac.GetComboList(),
                Products = SortedList,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = dac.GetTotalCount(Category)
                },
                CurrentCategory = Category
            };

            return View(model);
        }

        public ActionResult DetailProduct(int ProductID)
        {
            ProductListViewModel model = new ProductListViewModel();

            model.ProductDetail = dac.DetailProduct(ProductID);

            List<ProductList> ForwardBom = dac.ProductBOM(true, ProductID);
            List<ProductList> ReverseBom = dac.ProductBOM(false, ProductID);

            if (ForwardBom != null)
                model.ForwardBom = ForwardBom;
            else
                model.ForwardBom = NullList;

            if (ReverseBom != null)
                model.ReverseBom = ReverseBom;
            else
                model.ReverseBom = NullList;

            return View(model);
        }
    }
}