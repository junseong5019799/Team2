using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Wizards;
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
    public partial class FactoryForm : ListForm
    {
        DataTable dtDgv;
        FactoryService service = new FactoryService();
        //List<FactoryForm> flist;
        EmployeeVO emp;

        public FactoryForm()
        {
            InitializeComponent();
        }

        private void FactoryForm_Load(object sender, EventArgs e)
        {
            dgvFactorylist.IsAllCheckColumnHeader = true;

            dgvFactorylist.AddNewColumns("법인명", "corporation_name", 100, true);
            dgvFactorylist.AddNewColumns("공장코드", "factory_id", 100, true);
            dgvFactorylist.AddNewColumns("공장명", "factory_name", 100, true);
            dgvFactorylist.AddNewColumns("공장순번", "factory_seq", 100, true);
            dgvFactorylist.AddNewColumns("공장비고1", "factory_note1", 100, true);
            dgvFactorylist.AddNewColumns("공장비고2", "factory_note2", 100, true);
            dgvFactorylist.AddNewBtnCol("사용여부", "", new Padding(1,1,1,1), false); // 7 버튼
            dgvFactorylist.AddNewColumns("사용여부", "factory_use", 100, true); // 명
            dgvFactorylist.AddNewColumns("최초등록시각", "first_regist_time", 100, true);
            dgvFactorylist.AddNewColumns("최초등록사원", "first_regist_employee", 100, true);
            dgvFactorylist.AddNewColumns("최종등록시각", "final_regist_time", 100, true);
            dgvFactorylist.AddNewColumns("최종등록사원", "final_regist_employee", 100, true);

            LoadData();

            cboCorporationName.ComboBinding(service.ComboGet(), "corporation_id", "corporation_name", "전체", 0);
            emp = this.GetEmployee();
        }

        private void LoadData()
        {

           dtDgv= service.SelectFactory();

            dgvFactorylist.DataSource = null;
           dgvFactorylist.DataSource = dtDgv;
        }

        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                string fname = txtFactoryName.Text.Trim();
                FactoryVO vo = new FactoryVO()
                {
                    corporation_id = cboCorporationName.SelectedValue.ToInt()

                };

                dtDgv = service.SearchName(vo);


                DataView dv = dtDgv.DefaultView;
                if (fname.Length > 0)
                {
                    dv.RowFilter = $"factory_name like '%{fname}%'";
                }
                dgvFactorylist.DataSource = dv;
                DataTable dt = dv.ToTable();
                List<FactoryVO> sortedData = SqlHelper.ConvertDataTableToList<FactoryVO>(dt);

                dgvFactorylist.DataSource = sortedData;
            }
        }

        private void OpenPopup(bool IsUpdate, FactoryVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                FactoryPopupForm frm = new FactoryPopupForm(emp.Employee_name, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void dgvFactorylist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvFactorylist.Rows)
            {
                if (dgvFactorylist[8, row.Index].Value.ToString() == "Y")
                    dgvFactorylist[7, row.Index].Value ="사용";
                else if(dgvFactorylist[8, row.Index].Value.ToString() == "N")
                    dgvFactorylist[7, row.Index].Value = "미사용";
            }
        }

        private void dgvFactorylist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                int factory_id = dgvFactorylist[2, e.RowIndex].Value.ToInt();

                if (dgvFactorylist[7, e.RowIndex].Value.ToString() == "사용")
                { 
                    if(service.UseTypeChange(factory_id, "N"))
                            dgvFactorylist[7, e.RowIndex].Value = "미사용";
                }
                else if (dgvFactorylist[7, e.RowIndex].Value.ToString() == "미사용")
                {
                    if (service.UseTypeChange(factory_id, "Y"))
                        dgvFactorylist[7, e.RowIndex].Value = "사용";
                }
                LoadData();
                dgvFactorylist.ClearSelection();

            }
        }

        private void dgvFactorylist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 7)
                return;

            FactoryVO updatevo = new FactoryVO
            {
                factory_id = dgvFactorylist[2,e.RowIndex].Value.ToInt(),
                corporation_name = dgvFactorylist[1, e.RowIndex].Value.ToString(),
                factory_name = dgvFactorylist[3, e.RowIndex].Value.ToString(),
                factory_seq = dgvFactorylist[4, e.RowIndex].Value.ToInt(),
                factory_use = dgvFactorylist[8, e.RowIndex].Value.ToString(),
                factory_note1 = dgvFactorylist[5, e.RowIndex].Value.ToString(),
                factory_note2 = dgvFactorylist[6, e.RowIndex].Value.ToString()
            };
            OpenPopup(true, updatevo);


        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                FactoryPopupForm frm = new FactoryPopupForm(emp.Employee_name, false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("공장을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dgvFactorylist.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dgvFactorylist.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFactorylist[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                            CheckList.Add(dgvFactorylist[2, row.Index].Value.ToInt());

                    }

                    int factory_id = Convert.ToInt32(dgvFactorylist.SelectedRows[0].Cells[2].Value);

                    if (CheckList.Count > 0)
                    {
                        service.FactoryDelete(CheckList);

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

        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                cboCorporationName.SelectedIndex = 0;
                txtFactoryName.Text = "";
                LoadData();
            }
        }

    }
}
