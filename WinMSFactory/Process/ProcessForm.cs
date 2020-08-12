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
    public partial class ProcessForm : ListForm
    {
        DataTable dtDgv;
        ProcessService service = new ProcessService();
        List<FactoryVO> factories;
        List<LineVO> lines;
        List<StorageVO> storages;

        EmployeeVO emp;
        public ProcessForm()
        {
            InitializeComponent();
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            dgvProcess.IsAllCheckColumnHeader = true;

            dgvProcess.AddNewColumns("법인명", "corporation_name", 100, true);
            dgvProcess.AddNewColumns("공장명", "factory_name", 100, true);
            dgvProcess.AddNewColumns("라인명", "line_name", 100, true);
            dgvProcess.AddNewColumns("창고명", "Storage_Name", 100, true);
            dgvProcess.AddNewColumns("공정코드", "process_id", 100, true);
            dgvProcess.AddNewColumns("공정명", "process_name", 100, true);
            dgvProcess.AddNewColumns("라인순번", "process_seq", 100, true);
            dgvProcess.AddNewColumns("라인비고1", "process_note1", 100, true);
            dgvProcess.AddNewColumns("라인비고2", "process_note2", 100, true);
            dgvProcess.AddNewBtnCol("사용여부", "", new Padding(1, 1, 1, 1), false); // 10 버튼
            dgvProcess.AddNewColumns("사용여부", "process_use", 100, true); // 11
            dgvProcess.AddNewColumns("최초등록시각", "first_regist_time", 100, true);
            dgvProcess.AddNewColumns("최초등록사원", "first_regist_employee", 100, true);
            dgvProcess.AddNewColumns("최종등록시각", "final_regist_time", 100, true);
            dgvProcess.AddNewColumns("최종등록사원", "final_regist_employee", 100, true);


            LoadData();

            cboCorporationName.ComboBinding(service.CorporationCombo(), "corporation_id", "corporation_name", "전체", 0);
            factories = service.FactoryCombo();
            cboFactoryName.ComboBinding(factories != null ? factories.ToList() : null, "factory_id", "factory_name", "전체", 0);
           
            cboFactoryName.ComboBinding(service.FactoryCombo(), "factory_id", "factory_name", "전체", 0);
            lines = service.LineCombo();
            cboLineName.ComboBinding(lines != null ? lines.ToList() : null, "line_id", "line_name", "전체", 0);
            storages = service.StorageCombo();
            cboStorageName.ComboBinding(storages != null ? storages.ToList() : null, "Storage_Id", "Storage_Name", "전체", 0);

            emp = this.GetEmployee();
        }

        private void LoadData()
        {
            dtDgv = service.GetAll();

            dgvProcess.DataSource = null;
            dgvProcess.DataSource = dtDgv;
        }

        private void Search(object sender, EventArgs e)
        {
            dgvProcess.EndEdit();

            string fname = txtProcessName.Text.Trim();
            ProcessVO vo = new ProcessVO()
            {
                corporation_id = cboCorporationName.SelectedValue.ToInt(),
                factory_id = cboFactoryName.SelectedValue.ToInt(),
                line_id = cboLineName.SelectedValue.ToInt(),
                storage_id= cboStorageName.SelectedValue.ToInt()

            };

            dtDgv = service.ProcessSearch(vo);


            DataView dv = dtDgv.DefaultView;
            if (fname.Length > 0)
            {
                dv.RowFilter = $"process_name like '%{fname}%'";
            }
            dgvProcess.DataSource = dv;
            DataTable dt = dv.ToTable();
            List<ProcessVO> sortedData = SqlHelper.ConvertDataTableToList<ProcessVO>(dt);

            dgvProcess.DataSource = sortedData;
        }

        private void dgvProcess_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvProcess.Rows)
            {
                if (dgvProcess[11, row.Index].Value.ToString() == "Y")
                    dgvProcess[10, row.Index].Value = "사용";
                else if (dgvProcess[11, row.Index].Value.ToString() == "N")
                    dgvProcess[10, row.Index].Value = "미사용";
            }
        }

        private void dgvProcess_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                int process_id = dgvProcess[5, e.RowIndex].Value.ToInt();

                if (dgvProcess[10, e.RowIndex].Value.ToString() == "사용")
                {
                    if (service.UseTypeChange(process_id, "N"))
                        dgvProcess[10, e.RowIndex].Value = "미사용";
                }
                else if (dgvProcess[10, e.RowIndex].Value.ToString() == "미사용")
                {
                    if (service.UseTypeChange(process_id, "Y"))
                        dgvProcess[10, e.RowIndex].Value = "사용";
                }
                dgvProcess.ClearSelection();
            }
        }

        private void dgvProcess_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 10)
                return;

            ProcessVO updatevo = new ProcessVO
            {

                corporation_name = dgvProcess[1, e.RowIndex].Value.ToString(),
                factory_name = dgvProcess[2, e.RowIndex].Value.ToString(),
                line_name = dgvProcess[3, e.RowIndex].Value.ToString(),
                storage_name = dgvProcess[4, e.RowIndex].Value.ToString(),
                process_id = dgvProcess[5, e.RowIndex].Value.ToInt(),
                process_name = dgvProcess[6, e.RowIndex].Value.ToString(),
                process_seq = dgvProcess[7, e.RowIndex].Value.ToInt(),
                process_note1 = dgvProcess[8, e.RowIndex].Value.ToString(),
                process_note2 = dgvProcess[9, e.RowIndex].Value.ToString(),
                process_use = dgvProcess[11, e.RowIndex].Value.ToString()

            };
            OpenPopup(true, updatevo);
        }

        private void OpenPopup(bool IsUpdate, ProcessVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                ProcessPopupForm frm = new ProcessPopupForm(emp.Employee_name, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                ProcessPopupForm frm = new ProcessPopupForm(emp.Employee_name, false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            cboCorporationName.SelectedIndex = 0;
            cboFactoryName.SelectedIndex = 0;
            cboLineName.SelectedIndex = 0;
            txtProcessName.Text = "";
            LoadData();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (MessageBox.Show("공정을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                dgvProcess.EndEdit();

                List<int> CheckList = new List<int>();

                foreach (DataGridViewRow row in dgvProcess.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvProcess[0, row.Index];

                    if (chk.Value == null)
                        continue;

                    else if ((bool)chk.Value == true)
                        CheckList.Add(dgvProcess[5, row.Index].Value.ToInt());

                }

                int process_id = Convert.ToInt32(dgvProcess.SelectedRows[0].Cells[5].Value);

                if (CheckList.Count > 0)
                {
                    service.ProcessDelete(CheckList);

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

        private void cboCorporationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int corporation_id = cboCorporationName.SelectedValue.ToInt();
            var f = factories; 

            if (corporation_id > 0)    
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

        private void cboFactoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStorageName.SelectedValue.ToInt() > 0)
            {
                int storage_id = cboStorageName.SelectedValue.ToInt();
                var s = storages;

                if (storage_id > 0)
                {
                    List<StorageVO> list = new List<StorageVO>();

                    foreach (StorageVO stor in s)
                    {
                        if (stor.Storage_Id == storage_id)
                            list.Add(stor);
                    }

                    s = list;


                }
                else if (s != null)
                    s = s.ToList();

                cboStorageName.ComboBinding(s, "Storage_Id", "Storage_Name", "전체", 0);
            }
            else if (cboLineName.SelectedIndex > 0)
            {

                if (cboStorageName.SelectedValue.ToInt() > 0)
                {
                    int line_id = cboLineName.SelectedValue.ToInt();
                    var l = lines;

                    if (line_id > 0)
                    {
                        List<LineVO> list = new List<LineVO>();

                        foreach (LineVO ln in l)
                        {
                            if (ln.line_id == line_id)
                                list.Add(ln);
                        }

                        l = list;


                    }
                    else if (l != null)
                        l = l.ToList();

                    cboLineName.ComboBinding(l, "line_id", "line_name", "전체", 0);
                }
            }
        }
    }
}
