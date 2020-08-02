using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class BomLogVO
    {
        public int Log_No { get; set; }
        public int High_Product_ID { get; set; }
        public string High_Product_Name { get; set; }
        public int Low_Product_ID { get; set; }
        public string Low_Product_Name { get; set; }
        public string Bom_Log_Status { get; set; }
        public int Bom_Seq { get; set; }
        public DateTime Bom_Enroll_Date { get; set; }
        public string Employee_ID { get; set; } // 사번은 NVARCHAR임
        public string Employee_Name { get; set; }
        public char Bom_Exists { get; set; }
        public string Product_Name { get; set; }

    }
}
