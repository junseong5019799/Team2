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

        public List<DefectiveTypeVO> DefectiveTypeSelectAll()
        {
            return dac.DefectiveTypeSelectAll();
        }

        public bool DefectiveTypeUpsert(DefectiveTypeVO typeVO)
        {
            return dac.DefectiveTypeUpsert(typeVO);
        }

        public bool UseTypeChange(int productID, string IsTypeUse)
        {
            return dac.UseTypeChange(productID, IsTypeUse);
        }

        public void DefectiveDelete(int defectiveNo)
        {
            dac.DefectiveDelete(defectiveNo);
        }
    }
}
