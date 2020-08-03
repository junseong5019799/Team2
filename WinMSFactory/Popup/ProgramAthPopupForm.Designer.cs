namespace WinMSFactory
{
	partial class ProgramAthPopupForm
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
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cboProg_id = new System.Windows.Forms.ComboBox();
			this.chkProg_select = new System.Windows.Forms.CheckBox();
			this.chkProg_insert = new System.Windows.Forms.CheckBox();
			this.chkProg_delect = new System.Windows.Forms.CheckBox();
			this.chkProg_save = new System.Windows.Forms.CheckBox();
			this.chkProg_excel = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblAth_grp_name = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 287);
			this.panel1.Size = new System.Drawing.Size(350, 40);
			// 
			// btnConfirm
			// 
			this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
			this.btnConfirm.Location = new System.Drawing.Point(101, 3);
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(220, 3);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// cboModule_id
			// 
			this.cboModule_id.FormattingEnabled = true;
			this.cboModule_id.Location = new System.Drawing.Point(129, 88);
			this.cboModule_id.Name = "cboModule_id";
			this.cboModule_id.Size = new System.Drawing.Size(121, 24);
			this.cboModule_id.TabIndex = 0;
			this.cboModule_id.SelectedIndexChanged += new System.EventHandler(this.cboModule_id_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(45, 149);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 16);
			this.label4.TabIndex = 20;
			this.label4.Text = "프로그램";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(67, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 16);
			this.label1.TabIndex = 21;
			this.label1.Text = "모듈";
			// 
			// cboProg_id
			// 
			this.cboProg_id.FormattingEnabled = true;
			this.cboProg_id.Location = new System.Drawing.Point(129, 145);
			this.cboProg_id.Name = "cboProg_id";
			this.cboProg_id.Size = new System.Drawing.Size(121, 24);
			this.cboProg_id.TabIndex = 1;
			// 
			// chkProg_select
			// 
			this.chkProg_select.AutoSize = true;
			this.chkProg_select.Location = new System.Drawing.Point(129, 198);
			this.chkProg_select.Name = "chkProg_select";
			this.chkProg_select.Size = new System.Drawing.Size(49, 20);
			this.chkProg_select.TabIndex = 2;
			this.chkProg_select.Text = "조회";
			this.chkProg_select.UseVisualStyleBackColor = true;
			// 
			// chkProg_insert
			// 
			this.chkProg_insert.AutoSize = true;
			this.chkProg_insert.Location = new System.Drawing.Point(197, 198);
			this.chkProg_insert.Name = "chkProg_insert";
			this.chkProg_insert.Size = new System.Drawing.Size(49, 20);
			this.chkProg_insert.TabIndex = 3;
			this.chkProg_insert.Text = "추가";
			this.chkProg_insert.UseVisualStyleBackColor = true;
			// 
			// chkProg_delect
			// 
			this.chkProg_delect.AutoSize = true;
			this.chkProg_delect.Location = new System.Drawing.Point(265, 198);
			this.chkProg_delect.Name = "chkProg_delect";
			this.chkProg_delect.Size = new System.Drawing.Size(49, 20);
			this.chkProg_delect.TabIndex = 4;
			this.chkProg_delect.Text = "삭제";
			this.chkProg_delect.UseVisualStyleBackColor = true;
			// 
			// chkProg_save
			// 
			this.chkProg_save.AutoSize = true;
			this.chkProg_save.Location = new System.Drawing.Point(129, 229);
			this.chkProg_save.Name = "chkProg_save";
			this.chkProg_save.Size = new System.Drawing.Size(49, 20);
			this.chkProg_save.TabIndex = 5;
			this.chkProg_save.Text = "저장";
			this.chkProg_save.UseVisualStyleBackColor = true;
			// 
			// chkProg_excel
			// 
			this.chkProg_excel.AutoSize = true;
			this.chkProg_excel.Location = new System.Drawing.Point(197, 229);
			this.chkProg_excel.Name = "chkProg_excel";
			this.chkProg_excel.Size = new System.Drawing.Size(49, 20);
			this.chkProg_excel.TabIndex = 6;
			this.chkProg_excel.Text = "엑셀";
			this.chkProg_excel.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(45, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 16);
			this.label2.TabIndex = 21;
			this.label2.Text = "권한그룹";
			// 
			// lblAth_grp_name
			// 
			this.lblAth_grp_name.AutoSize = true;
			this.lblAth_grp_name.Location = new System.Drawing.Point(126, 35);
			this.lblAth_grp_name.Name = "lblAth_grp_name";
			this.lblAth_grp_name.Size = new System.Drawing.Size(52, 16);
			this.lblAth_grp_name.TabIndex = 21;
			this.lblAth_grp_name.Text = "권한그룹";
			// 
			// ProgramAthPopupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(350, 327);
			this.Controls.Add(this.chkProg_delect);
			this.Controls.Add(this.chkProg_excel);
			this.Controls.Add(this.chkProg_save);
			this.Controls.Add(this.chkProg_insert);
			this.Controls.Add(this.chkProg_select);
			this.Controls.Add(this.cboProg_id);
			this.Controls.Add(this.cboModule_id);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblAth_grp_name);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ProgramAthPopupForm";
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.lblAth_grp_name, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.cboModule_id, 0);
			this.Controls.SetChildIndex(this.cboProg_id, 0);
			this.Controls.SetChildIndex(this.chkProg_select, 0);
			this.Controls.SetChildIndex(this.chkProg_insert, 0);
			this.Controls.SetChildIndex(this.chkProg_save, 0);
			this.Controls.SetChildIndex(this.chkProg_excel, 0);
			this.Controls.SetChildIndex(this.chkProg_delect, 0);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cboModule_id;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboProg_id;
		private System.Windows.Forms.CheckBox chkProg_select;
		private System.Windows.Forms.CheckBox chkProg_insert;
		private System.Windows.Forms.CheckBox chkProg_delect;
		private System.Windows.Forms.CheckBox chkProg_save;
		private System.Windows.Forms.CheckBox chkProg_excel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblAth_grp_name;
	}
}
