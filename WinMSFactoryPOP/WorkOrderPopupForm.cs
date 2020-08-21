using MSFactoryVO;
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
        taskItem ti;
        BackgroundWorker worker;

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
            dataGridView1.RowTemplate.Height = 50;

            // 작업지시 번호, 품명, 작업자, 지시량
            dataGridView1.AddNewColumns("작업지시 번호", "WORK_ORDER_NO", 200);
			dataGridView1.AddNewColumns("품명", "PRODUCT_NAME", 300);
			dataGridView1.AddNewColumns("작업자", "EMPLOYEE_NAME", 300);
			dataGridView1.AddNewColumns("지시량", "QTY", 170, true, true, false, DataGridViewContentAlignment.MiddleRight);

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
                string process_id = dr["PROCESS_ID"].ToString();
                MainForm mainFrm = this.MdiParent as MainForm;
                ti = mainFrm.tasks.FirstOrDefault(item => item.processId == process_id);
                int index = mainFrm.popList.FindIndex(item => item.TaskID == ti.taskID);

                if (index > -1)
                {
                    MessageBox.Show("해당 공정은 이미 작업 중입니다.");
                    return;
                }

				worker = new BackgroundWorker();
				worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
				worker.RunWorkerAsync();
			}
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            workOrderNo = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            dr = dt.AsEnumerable().FirstOrDefault(item => Convert.ToInt32(item["WORK_ORDER_NO"]) == workOrderNo);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MainForm mf = this.MdiParent as MainForm;
            string path = $"WInServerTask{ti.taskID.Replace("task", "")}.exe";
            int task_proc_id = 0;

            try
            {
                Process proc = Process.Start(path, $"{ti.taskID} {ti.hostIP} {ti.hostPort} {dr["PRODUCT_ID"]} {dr["PRODUCT_TACT_TIME"]}"); // 던질 파라미터
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

            frmATLTask frm = new frmATLTask(ti.taskID, ti.hostIP, ti.hostPort, workOrderNo);
            frm.Show();
            frm.Hide();

            mf.popList.Add(new POPItem
            {
                TaskID = ti.taskID,
                Task_proc_id = task_proc_id,
                Worker = worker,
                Frm = frm,
                Work_order_no = Convert.ToInt32(dr["WORK_ORDER_NO"]),
                Employee_name = dr["EMPLOYEE_NAME"].ToString(),
                Product_name = dr["PRODUCT_NAME"].ToString(),
                Qty = Convert.ToInt32(dr["QTY"]),
                Process_name = dr["PROCESS_NAME"].ToString()
            });

            PopForm popFrm = (this.MdiParent as MainForm).popFrm;

            if (popFrm != null)
                frm.ReadData += popFrm.ReadDataDisplay;
        }

        public void CloseFrm(frmATLTask frm)
        {
			frm.bExit = true;
			frm.Close();
		}
    }
}
