using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class ProductionVO
    {
        public string Work_Order_No { get; set; }
        public string Product_Name { get; set; }
        public string Work_Order_Quantity { get; set; }
        public string Defective_Quantity { get; set; }
        public string Good_Quantity { get; set; }
        public string Employee_Name { get; set; }
        public DateTime Work_Start_Time { get; set; }
        public DateTime Wor_Finish_Time { get; set; }
    }
}
