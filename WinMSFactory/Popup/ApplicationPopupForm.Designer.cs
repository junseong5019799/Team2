namespace WinMSFactory
{
	partial class ApplicationPopupForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtApp_name = new System.Windows.Forms.TextBox();
			this.nudApp_seq = new System.Windows.Forms.NumericUpDown();
			this.rdoApp_useY = new System.Windows.Forms.RadioButton();
			this.rdoApp_useN = new System.Windows.Forms.RadioButton();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudApp_seq)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 255);
			this.panel1.Size = new System.Drawing.Size(364, 40);
			// 
			// btnConfirm
			// 
			this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
			this.btnConfirm.Location = new System.Drawing.Point(121, 3);
			this.btnConfirm.Text = "저장";
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(240, 3);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "어플리케이션";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(92, 111);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "순번";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(70, 177);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "사용여부";
			// 
			// txtApp_name
			// 
			this.txtApp_name.Location = new System.Drawing.Point(154, 39);
			this.txtApp_name.Name = "txtApp_name";
			this.txtApp_name.Size = new System.Drawing.Size(147, 22);
			this.txtApp_name.TabIndex = 0;
			this.txtApp_name.Tag = "어플리케이션을 입력해주세요.";
			// 
			// nudApp_seq
			// 
			this.nudApp_seq.Location = new System.Drawing.Point(154, 108);
			this.nudApp_seq.Name = "nudApp_seq";
			this.nudApp_seq.Size = new System.Drawing.Size(77, 22);
			this.nudApp_seq.TabIndex = 1;
			// 
			// rdoApp_useY
			// 
			this.rdoApp_useY.AutoSize = true;
			this.rdoApp_useY.Checked = true;
			this.rdoApp_useY.Location = new System.Drawing.Point(154, 175);
			this.rdoApp_useY.Name = "rdoApp_useY";
			this.rdoApp_useY.Size = new System.Drawing.Size(48, 20);
			this.rdoApp_useY.TabIndex = 2;
			this.rdoApp_useY.TabStop = true;
			this.rdoApp_useY.Text = "사용";
			this.rdoApp_useY.UseVisualStyleBackColor = true;
			// 
			// rdoApp_useN
			// 
			this.rdoApp_useN.AutoSize = true;
			this.rdoApp_useN.Location = new System.Drawing.Point(225, 175);
			this.rdoApp_useN.Name = "rdoApp_useN";
			this.rdoApp_useN.Size = new System.Drawing.Size(76, 20);
			this.rdoApp_useN.TabIndex = 3;
			this.rdoApp_useN.Text = "사용 안 함";
			this.rdoApp_useN.UseVisualStyleBackColor = true;
			// 
			// ApplicationPopupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(364, 295);
			this.Controls.Add(this.rdoApp_useN);
			this.Controls.Add(this.rdoApp_useY);
			this.Controls.Add(this.nudApp_seq);
			this.Controls.Add(this.txtApp_name);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ApplicationPopupForm";
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtApp_name, 0);
			this.Controls.SetChildIndex(this.nudApp_seq, 0);
			this.Controls.SetChildIndex(this.rdoApp_useY, 0);
			this.Controls.SetChildIndex(this.rdoApp_useN, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudApp_seq)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtApp_name;
		private System.Windows.Forms.NumericUpDown nudApp_seq;
		private System.Windows.Forms.RadioButton rdoApp_useY;
		private System.Windows.Forms.RadioButton rdoApp_useN;
	}
}
