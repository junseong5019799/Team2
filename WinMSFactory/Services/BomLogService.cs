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
        public List<BomLogVO> SelectAllLogs(int Corporation_id)
        {
            return dac.SelectAllLogs(Corporation_id);
        }

        public void InsertLogs(BomLogVO AddLogs)
        {
            dac.InsertLogs(AddLogs);
        }
    }
}
