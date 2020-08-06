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

            txtCompany_Id.Enabled = false;
        }

        private void CompanyProductPopupForm_Load(object sender, EventArgs e)
        {
            cboCompany_Type.SelectedIndexChanged += cboCompany_Type_SelectedIndexChanged;

            clist = new CommonCodeService().GetCommonCodes("COMTYPE");
            cboCompany_Type.ComboBinding(clist);

            cboCompany_Type.SelectedIndex = -1;

            if (IsDataExists == true)
            {
                txtCompany_Id.Enabled = false;
                dtpFirst_Regist_Time.Enabled = false;
                txtFirst_Regist_Employee.Enabled = false;

                txtCompany_Id.Text = companyVO.company_id.ToString();
                txtCompany_Name.Text = companyVO.company_name;
                cboCompany_Type.Text = companyVO.company_type;
                txtCompany_Seq.Text = companyVO.company_seq.ToString();
                dtpFirst_Regist_Time.Value = companyVO.first_regist_time;
                dtpFinal_Regist_Time.Value = companyVO.final_regist_time;
                txtFirst_Regist_Employee.Text = companyVO.first_regist_employee;
                txtFinal_Regist_Employee.Text = companyVO.final_regist_employee;
                listBoxProduct.SelectedItem = cboCompany_Product.SelectedItem;//값이 있는 거래처이면 값을 넣어서 보여주고   

                cboCompany_Product.ComboBinding<CompanyVO>(service.ProductBinding(cboCompany_Type.SelectedValue.ToString()), "PRODUCT_ID", "PRODUCT_NAME");

                //companyVO.company_id 를 파라미터로 전달해서 제품명 조회해서 받아오기
                List<ProductSimpleVO> prods = service.SelectProductByCompanyID(companyVO.company_id);
                foreach(var item in prods)
                {
                    listBoxProduct.Items.Add(item.Product_ID + "/" + item.Product_Name);
                }
                cboCompany_Product.SelectedIndex = -1;
            }

            
        }

        private void cboCompany_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCompany_Type.SelectedValue != null)
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
        }

        private void btnProductAdd_Click(object sender, EventArgs e) //리스트박스에도 처음 값을 보여주고 싶다 지금은 cboCompany_Type.SelectedIndex = 0;
        {
            listBoxProduct.Items.Add(cboCompany_Product.SelectedValue.ToString() + "/" + cboCompany_Product.Text);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyVO vo = new CompanyVO();
                List<ProductSimpleVO> prodListVO = new List<ProductSimpleVO>();

                vo.company_id = Convert.ToInt32((txtCompany_Id.Text.Length> 0) ? txtCompany_Id.Text:"0");
                vo.company_name = txtCompany_Name.Text;
                vo.company_seq = Convert.ToInt32((txtCompany_Seq.Text.Length > 0) ? txtCompany_Seq.Text : "0");
                vo.company_type = cboCompany_Type.SelectedValue.ToString();
                vo.first_regist_employee = txtFirst_Regist_Employee.Text;
                vo.final_regist_employee = txtFinal_Regist_Employee.Text;

                if (listBoxProduct.Items.Count > 0)
                {
                    foreach (string prodInfo in listBoxProduct.Items)
                    {
                        prodListVO.Add(new ProductSimpleVO
                        {
                            Product_ID = Convert.ToInt32(prodInfo.Split('/')[0]),
                            Product_Name = prodInfo.Split('/')[1]
                        }
                        );
                    }
                }

                if(service.SaveCompany(vo, prodListVO))
                {
                    MessageBox.Show("정상적으로 저장되었습니다.");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listBoxProduct.Items.RemoveAt(listBoxProduct.SelectedIndex);
        }

        private void txtCompany_Seq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}
