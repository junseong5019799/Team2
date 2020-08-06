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
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class CorporationPopupForm : PopUpDialogForm
    {
        CorporationVO corporationVO;
        CorporationForm frm;
        bool IsDataExists;
        CorporationService service = new CorporationService();
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
            try
            {
                CorporationVO vo = new CorporationVO();

                vo.corporation_id = Convert.ToInt32((txtID.Text.Length > 0) ? txtID.Text : "0");
                vo.corporation_name = txtName.Text;
                vo.corporation_seq = Convert.ToInt32((txtSeq.Text.Length > 0) ? txtSeq.Text : "0");
                vo.corporation_note1 = txtNote1.Text;
                vo.corporation_note2 = txtNote2.Text;
                vo.corporation_use = (rboUse.Checked == true) ? "Y" : "N";
                vo.first_regist_employee = txtFirst.Text;
                vo.final_regist_employee = txtFinal.Text;

                if (service.SaveCorporation(vo))
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

        private void txtSeq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }

        }
    }
}
