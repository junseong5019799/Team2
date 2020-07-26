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

        public string CompanyName 
        { 
            get { return CompanyName; } 
            set {txtCompany.Text = value; } 
        }
        public int RequestNum
        {
            get { return RequestNum; }
            set { txtOrderNum.Text = value.ToString(); }
        }
        public string ProductName
        {
            get { return ProductName; }
            set { cboProduct.SelectedItem = value; }
        }
        public DateTime RequestDate
        {
            get { return RequestDate; }
            set { dtpRequest.Value = value; }
        }
        public int PlanID
        {
            get { return PlanID; }
            set { PlanID = value; }
        }

        public ReleaseExcelPopUpForm()
        {           

            InitializeComponent();
            
        }

        private void ReleaseExcelPopUpForm_Load(object sender, EventArgs e)
        {
            cboProduct.ComboBinding(releaseService.SelectProduct(), "Product_ID", "Product_Name");

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
            ReleaseVO release = new ReleaseVO();
            release.release_no = 10;    //planID
            release.product_id = 1; //releaseService.GetProductID(cboProduct.SelectedItem.ToString());
            release.release_date = dtpOut.Value;
            release.release_plan_date = dtpRequest.Value;
            release.release_status = "출고예정";
            release.final_regist_employee = "aa";
            release.first_regist_employee = "aa";
            release.order_request_quantity = Convert.ToInt32(txtOrderNum.Text);

            if (releaseService.SaveReleasePlan(release))
            {
                MessageBox.Show("등록되었습니다.");                
                this.Close();
            }
        }
    }
}
