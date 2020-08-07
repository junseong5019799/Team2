using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class GroupManagementForm : ListForm
    {
        ProductGroupService service = new ProductGroupService();
        List<ProductGroupVO> SelectAllGroup;
        // 제품 그룹 관리
        public GroupManagementForm()
        {
            InitializeComponent();
        }

        private void frmMItemGrp_Load(object sender, EventArgs e)
        {
            dgv.IsAllCheckColumnHeader = true;
            dgvColumns();

            SelectAllGroup = service.SelectAllProductGroups();
            ReviewDGV();

            // dgv 체크박스만 readonly false
            for (int i = 0; i < dgv.Rows.Count; i++)
                for (int j = 1; j < dgv.Columns.Count; j++)
                    dgv[j, i].ReadOnly = true;
        }

        private void dgvColumns()
        {
            dgv.AddNewColumns("번호", "Product_Group_ID", 100, true); // identity
            dgv.AddNewColumns("제품그룹 명칭", "Product_Group_Name", 200, true);
            dgv.AddNewBtnCol("", "사용 여부", new Padding(1, 1, 1, 1)); // 제품 그룹의 사용 여부를 결정
            dgv.AddNewColumns("비고1", "Product_Group_Note1", 150, true);
            dgv.AddNewColumns("비고2", "Product_Group_Note2", 150, true);
            dgv.AddNewColumns("최초등록시각", "First_Regist_Time", 170, true);
            dgv.AddNewColumns("최초등록사원", "First_Regist_Employee", 130, true);
            dgv.AddNewColumns("최종등록시각", "Final_Regist_Time", 170, true);
            dgv.AddNewColumns("최종등록사원", "Final_Regist_Employee", 130, true);
            dgv.AddNewColumns("순번", "Product_Group_Seq", 100, false);
            dgv.AddNewColumns("사용여부", "Product_Group_Use_String", 100, false); // 이 값에 따라 사용 여부 버튼 텍스트가 달라짐
        }

        private void ReviewDGV()
        {
            dgv.DataSource = null;
            dgv.DataSource = service.SelectAllProductGroups();
        }
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow row in dgv.Rows)
            {
                if (dgv[11, row.Index].Value.ToString() == "Y")
                    dgv[3, row.Index].Value = "사용";
                else 
                    dgv[3, row.Index].Value = "미사용";
            }
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                ProductGroupInfoForm frm = new ProductGroupInfoForm();

                if (frm.ShowDialog() == DialogResult.OK)
                    ReviewDGV();
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                dgv.EndEdit();

                int DeleteNum;
                try
                {
                    DeleteNum = dgv.SelectedRows[0].Cells[1].Value.ToInt();
                }
                catch
                {
                    MessageBox.Show("체크박스를 체크하시거나, 목록을 선택해주세요");
                    return;
                }

                List<int> CheckList = new List<int>();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv[0, row.Index];

                    if (chk.Value == null)
                        continue;

                    else if ((bool)chk.Value == true)
                        CheckList.Add(dgv[1, row.Index].Value.ToInt());

                }

                if (CheckList.Count < 1) // 체크가 안되어있을 때
                {
                    string valueString = dgv.SelectedRows[0].Cells[2].Value.ToString();

                    if (valueString == "반제품" || valueString == "재료")
                    {
                        MessageBox.Show("반제품과 재료 그룹은 삭제가 불가능합니다.");
                        return;
                    }

                    if (MessageBox.Show("정말로 삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (service.DeleteGroups(DeleteNum))
                        {
                            MessageBox.Show("그룹이 삭제되었습니다.");
                            ReviewDGV();
                        }
                    }
                }
                else
                {

                    if (MessageBox.Show("정말로 삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv[0, row.Index];

                            if (chk.Value == null)
                                continue;

                            if ((bool)chk.Value == true)
                            {
                                string ProductGroup = dgv[2, row.Index].Value.ToString();

                                if (ProductGroup == "반제품" || ProductGroup == "재료")
                                {
                                    MessageBox.Show("반제품과 재료 그룹은 삭제가 불가능합니다.");
                                    return;
                                }
                            }
                        }

                        foreach (int numbers in CheckList)
                        {
                            service.DeleteGroups(numbers);
                        }
                        MessageBox.Show("그룹이 삭제되었습니다.");
                        ReviewDGV();
                    }
                }
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ItemNum = dgv[0, e.RowIndex].Value.ToInt();
            if (e.ColumnIndex == 3)
            {
                if (dgv[3, e.RowIndex].Value.ToString() == "미사용")
                {
                    service.UpdateStatus(ItemNum,Convert.ToInt32(UseCheckNum.ProductUnUsed));
                    dgv[3, e.RowIndex].Value = "사용";
                }

                else
                {
                    service.UpdateStatus(ItemNum, Convert.ToInt32(UseCheckNum.ProductUsed));
                    dgv[3, e.RowIndex].Value = "미사용";
                }
            }
        }


        private void buttonControl1_Click(object sender, EventArgs e)
        {
            if (txtGroupName.TextLength < 1)
                dgv.DataSource = SelectAllGroup;
            else
            {
                var List = (from SortedList in SelectAllGroup
                            where SortedList.Product_Group_Name.Contains(txtGroupName.Text)
                            select SortedList).ToList();

                dgv.DataSource = List;
            }
        }
    }
}
