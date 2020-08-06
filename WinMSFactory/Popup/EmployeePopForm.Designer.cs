namespace WinMSFactory
{
	partial class EmployeePopForm
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
			this.cboAth_grp_id = new System.Windows.Forms.ComboBox();
			this.rdoEmployee_useN = new System.Windows.Forms.RadioButton();
			this.rdoEmployee_useY = new System.Windows.Forms.RadioButton();
			this.txtEmployee_id = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEmployee_name = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtEmployee_pwd = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtEmployee_pwd_confirm = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 398);
			this.panel1.Size = new System.Drawing.Size(365, 40);
			// 
			// btnConfirm
			// 
			this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
			this.btnConfirm.Location = new System.Drawing.Point(131, 4);
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(250, 4);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// cboAth_grp_id
			// 
			this.cboAth_grp_id.FormattingEnabled = true;
			this.cboAth_grp_id.Location = new System.Drawing.Point(145, 29);
			this.cboAth_grp_id.Name = "cboAth_grp_id";
			this.cboAth_grp_id.Size = new System.Drawing.Size(121, 24);
			this.cboAth_grp_id.TabIndex = 0;
			// 
			// rdoEmployee_useN
			// 
			this.rdoEmployee_useN.AutoSize = true;
			this.rdoEmployee_useN.Location = new System.Drawing.Point(216, 347);
			this.rdoEmployee_useN.Name = "rdoEmployee_useN";
			this.rdoEmployee_useN.Size = new System.Drawing.Size(76, 20);
			this.rdoEmployee_useN.TabIndex = 6;
			this.rdoEmployee_useN.Text = "사용 안 함";
			this.rdoEmployee_useN.UseVisualStyleBackColor = true;
			// 
			// rdoEmployee_useY
			// 
			this.rdoEmployee_useY.AutoSize = true;
			this.rdoEmployee_useY.Checked = true;
			this.rdoEmployee_useY.Location = new System.Drawing.Point(145, 347);
			this.rdoEmployee_useY.Name = "rdoEmployee_useY";
			this.rdoEmployee_useY.Size = new System.Drawing.Size(48, 20);
			this.rdoEmployee_useY.TabIndex = 5;
			this.rdoEmployee_useY.TabStop = true;
			this.rdoEmployee_useY.Text = "사용";
			this.rdoEmployee_useY.UseVisualStyleBackColor = true;
			// 
			// txtEmployee_id
			// 
			this.txtEmployee_id.Location = new System.Drawing.Point(145, 91);
			this.txtEmployee_id.Name = "txtEmployee_id";
			this.txtEmployee_id.Size = new System.Drawing.Size(147, 22);
			this.txtEmployee_id.TabIndex = 1;
			this.txtEmployee_id.Tag = "ID를 입력해주세요.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(61, 348);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 16);
			this.label3.TabIndex = 23;
			this.label3.Text = "사용여부";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(92, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 16);
			this.label4.TabIndex = 25;
			this.label4.Text = "ID";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(61, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 16);
			this.label1.TabIndex = 26;
			this.label1.Text = "권한그룹";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(83, 159);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 16);
			this.label2.TabIndex = 25;
			this.label2.Text = "이름";
			// 
			// txtEmployee_name
			// 
			this.txtEmployee_name.Location = new System.Drawing.Point(145, 152);
			this.txtEmployee_name.Name = "txtEmployee_name";
			this.txtEmployee_name.Size = new System.Drawing.Size(147, 22);
			this.txtEmployee_name.TabIndex = 2;
			this.txtEmployee_name.Tag = "이름을 입력해주세요.";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(61, 222);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 16);
			this.label5.TabIndex = 25;
			this.label5.Text = "비밀번호";
			// 
			// txtEmployee_pwd
			// 
			this.txtEmployee_pwd.Location = new System.Drawing.Point(145, 213);
			this.txtEmployee_pwd.Name = "txtEmployee_pwd";
			this.txtEmployee_pwd.PasswordChar = '*';
			this.txtEmployee_pwd.Size = new System.Drawing.Size(147, 22);
			this.txtEmployee_pwd.TabIndex = 3;
			this.txtEmployee_pwd.Tag = "비밀번호를 입력해주세요.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(36, 285);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 16);
			this.label6.TabIndex = 25;
			this.label6.Text = "비밀번호 확인";
			// 
			// txtEmployee_pwd_confirm
			// 
			this.txtEmployee_pwd_confirm.Location = new System.Drawing.Point(145, 279);
			this.txtEmployee_pwd_confirm.Name = "txtEmployee_pwd_confirm";
			this.txtEmployee_pwd_confirm.PasswordChar = '*';
			this.txtEmployee_pwd_confirm.Size = new System.Drawing.Size(147, 22);
			this.txtEmployee_pwd_confirm.TabIndex = 4;
			this.txtEmployee_pwd_confirm.Tag = "비밀번호 확인을 입력해주세요.";
			// 
			// EmployeePopForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(365, 438);
			this.Controls.Add(this.cboAth_grp_id);
			this.Controls.Add(this.rdoEmployee_useN);
			this.Controls.Add(this.rdoEmployee_useY);
			this.Controls.Add(this.txtEmployee_pwd_confirm);
			this.Controls.Add(this.txtEmployee_pwd);
			this.Controls.Add(this.txtEmployee_name);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtEmployee_id);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Name = "EmployeePopForm";
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtEmployee_id, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.txtEmployee_name, 0);
			this.Controls.SetChildIndex(this.txtEmployee_pwd, 0);
			this.Controls.SetChildIndex(this.txtEmployee_pwd_confirm, 0);
			this.Controls.SetChildIndex(this.rdoEmployee_useY, 0);
			this.Controls.SetChildIndex(this.rdoEmployee_useN, 0);
			this.Controls.SetChildIndex(this.cboAth_grp_id, 0);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cboAth_grp_id;
		private System.Windows.Forms.RadioButton rdoEmployee_useN;
		private System.Windows.Forms.RadioButton rdoEmployee_useY;
		private System.Windows.Forms.TextBox txtEmployee_id;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEmployee_name;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtEmployee_pwd;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtEmployee_pwd_confirm;
	}
}
