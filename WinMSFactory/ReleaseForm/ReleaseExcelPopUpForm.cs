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

namespace WinMSFactory.ReleaseForm
{
    public partial class ReleaseExcelPopUpForm : PopUpDialogForm
    {
        ReleaseService releaseService = new ReleaseService();
        ReleaseVO release = new ReleaseVO();

        private int companyID;
        private int requestNum;
        private int releaseNo;
        private string productName;
        private string requestDate;

        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        public int RequestNum
        {
            get { return requestNum; }
            set { requestNum = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string RequestDate
        {
            get { return requestDate; }
            set { requestDate = value; }
        }

        public int ReleaseNo
        {
            get { return releaseNo; }
            set { releaseNo = value; }
        }


        public ReleaseExcelPopUpForm()
        {           

            InitializeComponent();
            
        }

        private void ReleaseExcelPopUpForm_Load(object sender, EventArgs e)
        {
            cboProduct.ComboBinding(releaseService.SelectProduct(), "Product_ID", "Product_Name");
            txtCompany.Text = companyID.ToString(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            release.release_no = releaseNo;
            release.company_id = companyID; 
            release.product_id = Convert.ToInt32(cboProduct.SelectedValue);
            release.release_date = dtpOut.Value;
            release.release_plan_date = dtpRequest.Value;
            release.release_status = "출고예정";
            release.final_regist_employee = "aa";
            release.first_regist_employee = "aa";
            release.order_request_quantity = Convert.ToInt32(txtOrderNum.Text);

            //if (releaseService.SaveReleasePlan(release))
            //{
            //    MessageBox.Show("등록되었습니다.");                
            //    this.Close();
            //}
        }
    }
}
