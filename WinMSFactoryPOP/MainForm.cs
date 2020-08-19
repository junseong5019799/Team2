using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactoryPOP
{
	public partial class MainForm : Form
	{
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
	}
}
