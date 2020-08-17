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
    public partial class ProcessWorkerForm : ListForm
    {
        DataTable dtDGV;
        ProcessWorkerService service = new ProcessWorkerService();
        List<ProcessVO> proceses;
        List<FactoryVO> factories;
        List<LineVO> lines;
        List<EmployeeVO> employees;

        EmployeeVO emp;
        public ProcessWorkerForm()
        {
            InitializeComponent();
        }

        private void ProcessWorkerForm_Load(object sender, EventArgs e)
        {
            dgvProcessWorker.IsAllCheckColumnHeader = true;

            dgvProcessWorker.AddNewColumns("법인명", "corporation_name", 100, true);
            dgvProcessWorker.AddNewColumns("공장명", "factory_name", 100, true);
            dgvProcessWorker.AddNewColumns("라인명", "line_name", 100, true);
            dgvProcessWorker.AddNewColumns("공정명", "process_name", 100, true);
            dgvProcessWorker.AddNewColumns("작업자코드", "worker_id", 100, false);
            dgvProcessWorker.AddNewColumns("작업자명", "employee_name", 100, true);

            LoadData();

            cboCorporationName.ComboBinding(service.CorporationCombm(), "corporation_id", "corporation_name", "전체", 0);
            factories = service.FactoryCombo();
            cboFactoryName.ComboBinding(factories != null ? factories.ToList() : null, "factory_id", "factory_name", "전체", 0);
            employees = service.EmployeeCombo();
            cboWorkerName.ComboBinding(employees != null ? employees.ToList() : null, "employee_id", "employee_name", "전체", 0);

            cboFactoryName.ComboBinding(service.FactoryCombo(), "factory_id", "factory_name", "전체", 0);
            lines = service.LineCombo();
            cboLineName.ComboBinding(lines != null ? lines.ToList() : null, "line_id", "line_name", "전체", 0);

            cboLineName.ComboBinding(service.LineCombo(), "line_id", "line_name", "전체", 0);
            proceses = service.ProcessCombo();
            cboProcessName.ComboBinding(proceses != null ? proceses.ToList() : null, "process_id", "process_name", "전체", 0);



            emp = this.GetEmployee();
        }

        private void LoadData()
        {
            dtDGV = service.ProseccWorkerGetAll();

            dgvProcessWorker.DataSource = null;
            dgvProcessWorker.DataSource = dtDGV;
        }

        private void cboCorporationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int corporation_id = cboCorporationName.SelectedValue.ToInt();
            var f = factories;
            var em = employees;

            if (corporation_id > 0)
            {
                List<FactoryVO> flist = new List<FactoryVO>();
                List<EmployeeVO> elist = new List<EmployeeVO>();
                foreach (FactoryVO fac in f)
                {
                    if (fac.corporation_id == corporation_id)
                        flist.Add(fac);
                }

                f = flist;

                foreach (EmployeeVO emp in em)
                {
                    if (emp.Corporation_id == corporation_id)
                        elist.Add(emp);
                }

                em = elist;
            }
            else if (f != null)
                f = f.ToList();
            else if (em != null)
                em = em.ToList(); 

            cboFactoryName.ComboBinding(f, "factory_id", "factory_name", "전체", 0);
            cboWorkerName.ComboBinding(em, "employee_id", "employee_name", "전체", 0);
          
        }

        private void cboFactoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int factory_id = cboFactoryName.SelectedValue.ToInt();
            var l = lines;
            if (factory_id > 0)
            {
                List<LineVO> list = new List<LineVO>();

                foreach (LineVO ln in l)
                {
                    if (ln.factory_id == factory_id)
                        list.Add(ln);
                }
                l = list;
            }
            else if (l != null)
                l = l.ToList();

            cboLineName.ComboBinding(l, "line_id", "line_name", "전체", 0);
        }

        private void cboLineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int line_id = cboLineName.SelectedValue.ToInt();
            var p = proceses;
            if (line_id > 0)
            {
                List<ProcessVO> list = new List<ProcessVO>();

                foreach (ProcessVO pc in p)
                {
                    if (pc.line_id == line_id)
                        list.Add(pc);
                }
                p = list;
            }
            else if (p != null)
                p = p.ToList();

            cboProcessName.ComboBinding(p, "process_id", "process_name", "전체", 0);
        }

      

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                ProcessWorkerPopupForm frm = new ProcessWorkerPopupForm(emp.Employee_name, false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            cboCorporationName.SelectedIndex = 0;
            cboFactoryName.SelectedIndex = 0;
            cboLineName.SelectedIndex = 0;
            cboProcessName.SelectedIndex = 0;
            cboWorkerName.SelectedIndex = 0;
            LoadData();
        }

        private void dgvProcessWorker_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 10)
                return;

            ProcessWorkerVO updatevo = new ProcessWorkerVO
            {

                corporation_name = dgvProcessWorker[1, e.RowIndex].Value.ToString(),
                factory_name = dgvProcessWorker[2, e.RowIndex].Value.ToString(),
                line_name = dgvProcessWorker[3, e.RowIndex].Value.ToString(),
                process_name = dgvProcessWorker[4, e.RowIndex].Value.ToString(),
                worker_id = dgvProcessWorker[5, e.RowIndex].Value.ToInt(),
                employee_name = dgvProcessWorker[6, e.RowIndex].Value.ToString()

            };
            OpenPopup(true, updatevo);
        }

        private void OpenPopup(bool IsUpdate, ProcessWorkerVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                ProcessWorkerPopupForm frm = new ProcessWorkerPopupForm(emp.Employee_name, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (MessageBox.Show("공정 별 작업자를 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                dgvProcessWorker.EndEdit();

                List<int> CheckList = new List<int>();

                foreach (DataGridViewRow row in dgvProcessWorker.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvProcessWorker[0, row.Index];

                    if (chk.Value == null)
                        continue;

                    else if ((bool)chk.Value == true)
                        CheckList.Add(dgvProcessWorker[5, row.Index].Value.ToInt());

                }

                int worker_id = Convert.ToInt32(dgvProcessWorker.SelectedRows[0].Cells[5].Value);

                if (CheckList.Count > 0)
                {
                    service.ProcessWorkerDelete(CheckList);

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

        private void Search(object sender, EventArgs e)
        {
            dgvProcessWorker.EndEdit();


            ProcessWorkerVO vo = new ProcessWorkerVO()
            {
                corporation_id = cboCorporationName.SelectedValue.ToInt(),
                factory_id = cboFactoryName.SelectedValue.ToInt(),
                line_id = cboLineName.SelectedValue.ToInt(),
                process_id = cboProcessName.SelectedValue.ToInt(),
                employee_id = cboWorkerName.SelectedValue.ToString()

            };

            dtDGV = service.ProcessWorkerSearch(vo);
            dgvProcessWorker.DataSource = dtDGV;
        }
    }
}
