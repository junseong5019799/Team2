namespace WinMSFactory
{
	partial class BarcodePortSettingPopForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboHandshake = new System.Windows.Forms.ComboBox();
			this.cboParity = new System.Windows.Forms.ComboBox();
			this.cboDataSize = new System.Windows.Forms.ComboBox();
			this.cboBaudrate = new System.Windows.Forms.ComboBox();
			this.cboComport = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnConnect = new WinMSFactory.ButtonControl();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 492);
			this.panel1.Size = new System.Drawing.Size(311, 40);
			// 
			// btnConfirm
			// 
			this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
			this.btnConfirm.Location = new System.Drawing.Point(43, 4);
			this.btnConfirm.Text = "저장";
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(162, 4);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(14, 391);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(285, 85);
			this.textBox1.TabIndex = 103;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(28, 364);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(136, 16);
			this.label6.TabIndex = 102;
			this.label6.Text = "연결여부 확인(Receive)";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cboHandshake);
			this.groupBox1.Controls.Add(this.cboParity);
			this.groupBox1.Controls.Add(this.cboDataSize);
			this.groupBox1.Controls.Add(this.cboBaudrate);
			this.groupBox1.Controls.Add(this.cboComport);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(14, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(285, 299);
			this.groupBox1.TabIndex = 100;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			// 
			// cboHandshake
			// 
			this.cboHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboHandshake.FormattingEnabled = true;
			this.cboHandshake.Items.AddRange(new object[] {
            "None",
            "XOnXOff",
            "RequestToSend",
            "RequestToSendXOnXOff"});
			this.cboHandshake.Location = new System.Drawing.Point(126, 254);
			this.cboHandshake.Name = "cboHandshake";
			this.cboHandshake.Size = new System.Drawing.Size(121, 24);
			this.cboHandshake.TabIndex = 1;
			// 
			// cboParity
			// 
			this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboParity.FormattingEnabled = true;
			this.cboParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
			this.cboParity.Location = new System.Drawing.Point(126, 198);
			this.cboParity.Name = "cboParity";
			this.cboParity.Size = new System.Drawing.Size(121, 24);
			this.cboParity.TabIndex = 1;
			// 
			// cboDataSize
			// 
			this.cboDataSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDataSize.FormattingEnabled = true;
			this.cboDataSize.Items.AddRange(new object[] {
            "8",
            "7",
            "6"});
			this.cboDataSize.Location = new System.Drawing.Point(126, 142);
			this.cboDataSize.Name = "cboDataSize";
			this.cboDataSize.Size = new System.Drawing.Size(121, 24);
			this.cboDataSize.TabIndex = 1;
			// 
			// cboBaudrate
			// 
			this.cboBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBaudrate.FormattingEnabled = true;
			this.cboBaudrate.Items.AddRange(new object[] {
            "115200",
            "57600",
            "38400",
            "19200",
            "9600"});
			this.cboBaudrate.Location = new System.Drawing.Point(126, 86);
			this.cboBaudrate.Name = "cboBaudrate";
			this.cboBaudrate.Size = new System.Drawing.Size(121, 24);
			this.cboBaudrate.TabIndex = 1;
			// 
			// cboComport
			// 
			this.cboComport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboComport.FormattingEnabled = true;
			this.cboComport.Location = new System.Drawing.Point(126, 30);
			this.cboComport.Name = "cboComport";
			this.cboComport.Size = new System.Drawing.Size(121, 24);
			this.cboComport.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Port";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(25, 258);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Handshake";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Baudrate";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(25, 202);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Parity";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 146);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Data size";
			// 
			// btnConnect
			// 
			this.btnConnect.BackColor = System.Drawing.Color.White;
			this.btnConnect.ForeColor = System.Drawing.Color.Black;
			this.btnConnect.Location = new System.Drawing.Point(14, 323);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(285, 32);
			this.btnConnect.TabIndex = 104;
			this.btnConnect.Text = "연결";
			this.btnConnect.UseVisualStyleBackColor = false;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// BarcodePortSettingPopForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(311, 532);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.groupBox1);
			this.Name = "BarcodePortSettingPopForm";
			this.Text = "바코드 설정";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarcodePortSettingPopForm_FormClosing);
			this.Load += new System.EventHandler(this.BarcodePortSettingPopForm_Load);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.textBox1, 0);
			this.Controls.SetChildIndex(this.btnConnect, 0);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cboHandshake;
		private System.Windows.Forms.ComboBox cboParity;
		private System.Windows.Forms.ComboBox cboDataSize;
		private System.Windows.Forms.ComboBox cboBaudrate;
		private System.Windows.Forms.ComboBox cboComport;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private ButtonControl btnConnect;
	}
}
