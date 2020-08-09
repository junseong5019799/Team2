using DevExpress.Utils.Taskbar;
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
    public partial class FactoryPopupForm : PopUpDialogForm
    {
        FactoryService service = new FactoryService();
        FactoryVO vo;
        bool IsUpdate;
        public FactoryPopupForm(bool IsUpdate, FactoryVO vo)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;
            if (IsUpdate == true)
            {
                this.vo = vo;
            }
             
        }

        private void FactoryPopupForm_Load(object sender, EventArgs e)
        {

            cboName.ComboBinding(service.ComboGet(), "corporation_id", "corporation_name", "-------------------------------", 0);

            if (IsUpdate == false)
                rdoFactory_useY.Checked = true;

            else if (IsUpdate == true)
            {
                if (vo.factory_use == "Y")
                {
                    rdoFactory_useY.Checked = true;
                    rdoFactory_useN.Checked = false;
                }

                else
                {
                    rdoFactory_useY.Checked = false;
                    rdoFactory_useN.Checked = true;
                }

                cboName.SelectedIndex = cboName.FindString(vo.corporation_name);
                txtName.Text = vo.factory_name;
                nudFactory_seq.Value = vo.factory_seq;
                txtNote1.Text = vo.factory_note1;
                txtNote2.Text = vo.factory_note2;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.TextLength < 1)
                {
                    MessageBox.Show("공장을 입력해주세요");
                    return;
                }

                string UseCheck;

                if (rdoFactory_useY.Checked == true)
                    UseCheck = "Y";
                else
                    UseCheck = "N";
                if (IsUpdate == false)
                    FactorySave(UseCheck, "등록", 0);

                else
                    FactorySave(UseCheck, "수정", vo.factory_id);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void FactorySave(string UseCheck, string Status, int factory_id)
        {
            if (MessageBox.Show($"공장을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EmployeeVO employee = this.GetEmployee();

                FactoryVO factory = new FactoryVO
                {
                    factory_id = factory_id,
                    corporation_id = cboName.SelectedValue.ToInt(),
                    factory_name = txtName.Text,
                    factory_seq = Convert.ToInt32((nudFactory_seq.Value.ToString().Length > 0) ? nudFactory_seq.Value.ToString() : "0"),
                    factory_use = UseCheck,
                    first_regist_employee = "홍길동",
                    final_regist_employee = "홍길동",
                    factory_note1 = txtNote1.Text,
                    factory_note2 = txtNote2.Text
                };

                if (service.SaveFactory(factory))
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
