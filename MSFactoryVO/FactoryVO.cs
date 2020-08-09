using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class FactoryVO
    {
       public int factory_id            { get; set; }
       public int corporation_id        { get; set; }
       public string factory_note1         { get; set; }
       public string factory_note2         { get; set; }
       public string factory_name          { get; set; }
       public int factory_seq           { get; set; }
       public string factory_use           { get; set; }
       public DateTime first_regist_time     { get; set; }
       public string first_regist_employee { get; set; }
       public DateTime final_regist_time     { get; set; }
       public string final_regist_employee { get; set; }

       public string corporation_name { get; set; }
       public string Company_Name { get; set; }
        public int Company_id { get; set; }

    }

}
