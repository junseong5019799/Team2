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

namespace WinMSFactory.TechnologyStandards
{
    public partial class CompanyProductPopupForm : PopUpDialogForm
    {
        public CompanyVO companypop
        {
            get 
            {
                CompanyVO company = new CompanyVO();

                company.company_id = int.Parse(txtCompany_Id.Text);

                return company; 
            }

            set 
            {
                txtCompany_Id.Text = value.company_id.ToString();
            }
        
        }
        public CompanyProductPopupForm()
        {
            InitializeComponent();
            
        }
    }
}
