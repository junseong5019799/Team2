using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
        public delegate void BarCodeReadComplete(object sender, ReadEventArgs e);
        public event EventHandler Search;
        public event EventHandler Add;
        public event EventHandler Delete;
        public event EventHandler Save;
        public event EventHandler Excel;
        public event EventHandler Print;
        public event EventHandler Barcode;
        public event EventHandler Clear;
        public event BarCodeReadComplete Readed;
        int index;  // 메뉴 모듈 index(timer에서 사용)
        SerialPort port;
        StringBuilder strs;

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
        public bool BtnBarcodeVisible
        {
            set { btnBarcode.Visible = value; }
        }
        public bool BtnClearVisible
        {
            set { btnClear.Visible = value; }
        }
        public SerialPort Port
        {
            get
            {
                if (port == null)
                {
                    port = new SerialPort();
                    port.DataReceived += Port_DataReceived;
                }

                return port;
            }
        }
        public string Strs
        {
            set
            {
                if (strs == null)
                    strs = new StringBuilder();

                strs.AppendLine(value);

                if (Readed != null)
                {
                    ReadEventArgs args = new ReadEventArgs();
                    args.ReadMsg = strs.ToString();
                    Readed(this, args);
                }
            }
        }
        public bool IsOpen { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoginForm();

            if (Properties.Settings.Default.PortName.Length > 0)
            {
                SerialPortConnection();
            }
        }

		#region tab
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
		#endregion

		#region menuBtn
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

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (Barcode != null)
                Barcode(sender, new EventArgs());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (Clear != null)
                Clear(sender, new EventArgs());
        }

        private void tsbLogOut_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }
		#endregion

		private void ShowLoginForm()
        {
            this.Hide();
            tsMenu.Items.Clear();

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
            int cnt = 0;
            string moduleID = string.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                if (string.IsNullOrEmpty(moduleID) || dr["MODULE_ID"].ToString() != moduleID)
                {
                    moduleID = dr["MODULE_ID"].ToString();
                    ToolStripButton tsbM = new ToolStripButton();
                    tsbM.Tag = ++cnt;
                    tsbM.Text = dr["MODULE_NAME"].ToString();
                    tsbM.BackColor = Color.AliceBlue;
                    tsbM.Click += (sender, e) =>
                    {
                        if (!timer1.Enabled)
                        { 
                            index = ((ToolStripButton)sender).Tag.ToInt();
                            timer1.Start();
                        }
                    };
                    tsMenu.Items.Add(tsbM);
                }

                ToolStripButton tsbP = new ToolStripButton();
                tsbP.Text = dr["PROG_NAME"].ToString();
                tsbP.Click += (sender, e) => this.MdiChildrenShow(mainTabControl1, dr);
                tsbP.Visible = false;
                tsMenu.Items.Add(tsbP);
                cnt++;
            }

            ToolStripButton tsb = new ToolStripButton();
            tsb.Text = "바코드 설정";
            tsb.Click += (sender, e) =>
            {
                BarcodePortSettingPopForm frm = new BarcodePortSettingPopForm();
                frm.ShowDialog();

                if (Properties.Settings.Default.PortName.Length > 0)
                {
                    SerialPortConnection();
                }
            };
            tsMenu.Items.Add(tsb);
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
            ToolStripItem tsi;

            if (index < tsMenu.Items.Count - 1 && (tsi = tsMenu.Items[index]).Tag.ToInt() == 0)
            {
                tsi.Visible = !tsi.Visible;
                index++;
            }
            else
            { 
                timer1.Stop();
            }
        }

        private void SerialPortConnection()
        {
            if (!Port.IsOpen)   // 연결
            {
                Port.PortName = Properties.Settings.Default.PortName;
                Port.BaudRate = int.Parse(Properties.Settings.Default.Baudrate);
                Port.DataBits = int.Parse(Properties.Settings.Default.DataSize);
                Port.Parity = (Parity)Enum.Parse(typeof(Parity), Properties.Settings.Default.Parity);
                Port.Handshake = (Handshake)Enum.Parse(typeof(Handshake), Properties.Settings.Default.Handshake);

                try
                {
                    Port.Open();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else // 연결 끊기
            {
                Port.Close();
            }

            IsOpen = port.IsOpen;
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);

            string msg = Port.ReadExisting();
            this.Invoke(new EventHandler(delegate { Strs = msg; }));
        }

        public void ClearStrs()
        {
            strs.Clear();
        }

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (Port.IsOpen)
                Port.Close();
        }
	}
}
