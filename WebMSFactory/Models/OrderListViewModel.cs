using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMSFactory
{
    public class OrderListViewModel
    {
        public List<OrderModel> OrderLists { get; set; }
        public List<string> ComboLists { get; set; }
    }
}