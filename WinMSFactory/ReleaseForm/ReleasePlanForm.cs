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

namespace WinMSFactory
{
    public partial class ReleasePlanForm : ListForm
    {
        ReleaseService releaseService = new ReleaseService();
        List<CommonCodeVO> list = new List<CommonCodeVO>();
        CommonCodeService commonService = new CommonCodeService();

        public ReleasePlanForm()
        {
            InitializeComponent();
        }

        private void ReleasePlanForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("출고예정 번호", "", 100, true);
            dgv.AddNewColumns("거래처", "", 100, true);
            dgv.AddNewColumns("거래처명", "", 100, true);
            dgv.AddNewColumns("출고 요청일", "", 100, true);
            dgv.AddNewColumns("품목 코드", "", 100, true);
            dgv.AddNewColumns("요청 수량", "", 100, true);
            dgv.AddNewColumns("출고 상태", "", 100, true);
            dgv.AddNewColumns("출고일", "", 100, true);
            dgv.AddNewColumns("최초등록 시각", "", 100, true);
            dgv.AddNewColumns("최종등록 시각", "", 100, true);
            dgv.AddNewColumns("최초등록 시각", "", 100, true);
            dgv.AddNewColumns("최종등록 사원", "", 100, true);

            dgv.DataSource = releaseService.GetReleasePlan();

            cboProduct.ComboBinding(BomService.CboProductType("Search"), "Member", "");

        }


        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cboProduct.SelectedIndex > 0)
            {
               // var productList = 
            }
        }

      
    }
}
