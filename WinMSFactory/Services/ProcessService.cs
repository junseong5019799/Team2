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
    public class ProcessService
    {
        ProcessDAC dac = new ProcessDAC();
        public DataTable GetAll()
        {
            return dac.GetAll();
        }

        public List<CorporationVO> CorporationCombo()
        {
            return dac.CorporationCombo();
        }
        public List<FactoryVO> FactoryCombo()
        {
            return dac.FactoryCombo();
        }

        public List<LineVO> LineCombo()
        {
            return dac.LineCombo();
        }
        public DataTable ProcessSearch(ProcessVO vo)
        {
            return dac.ProcessSearch(vo);
        }

        public bool UseTypeChange(int process_id, string isTypeUse)
        {
            return dac.UseTypeChange(process_id, isTypeUse);
        }

        public bool ProcessDelete(List<int> process_idList)
        {
            return dac.ProcessDelete(process_idList);
        }
    }
}
