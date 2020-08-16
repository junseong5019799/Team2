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
    public partial class ProcessWorkerPopupForm : PopUpDialogForm
    {
        ProcessWorkerService service = new ProcessWorkerService();
        ProcessWorkerVO vo;
        CorporationVO cvo;
        FactoryVO fvo;
        LineVO lvo;
        ProcessVO pvo;
         bool IsUpdate;
        string employeeName;
        public ProcessWorkerPopupForm(string employeeName, bool IsUpdate, ProcessWorkerVO vo)
        {
            InitializeComponent();

            this.IsUpdate = IsUpdate;

            this.employeeName = employeeName;
            if (IsUpdate == true)
            {
                this.vo = vo;
            }
        }

        private void ProcessWorkerPopupForm_Load(object sender, EventArgs e)
        {
            cboCorporationName.ComboBinding(service.CorporationCombm(), "corporation_id", "corporation_name", "전체", 0);

            cboCorporationName.SelectedIndex = cboCorporationName.FindString(cvo.corporation_name);
            if (cboCorporationName.SelectedIndex < 0)
            {
                MessageBox.Show("법인명을 먼저 선택해주세요");
            }
            else
            {
                cboFactoryName.SelectedIndex = cboFactoryName.FindString(fvo.factory_name);
                if (cboFactoryName.SelectedIndex < 0)
                {
                    MessageBox.Show("해당공장을 사용 할 수 없습니다!"); //사용 여부:Y
                    cboFactoryName.SelectedIndex = 0;
                }
                cboLineName.SelectedIndex = cboLineName.FindString(lvo.line_name);
                if (cboLineName.SelectedIndex < 0)
                {
                    MessageBox.Show("해당라인을 사용 할 수 없습니다!");
                    cboLineName.SelectedIndex = 0;
                }
                cboProcessName.SelectedIndex = cboProcessName.FindString(pvo.process_name);
                if (cboProcessName.SelectedIndex < 0)
                {
                    MessageBox.Show("해당공정을 사용 할 수 없습니다.");
                    cboProcessName.SelectedIndex = 0;
                }
            }

            txtName.Text = vo.employee_name;
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

               
                if (IsUpdate == false)
                    ProsessWorkerSave("등록", 0);

                else
                    ProsessWorkerSave( "수정", vo.worker_id);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void ProsessWorkerSave(string Status, int worker_id)
        {
            if (MessageBox.Show($"공정 별 작업자를 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                ProcessWorkerVO worker = new ProcessWorkerVO
                {
                    worker_id= worker_id,
                    process_id = cboProcessName.SelectedValue.ToInt(),
                    employee_id = txtName.Text.GetHashCode(),
                    first_regist_employee = employeeName,
                    final_regist_employee = employeeName
     
                };

                if (service.ProcessWorker(worker))
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

        private void cboCorporationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int corporation_id = cboCorporationName.SelectedValue.ToInt();
            cboFactoryName.ComboBinding(service.FactoryCombo(corporation_id), "factory_id", "factory_name", "선택", 0);
        }

        private void cboFactoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int factory_id = cboFactoryName.SelectedIndex.ToInt();
            cboLineName.ComboBinding(service.LineCombo(factory_id), "line_id", "line_name", "선택", 0);
        }

        private void cboLineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int line_id = cboLineName.SelectedIndex.ToInt();
            cboProcessName.ComboBinding(service.ProcessCombo(line_id), "process_id", "process_name","선택", 0);
        }
    }
}
