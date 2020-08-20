using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactoryPOP.Services;

namespace WinMSFactoryPOP
{
	public partial class WorkOrderPopupForm : Form
	{
        DataTable dt;
        DataRow dr;
        int workOrderNo;
        int task_proc_id;
        taskItem ti;
        BackgroundWorker worker;
        frmATLTask frm;

        public WorkOrderPopupForm()
		{
			InitializeComponent();
		}

		private void WorkOrderPopupForm_Load(object sender, EventArgs e)
		{
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
			dataGridView1.MultiSelect = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.RowHeadersVisible = false;

			// 작업지시 번호, 품명, 작업자, 지시량
			dataGridView1.AddNewColumns("작업지시 번호", "WORK_ORDER_NO", 200);
			dataGridView1.AddNewColumns("품명", "PRODUCT_NAME", 250);
			dataGridView1.AddNewColumns("작업자", "EMPLOYEE_NAME", 150);
			dataGridView1.AddNewColumns("지시량", "QTY", 120, true, true, false, DataGridViewContentAlignment.MiddleRight);

			int.TryParse(ConfigurationManager.AppSettings["line_id"], out int line_id);
            DataTable comboDt = new ProcessService().GetProcesses(line_id);
            DataRow dr = comboDt.NewRow();
            dr["PROCESS_NAME"] = "전체";
            dr["PROCESS_ID"] = 0;
            comboDt.Rows.InsertAt(dr, 0);

            comboBox1.DataSource = comboDt;
            comboBox1.DisplayMember = "PROCESS_NAME";
            comboBox1.ValueMember = "PROCESS_ID";
            LoadData();
		}

		private void LoadData()
		{
            dt = new WorkOrderService().GetPOPWO(dateTimePicker1.Value.ToShortDateString(), Convert.ToInt32(comboBox1.SelectedValue));
            dataGridView1.DataSource = dt;
        }

		private void button1_Click(object sender, EventArgs e)
		{
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm mainFrm = this.MdiParent as MainForm;
                string process_id = dr["PROCESS_ID"].ToString();
                int index = mainFrm.popList.FindIndex(item => item.Item1 == process_id);

                if (index > -1)
                {
                    MessageBox.Show("해당 공정은 이미 작업 중입니다.");
                    return;
                }

                ti = mainFrm.tasks.FirstOrDefault(item => item.processId == process_id);

                BackgroundWorker task = new BackgroundWorker();
                task.RunWorkerCompleted += Task_RunWorkerCompleted;
                task.RunWorkerAsync();

                worker = new BackgroundWorker();
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                worker.RunWorkerAsync();

                mainFrm.popList.Add((process_id, task_proc_id, worker, frm));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            workOrderNo = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            dr = dt.AsEnumerable().FirstOrDefault(item => Convert.ToInt32(item["WORK_ORDER_NO"]) == workOrderNo);
        }

        private void Task_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string path = $"WinServerTask{ti.taskID.Replace("task", "")}.exe";

            try
            {
                Process proc = Process.Start(path, $"{ti.taskID} {ti.hostIP} {ti.hostPort} {dr["PRODUCT_ID"]}"); // 던질 파라미터
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                task_proc_id = proc.Id;
            }
            catch (Exception err)
            {
                foreach (var process in Process.GetProcesses())
                {
                    if (process.ProcessName == path)
                        process.Kill();
                }
                MessageBox.Show(err.Message);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frm = new frmATLTask(ti.taskID, ti.hostIP, ti.hostPort);
            frm.Show();
            frm.Hide();
        }
	}
}
