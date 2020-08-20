using MSFactoryDAC;
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
    public partial class LineForm : ListForm
    {
        DataTable dtDgv;
        LineService service = new LineService();
        List<FactoryVO> factories;

        EmployeeVO emp;
        public LineForm()
        {
            InitializeComponent();
        }

        private void LineForm_Load(object sender, EventArgs e)
        {
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            dgvLinelist.IsAllCheckColumnHeader = true;

            dgvLinelist.AddNewColumns("법인명", "corporation_name", 100, true);
            dgvLinelist.AddNewColumns("공장명", "factory_name", 100, true);
            dgvLinelist.AddNewColumns("라인코드", "line_id", 100, true);
            dgvLinelist.AddNewColumns("라인명", "line_name", 100, true);
            dgvLinelist.AddNewColumns("라인순번", "line_seq", 100, true, true, false, RightAlign);
            dgvLinelist.AddNewColumns("라인비고1", "line_note1", 100, true);
            dgvLinelist.AddNewColumns("라인비고2", "line_note2", 100, true);
            dgvLinelist.AddNewBtnCol("사용여부", "", new Padding(1, 1, 1, 1), false); // 8 버튼
            dgvLinelist.AddNewColumns("사용여부", "line_use", 100, true); // 9
            dgvLinelist.AddNewColumns("최초등록시각", "first_regist_time", 100, true);
            dgvLinelist.AddNewColumns("최초등록사원", "first_regist_employee", 100, true);
            dgvLinelist.AddNewColumns("최종등록시각", "final_regist_time", 100, true);
            dgvLinelist.AddNewColumns("최종등록사원", "final_regist_employee", 100, true);

            LoadData();
            cboCorporationName.ComboBinding(service.LineComboGet(), "corporation_id", "corporation_name", "전체", 0);
            factories = service.factoryAllCombo();
            cboFactoryName.ComboBinding(factories != null ? factories.ToList() : null, "factory_id", "factory_name", "전체", 0);


            emp = this.GetEmployee();
        }

        private void LoadData()
        {
            dtDgv = service.GetAll();

            dgvLinelist.DataSource = null;
            dgvLinelist.DataSource = dtDgv;
        }

        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                dgvLinelist.EndEdit();

                string fname = txtLineName.Text.Trim();
                LineVO vo = new LineVO()
                {
                    corporation_id = cboCorporationName.SelectedValue.ToInt(),
                    factory_id = cboFactoryName.SelectedValue.ToInt()

                };

                dtDgv = service.LineSearch(vo);


                DataView dv = dtDgv.DefaultView;
                if (fname.Length > 0)
                {
                    dv.RowFilter = $"line_name like '%{fname}%'";
                }
                dgvLinelist.DataSource = dv;
                DataTable dt = dv.ToTable();
                List<LineVO> sortedData = SqlHelper.ConvertDataTableToList<LineVO>(dt);

                dgvLinelist.DataSource = sortedData;
            }
        }

        private void dgvLinelist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvLinelist.Rows)
            {
                if (dgvLinelist[9, row.Index].Value.ToString() == "Y")
                    dgvLinelist[8, row.Index].Value = "사용";
                else if (dgvLinelist[9, row.Index].Value.ToString() == "N")
                    dgvLinelist[8, row.Index].Value = "미사용";
            }
        }

        private void dgvLinelist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                int line_id = dgvLinelist[3, e.RowIndex].Value.ToInt();

                if (dgvLinelist[8, e.RowIndex].Value.ToString() == "사용")
                {
                    if (service.UseTypeChange(line_id, "N"))
                        dgvLinelist[8, e.RowIndex].Value = "미사용";
                }
                else if (dgvLinelist[8, e.RowIndex].Value.ToString() == "미사용")
                {
                    if (service.UseTypeChange(line_id, "Y"))
                        dgvLinelist[8, e.RowIndex].Value = "사용";
                }
                dgvLinelist.ClearSelection();
            }

        }

        private void dgvLinelist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 8)
                return;

            LineVO updatevo = new LineVO
            {

                corporation_name = dgvLinelist[1, e.RowIndex].Value.ToString(),
                factory_name = dgvLinelist[2, e.RowIndex].Value.ToString(),
                line_id = dgvLinelist[3, e.RowIndex].Value.ToInt(),
                line_name = dgvLinelist[4, e.RowIndex].Value.ToString(),
                line_seq = dgvLinelist[5, e.RowIndex].Value.ToInt(),
                line_note1 = dgvLinelist[6, e.RowIndex].Value.ToString(),
                line_note2 = dgvLinelist[7, e.RowIndex].Value.ToString(),
                line_use = dgvLinelist[9, e.RowIndex].Value.ToString()

            };
            OpenPopup(true, updatevo);
         }

        private void OpenPopup(bool IsUpdate, LineVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                LinePopupForm frm = new LinePopupForm(emp.Employee_name, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                LinePopupForm frm = new LinePopupForm(emp.Employee_name,false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                cboFactoryName.SelectedIndex = 0;
                cboCorporationName.SelectedIndex = 0;
                txtLineName.Text = "";
                LoadData();
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("라인을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dgvLinelist.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dgvLinelist.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvLinelist[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                            CheckList.Add(dgvLinelist[3, row.Index].Value.ToInt());

                    }

                    int line_id = Convert.ToInt32(dgvLinelist.SelectedRows[0].Cells[3].Value);

                    if (CheckList.Count > 0)
                    {
                        service.LineDelete(CheckList);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("다시 선택해주세요");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void cboCorporationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int corporation_id = cboCorporationName.SelectedValue.ToInt();
            var f = factories; //List<factoryVO>

            if (corporation_id > 0)    // vo.corprration 값이있으면
            {
                List<FactoryVO> list = new List<FactoryVO>();

                foreach (FactoryVO fac in f)
                {
                    if (fac.corporation_id == corporation_id)
                        list.Add(fac);
                }

                f = list;


            }
            else if (f != null)
                f = f.ToList();

            cboFactoryName.ComboBinding(f, "factory_id", "factory_name", "전체", 0);
        }
    }
}
