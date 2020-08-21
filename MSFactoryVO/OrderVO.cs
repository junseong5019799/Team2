using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class OrderVO
    {
        public int release_no { get; set; }
        public int order_no { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public DateTime first_regist_time { get; set; }
        public string first_regist_employee { get; set; }
        public DateTime final_regist_time { get; set; }
        public string final_regist_employee { get; set; }

        public int order_seq { get; set; }
        public int product_id { get; set; }
        public DateTime order_request_date { get; set; }
        public int order_request_quantity { get; set; }
        public int order_quantity { get; set; }
        public string order_status { get; set; }
        public int material_current_price { get; set; }
        public int sell_current_price { get; set; }
        public decimal order_price { get; set; }
    }

    public class WareHouseVO
    {
        public int order_no { get; set; }
        public DateTime warehouse_date { get; set; }
        public DateTime order_request_date { get; set; }
        public int warehouse_quantity { get; set; }
        public int storage_id { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int order_request_quantity { get; set; }
        public string order_status { get; set; }
        public int order_seq { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }

    }
}
