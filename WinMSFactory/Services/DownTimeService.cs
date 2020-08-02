using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
    public class DownTimeService
    {
        DownTimeDAC dac = new DownTimeDAC();
        public List<DownTimeVO> SelectAllDownTime()
        {
            return dac.SelectAllDownTime();
        }
    }
}
