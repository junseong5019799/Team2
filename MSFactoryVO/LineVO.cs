using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class LineVO
    {
       public int line_id  {get; set;}
       public int factory_id  {get; set;}
       public string line_note1 {get; set;}
       public string line_note2 {get; set;}
       public string line_name {get; set;}
       public int line_seq     {get; set;}
       public string line_use  {get; set;}
       public DateTime first_regist_time      {get; set;}
       public string first_regist_employee  {get; set;}
       public DateTime final_regist_time      { get; set;}
       public string final_regist_employee  { get; set;}

       public int corporation_id { get; set; }

       public string factory_name { get; set; }
       public string corporation_name { get; set; }

    }
}
