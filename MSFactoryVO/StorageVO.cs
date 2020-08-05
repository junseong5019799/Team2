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
        public int Product_Id { get; set; }
        public string Storage_Name { get; set; }
        public int Stock_No { get; set; }
        public string Product_Name { get; set; }
        public string Stock_Quantity { get; set; }
        public DateTime Stock_Regist_Date { get; set; }
        public string Product_Group_Name { get; set; }
        public string Factory_name { get; set; }
    }
}
