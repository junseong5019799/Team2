using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class CorporationVO
    {
        public int corporation_id { get; set; }
        public string corporation_name { get; set; }
        public string corporation_note1 { get; set; }  //비고1
        public string corporation_note2 { get; set; }  //비고2
        public int corporation_seq { get; set; }    //순번
        public string corporation_use { get; set; }    //사용여부
        public DateTime first_regist_time { get; set; }   
        public string first_regist_employee { get; set; }
        public DateTime final_regist_time { get; set; }
        public string final_regist_employee { get; set; }

    }
}
