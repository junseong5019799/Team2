using DevExpress.XtraCharts.Native;
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
    public partial class ProcessPopupForm : PopUpDialogForm
    {
        ProcessService service = new ProcessService();
        ProcessVO vo;
        bool IsUpdate;
        string employeeName;
        public ProcessPopupForm(string employeeName, bool IsUpdate, ProcessVO vo)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;

            this.employeeName = employeeName;
            if (IsUpdate == true)
            {
                this.vo = vo;
            }
        }

        private void ProcessPopupForm_Load(object sender, EventArgs e)
        {
            cboCorporationName.ComboBinding(service.CorporationCombo(/*셀렉티드벨류*/), "corporation_id", "corporation_name", "전체", 0);

            if (IsUpdate == false)
                rdoProcess_useY.Checked = true;

            else if (IsUpdate == true)
            {
                cboCorporationName.Enabled = false;

                if (vo.process_use == "Y")
                {
                    rdoProcess_useY.Checked = true;
                    rdoProcess_useN.Checked = false;

                }
                else
                {
                    rdoProcess_useY.Checked = false;
                    rdoProcess_useN.Checked = true;
                }

                cboCorporationName.SelectedIndex = cboCorporationName.FindString(vo.corporation_name);
                if (cboCorporationName.SelectedIndex < 0)
                {
                    MessageBox.Show("법인명을 먼저 선택해주세요");
                }
                else
                {
                    cboFactoryName.SelectedIndex = cboFactoryName.FindString(vo.factory_name);
                    if (cboFactoryName.SelectedIndex < 0)
                    {
                        MessageBox.Show("해당공장을 사용 할 수 없습니다!");
                        cboFactoryName.SelectedIndex = 0;
                    }
                    cboLineName.SelectedIndex = cboLineName.FindString(vo.line_name);
                    if (cboLineName.SelectedIndex < 0)
                    {
                        MessageBox.Show("해당라인을 사용 할 수 없습니다!");
                        cboLineName.SelectedIndex = 0;
                    }
                    cboStorageName.SelectedIndex = cboStorageName.FindString(vo.storage_name);
                    if (cboStorageName.SelectedIndex < 0)
                    {
                        MessageBox.Show("해당창고을 사용 할 수 없습니다!");
                        cboStorageName.SelectedIndex = 0;
                    }
                }
               
                txtName.Text = vo.process_name;
                nudProcess_seq.Value = vo.process_seq;
                txtNote1.Text = vo.process_note1;
                txtNote2.Text = vo.process_note2;
            }
        }

        private void cboCorporationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int corporation_id = cboCorporationName.SelectedValue.ToInt();
            cboFactoryName.ComboBinding(service.FactoryCombo(corporation_id), "factory_id", "factory_name", "선택", 0);
        }

        private void cboFactoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int factory_id = cboFactoryName.SelectedValue.ToInt();
                cboLineName.ComboBinding(service.LineCombo(factory_id), "line_id", "line_name", "선택", 0);
                cboStorageName.ComboBinding(service.StorageCombo(factory_id), "Storage_Id", "Storage_Name", "선택", 0);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.TextLength < 1)
                {
                    MessageBox.Show("공정을 입력해주세요");
                    return;
                }

                string UseCheck;

                if (rdoProcess_useY.Checked == true)
                    UseCheck = "Y";
                else
                    UseCheck = "N";
                if (IsUpdate == false)
                    LineSave(UseCheck, "등록", 0);

                else
                    LineSave(UseCheck, "수정", vo.line_id);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void LineSave(string UseCheck, string Status, int process_id)
        {
            if (MessageBox.Show($"공정을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                ProcessVO process = new ProcessVO
                {
                    process_id = process_id,
                    factory_id = cboFactoryName.SelectedValue.ToInt(),
                    line_id = cboLineName.SelectedValue.ToInt(),
                    storage_id = cboStorageName.SelectedValue.ToInt(),
                    process_name = txtName.Text,
                    process_seq = Convert.ToInt32((nudProcess_seq.Value.ToString().Length > 0) ? nudProcess_seq.Value.ToString() : "0"),
                    process_use = UseCheck,
                    first_regist_employee = employeeName,
                    final_regist_employee = employeeName,
                    process_note1 = txtNote1.Text,
                    process_note2 = txtNote2.Text
                };

                if (service.SaveProcess(process))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
