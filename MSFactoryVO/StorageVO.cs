using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class StorageVO // 창고
    {
        public int Storage_Id { get; set; }
        public int Factory_id { get; set; }
        public int Storage_Seq { get; set; }
        public DateTime First_regist_time { get; set; }
        public string First_regist_employee { get; set; }
        public DateTime Final_regist_time { get; set; }
        public string Final_regist_employee { get; set; }
        public int Product_Id { get; set; }
        public string Storage_Name { get; set; }
        public int Stock_No { get; set; }
        public string Product_Name { get; set; }
        public string Stock_Quantity { get; set; }
        public DateTime Stock_Regist_Date { get; set; }
        public string Product_Group_Name { get; set; }
        public string Storage_Use { get; set; }
        public string Corporation_Name { get; set; }
        public string Factory_Name { get; set; }
        public int Corporation_id { get; set; }

    }
}
