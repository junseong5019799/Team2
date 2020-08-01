using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
    public class DefectiveService
    {
        DefectiveDAC dac = new DefectiveDAC();
        public List<DefectiveVO> DefectiveSelectAll()
        {
            return dac.DefectiveSelectAll();
        }
    }
}
