using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
    public class LineService
    {
        LineDAC dac = new LineDAC();
        public DataTable GetAll()
        {
           return dac.GetAll();
        }

        public List<CorporationVO> LineComboGet()
        {
            return dac.LineComboGet();
        }

        public List<FactoryVO> LineCombo()
        {
            return dac.LineCombo();
        }

        public bool UseTypeChange(int line_id, string isTypeUse)
        {
            return dac.UseTypeChange(line_id, isTypeUse);
        }

        public DataTable LineSearch(LineVO vo)
        {
            return dac.LineSearch(vo);
        }
        public bool LineDelete(List<int> line_idList)
        {
            return dac.LineDelete(line_idList);
        }
    }
}
