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
    public partial class StoragePopupForm : PopUpDialogForm
    {
        CorporationService cservice = new CorporationService();
        LineService fservice = new LineService();
        StorageService service = new StorageService();

        StorageVO vo;
        bool IsUpdate;
        string employeeName;

        public StoragePopupForm(string employeeName, bool IsUpdate, StorageVO vo)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;

            this.employeeName = employeeName;
            if (IsUpdate == true)
            {
                this.vo = vo;
            }
        }
        private void StoragePopupForm_Load(object sender, EventArgs e)
        {
            cboCorporation.ComboBinding(cservice.GetCorporations(), "corporation_id", "corporation_name", "전체", 0);

            if (IsUpdate == false)
                rdoUse.Checked = true;

            else if (IsUpdate == true)
            {
                cboCorporation.Enabled = false;

                if (vo.Storage_Use == "Y")
                {
                    rdoUse.Checked = true;
                    rdoUnUse.Checked = false;

                }

                else
                {
                    rdoUse.Checked = false;
                    rdoUnUse.Checked = true;
                }

                cboCorporation.SelectedIndex = cboCorporation.FindString(vo.Corporation_Name);
                cboFactory.SelectedIndex = cboFactory.FindString(vo.Factory_Name);

                nudStorage_seq.Value = vo.Storage_Seq;
                txtStorage.Text = vo.Storage_Name;
            }
        }

        private void CorporationChange(object sender, EventArgs e)
        {
            if (cboCorporation.SelectedIndex < 0)
            {
                MessageBox.Show("법인명을 먼저 선택해주세요");
                return;
            }
            else
            {
                int corporation_id = cboCorporation.SelectedValue.ToInt();
                cboFactory.ComboBinding(fservice.FactoryCombo(corporation_id), "factory_id", "factory_name", "전체", 0);
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
                if (txtStorage.TextLength < 1)
                {
                    MessageBox.Show("창고를 입력해주세요");
                    return;
                }

                string UseCheck;

                if (rdoUse.Checked == true)
                    UseCheck = "Y";
                else
                    UseCheck = "N";

                if (IsUpdate == false)
                    StorageSave(UseCheck, "등록", 0);

                else
                    StorageSave(UseCheck, "수정", vo.Storage_Id);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void StorageSave(string UseCheck, string Status, int storage_id)
        {
            if (MessageBox.Show($"라인을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                StorageVO storage = new StorageVO
                {
                    Storage_Id = storage_id,
                    Factory_id = cboFactory.SelectedValue.ToInt(),
                    Storage_Name = txtStorage.Text,
                    Storage_Seq = Convert.ToInt32((nudStorage_seq.Value.ToString().Length > 0) ? nudStorage_seq.Value.ToString() : "0"),
                    Storage_Use = UseCheck,
                    First_regist_employee = employeeName,
                    Final_regist_employee = employeeName,
                };

                if (service.SaveStorage(storage))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
