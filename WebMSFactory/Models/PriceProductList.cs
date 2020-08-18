using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMSFactory
{
    public class PriceProductList
    {
        public int Product_ID { get; set; }
        public string Company_Name { get; set; }
        public string Product_Name { get; set; }
        public string Product_Group_Name { get; set; }
        public string Product_Information { get; set; }
        public string Product_Unit { get; set; }
        public string Material_Current_Price_String { get; set; }
        public string Material_Previous_Price_String { get; set; }
        public string Sell_Current_Price_String { get; set; }
        public string Sell_Previous_Price_String { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Start_Date_String { get; set; }
        public string End_Date_String { get; set; }
        public string Note { get; set; }
        public int Sell_Price_Code { get; set; }
        public int Total_Price { get; set; }
        public int Mon { get; set; } // 차트의 월별 표시
    }
}