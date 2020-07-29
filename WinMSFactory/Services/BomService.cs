using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
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

            list.Add(new ProductType { Member = "전체", ValueMember = 1 }) ;
            list.Add(new ProductType { Member = "반제품", ValueMember=2 });
            list.Add(new ProductType { Member = "재료", ValueMember = 3 });
            
            return list;
        }

        public List<BomVO> BOMDeployeeBinding()
        {
            return dac.BOMDeployeeBinding();
        }

        public List<BomVO> SelectMaterialSettings(string Category1, string Category2, int ProductID)
       {
            return dac.SelectMaterialSettings(Category1, Category2, ProductID);
       }

        

        public bool InsertUpdateProduct(List<BOMInsertUpdateVO> insertBOMLists)
        {
            return dac.InsertProducts(insertBOMLists);
        }

        internal List<BomVO> BOMEnrolledMaterial(int ProductID)
        {
            return dac.BOMEnrolledMaterial(ProductID);
        
        }

        public DataTable SelectAllBomProducts(char IsBomStatusForward)
        {
            return dac.SelectAllBomProducts(IsBomStatusForward);
        }
    }
}
