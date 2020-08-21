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
		public List<POPItem> popList = new List<POPItem>();
		public PopForm popFrm;
		public WorkOrderPopupForm workOrderPopupForm;

		public MainForm()
		{
			InitializeComponent();
		}

		private void pOPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (popFrm == null)
			{
				popFrm = new PopForm();
				popFrm.WindowState = FormWindowState.Maximized;
				popFrm.MdiParent = this;
				popFrm.Show();
			}
			else
			{
				foreach (Form frm in Application.OpenForms)
				{
					if (frm is PopForm)
						frm.Activate();
				}
			}
		}

		private void 작업지시선택ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (workOrderPopupForm == null)
			{
				workOrderPopupForm = new WorkOrderPopupForm();
				workOrderPopupForm.WindowState = FormWindowState.Maximized;
				workOrderPopupForm.MdiParent = this;
				workOrderPopupForm.Show();
			}
			else
			{
				foreach (Form frm in Application.OpenForms)
				{
					if (frm is WorkOrderPopupForm)
						frm.Activate();
				}
			}
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
					Stop(item.Worker, item.Frm, item.Task_proc_id);
				}
			}
		}

		public void Stop(BackgroundWorker worker, frmATLTask frm, int task_proc_id)
		{
			TaskStop(worker, frm);
			TaskServerStop(task_proc_id);
		}

		public void TaskStop(BackgroundWorker worker, frmATLTask frm)
		{
			try
			{
				frm.bExit = true;
				frm.Close();
				worker?.Dispose();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		public void TaskServerStop(int task_proc_id)
		{
			try
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
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}
	}
}
