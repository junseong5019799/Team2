using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
    public class StorageService
    {
        StorageDAC storagedac = new StorageDAC();

        public List<StorageVO> GetStorage()
        {
            return storagedac.GetStorage();
        }
    }
}
