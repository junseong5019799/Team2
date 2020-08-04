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
using WinCoffeePrince2nd.Util;
using WinMSFactory.Popup;
using WinMSFactory.Services;
using WinMSFactory.Technology_Standards;

namespace WinMSFactory
{
    public partial class MainForm : Form
    {
        public event EventHandler Search;
        public event EventHandler Add;
        public event EventHandler Delete;
        public event EventHandler Save;
        public event EventHandler Excel;
        public event EventHandler Print;
        public event EventHandler Clear;

        public EmployeeVO Employee { get; set; }
        public bool BtnSearchVisible
        {
            set { btnSearch.Visible = value; }
        }
        public bool BtnAddVisible
        {
            set { btnAdd.Visible = value; }
        }
        public bool BtnSaveVisible
        {
            set { btnSave.Visible = value; }
        }
        public bool BtnDeleteVisible
        {
            set { btnDelete.Visible = value; }
        }
        public bool BtnExcelVisible
        {
            set { btnExcel.Visible = value; }
        }
        public bool BtnPrintVisible
        {
            set { btnPrint.Visible = value; }
        }
        public bool BtnClearVisible
        {
            set { btnClear.Visible = value; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoginForm();
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

		private void toolStripButton11_Click(object sender, EventArgs e)
		{
            AuthorityForm frm = new AuthorityForm();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            mainTabControl1.Visible = true;
            frm.Show();
        }

        private void mainTabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < mainTabControl1.TabPages.Count; i++)
            {
                var tabRect = mainTabControl1.GetTabRect(i);
                //tabRect.Inflate(-2, -2);
                var closeImage = Properties.Resources.Delete_now;
                var imageRect = new Rectangle(
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                    closeImage.Width,
                    closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    this.ActiveMdiChild.Close();
                    //tabForms.TabPages.RemoveAt(i);                    
                    break;
                }
            }
        }


        private void tsbLogOut_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Search != null)
                Search(sender, new EventArgs());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Add != null)
                Add(Add, new EventArgs());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Delete != null)
                Delete(sender, new EventArgs());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save != null)
                Save(sender, new EventArgs());
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (Excel != null)
                Excel(sender, new EventArgs());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Print != null)
                Print(sender, new EventArgs());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (Clear != null)
                Clear(sender, new EventArgs());
        }

        private void ShowLoginForm()
        {
            this.Hide();

            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            LoginForm frm = new LoginForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!this.Visible)
                    this.Visible = true;

                this.Employee = frm.Employee;
                ShowMenu();
            }
            else
                this.Close();
        }

        private void ShowMenu()
        {
            DataTable dt = new AuthorityService().GetProgramAths(Employee.Ath_grp_id);
            string moduleID;
            ToolStripButton tsbPrent = null;

            foreach (DataRow dr in dt.Rows)
            {
                moduleID = dr["MODULE_ID"].ToString();

                if (tsbPrent == null || tsbPrent.Tag?.ToString() != moduleID)
                {
                    ToolStripButton tsbM = new ToolStripButton();
                    tsbM.Text = dr["MODULE_NAME"].ToString();
                    tsbM.Tag = moduleID;
                    tsbM.BackColor = Color.AliceBlue;
                    tsMenu.Items.Add(tsbM);
                    tsbPrent = tsbM;
                    //tsmiPrent.DropDownItems.Add(tsmi);
                }

                ToolStripButton tsbP = new ToolStripButton();
                tsbP.Text = dr["PROG_NAME"].ToString();
                tsbP.Click += (sender, e) => this.MdiChildrenShow(mainTabControl1, dr);
				tsMenu.Items.Add(tsbP);
            }
        }
	}
}
