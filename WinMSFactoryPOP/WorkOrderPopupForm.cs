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
		public WorkOrderPopupForm()
		{
			InitializeComponent();
		}

		private void WorkOrderPopupForm_Load(object sender, EventArgs e)
		{
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.MultiSelect = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.RowHeadersVisible = false;

			// 작업지시 번호, 품명, 작업자, 지시량
			dataGridView1.AddNewColumns("작업지시 번호", "", 150);
			dataGridView1.AddNewColumns("품명", "", 200);
			dataGridView1.AddNewColumns("작업자", "", 150);
			dataGridView1.AddNewColumns("지시량", "", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);

			int.TryParse(ConfigurationManager.AppSettings["line_id"], out int line_id);
			comboBox1.DataSource = new ProcessService().GetProcesses(line_id);
		}
		        
        private void button1_Click(object sender, EventArgs e)
		{

		}

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Task_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string path = $"WinServerTask{Task_ID.Replace("task", "")}.exe";

            try
            {
                Process proc = Process.Start(path, $"{Task_ID} {Task_IP} {Task_Port}"); // 던질 파라미터
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                task_proc_id = proc.Id;
                IsTask = true;
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

        private void btnTaskStop_Click(object sender, EventArgs e)
        {
            string path = $"WinServerTask{Task_ID.Replace("task", "")}";
            foreach (var process in Process.GetProcesses())
            {
                if (process.Id == task_proc_id)
                {
                    process.Kill();
                    IsTask = false;
                }
            }
        }
    }
}
