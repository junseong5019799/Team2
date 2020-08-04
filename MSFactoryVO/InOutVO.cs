using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class InOutVO
    {
        public string gubun { get; set; }
        public int release_no { get; set; }
        public int storage_id { get; set; }
        public string storage_name { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string product_type { get; set; }
        public int release_quantity { get; set; }
        public DateTime release_date { get; set; }       
    }
}
