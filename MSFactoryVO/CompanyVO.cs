using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class CompanyVO
    {
       public int company_id { get; set; }
       public string company_name { get; set; }
       public string company_type { get; set; }
       public int company_seq { get; set; }
       public string first_regist_time { get; set; }
       public string first_regist_employee { get; set; }
       public string final_regist_time { get; set; }
       public string final_regist_employee { get; set; }

       public int product_group_id { get; set; }


    }

    
}
