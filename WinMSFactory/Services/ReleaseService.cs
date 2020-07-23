using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
    class ReleaseService
    {
        ReleaseDAC dac = new ReleaseDAC();

        public List<ReleaseVO> GetReleasePlan()
        {
            return dac.GetReleasePlan();    
        }

        public bool SaveReleasePlan(ReleaseVO release)
        {
            return dac.SaveReleasePlan(release);
        }
    }
}
