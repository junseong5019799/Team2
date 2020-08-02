using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class DownTimeVO // DownTime(비가동) 조회
    {
        public string Downtime_Type_Name { get; set; }
        public string Enployee_Name { get; set; }
        public string Product_Name { get; set; }
        public DateTime Downtime_Start_Time { get; set; }
        public DateTime Downtime_Finish_Time { get; set; }
        public string DownTine_Type_Use { get; set; }
        public string Downtime_Type_Calculation { get; set; }
        public DateTime First_Regist_Time { get; set; }
        public string First_Regist_Employee { get; set; }
        public DateTime Final_Regist_Time { get; set; }
        public string Final_Regist_Employee { get; set; }
    }
}
