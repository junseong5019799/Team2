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
using WinMSFactory;
using System.Data.SqlClient;

namespace WinMSFactory
{
    //테스트박스 조회, 전체 체크 박스 풀기
    public partial class CompanyForm : ListForm
    {
        CheckBox headerCheckBox = new CheckBox();
        //CompanyService service;
        List<CommonCodeVO> list;
        DataTable dtOrg;
        public CompanyForm()
        {
            InitializeComponent();
        }


        private void CompanyForm_Load(object sender, EventArgs e)
        {
            dgvCompanyList.IsAllCheckColumnHeader = true;

            //거래처리스트 거래처코드, 거래처명칭, 거래처유형, 거래처순번, 거래처사용여부, 최초 최종
            dgvCompanyList.AddNewColumns("거래처코드", "company_id", 100, true);
            dgvCompanyList.AddNewColumns("거래처명칭", "company_name", 100, true);
            dgvCompanyList.AddNewColumns("거래처유형", "COMMON_NAME", 100, true);
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

            LoadData();
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {

            dgvCompanyList.EndEdit();

                foreach (DataGridViewRow row in dgvCompanyList.Rows)
                {
                    DataGridViewCheckBoxCell checkBox = (row.Cells["chk"] as DataGridViewCheckBoxCell);
                    checkBox.Value = headerCheckBox.Checked;
                }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            string type = (cboCompany_Type.SelectedValue).ToString();

            CompanyService service = new CompanyService();
            dtOrg = service.GetCompany(type);

            DataView dv = new DataView(dtOrg);
            if (!string.IsNullOrEmpty(type))
            {
                string RowData = string.Empty;
                //List<CompanyVO> clist = new List<CompanyVO>();
                //clist = (from selecttype in clist
                //         where selecttype.company_type.Equals(type)
                //         select selecttype).ToList();
                if (type == "COP")
                    RowData = "매입처";
                else
                    RowData = "매출처";


                dv.RowFilter = $"common_name = '{RowData}'";
               // dv.RowFilter = "company_type='" + type + "'";                
            }
            dgvCompanyList.DataSource = dv;
        }

        private void dgvCompanyList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //업데이트 할떄 더블클릭
        {

            CompanyVO company = new CompanyVO();
            company.company_id = Convert.ToInt32(dgvCompanyList.SelectedRows[0].Cells[1].Value);
            company.company_name = dgvCompanyList.SelectedRows[0].Cells[2].Value.ToString();
            company.company_type = dgvCompanyList.SelectedRows[0].Cells[3].Value.ToString();
            company.first_regist_time = Convert.ToDateTime(dgvCompanyList.SelectedRows[0].Cells[5].Value);
            company.first_regist_employee = dgvCompanyList.SelectedRows[0].Cells[6].Value.ToString();
            company.final_regist_time = Convert.ToDateTime(dgvCompanyList.SelectedRows[0].Cells[7].Value);
            company.final_regist_employee = dgvCompanyList.SelectedRows[0].Cells[8].Value.ToString();
            company.company_seq = Convert.ToInt32(dgvCompanyList.SelectedRows[0].Cells[4].Value);


            CompanyProductPopupForm cpp = new CompanyProductPopupForm(this, company);

            if (cpp.ShowDialog() == DialogResult.OK)
            {
                dgvCompanyList.Columns.Clear();
                CompanyForm_Load(null, null);
            }


        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            CompanyProductPopupForm cpp = new CompanyProductPopupForm();

            if (cpp.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void dgvCompanyList_CellClick(object sender, DataGridViewCellEventArgs e) //전체 체크박스풀기
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in dgvCompanyList.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = isChecked;
            }
        }

        private void btnDelect_Click(object sender, EventArgs e)
        {
            CompanyService service = new CompanyService();
            try
            {
                string company_id = dgvCompanyList.GetCheckIDs("company_id");

                if (string.IsNullOrEmpty(company_id))
                    return;

                if (service.DeleteCompany(company_id))
                {
                    MessageBox.Show("정상적으로 삭제되었습니다.");
                    LoadData();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void LoadData()
        {
            CompanyService service = new CompanyService();
            dtOrg = service.GetCompany("");

            DataView dv = new DataView(dtOrg);
            dgvCompanyList.DataSource = dv;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCompany_Name.Text = "";
            LoadData();
            cboCompany_Type.SelectedIndex = 0;
        }

        private void buttonControl1_Click(object sender, EventArgs e)
        {
            List<int> CheckList = new List<int>();

            foreach (DataGridViewRow row in dgvCompanyList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvCompanyList[0, row.Index];

                if (chk.Value == null)
                    continue;

                else if ((bool)chk.Value == true)
                    CheckList.Add(dgvCompanyList[1, row.Index].Value.ToInt());

            }

            if (CheckList.Count == 0)
            {
                MessageBox.Show("거래처를 선택하여 주세요.");
                return;
            }

            string selList = string.Join(",", CheckList);
            CompanyService service = new CompanyService();
            DataTable dt = service.CompanyPrint(selList);

            CompanyXtraReport xtra = new CompanyXtraReport();
            xtra.DataSource = dt;
            ReportPreviewForm frm = new ReportPreviewForm(xtra);
        }

        //오류//private void btnDelect_Click(object sender, EventArgs e)
        //{
        //    CompanyService service = new CompanyService();

        //    if (MessageBox.Show("거래처를 삭제 하시겠습니까? 거래처 품목도 같이 삭제 됩니다.", "", MessageBoxButtons.YesNo) == DialogResult.No)
        //        return;
        //    try
        //    {
        //         List<int> CheckList = new List<int>();

        //         foreach (DataGridViewRow row in dgvCompanyList.Rows)
        //         {
        //             DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvCompanyList[0, row.Index];

        //                 if (chk.Value == null)
        //                     continue;
        //                 else if ((bool)chk.Value == true)
        //                     CheckList.Add(dgvCompanyList[1, row.Index].Value.ToInt());
        //         }

        //          int company_id = Convert.ToInt32(dgvCompanyList.SelectedRows[0].Cells[1].Value);

        //        if (CheckList.Count > 0)
        //        {
        //            service.Delete(CheckList);

        //            DataView dv = new DataView(dtOrg);
        //            dgvCompanyList.DataSource = dv;

        //        }
        //        else
        //        {
        //            MessageBox.Show("다시 선택해주세요");
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        throw err;
        //    }
        //}
    }
}
