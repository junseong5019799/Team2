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
    public partial class DowntimeTypePopupForm : PopUpDialogForm
    {
        DowntimeTypeService service = new DowntimeTypeService();
        DowntimeTypeVO vo;
        bool IsUpdate;
        string employeeName;

        public DowntimeTypePopupForm(string employeeName, bool IsUpdate, DowntimeTypeVO vo)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;

            this.employeeName = employeeName;
            if (IsUpdate == true)
            {
                this.vo = vo;
            }
        }

        private void DowntimePopupForm_Load(object sender, EventArgs e)
        {

            if (IsUpdate == false)
                rdoDowntimeType_useY.Checked = true;

            else if (IsUpdate == true)
            {
                if (vo.downtime_type_use == "Y")
                {
                    rdoDowntimeType_useY.Checked = true;
                    rdoDowntimeType_useN.Checked = false;
                }

                else
                {
                    rdoDowntimeType_useY.Checked = false;
                    rdoDowntimeType_useN.Checked = true;
                }
                txtName.Text = vo.downtime_type_name;
                nudDowntimeType_seq.Value = vo.downtime_type_seq;

            }

            if (IsUpdate == false)
                rboTimeuse.Checked = true;

            else if (IsUpdate == true)
            {
                if (vo.downtime_type_calculation == "Y")
                {
                    rboTimeuse.Checked = true;
                    rboTimeNotuse.Checked = false;
                }
                else
                {
                    rboTimeuse.Checked = false;
                    rboTimeNotuse.Checked = true;
                }

                txtName.Text = vo.downtime_type_name;
                nudDowntimeType_seq.Value = vo.downtime_type_seq;
            }
                

           
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.TextLength < 1)
                {
                    MessageBox.Show("유형을 입력해주세요");
                    return;
                }

                string UseCheck;
                string TimeCheck;

                if (rdoDowntimeType_useY.Checked == true )
                {
                    UseCheck = "Y";
                  
                }
                else
                {
                    UseCheck = "N";
                   
                }

                if (rboTimeuse.Checked == true)
                {
                    TimeCheck = "Y";
                }
                else
                {
                    TimeCheck = "N";
                }

                if (IsUpdate == false)
                    DowntimeTypeSave(UseCheck, TimeCheck, "등록", 0);

                else
                    DowntimeTypeSave(UseCheck, TimeCheck, "수정", vo.downtime_type_id);

            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void DowntimeTypeSave(string UseCheck, string TimeCheck, string Status, int downtime_type_id)
        {
            if (MessageBox.Show($"유형을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EmployeeVO employee = this.GetEmployee();

                DowntimeTypeVO downtimetype = new DowntimeTypeVO
                {
                    downtime_type_id = downtime_type_id,
                    downtime_type_name = txtName.Text,
                    downtime_type_calculation = TimeCheck,
                    downtime_type_seq = Convert.ToInt32((nudDowntimeType_seq.Value.ToString().Length > 0) ? nudDowntimeType_seq.Value.ToString() : "0"),
                    downtime_type_use = UseCheck,
                    first_regist_employee = employeeName,
                    final_regist_employee = employeeName,
                };

                if (service.SaveDowntimeType(downtimetype))
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
