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
        EmployeeVO emp;
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


            emp = this.GetEmployee();
        }

        private void dgvColumns()
        {
            dgv.AddNewColumns("번호", "Product_Group_ID", 100, false); // identity
            dgv.AddNewColumns("제품그룹 명칭", "Product_Group_Name", 200, true);
            dgv.AddNewColumns("사용여부", "Product_Group_Use_String", 100, true);
            dgv.AddNewColumns("순번", "Product_Group_Seq", 100, true);
            dgv.AddNewColumns("비고1", "Product_Group_Note1", 150, true);
            dgv.AddNewColumns("비고2", "Product_Group_Note2", 150, true);
            dgv.AddNewColumns("최초등록시각", "First_Regist_Time", 170, true);
            dgv.AddNewColumns("최초등록사원", "First_Regist_Employee", 130, true);
            dgv.AddNewColumns("최종등록시각", "Final_Regist_Time", 170, true);
            dgv.AddNewColumns("최종등록사원", "Final_Regist_Employee", 130, true);
            
        }

        private void ReviewDGV()
        {
            dgv.DataSource = null;
            dgv.DataSource = service.SelectAllProductGroups();
        }
        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                ProductGroupInfoForm frm = new ProductGroupInfoForm(emp.Employee_name);

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

                    if (MessageBox.Show("정말로 삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
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
        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                txtGroupName.Text = "";
                ReviewDGV();
            }
        }

        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
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

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv[2, e.RowIndex].Value.ToString() == "반제품" || dgv[2, e.RowIndex].Value.ToString() == "재료")
            {
                MessageBox.Show("반제품, 재료는 수정이 불가능합니다.");
                return;
            }
                


            ProductGroupVO vo = new ProductGroupVO
            {
                Product_Group_ID = dgv[1,e.RowIndex].Value.ToInt(),
                Product_Group_Use_String = dgv[3,e.RowIndex].Value.ToString(),
                Product_Group_Seq = dgv[4,e.RowIndex].Value.ToInt(),
                Product_Group_Name = dgv[2,e.RowIndex].Value.ToString(),
                Product_Group_Note1 = dgv[5,e.RowIndex].Value.ToString(),
                Product_Group_Note2 = dgv[6,e.RowIndex].Value.ToString()
            };

            
            ProductGroupInfoForm frm = new ProductGroupInfoForm(emp.Employee_name,true, vo);

            if(frm.ShowDialog() == DialogResult.OK)
                ReviewDGV();
        }
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(null, null);
        }
    }
}
