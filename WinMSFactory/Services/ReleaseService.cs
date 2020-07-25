using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
    class ReleaseService
    {
        ReleaseDAC dac = new ReleaseDAC();

        public List<ReleaseVO> GetReleasePlan()
        {
            return dac.GetReleasePlan();    
        }

        public List<GroupComboVO> SelectProductGroup()
        {
            return dac.SelectProductGroup();
        }

        public List<GroupComboVO> SelectPlanID ()
        {
            return dac.SelectPlanID();
        }
         
        public List<BomVO> SelectProduct()
        {
            return dac.SelectProduct();
        }

        public bool SaveReleasePlan(ReleaseVO release)
        {
            return dac.SaveReleasePlan(release);
        }

        public int GetProductID(string name)
        {
            return dac.GetProductID(name);
        }
    }
}
