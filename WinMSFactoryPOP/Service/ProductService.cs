using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactoryPOP.Services
{
    public class ProductService
    {
        ProductDAC dac = new ProductDAC();

        public ProductVO GetProduct(int work_order_no)
        {
            return dac.GetProduct(work_order_no);
        }
    }
}
