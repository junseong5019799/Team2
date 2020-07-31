using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
    public class ProductService
    {
        ProductDAC dac = new ProductDAC();

        public List<ProductVO> SelectAllProducts()
        {
            return dac.SelectAllProducts();
        }
        

        public void UpdateStatus(int ItemNum, int StatusNum)
        {
            dac.UpdateStatus(ItemNum, StatusNum);
        }

        public bool InsertProducts(ProductInsertVO InsertData, char IsBomCopy)
        {
            return dac.InsertProducts(InsertData, IsBomCopy);
        }

        public bool DeleteProducts(int ProductNo)
        {
            return dac.DeleteProducts(ProductNo);
        }

    }
}
