using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
   public class DowntimeTypeVO
   {
       public int downtime_type_id { get; set; }
       public string  downtime_type_name { get; set; }
        public string  downtime_type_calculation { get; set; }
        public int  downtime_type_seq { get; set; }
        public string  downtime_type_use { get; set; }
        public DateTime  first_regist_time { get; set; }
        public string  first_regist_employee { get; set; }
        public DateTime final_regist_time { get; set; }
        public string  final_regist_employee { get; set; }

    }
}
