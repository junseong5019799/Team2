using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMSFactory
{
    public class PriceListViewModel
    {
        public List<string> comboList { get; set; }
        public List<PriceProductList> ProductPrice { get; set; }
        public List<PriceProductList> SellPrice { get; set; }
    }
}