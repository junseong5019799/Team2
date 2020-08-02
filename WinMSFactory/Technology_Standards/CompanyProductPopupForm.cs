using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;
using WinMSFactory.Technology_Standards;

namespace WinMSFactory.TechnologyStandards
{
    public partial class CompanyProductPopupForm : PopUpDialogForm
    {
        List<CommonCodeVO> clist;
        CompanyVO companyVO;
        CompanyService service = new CompanyService();
        bool IsDataExists;
        CompanyForm frm;
        public CompanyProductPopupForm(CompanyForm frm, CompanyVO company)
        {
            InitializeComponent();
            this.companyVO = company;
            IsDataExists = true;
            this.frm = frm;
        }
        public CompanyProductPopupForm()
        {
            InitializeComponent();
            IsDataExists = false;
        }

        private void CompanyProductPopupForm_Load(object sender, EventArgs e)
        {
            if(IsDataExists == true)
            {
                txtCompany_Id.Text = companyVO.company_id.ToString();
                txtCompany_Id.Text = companyVO.company_id.ToString();
                txtCompany_Name.Text = companyVO.company_name;
                cboCompany_Type.Text = companyVO.company_type;
                txtCompany_Seq.Text = companyVO.company_seq.ToString();
                dtpFirst_Regist_Time.Value = companyVO.first_regist_time;
                dtpFinal_Regist_Time.Value = companyVO.final_regist_time;
                txtFirst_Regist_Employee.Text = companyVO.first_regist_employee;
                txtFinal_Regist_Employee.Text = companyVO.final_regist_employee;
                listBoxProduct.SelectedItem = cboCompany_Product.SelectedItem;//값이 있는 거래처이면 값을 넣어서 보여주고   
                
            }

            clist = new CommonCodeService().GetCommonCodes("COMTYPE");
            cboCompany_Type.ComboBinding(clist);

            cboCompany_Type.SelectedIndexChanged += cboCompany_Type_SelectedIndexChanged;
            
            cboCompany_Product.ComboBinding<CompanyVO>(service.ProductBinding(cboCompany_Type.SelectedValue.ToString()), "PRODUCT_ID", "PRODUCT_NAME");
        }

        private void cboCompany_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 그룹 id가 1 : 반제품, 2: 재료, 나머지는 완제품
            string SelectedItem = cboCompany_Type.SelectedValue.ToString();
            if (SelectedItem == "COP") //매입처
            { 
              cboCompany_Product.ComboBinding<CompanyVO>(service.ProductBinding(SelectedItem), "PRODUCT_ID", "PRODUCT_NAME");
            }
            else if (SelectedItem == "POS") //매출처
            {
                cboCompany_Product.ComboBinding<CompanyVO>(service.ProductBinding(SelectedItem), "PRODUCT_ID", "PRODUCT_NAME");
            }
        }

        private void btnProductAdd_Click(object sender, EventArgs e) //리스트박스에도 처음 값을 보여주고 싶다 지금은 cboCompany_Type.SelectedIndex = 0;
        {
            listBoxProduct.Items.Add(cboCompany_Product.Text);
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyVO vo = new CompanyVO();
                vo.company_id = Convert.ToInt32(txtCompany_Id.Text);
                vo.company_name = txtCompany_Name.Text;
                vo.company_seq = Convert.ToInt32(txtCompany_Seq.Text);
                vo.company_type = cboCompany_Type.SelectedValue.ToString();
                vo.first_regist_time = dtpFirst_Regist_Time.Value;
                vo.first_regist_employee = txtFirst_Regist_Employee.Text;
                vo.final_regist_time = dtpFinal_Regist_Time.Value;
                vo.final_regist_employee = txtFinal_Regist_Employee.Text;

                if(service.SaveCompany(vo))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
