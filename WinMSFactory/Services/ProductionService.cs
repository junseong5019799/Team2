using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
    public class ProductionService
    {
        ProductionDAC dac = new ProductionDAC();
        // 생산 현황
        public List<ProductionVO> ProductionStatusSelect()
        {
            return dac.ProductionStatusSelect();
        }

        public List<ProductionVO> DefectiveSelect()
        {
            return dac.DefectiveSelect();
        }
    }
}
