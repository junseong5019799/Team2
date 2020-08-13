using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class ProcessWorkerVO
    {
        public int worker_id { get; set; }
        public int  process_id { get; set; }
        public int  employee_id { get; set; }
        public DateTime  first_regist_time { get; set; }
        public string  first_regist_employee { get; set; }
        public DateTime final_regist_time { get; set; }
        public string  final_regist_employee { get; set; }
    }
}
