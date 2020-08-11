using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class ProductionVO
    {
        public int Work_Order_No { get; set; }
        public string Product_Name { get; set; }
        public int Work_Order_Quantity { get; set; }
        public int Defective_Quantity { get; set; }
        public int Good_Quantity { get; set; }
        public string Employee_Name { get; set; }
        public DateTime Work_Start_Time { get; set; }
        public DateTime Work_Finish_Time { get; set; }
        public int Downtime_No { get; set; }
        public int Work_order_no { get; set; }
        public DateTime Downtime_start_time { get; set; }
        public DateTime Downtime_finish_time { get; set; }
        public DateTime Downtime_Hour { get; set; }
        public string Downtime_type_use { get; set; }
        public string Downtime_type_calculation { get; set; }
        public string Downtime_type_name { get; set; }
        public string Downtime_note { get; set; }
        public int Defection_Code { get; set; }
        public string Defection_type_name { get; set; }
        public string Defection_quantity { get; set; }
        public DateTime Defective_date { get; set; }
        public DateTime Work_Date { get; set; }
    }
}
