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
            return dac.CorporationCombo();
        }

        public List<FactoryVO> FactoryCombo(int corporation_id)
        {
            return dac.FactoryCombo(corporation_id);
        }

        public List<FactoryVO> factoryAllCombo()
        {
            return dac.FactoryAllCombo();
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

        public bool SaveLine(LineVO vo)
        {
            return dac.SaveLine(vo);
        }

        public DataTable GetLines(int factory_id)
        {
            return dac.GetLines(factory_id);
        }
    }
}
