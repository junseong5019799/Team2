using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;

namespace WinMSFactory.Technology_Standards
{
    public partial class CompanyForm : ListForm
    {
        public CompanyForm()
        {
            InitializeComponent();
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {

            //거래처리스트 거래처코드, 거래처명칭, 거래처유형, 거래처순번, 거래처사용여부, 최초 최종
            dgvCompanyList.AddNewColumns("거래처코드", "", 100, true);
            dgvCompanyList.AddNewColumns("거래처명칭", "", 100, true);
            dgvCompanyList.AddNewColumns("거래처유형", "", 100, true);
            dgvCompanyList.AddNewColumns("거래처순번", "", 100, true);
            dgvCompanyList.AddNewColumns("최초등록 시각", "", 100, true);
            dgvCompanyList.AddNewColumns("최초등록 사원", "", 100, true);
            dgvCompanyList.AddNewColumns("최종등록 시각", "", 100, true);
            dgvCompanyList.AddNewColumns("최종등록 사원", "", 100, true);

            //CompanyService service = new CompanyService();
            List<CommonCodeVO> list = new CommonCodeService().GetCommonCodes("COMTYPE");
            //list = service.GetCommonCodeList("COMTYPE");
            
            cboCompany_Type.ComboBinding(list, "선택");

        }
    }
}
