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
using WinMSFactory.TechnologyStandards;

namespace WinMSFactory.Technology_Standards
{
    public partial class CompanyForm : ListForm
    {
        CheckBox headerCheckBox = new CheckBox();
        CompanyService service;
        List<CommonCodeVO> list;
        DataTable dtOrg;

        public CompanyForm()
        {
            InitializeComponent();
        }


        private void CompanyForm_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvCompanyList.Columns.Add(chk);

            Point headerCellLocation = this.dgvCompanyList.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dgvCompanyList.Controls.Add(headerCheckBox);

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
            dtOrg = service.GetCompany(type);

            DataView dv = new DataView(dtOrg);
            dgvCompanyList.DataSource = dv;
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

            DataView dv = new DataView(dtOrg);
            if (!string.IsNullOrEmpty(type))
            {
                //List<CompanyVO> clist = new List<CompanyVO>();
                //clist = (from selecttype in clist
                //         where selecttype.company_type.Equals(type)
                //         select selecttype).ToList();
               
                dv.RowFilter = "company_type='" + type + "'";                
            }
            dgvCompanyList.DataSource = dv;
        }

        private void dgvCompanyList_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvCompanyList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CompanyProductPopupForm cpp = new CompanyProductPopupForm();
            cpp.ShowDialog();

        }
    }
}
