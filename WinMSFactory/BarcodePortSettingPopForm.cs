using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinMSFactory
{
	public partial class BarcodePortSettingPopForm : WinMSFactory.PopUpDialogForm
	{
		SerialPort port;
		StringBuilder strs;

		private SerialPort Port
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

		private string Strs
		{
			set
			{
				if (strs == null)
					strs = new StringBuilder();

				strs.AppendLine(value);
				textBox1.Text = strs.ToString();
			}
		}

		private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			Thread.Sleep(500);

			string msg = Port.ReadExisting();
			this.Invoke(new EventHandler(delegate { Strs = $"[RECV] {msg}"; }));
		}

		public BarcodePortSettingPopForm()
		{
			InitializeComponent();
		}

		private void BarcodePortSettingPopForm_Load(object sender, EventArgs e)
		{
			// 시리얼포트 목록 조회
			cboComport.DataSource = SerialPort.GetPortNames();
			// 컨피그에서 설정값이 있는 경우, 그 값을 조회해서 바인딩
			cboComport.SelectedIndex = cboComport.Items.IndexOf(Properties.Settings.Default.PortName);
			cboBaudrate.SelectedIndex = cboBaudrate.Items.IndexOf(Properties.Settings.Default.Baudrate);
			cboDataSize.SelectedIndex = cboDataSize.Items.IndexOf(Properties.Settings.Default.DataSize);
			cboParity.SelectedIndex = cboParity.Items.IndexOf(Properties.Settings.Default.Parity);
			cboHandshake.SelectedIndex = cboHandshake.Items.IndexOf(Properties.Settings.Default.Handshake);
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (!Port.IsOpen)   // 연결
			{
				Port.PortName = cboComport.SelectedItem.ToString();
				Port.BaudRate = Convert.ToInt32(cboBaudrate.SelectedItem);
				Port.DataBits = Convert.ToInt32(cboDataSize.SelectedItem);
				Port.Parity = (Parity)cboParity.SelectedIndex;
				Port.Handshake = (Handshake)cboHandshake.SelectedIndex;

				try
				{
					Port.Open();
					textBox1.Text = "연결됨";
					textBox1.Text += Port.ReadExisting();
					btnConnect.Text = "연결 끊기";
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}
			else // 연결 끊기
			{
				Port.Close();
				btnConnect.Text = "연결";
			}
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (cboComport.Text.Length > 0 && cboBaudrate.Text.Length > 0)
			{
				Properties.Settings.Default.PortName = cboComport.Text;
				Properties.Settings.Default.Baudrate = cboBaudrate.Text;
				Properties.Settings.Default.DataSize = cboDataSize.Text;
				Properties.Settings.Default.Parity = cboParity.Text;
				Properties.Settings.Default.Handshake = cboHandshake.Text;

				Properties.Settings.Default.Save();

				MessageBox.Show("시리얼포트 설정이 저장되었습니다.");

				if (MessageBox.Show("팝업창을 닫으시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					this.Close();
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void BarcodePortSettingPopForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Port.IsOpen)
				Port.Close();
		}
	}
}
