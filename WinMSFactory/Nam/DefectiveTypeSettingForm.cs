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
using WinMSFactory.Nam;

namespace WinMSFactory
{
    public partial class DefectiveTypeSettingForm : BasicForm
    {
        DefectiveService service = new DefectiveService();
        List<DefectiveTypeVO> SelectAllList;
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
            dgv.AddNewCol("불량 순번", "defective_type_seq", false, 100);
            dgv.AddNewBtnCol("명칭 사용여부","", new Padding(1, 1, 1, 1));
            dgv.AddNewCol("최초등록시간", "first_regist_time", true, 140);
            dgv.AddNewCol("최초등록사원", "first_regist_employee", true, 100);
            dgv.AddNewCol("최종등록시간", "final_regist_time", true, 140);
            dgv.AddNewCol("최종등록사원", "final_regist_employee", true, 100);
            dgv.AddNewCol("명칭 사용여부", "defective_type_use", false, 100);

            
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
            if (e.RowIndex < 0 || e.ColumnIndex == 4)
                return;
            // VO를 보내줘야 함, 수정할 것

            DefectiveTypeVO updateVO = new DefectiveTypeVO
            {
                Defective_Type_ID = dgv[1, e.RowIndex].Value.ToInt(),
                Defective_Type_Use = dgv[9, e.RowIndex].Value.ToString(),
                Defective_Type_Name = dgv[2, e.RowIndex].Value.ToString()
            };
            OpenPopup(true, updateVO);

        }

        private void OpenPopup(bool IsUpdate, DefectiveTypeVO vo = null)
        {
            DefectiveTypePopupForm frm = new DefectiveTypePopupForm(IsUpdate, vo);
            if (frm.ShowDialog() == DialogResult.OK)
                ReviewDGV();
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow row in dgv.Rows)
            {
                if (dgv[9, row.Index].Value.ToString() == "Y")
                    dgv[4, row.Index].Value = "사용";
                else if (dgv[9, row.Index].Value.ToString() == "N")
                    dgv[4, row.Index].Value = "미사용";
            }
            
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                int ProductID = dgv[1, e.RowIndex].Value.ToInt();

                if (dgv[4, e.RowIndex].Value.ToString() == "사용")
                {
                    if(service.UseTypeChange(ProductID,"N"))
                        dgv[4, e.RowIndex].Value = "미사용";
                }
                else if(dgv[4, e.RowIndex].Value.ToString() == "미사용")
                {
                    if (service.UseTypeChange(ProductID, "Y"))

                        dgv[4, e.RowIndex].Value = "사용";
                }

                ReviewDGV();
                dgv.ClearSelection();
            }
        }

        private void buttonControl1_Click(object sender, EventArgs e) // 검색
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
                else if((bool)chk.Value == true)
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
    }
}
