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
    public class DowntimeTypeService
    {
        DowntimeTypeDAC dac = new DowntimeTypeDAC();
        public DataTable GetAll()
        {
            return dac.GetAll();
        }
        public bool UseTypeChange(int downtime_type_id, string isTypeUse = null, string isTimeuse = null)
        {
            return dac.UseTypeChange(downtime_type_id, isTypeUse, isTimeuse);
        }
        public bool SaveDowntimeType(DowntimeTypeVO vo)
        {
            return dac.SaveDowntimeType(vo);
        }
    }
}
