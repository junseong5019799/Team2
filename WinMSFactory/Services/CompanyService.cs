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
    public class CompanyService
    {
        /// <summary>
        /// 콤보박스 바인딩 서비스
        /// </summary>
        //public List<CommonCodeVO> GetCommonCodeList(string type)
        //{
        //    CompanyDAC dac = new CompanyDAC();
        //    return dac.GetCommonCodeList(type);
        //}
        ///<returns></returns>

        ///<summary>
        ///전체데이타그리드뷰에 바인딩
        ///</summary>
        CompanyDAC dac = new CompanyDAC();
        public DataTable GetCompany(string type)
        {

            return dac.GetCompany(type);
        }

        public List<CompanyVO> ProductBinding(string selectedItem)
        {
            return dac.ProductBinding(selectedItem);
        }
        ///<returns></returns>

        /// <summary>
        /// 저장하기
        /// </summary>
        public bool SaveCompany(CompanyVO company)
        {
            return dac.SaveCompany(company);
        }
        ///<returns></returns>
    }
}
