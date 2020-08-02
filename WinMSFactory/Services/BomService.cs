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
        // Bom 수정(한개만 수정)
        public  List<BomVO> BOMEnrolledMaterial(int ProductID)
        {
            return dac.BOMEnrolledMaterial(ProductID);
        
        }
        // BOM 복사(여러개 가능)
        public List<BomVO> BOMEnrolledMaterial(List<int> ProductIDs)
        {
            return dac.BOMEnrolledMaterial(ProductIDs);
        }

        public DataTable SelectAllBomProducts(char IsBomStatusForward)
        {
            return dac.SelectAllBomProducts(IsBomStatusForward);
        }

        

       

        public DataTable BOMDeployDGVBinding(bool IsBOMForward, int SelectedValue)
        {
            return dac.BomDeployDGVBinding(IsBOMForward, SelectedValue);
        }

        public List<BomVO> BOMTypeBinding(bool IsBOMForward)
        {
            return dac.BomTypeBinding(IsBOMForward);
        }

        public List<BomVO> BOMProductBinding(string product)
        {
            return dac.BOMProductBinding(product);
        }

        public bool BOMDelete(int DeleteBomNum)
        {
            return dac.BomDelete(DeleteBomNum);
        }

        public bool InsertUpdateProductByBomCopy(List<BOMInsertUpdateVO> insertBOMLists, string Product_Name)
        {
            return dac.InsertUpdateProductByBomCopy(insertBOMLists, Product_Name);
        }
    }
}
