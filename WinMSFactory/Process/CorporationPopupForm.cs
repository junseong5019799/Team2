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
        bool IsDataExists;
        CorporationService service = new CorporationService();
        string employeeName;

        public CorporationPopupForm(string employeeName, bool IsDataExists,CorporationVO corporation)
        {
            InitializeComponent();
            this.IsDataExists = IsDataExists;

            this.employeeName = employeeName;
            if (IsDataExists == true)
            {
                this.corporationVO = corporation;
            }

        }

        private void CorporationPopupForm_Load(object sender, EventArgs e)
        {
            if (IsDataExists == false)
                rboUse.Checked = true;

            else if (IsDataExists == true)
            {
                if (corporationVO.corporation_use == "Y")
                {
                    rboUse.Checked = true;
                    rboNotUse.Checked = false;
                }

                else
                {
                    rboUse.Checked = false;
                    rboNotUse.Checked = true;
                }

                txtID.Text = corporationVO.corporation_id.ToString();
                txtName.Text = corporationVO.corporation_name;
                nudCorporation_seq.Text = corporationVO.corporation_seq.ToString();
                txtNote1.Text = corporationVO.corporation_note1;
                txtNote2.Text = corporationVO.corporation_note2;
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
                if (txtName.TextLength < 1)
                {
                    MessageBox.Show("법인을 입력해주세요");
                    return;
                }

                string UseCheck;

                if (rboUse.Checked == true)
                    UseCheck = "Y";
                else
                    UseCheck = "N";

                if (IsDataExists == false)
                    CorporationSave(UseCheck, "등록", 0);

                else
                    CorporationSave(UseCheck, "수정", corporationVO.corporation_id);
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        private void CorporationSave(string UseCheck, string Status, int corporation_id)
        {
            if (MessageBox.Show($"법인을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                CorporationVO corporation = new CorporationVO
                {
                    corporation_id = corporation_id,
                    corporation_name = txtName.Text,
                    corporation_seq = Convert.ToInt32((nudCorporation_seq.Value.ToString().Length > 0) ? nudCorporation_seq.Value.ToString() : "0"),
                    corporation_use = UseCheck,
                    first_regist_employee = employeeName,
                    final_regist_employee = employeeName,
                    corporation_note1 = txtNote1.Text,
                    corporation_note2 = txtNote2.Text
                };

                if (service.SaveCorporation(corporation))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
