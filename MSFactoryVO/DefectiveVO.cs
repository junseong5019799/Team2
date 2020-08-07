using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class DefectiveVO
    {
        public int Defective_No { get; set; }
        public string Product_Name { get; set; }
        public string Defective_Type_Name { get; set; }
        public int Defective_Quantity { get; set; }
        public DateTime Defective_Date { get; set; }
        public string Note { get; set; }
        public string Defective_Type_Use { get; set; }
        public DateTime First_Regist_Time { get; set; }
        public string First_Regist_Employee { get; set; }

    }
    public class DefectiveTypeVO
    {
        public int Defective_Type_ID { get; set; }
        public string Defective_Type_Name { get; set; }
        public int Defective_Type_Seq { get; set; }
        public string Defective_Type_Use { get; set; }
        public DateTime First_Regist_Time { get; set; }
        public string First_Regist_Employee { get; set; }
        public DateTime Final_Regist_Time { get; set; }
        public string Final_Regist_Employee { get; set; }
        public char P_Category { get; set; }

    }
}
