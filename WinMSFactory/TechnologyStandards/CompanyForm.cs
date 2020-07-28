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
        CompanyService service;
        List<CommonCodeVO> list;
        public CompanyForm()
        {
            InitializeComponent();
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            //거래처리스트 거래처코드, 거래처명칭, 거래처유형, 거래처순번, 거래처사용여부, 최초 최종
            dgvCompanyList.AddNewColumns("거래처코드", "company_id", 100, true);
            dgvCompanyList.AddNewColumns("거래처명칭", "company_name", 100, true);
            dgvCompanyList.AddNewColumns("거래처유형", "company_type", 100, true);
            dgvCompanyList.AddNewColumns("거래처순번", "company_seq", 100, true);
            dgvCompanyList.AddNewColumns("최초등록 시각", "first_regist_time", 100, true);
            dgvCompanyList.AddNewColumns("최초등록 사원", "first_regist_employee", 100, true);
            dgvCompanyList.AddNewColumns("최종등록 시각", "final_regist_time", 100, true);
            dgvCompanyList.AddNewColumns("최종등록 사원", "final_regist_employee", 100, true);

            list = new CommonCodeService().GetCommonCodes("COMTYPE");
            //list = service.GetCommonCodeList("COMTYPE");
            cboCompany_Type.ComboBinding(list, "전체");

            string type = string.Empty;
            if (cboCompany_Type.SelectedValue == null)
                type = "";
            else
                type = cboCompany_Type.SelectedValue.ToString();

            CompanyService service = new CompanyService();
            DataTable dt = service.GetCompany(type);
            dgvCompanyList.DataSource = dt;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<CompanyVO> clist = new List<CompanyVO>();
            string type = (cboCompany_Type.SelectedValue).ToString();

            if (!string.IsNullOrEmpty(type))
            {
                clist = (from selecttype in clist
                         where selecttype.company_type.Equals(type)
                         select selecttype).ToList();
            }
            dgvCompanyList.DataSource = null;
            dgvCompanyList.DataSource = clist;

             
        }
    }
}
