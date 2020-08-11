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
    public partial class DefectiveTypeSettingForm : BasicForm
    {
        DefectiveService service = new DefectiveService();
        List<DefectiveTypeVO> SelectAllList;
        EmployeeVO emp;
        public DefectiveTypeSettingForm()
        {
            InitializeComponent();
        }

        private void DefectiveTypeSettingForm_Load(object sender, EventArgs e)
        {
            // 불량 유형 CRUD

            dgv.IsAllCheckColumnHeader = true;

            dgv.AddNewCol("불량 코드", "defective_type_id", true, 100);
            dgv.AddNewCol("불량 명칭", "defective_type_name", true, 200);
            dgv.AddNewCol("명칭 사용여부", "defective_type_use", true, 100);
            dgv.AddNewCol("불량 순번", "defective_type_seq", true, 100);
            dgv.AddNewCol("최초등록시간", "first_regist_time", true, 140);
            dgv.AddNewCol("최초등록사원", "first_regist_employee", true, 100);
            dgv.AddNewCol("최종등록시간", "final_regist_time", true, 140);
            dgv.AddNewCol("최종등록사원", "final_regist_employee", true, 100);

            emp = this.GetEmployee();


            ReviewDGV();
        }

        private void ReviewDGV()
        {
            dgv.DataSource = null;
            dgv.DataSource = SelectAllList = service.DefectiveTypeSelectAll();
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
                OpenPopup(false);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            // VO를 보내줘야 함, 수정할 것

            DefectiveTypeVO updateVO = new DefectiveTypeVO
            {
                Defective_Type_ID = dgv[1, e.RowIndex].Value.ToInt(),
                Defective_Type_Use = dgv[3, e.RowIndex].Value.ToString(),
                Defective_Type_Name = dgv[2, e.RowIndex].Value.ToString(),
                Defective_Type_Seq = dgv[4,e.RowIndex].Value.ToInt()
            };
            OpenPopup(true, updateVO);

        }

        private void OpenPopup(bool IsUpdate, DefectiveTypeVO vo = null)
        {
            DefectiveTypePopupForm frm = new DefectiveTypePopupForm(emp.Employee_name, IsUpdate, vo);
            if (frm.ShowDialog() == DialogResult.OK)
                ReviewDGV();
        }


        private void Search(object sender, EventArgs e) // 검색
        {
            if (txtSearchName.Text.Length < 1)
                dgv.DataSource = service.DefectiveTypeSelectAll();
            else
            {
                var SortedList = (from sortList in SelectAllList
                                  where sortList.Defective_Type_Name.Contains(txtSearchName.Text)
                                  select sortList).ToList();

                dgv.DataSource = SortedList;
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            dgv.EndEdit();

            List<int> CheckList = new List<int>();
            
            foreach(DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv[0, row.Index];
                if ((object)chk.Value == null)
                    continue;
                else if ((bool)chk.Value == true)
                {
                    CheckList.Add(dgv[1, row.Index].Value.ToInt());
                }
                
            }

            if (CheckList.Count < 1)
            {
                int DefectiveNo;
                try
                {
                    DefectiveNo = dgv.SelectedRows[0].Cells[1].Value.ToInt();
                }
                catch
                {
                    MessageBox.Show("체크박스를 체크하시거나, 목록을 선택해주세요");
                    return;
                }

                if (MessageBox.Show("정말로 삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                service.DefectiveDelete(DefectiveNo);
            }
            else
            {
                if (MessageBox.Show("정말로 삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                foreach (int ProductNum in CheckList)
                {
                    service.DefectiveDelete(ProductNum);
                }
            }

            MessageBox.Show("삭제가 완료되었습니다.");
            ReviewDGV();
        }
        private void Clear(object sender, EventArgs e)
        {
            txtSearchName.Text = "";
            ReviewDGV();
        }
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(null, null);
        }
    }
}
