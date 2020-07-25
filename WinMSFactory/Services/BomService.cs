using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
    
    public class BomService
    {
        BomDAC dac = new BomDAC();
        public static List<ProductType> CboProductType()
        {
            List<ProductType> list = new List<ProductType>();
            
            list.Add(new ProductType { Member = "전체" });
            list.Add(new ProductType { Member = "반제품" });
            list.Add(new ProductType { Member = "재료" });
            
            return list;
        }

       public List<BomVO> SelectMaterialSettings(string Category1, string Category2)
       {
            return dac.SelectMaterialSettings(Category1, Category2);
       }

        

        public bool InsertProducts(List<BOMInsertUpdateVO> insertBOMLists)
        {
            return dac.InsertProducts(insertBOMLists);
        }
    }
}
