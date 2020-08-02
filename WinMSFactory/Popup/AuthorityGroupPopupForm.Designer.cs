namespace WinMSFactory
{
	partial class AuthorityGroupPopupForm
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
			this.txtAth_grp_expl = new System.Windows.Forms.TextBox();
			this.rdoAth_grp_useN = new System.Windows.Forms.RadioButton();
			this.rdoAth_grp_useY = new System.Windows.Forms.RadioButton();
			this.nudAth_grp_seq = new System.Windows.Forms.NumericUpDown();
			this.txtAth_grp_name = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudAth_grp_seq)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 313);
			this.panel1.Size = new System.Drawing.Size(416, 40);
			// 
			// btnConfirm
			// 
			this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
			this.btnConfirm.Location = new System.Drawing.Point(179, 4);
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(298, 4);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtAth_grp_expl
			// 
			this.txtAth_grp_expl.Location = new System.Drawing.Point(146, 210);
			this.txtAth_grp_expl.Multiline = true;
			this.txtAth_grp_expl.Name = "txtAth_grp_expl";
			this.txtAth_grp_expl.Size = new System.Drawing.Size(200, 78);
			this.txtAth_grp_expl.TabIndex = 21;
			// 
			// rdoAth_grp_useN
			// 
			this.rdoAth_grp_useN.AutoSize = true;
			this.rdoAth_grp_useN.Location = new System.Drawing.Point(217, 159);
			this.rdoAth_grp_useN.Name = "rdoAth_grp_useN";
			this.rdoAth_grp_useN.Size = new System.Drawing.Size(76, 20);
			this.rdoAth_grp_useN.TabIndex = 3;
			this.rdoAth_grp_useN.Text = "사용 안 함";
			this.rdoAth_grp_useN.UseVisualStyleBackColor = true;
			// 
			// rdoAth_grp_useY
			// 
			this.rdoAth_grp_useY.AutoSize = true;
			this.rdoAth_grp_useY.Checked = true;
			this.rdoAth_grp_useY.Location = new System.Drawing.Point(146, 159);
			this.rdoAth_grp_useY.Name = "rdoAth_grp_useY";
			this.rdoAth_grp_useY.Size = new System.Drawing.Size(48, 20);
			this.rdoAth_grp_useY.TabIndex = 2;
			this.rdoAth_grp_useY.TabStop = true;
			this.rdoAth_grp_useY.Text = "사용";
			this.rdoAth_grp_useY.UseVisualStyleBackColor = true;
			// 
			// nudAth_grp_seq
			// 
			this.nudAth_grp_seq.Location = new System.Drawing.Point(146, 99);
			this.nudAth_grp_seq.Name = "nudAth_grp_seq";
			this.nudAth_grp_seq.Size = new System.Drawing.Size(77, 22);
			this.nudAth_grp_seq.TabIndex = 1;
			// 
			// txtAth_grp_name
			// 
			this.txtAth_grp_name.Location = new System.Drawing.Point(146, 41);
			this.txtAth_grp_name.Name = "txtAth_grp_name";
			this.txtAth_grp_name.Size = new System.Drawing.Size(147, 22);
			this.txtAth_grp_name.TabIndex = 0;
			this.txtAth_grp_name.Tag = "권한그룹 명칭을 입력해주세요.";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(84, 213);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 16);
			this.label5.TabIndex = 22;
			this.label5.Text = "설명";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(62, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 16);
			this.label3.TabIndex = 23;
			this.label3.Text = "사용여부";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(37, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 16);
			this.label4.TabIndex = 25;
			this.label4.Text = "권한그룹 명칭";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(84, 102);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 16);
			this.label2.TabIndex = 24;
			this.label2.Text = "순번";
			// 
			// AuthorityGroupPopupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(416, 353);
			this.Controls.Add(this.txtAth_grp_expl);
			this.Controls.Add(this.rdoAth_grp_useN);
			this.Controls.Add(this.rdoAth_grp_useY);
			this.Controls.Add(this.nudAth_grp_seq);
			this.Controls.Add(this.txtAth_grp_name);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Name = "AuthorityGroupPopupForm";
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtAth_grp_name, 0);
			this.Controls.SetChildIndex(this.nudAth_grp_seq, 0);
			this.Controls.SetChildIndex(this.rdoAth_grp_useY, 0);
			this.Controls.SetChildIndex(this.rdoAth_grp_useN, 0);
			this.Controls.SetChildIndex(this.txtAth_grp_expl, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudAth_grp_seq)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtAth_grp_expl;
		private System.Windows.Forms.RadioButton rdoAth_grp_useN;
		private System.Windows.Forms.RadioButton rdoAth_grp_useY;
		private System.Windows.Forms.NumericUpDown nudAth_grp_seq;
		private System.Windows.Forms.TextBox txtAth_grp_name;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
	}
}
