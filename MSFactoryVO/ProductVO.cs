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
        public string Bom_Check { get; set; }


    }
}
