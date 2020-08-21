namespace WinMSFactoryPOP
{
	partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.pOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.작업지시선택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pOPToolStripMenuItem,
            this.작업지시선택ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1234, 33);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStrip1_ItemAdded);
			// 
			// pOPToolStripMenuItem
			// 
			this.pOPToolStripMenuItem.Name = "pOPToolStripMenuItem";
			this.pOPToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
			this.pOPToolStripMenuItem.Text = "POP";
			this.pOPToolStripMenuItem.Click += new System.EventHandler(this.pOPToolStripMenuItem_Click);
			// 
			// 작업지시선택ToolStripMenuItem
			// 
			this.작업지시선택ToolStripMenuItem.Name = "작업지시선택ToolStripMenuItem";
			this.작업지시선택ToolStripMenuItem.Size = new System.Drawing.Size(152, 29);
			this.작업지시선택ToolStripMenuItem.Text = "작업 지시 선택";
			this.작업지시선택ToolStripMenuItem.Click += new System.EventHandler(this.작업지시선택ToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1234, 749);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "메인";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem pOPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 작업지시선택ToolStripMenuItem;
	}
}

