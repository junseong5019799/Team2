namespace WinMSFactory
{
	partial class ModulePopupForm
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
			this.rdoModule_useN = new System.Windows.Forms.RadioButton();
			this.rdoModule_useY = new System.Windows.Forms.RadioButton();
			this.nudModule_seq = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtModule = new System.Windows.Forms.TextBox();
			this.cboApp_id = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudModule_seq)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 282);
			this.panel1.Size = new System.Drawing.Size(379, 40);
			// 
			// btnConfirm
			// 
			this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
			this.btnConfirm.Location = new System.Drawing.Point(141, 3);
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(260, 3);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// rdoModule_useN
			// 
			this.rdoModule_useN.AutoSize = true;
			this.rdoModule_useN.Location = new System.Drawing.Point(237, 218);
			this.rdoModule_useN.Name = "rdoModule_useN";
			this.rdoModule_useN.Size = new System.Drawing.Size(76, 20);
			this.rdoModule_useN.TabIndex = 4;
			this.rdoModule_useN.Text = "사용 안 함";
			this.rdoModule_useN.UseVisualStyleBackColor = true;
			// 
			// rdoModule_useY
			// 
			this.rdoModule_useY.AutoSize = true;
			this.rdoModule_useY.Checked = true;
			this.rdoModule_useY.Location = new System.Drawing.Point(166, 218);
			this.rdoModule_useY.Name = "rdoModule_useY";
			this.rdoModule_useY.Size = new System.Drawing.Size(48, 20);
			this.rdoModule_useY.TabIndex = 3;
			this.rdoModule_useY.TabStop = true;
			this.rdoModule_useY.Text = "사용";
			this.rdoModule_useY.UseVisualStyleBackColor = true;
			// 
			// nudModule_seq
			// 
			this.nudModule_seq.Location = new System.Drawing.Point(166, 158);
			this.nudModule_seq.Name = "nudModule_seq";
			this.nudModule_seq.Size = new System.Drawing.Size(77, 22);
			this.nudModule_seq.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(82, 219);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "사용여부";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(104, 161);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "순번";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(60, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "어플리케이션";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(79, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "모듈 명칭";
			// 
			// txtModule
			// 
			this.txtModule.Location = new System.Drawing.Point(166, 100);
			this.txtModule.Name = "txtModule";
			this.txtModule.Size = new System.Drawing.Size(147, 22);
			this.txtModule.TabIndex = 1;
			this.txtModule.Tag = "모듈 명칭을 입력해주세요.";
			// 
			// cboApp_id
			// 
			this.cboApp_id.FormattingEnabled = true;
			this.cboApp_id.Location = new System.Drawing.Point(166, 41);
			this.cboApp_id.Name = "cboApp_id";
			this.cboApp_id.Size = new System.Drawing.Size(121, 24);
			this.cboApp_id.TabIndex = 0;
			// 
			// ModulePopupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(379, 322);
			this.Controls.Add(this.cboApp_id);
			this.Controls.Add(this.rdoModule_useN);
			this.Controls.Add(this.rdoModule_useY);
			this.Controls.Add(this.nudModule_seq);
			this.Controls.Add(this.txtModule);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ModulePopupForm";
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtModule, 0);
			this.Controls.SetChildIndex(this.nudModule_seq, 0);
			this.Controls.SetChildIndex(this.rdoModule_useY, 0);
			this.Controls.SetChildIndex(this.rdoModule_useN, 0);
			this.Controls.SetChildIndex(this.cboApp_id, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudModule_seq)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rdoModule_useN;
		private System.Windows.Forms.RadioButton rdoModule_useY;
		private System.Windows.Forms.NumericUpDown nudModule_seq;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtModule;
		private System.Windows.Forms.ComboBox cboApp_id;
	}
}
