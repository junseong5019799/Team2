using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMSFactory
{
    public class ProductList
    {
        public int Num { get; set; }
        public int Product_ID { get; set; }
        public string Product_Group_Name { get; set; }
        public string Product_Name { get; set; }
        public string Product_Information { get; set; }
        public string Product_Unit { get; set; }
        public string Product_Standards { get; set; }
        public string Product_Note1 { get; set; }
        public string Product_Note2 { get; set; }
        public int Product_Lead_Time { get; set; }
        public int Product_Tact_Time { get; set; }
        public string Product_Use { get; set; }
        public string Bom_Use_Quantity { get; set; }
        public int LV { get; set; }
    }
}