namespace WinMSFactory.Popup
{
	partial class LoginForm
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
			this.txtEmployee_id = new System.Windows.Forms.TextBox();
			this.txtEmployee_pwd = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 154);
			this.panel1.Size = new System.Drawing.Size(338, 40);
			this.panel1.TabIndex = 3;
			// 
			// btnConfirm
			// 
			this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
			this.btnConfirm.Location = new System.Drawing.Point(77, 1);
			this.btnConfirm.Text = "로그인";
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(196, 1);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtEmployee_id
			// 
			this.txtEmployee_id.Location = new System.Drawing.Point(132, 42);
			this.txtEmployee_id.Name = "txtEmployee_id";
			this.txtEmployee_id.Size = new System.Drawing.Size(171, 22);
			this.txtEmployee_id.TabIndex = 0;
			this.txtEmployee_id.Tag = "ID를 입력해주세요.";
			// 
			// txtEmployee_pwd
			// 
			this.txtEmployee_pwd.Location = new System.Drawing.Point(132, 93);
			this.txtEmployee_pwd.Name = "txtEmployee_pwd";
			this.txtEmployee_pwd.PasswordChar = '*';
			this.txtEmployee_pwd.Size = new System.Drawing.Size(171, 22);
			this.txtEmployee_pwd.TabIndex = 1;
			this.txtEmployee_pwd.Tag = "비밀번호를 입력해주세요.";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(58, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(21, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "ID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "비밀번호";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(27, 24);
			this.button1.TabIndex = 99;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(338, 194);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtEmployee_id);
			this.Controls.Add(this.txtEmployee_pwd);
			this.Name = "LoginForm";
			this.Text = "로그인";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtEmployee_id;
		private System.Windows.Forms.TextBox txtEmployee_pwd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
	}
}
