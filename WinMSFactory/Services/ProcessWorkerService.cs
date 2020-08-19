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

        public List<FactoryVO> FactoryCombo(int corporation_id)
        {
            return dac.FactoryCombo(corporation_id);
        }

        public List<LineVO> LineCombo(int factory_id)
        {
            return dac.LineCombo(factory_id);
        }
        public List<ProcessVO> ProcessCombo(int line_id)
        {
            return dac.ProcessCombo(line_id);
        }
        public bool ProcessWorker(ProcessWorkerVO vo)
        {
            return dac.ProcessWorker(vo);
        }
        public bool ProcessWorkerDelete(List<int> worker_idList)
        {
            return dac.ProcessWorkerDelete(worker_idList);
        }

        public DataTable ProcessWorkerSearch(ProcessWorkerVO vo)
        {
            return dac.ProcessWorkerSearch(vo);
        }

        public List<EmployeeVO> EmployeeCombo()
        {
            return dac.EmployeeCombo();
        }

        public List<EmployeeVO> EmployeeCombo(int corporation_id)
        {
            return dac.EmployeeCombo(corporation_id);
        }

        public DataTable GetProcessWorkers(int process_id)
        {
            return dac.GetProcessWorkers(process_id);
        }
    }
}
