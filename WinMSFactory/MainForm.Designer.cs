﻿namespace WinMSFactory
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.btnSearch = new System.Windows.Forms.ToolStripButton();
			this.btnAdd = new System.Windows.Forms.ToolStripButton();
			this.btnDelete = new System.Windows.Forms.ToolStripButton();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.btnExcel = new System.Windows.Forms.ToolStripButton();
			this.btnLogOut = new System.Windows.Forms.ToolStripButton();
			this.btnPrint = new System.Windows.Forms.ToolStripButton();
			this.btnClear = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
			this.tsMenu = new System.Windows.Forms.ToolStrip();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.mainTabControl1 = new WinMSFactory.MainTabControl();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip2
			// 
			this.toolStrip2.AutoSize = false;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.btnAdd,
            this.btnDelete,
            this.btnSave,
            this.btnExcel,
            this.btnLogOut,
            this.btnPrint,
            this.btnClear});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(1561, 65);
			this.toolStrip2.TabIndex = 1;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// btnSearch
			// 
			this.btnSearch.AutoSize = false;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnSearch.Size = new System.Drawing.Size(50, 50);
			this.btnSearch.Text = "조회";
			this.btnSearch.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSearch.Visible = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.AutoSize = false;
			this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
			this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnAdd.Size = new System.Drawing.Size(50, 50);
			this.btnAdd.Text = "추가";
			this.btnAdd.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAdd.Visible = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.AutoSize = false;
			this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
			this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnDelete.Size = new System.Drawing.Size(50, 50);
			this.btnDelete.Text = "삭제";
			this.btnDelete.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDelete.Visible = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSave
			// 
			this.btnSave.AutoSize = false;
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSave.Name = "btnSave";
			this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnSave.Size = new System.Drawing.Size(50, 50);
			this.btnSave.Text = "저장";
			this.btnSave.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSave.Visible = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnExcel
			// 
			this.btnExcel.AutoSize = false;
			this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
			this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnExcel.Size = new System.Drawing.Size(50, 50);
			this.btnExcel.Text = "엑셀";
			this.btnExcel.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExcel.Visible = false;
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// btnLogOut
			// 
			this.btnLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnLogOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
			this.btnLogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnLogOut.Name = "btnLogOut";
			this.btnLogOut.Size = new System.Drawing.Size(59, 62);
			this.btnLogOut.Text = "로그아웃";
			this.btnLogOut.ToolTipText = "로그아웃";
			this.btnLogOut.Click += new System.EventHandler(this.tsbLogOut_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.AutoSize = false;
			this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
			this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(50, 50);
			this.btnPrint.Text = "출력";
			this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnPrint.Visible = false;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnClear
			// 
			this.btnClear.AutoSize = false;
			this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
			this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(50, 50);
			this.btnClear.Text = "초기화";
			this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnClear.Visible = false;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(217, 19);
			this.toolStripButton5.Text = "PopUpDialog";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 817);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1561, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 62);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(23, 23);
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.Size = new System.Drawing.Size(23, 23);
			// 
			// toolStripButton8
			// 
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.Size = new System.Drawing.Size(23, 23);
			// 
			// toolStripButton9
			// 
			this.toolStripButton9.Name = "toolStripButton9";
			this.toolStripButton9.Size = new System.Drawing.Size(23, 23);
			// 
			// toolStripButton10
			// 
			this.toolStripButton10.Name = "toolStripButton10";
			this.toolStripButton10.Size = new System.Drawing.Size(23, 23);
			// 
			// tsMenu
			// 
			this.tsMenu.AutoSize = false;
			this.tsMenu.Dock = System.Windows.Forms.DockStyle.Left;
			this.tsMenu.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.tsMenu.Location = new System.Drawing.Point(0, 65);
			this.tsMenu.Name = "tsMenu";
			this.tsMenu.Size = new System.Drawing.Size(219, 752);
			this.tsMenu.TabIndex = 2;
			this.tsMenu.Text = "toolStrip1";
			// 
			// timer1
			// 
			this.timer1.Interval = 25;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// mainTabControl1
			// 
			this.mainTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.mainTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.mainTabControl1.Location = new System.Drawing.Point(219, 65);
			this.mainTabControl1.Name = "mainTabControl1";
			this.mainTabControl1.SelectedIndex = 0;
			this.mainTabControl1.Size = new System.Drawing.Size(1342, 23);
			this.mainTabControl1.TabIndex = 6;
			this.mainTabControl1.Visible = false;
			this.mainTabControl1.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
			this.mainTabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainTabControl1_MouseDown);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1561, 839);
			this.Controls.Add(this.mainTabControl1);
			this.Controls.Add(this.tsMenu);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.statusStrip1);
			this.IsMdiContainer = true;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "MainForm";
			this.Text = "Main";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private MainTabControl mainTabControl1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
		private System.Windows.Forms.ToolStripButton btnLogOut;
		private System.Windows.Forms.ToolStripButton btnPrint;
		private System.Windows.Forms.ToolStripButton btnClear;
		private System.Windows.Forms.ToolStrip tsMenu;
		private System.Windows.Forms.Timer timer1;
	}
}

