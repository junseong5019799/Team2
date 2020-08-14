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
    public class ProcessWorkerService
    {
        ProcessWorkerDAC dac = new ProcessWorkerDAC();
        public DataTable ProseccWorkerGetAll()
        {
            return dac.ProseccWorkerGetAll();
        }

        public List<CorporationVO> CorporationCombm()
        {
            return dac.CorporationCombm();
        }
        public List<FactoryVO> FactoryCombo()
        {
            return dac.FactoryCombo();
        }

        public List<LineVO> LineCombo()
        {
            return dac.LineCombo();
        }
        public List<ProcessVO> ProcessCombo()
        {
            return dac.ProcessCombo();
        }
    }
}
