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
        public List<FactoryVO> FactoryCombo(int corporation_id)
        {
            return dac.FactoryCombo(corporation_id);
        }

        public List<LineVO> LineCombo(int factory_id)
        {
            return dac.LineCombo(factory_id);
        }

        public List<StorageVO> StorageCombo(int factory_id)
        {
            return dac.StorageCombo(factory_id);
        }

        public List<LineVO> LineCombo()
        {
            return dac.LineCombo();
        }

        public List<StorageVO> StorageCombo()
        {
            return dac.StorageCombo();
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

        public bool SaveProcess(ProcessVO vo)
        {
            return dac.SaveProcess(vo);
        }
    }
}
