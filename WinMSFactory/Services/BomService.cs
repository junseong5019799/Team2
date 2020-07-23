using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
    
    public class BomService
    {
        BomDAC dac = new BomDAC();
        public static List<ProductType> CboProductType(string Category = null)
        {
            List<ProductType> list = new List<ProductType>();
            if (Category == "Search")
            {
                list.Add(new ProductType { Member = "전체" });
                list.Add(new ProductType { Member = "완제품" });
                list.Add(new ProductType { Member = "반제품" });
                list.Add(new ProductType { Member = "재료" });
            }
            else
            {
                list.Add(new ProductType { Member = "완제품" });
                list.Add(new ProductType { Member = "반제품" });
            }
            return list;
        }

       public List<BomVO> SelectMaterialSettings(string Category1, string Category2)
       {
            return dac.SelectMaterialSettings(Category1, Category2);
       }

        public List<GroupComboVO> SelectAllGroup()
        {
            return dac.SelectAllGroup();
        }
    }
}
