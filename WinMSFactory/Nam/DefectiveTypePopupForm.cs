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

namespace WinMSFactory
{
    public partial class DefectiveTypePopupForm : PopUpDialogForm
    {
        DefectiveService service = new DefectiveService();
        DefectiveTypeVO vo;
        string employee;
        bool IsUpdate;
        public DefectiveTypePopupForm(string employee, bool IsUpdate, DefectiveTypeVO vo)
        {
            InitializeComponent();
            this.IsUpdate = IsUpdate;
            this.vo = vo;
            this.employee = employee;
        }

        private void DefectiveTypePopupForm_Load(object sender, EventArgs e)
        {
            if (IsUpdate == false)
                rdoUse.Checked = true;

            else if (IsUpdate == true)
            {
                if (vo.Defective_Type_Use == "Y")
                {
                    rdoUse.Checked = true;
                    rdoUnUse.Checked = false;
                }
                   
                else
                {
                    rdoUse.Checked = false;
                    rdoUnUse.Checked = true;
                }
                    
                txtDefectiveString.Text = vo.Defective_Type_Name;
                numericUpDown1.Value = vo.Defective_Type_Seq;
            }
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtDefectiveString.TextLength < 1)
            {
                MessageBox.Show("불량 유형을 입력해주세요");
                return;
            }

            string UseCheck;

            if (rdoUse.Checked == true)
                UseCheck = "Y";
            else
                UseCheck = "N";

            if (IsUpdate == false)
                DefectiveUpsertMethod(UseCheck, "등록", 'I', 0);

            else
                DefectiveUpsertMethod(UseCheck, "수정",'U', vo.Defective_Type_ID);

        }

        private void DefectiveUpsertMethod(string UseCheck, string Status, char Category, int DefectiveID)
        {
            if (MessageBox.Show($"불량 유형을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DefectiveTypeVO typeVO = new DefectiveTypeVO
                {
                    Defective_Type_ID = DefectiveID,
                    Defective_Type_Name = txtDefectiveString.Text,
                    Defective_Type_Use = UseCheck,
                    Final_Regist_Time = DateTime.Now,
                    Final_Regist_Employee = employee, 
                    P_Category = Category,
                    Defective_Type_Seq = numericUpDown1.Value.ToInt()
                };

                if (service.DefectiveTypeUpsert(typeVO))
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
