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
using WinMSFactory.Popup;
using WinMSFactory.Services;

namespace WinMSFactory.ReleaseForm
{
    public partial class ReleaseOutPopUpForm : PopUpDialogForm
    {
        ReleaseService releaseService = new ReleaseService();
        ReleaseVO release = new ReleaseVO();

        private int companyID;
        private int requestQuantity;
        private int releaseNo;
        private int productno;
        private string requestDate;
        private string companyName;
        private int releaseSeq;

        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }        

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public int RequestQuantity
        {
            get { return requestQuantity; }
            set { requestQuantity = value; }
        }

        public int ProductNo
        {
            get { return productno; }
            set { productno = value; }
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

        public int ReleaseSeq
        {
            get { return releaseSeq; }
            set { releaseSeq = value; }
        }

        public ReleaseOutPopUpForm()
        {           

            InitializeComponent();
            
        }

        private void ReleaseExcelPopUpForm_Load(object sender, EventArgs e)
        {
            cboProduct.ComboBinding(releaseService.SelectProduct(), "Product_ID", "Product_Name");
            cboProduct.SelectedValue = productno;
                        
            txtCompany.Text = companyName.ToString();
            txtQuantity.Text = requestQuantity.ToString();
            txtQuantity.ReadOnly = true;
            txtCompany.ReadOnly = true;
            txtStock.ReadOnly = true;           

            lblPlanID.Text = releaseNo.ToString();
            lblSeq.Text = releaseSeq.ToString();

            StorageService service = new StorageService();
            txtStock.Text = service.GetStockByProduct(cboProduct.SelectedValue.ToInt()).ToString();

            dtpOut.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 출고 완료 등록하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                release.release_no = releaseNo;
                release.release_seq = releaseSeq;
                release.release_status = "출고완료";
                release.final_regist_employee = "admin";
                release.release_quantity = Convert.ToInt32(txtQuantity.Text);

                if (releaseService.SaveReleaseOut(release))
                {
                    MessageBox.Show("출고 되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                this.Close();
            }
        }
    }
}
