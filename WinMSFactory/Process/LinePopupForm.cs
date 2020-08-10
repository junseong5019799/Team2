using DevExpress.Charts.Model;
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
    public partial class LinePopupForm : PopUpDialogForm
    {
        LineService service = new LineService();
        LineVO vo;
        bool IsUpdate;
        string employeeName;
        public LinePopupForm(string employeeName, bool IsUpdate, LineVO vo)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;

            this.employeeName = employeeName;
            if (IsUpdate == true)
            {
                this.vo = vo;
            }
        }

        private void LinePopupForm_Load(object sender, EventArgs e)
        {
 
            cboCorporationName.ComboBinding(service.LineComboGet(), "corporation_id", "corporation_name", "전체", 0);

            if (IsUpdate == false)
                rdoLine_useY.Checked = true;

            else if (IsUpdate == true)
            {
                cboCorporationName.Enabled = false;

                if (vo.line_use == "Y")
                {
                    rdoLine_useY.Checked = true;
                    rdoLine_useN.Checked = false;
                    
                }

                else
                {
                    rdoLine_useY.Checked = false;
                    rdoLine_useN.Checked = true;
                }

                cboCorporationName.SelectedIndex = cboCorporationName.FindString(vo.corporation_name);
                cboFactoryName.SelectedIndex = cboFactoryName.FindString(vo.factory_name);
                txtLineName.Text = vo.line_name;
                nudLine_seq.Value = vo.line_seq;
                txtNote1.Text = vo.line_note1;
                txtNote2.Text = vo.line_note2;
            }

        }

        private void cboCorporationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int corporation_id = cboCorporationName.SelectedValue.ToInt();
            cboFactoryName.ComboBinding(service.FactoryCombo(corporation_id), "factory_id", "factory_name", "전체", 0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLineName.TextLength < 1)
                {
                    MessageBox.Show("라인을 입력해주세요");
                    return;
                }

                string UseCheck;

                if (rdoLine_useY.Checked == true)
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

        private void LineSave(string UseCheck, string Status, int line_id)
        {
            if (MessageBox.Show($"라인을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                LineVO line = new LineVO
                {
                    line_id = line_id,
                    factory_id = cboFactoryName.SelectedValue.ToInt(),
                    line_name = txtLineName.Text,
                    line_seq = Convert.ToInt32((nudLine_seq.Value.ToString().Length > 0) ? nudLine_seq.Value.ToString() : "0"),
                    line_use = UseCheck,
                    first_regist_employee = employeeName,
                    final_regist_employee = employeeName,
                    line_note1 = txtNote1.Text,
                    line_note2 = txtNote2.Text
                };

                if (service.SaveLine(line))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
