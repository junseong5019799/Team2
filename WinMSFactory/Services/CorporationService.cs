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
    public class CorporationService
    {
        CorporationDAC dac = new CorporationDAC();

        //테이블로 전체 가져오기
        //public DataTable Getall()
        //{
        //    return dac.Getall();
        //}

        public List<CorporationVO> GetSearch(string corporation_name)
        {
            return dac.GetSearch(corporation_name);
        }

        public bool SaveCorporation(CorporationVO corporationvo)
        {
            return dac.SaveCorporation(corporationvo);
        }
    }
}
