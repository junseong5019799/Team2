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

namespace WinMSFactoryPOP
{
	public partial class MainForm : Form
	{
		public List<taskItem> tasks = ConfigurationManager.GetSection("taskList") as List<taskItem>;
		// process_id, task_proc_id, frm, worker
		public List<(string, int, BackgroundWorker, frmATLTask)> popList = new List<(string, int, BackgroundWorker, frmATLTask)>();

		public MainForm()
		{
			InitializeComponent();
		}

		private void pOPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PopForm frm = new PopForm();
			frm.WindowState = FormWindowState.Maximized;
			frm.MdiParent = this;
			frm.Show();
		}

		private void 작업지시선택ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WorkOrderPopupForm frm = new WorkOrderPopupForm();
			frm.WindowState = FormWindowState.Maximized;
			frm.MdiParent = this;
			frm.Show();
		}

		private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
		{
			e.Item.Visible = false;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (popList.Count > 0)
			{
				foreach (var item in popList)
				{
					TaskStop(item.Item3, item.Item4);
					TaskServerStop(item.Item2);
				}
			}
		}

		private void TaskStop(BackgroundWorker worker, frmATLTask frm)
		{
			frm.bExit = true;
			frm.Close();
			worker.Dispose();
		}

		private void TaskServerStop(int task_proc_id)
		{
			foreach (var process in Process.GetProcesses())
			{
				if (process.Id == task_proc_id)
				{
					process.Kill();
					break;
				}
			}
		}
	}
}
