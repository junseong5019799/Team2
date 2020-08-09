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
    public class FactoryService
    {
        FactoryDAC dac = new FactoryDAC();

        public DataTable SelectFactory()
        {
            return dac.SelectFactory();
        }

        public List<CorporationVO> ComboGet()
        {
            return dac.ComboGet();
        }

        public DataTable SearchName(FactoryVO vo)
        {
            return dac.SearchName(vo);
        }

        public bool UseTypeChange(int factory_id, string isTypeUse)
        {
            return dac.UseTypeChange(factory_id, isTypeUse);
        }

        public List<FactoryVO> FactoryComboBindings(int CorporationID)
        {
            return dac.CompanyComboBindings(CorporationID);
        }

        public bool SaveFactory(FactoryVO vo)
        {
            return dac.SaveFactory(vo);
        }

        public bool LineDelete(List<int> factory_idList)
        {
            return dac.LineDelete(factory_idList);
        }
}
}
