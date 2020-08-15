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
                    MessageBox.Show("해당공장을 사용 할 수 없습니다!"); //사용 여부:Y
                    cboFactoryName.SelectedIndex = 0;
                }
                cboLineName.SelectedIndex = cboLineName.FindString(vo.line_name);
                if (cboLineName.SelectedIndex < 0)
                {
                    MessageBox.Show("해당라인을 사용 할 수 없습니다!");
                    cboLineName.SelectedIndex = 0;
                }
                cboProcessName.SelectedIndex = cboProcessName.FindString(vo.process_name);
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

        }

        private void cboLineName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
