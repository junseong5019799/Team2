using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ListForm frm = new ListForm();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            mainTabControl1.Visible = true;
            frm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ListListForm frm = new ListListForm();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            mainTabControl1.Visible = true;
            frm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ListDetailForm frm = new ListDetailForm();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            mainTabControl1.Visible = true;
            frm.Show();
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                mainTabControl1.Visible = false;
            else
            {

                if (this.ActiveMdiChild.Tag == null)
                {
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text + "    ");
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = mainTabControl1;
                    mainTabControl1.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }

                if (!mainTabControl1.Visible) mainTabControl1.Visible = true;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((mainTabControl1.SelectedTab != null) && (mainTabControl1.SelectedTab.Tag != null))
                (mainTabControl1.SelectedTab.Tag as Form).Select();
        }
    }
}
