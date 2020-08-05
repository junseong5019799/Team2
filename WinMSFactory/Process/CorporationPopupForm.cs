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

namespace WinMSFactory.Process
{
    public partial class CorporationPopupForm : PopUpDialogForm
    {
        CorporationVO corporationVO;
        CorporationForm frm;
        bool IsDataExists;
        public CorporationPopupForm(CorporationForm frm, CorporationVO corporation)
        {
            InitializeComponent();
            this.corporationVO = corporation;
            IsDataExists = true;
            this.frm = frm;
        }

        public CorporationPopupForm()
        {
            InitializeComponent();
            IsDataExists = false;

            txtID.Enabled = false;
        }

        private void CorporationPopupForm_Load(object sender, EventArgs e)
        {
            if (IsDataExists == true)
            {
                txtID.Enabled = false;
                dtpFirst.Enabled = false;
                txtFirst.Enabled = false;

                txtID.Text = corporationVO.corporation_id.ToString();
                txtName.Text = corporationVO.corporation_name;
                txtSeq.Text = corporationVO.corporation_seq.ToString();
                txtNote1.Text = corporationVO.corporation_note1;
                txtNote2.Text = corporationVO.corporation_note2;
                dtpFirst.Value = corporationVO.first_regist_time;
                dtpFinal.Value = corporationVO.final_regist_time;
                txtFirst.Text = corporationVO.first_regist_employee;
                txtFinal.Text = corporationVO.final_regist_employee;
                if (corporationVO.corporation_use.ToUpper() == "Y")
                {
                    rboUse.Checked = true;
                }
                else if (corporationVO.corporation_use.ToUpper() == "N")
                {
                    rboNotUse.Checked = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
