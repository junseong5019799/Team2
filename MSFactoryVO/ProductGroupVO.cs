using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFactoryVO
{
    public class ProductGroupVO
    {
       //"SELECT [product_group_id], [product_group_name], [product_group_use], [product_group_note1], [product_group_note2], [product_group_seq], 
       //                            [first_regist_time], [first_regist_employee], [final_regist_time], [final_regist_employee]
       // FROM TBL_PRODUCT_GROUP_MANAGEMENT"

        public int Product_Group_ID { get; set; }
        public string Product_Group_Name { get; set; }
        public string Product_Group_Note1 { get; set; }
        public string Product_Group_Note2 { get; set; }
        public DateTime First_Regist_Time { get; set; }
        public string First_Regist_Employee { get; set; }
        public DateTime Final_Regist_Time { get; set; }
        public string Final_Regist_Employee { get; set; }
        public int Product_Group_Seq { get; set; }
        public char Product_Group_Use { get; set; }
        public string Product_Group_Use_String { get; set; }
        public string Category { get; set; }
    }

    public class GroupComboVO
    {
        public int Product_Group_Id { get; set; }
        public string Product_Group_Name { get; set; }

        public GroupComboVO() { }
        public GroupComboVO(int Product_Group_Id, string Product_Group_Name)
        {
            this.Product_Group_Id = Product_Group_Id;
            this.Product_Group_Name = Product_Group_Name;
        }
    }
}
