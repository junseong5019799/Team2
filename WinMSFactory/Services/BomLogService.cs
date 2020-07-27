using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
    public class BomLogService
    {
        BomLogDAC dac = new BomLogDAC();
        public List<BomLogVO> SelectAllLogs()
        {
            return dac.SelectAllLogs();
        }

        public void InsertLogs(BomLogVO AddLogs)
        {
            dac.InsertLogs(AddLogs);
        }
    }
}
