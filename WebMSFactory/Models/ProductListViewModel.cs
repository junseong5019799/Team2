using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMSFactory
{
    public class ProductListViewModel
    {
        public List<string> ComboList { get; set; }
        public List<ProductList> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}