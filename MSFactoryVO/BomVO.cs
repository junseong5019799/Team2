using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class ProductType
    {
        public string Member { get; set; }
    }
    public class BomVO
    {
        public int Product_ID { get; set; }
        public string Product_Group_Name { get; set; }
        public string Product_Name { get; set; }
        public string Product_Information { get; set; }
        public string Product_Unit { get; set; }
        public string Product_Note1 { get; set; }
        public string Product_Note2 { get; set; }
    }

    public class BOMInsertVO
    {
        //public int Higher_Product_ID { get; set; }
        //public int Lower_Product_ID { get; set; }
        public int Product_ID { get; set; }
        public int Bom_Use_Quantity { get; set; }
        public int Bom_Seq { get; set; }
        public char Bom_Use { get; set; }
        public DateTime First_Regist_Time { get; set; }
        public string First_Regist_Employee { get; set; }
        public DateTime Final_Regist_Time { get; set; }
        public string Final_Regist_Employee { get; set; }
    }

    public class ProductInsertVO
    {
        public int Product_ID { get; set; }
        public int Product_Group_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Information { get; set; }
        public string Product_Unit { get; set; }
        public int Product_Standards { get; set; }
        public string Product_Note1 { get; set; }
        public string Product_Note2 { get; set; }
        public int Product_Seq { get; set; }
        public char Product_Use { get; set; }
        public DateTime First_Regist_Time { get; set; }
        public string First_Regist_Employee { get; set; }
        public DateTime Final_Regist_Time { get; set; }
        public string Final_Regist_Employee { get; set; }
    }

    public class GroupComboVO
    {
        public int Product_Group_Id { get; set; }
        public string Product_Group_Name { get; set; }
    }

    public class SendInfoVO
    {
        public bool UseCheck { get; set; }
        public string ProductName { get; set; }
        public string ProductGroup { get; set; }
        public int ProductGroupNum { get; set; }
    }
}
