namespace WinMSFactory
{
	partial class ProgramPopupForm
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
			this.cboModule_id = new System.Windows.Forms.ComboBox();
			this.rdoProg_useN = new System.Windows.Forms.RadioButton();
			this.rdoProg_useY = new System.Windows.Forms.RadioButton();
			this.nudProg_seq = new System.Windows.Forms.NumericUpDown();
			this.txtProg_name = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtProg_expl = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudProg_seq)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 380);
			this.panel1.Size = new System.Drawing.Size(402, 40);
			// 
			// btnConfirm
			// 
			this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
			this.btnConfirm.Location = new System.Drawing.Point(162, 5);
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(281, 5);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// cboModule_id
			// 
			this.cboModule_id.FormattingEnabled = true;
			this.cboModule_id.Location = new System.Drawing.Point(162, 47);
			this.cboModule_id.Name = "cboModule_id";
			this.cboModule_id.Size = new System.Drawing.Size(121, 24);
			this.cboModule_id.TabIndex = 0;
			// 
			// rdoProg_useN
			// 
			this.rdoProg_useN.AutoSize = true;
			this.rdoProg_useN.Location = new System.Drawing.Point(233, 224);
			this.rdoProg_useN.Name = "rdoProg_useN";
			this.rdoProg_useN.Size = new System.Drawing.Size(76, 20);
			this.rdoProg_useN.TabIndex = 4;
			this.rdoProg_useN.Text = "사용 안 함";
			this.rdoProg_useN.UseVisualStyleBackColor = true;
			// 
			// rdoProg_useY
			// 
			this.rdoProg_useY.AutoSize = true;
			this.rdoProg_useY.Checked = true;
			this.rdoProg_useY.Location = new System.Drawing.Point(162, 224);
			this.rdoProg_useY.Name = "rdoProg_useY";
			this.rdoProg_useY.Size = new System.Drawing.Size(48, 20);
			this.rdoProg_useY.TabIndex = 3;
			this.rdoProg_useY.TabStop = true;
			this.rdoProg_useY.Text = "사용";
			this.rdoProg_useY.UseVisualStyleBackColor = true;
			// 
			// nudProg_seq
			// 
			this.nudProg_seq.Location = new System.Drawing.Point(162, 164);
			this.nudProg_seq.Name = "nudProg_seq";
			this.nudProg_seq.Size = new System.Drawing.Size(77, 22);
			this.nudProg_seq.TabIndex = 2;
			// 
			// txtProg_name
			// 
			this.txtProg_name.Location = new System.Drawing.Point(162, 106);
			this.txtProg_name.Name = "txtProg_name";
			this.txtProg_name.Size = new System.Drawing.Size(147, 22);
			this.txtProg_name.TabIndex = 1;
			this.txtProg_name.Tag = "프로그램 명칭을 입력해주세요.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(78, 225);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "사용여부";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(53, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 16);
			this.label4.TabIndex = 16;
			this.label4.Text = "프로그램 명칭";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(100, 167);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 16);
			this.label2.TabIndex = 15;
			this.label2.Text = "순번";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(100, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 16);
			this.label1.TabIndex = 17;
			this.label1.Text = "모듈";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(100, 278);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 16);
			this.label5.TabIndex = 14;
			this.label5.Text = "설명";
			// 
			// txtProg_expl
			// 
			this.txtProg_expl.Location = new System.Drawing.Point(162, 275);
			this.txtProg_expl.Multiline = true;
			this.txtProg_expl.Name = "txtProg_expl";
			this.txtProg_expl.Size = new System.Drawing.Size(200, 78);
			this.txtProg_expl.TabIndex = 5;
			// 
			// ProgramPopupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(402, 420);
			this.Controls.Add(this.txtProg_expl);
			this.Controls.Add(this.cboModule_id);
			this.Controls.Add(this.rdoProg_useN);
			this.Controls.Add(this.rdoProg_useY);
			this.Controls.Add(this.nudProg_seq);
			this.Controls.Add(this.txtProg_name);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ProgramPopupForm";
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtProg_name, 0);
			this.Controls.SetChildIndex(this.nudProg_seq, 0);
			this.Controls.SetChildIndex(this.rdoProg_useY, 0);
			this.Controls.SetChildIndex(this.rdoProg_useN, 0);
			this.Controls.SetChildIndex(this.cboModule_id, 0);
			this.Controls.SetChildIndex(this.txtProg_expl, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudProg_seq)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cboModule_id;
		private System.Windows.Forms.RadioButton rdoProg_useN;
		private System.Windows.Forms.RadioButton rdoProg_useY;
		private System.Windows.Forms.NumericUpDown nudProg_seq;
		private System.Windows.Forms.TextBox txtProg_name;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtProg_expl;
	}
}
