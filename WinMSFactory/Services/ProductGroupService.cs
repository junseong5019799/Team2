using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
    
    class ProductGroupService
    {
        ProductGroupDAC dac = new ProductGroupDAC();
        public List<ProductGroupVO> SelectAllProductGroups()
        {
            return dac.SelectAllProductGroups();
        }
    }
}
