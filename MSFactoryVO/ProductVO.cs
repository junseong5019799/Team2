using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class ProductVO
    {

        public int Product_ID { get; set; }
        public string Product_Group_Name{ get; set; }
        public string Product_Name { get; set; }
        public string Product_Information { get; set; }
        public string Product_Unit { get; set; }
        public int Product_Standards { get; set; }
        public string Product_Note1 { get; set; }
        public string Product_Note2 { get; set; }
        public DateTime First_Regist_Time { get; set; }
        public string First_Regist_Employee { get; set; }
        public DateTime Final_Regist_Time { get; set; }
        public string Final_Regist_Employee { get; set; }
        public string Product_Use { get; set; }
        public string Bom_Exists { get; set; }
        public int Bom_Seq { get; set; }
        public int Product_Tact_Time { get; set; }
        public int Product_Lead_Time { get; set; }
    }

    public class ProductPriceManageVO
    {

        public int Material_Price_Code { get; set; }
        public int Company_ID { get; set; } // 등록할 때 사용
        public int Product_ID { get; set; } // 등록할 때 사용
        public string Company_Name { get; set; }
        public string Product_Name { get; set; }
        public string Product_Information { get; set; }
        public string Product_Unit { get; set; }
        public int Material_Current_Price { get; set; }
        public string Material_Current_Price_String { get; set; }
        public int Material_Previous_Price { get; set; }
        public string Material_Previous_Price_String { get; set; }
        public DateTime Start_Date { get; set; }
        public string Start_Date_String { get; set; }
        public DateTime? End_Date { get; set; }
        public string End_Date_String { get; set; }
        public string Note { get; set; }

    }

    public class ProductSimpleVO
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
    }
}
