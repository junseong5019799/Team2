namespace WinMSFactory
{
	partial class AuthorityForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorityForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridViewControl1 = new WinMSFactory.DataGridViewControl();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnAdd = new System.Windows.Forms.ToolStripButton();
			this.btnDelete = new System.Windows.Forms.ToolStripButton();
			this.dataGridViewControl2 = new WinMSFactory.DataGridViewControl();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl2)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.SetChildIndex(this.Guidlabel1, 0);
			this.panel1.Controls.SetChildIndex(this.button1, 0);
			this.panel1.Controls.SetChildIndex(this.button2, 0);
			this.panel1.Controls.SetChildIndex(this.button3, 0);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dataGridViewControl1);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dataGridViewControl2);
			this.panel3.Controls.Add(this.toolStrip1);
			// 
			// dataGridViewControl1
			// 
			this.dataGridViewControl1.AllowUserToAddRows = false;
			this.dataGridViewControl1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewControl1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewControl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewControl1.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewControl1.IsAllCheckColumnHeader = false;
			this.dataGridViewControl1.IsAutoGenerateColumns = false;
			this.dataGridViewControl1.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewControl1.MultiSelect = false;
			this.dataGridViewControl1.Name = "dataGridViewControl1";
			this.dataGridViewControl1.RowHeadersVisible = false;
			this.dataGridViewControl1.RowTemplate.Height = 23;
			this.dataGridViewControl1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewControl1.Size = new System.Drawing.Size(1534, 290);
			this.dataGridViewControl1.TabIndex = 0;
			this.dataGridViewControl1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewControl1_CellClick);
			this.dataGridViewControl1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewControl1_CellDoubleClick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDelete});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1534, 53);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
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
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// dataGridViewControl2
			// 
			this.dataGridViewControl2.AllowUserToAddRows = false;
			this.dataGridViewControl2.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewControl2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewControl2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewControl2.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewControl2.IsAllCheckColumnHeader = false;
			this.dataGridViewControl2.IsAutoGenerateColumns = false;
			this.dataGridViewControl2.Location = new System.Drawing.Point(0, 53);
			this.dataGridViewControl2.MultiSelect = false;
			this.dataGridViewControl2.Name = "dataGridViewControl2";
			this.dataGridViewControl2.RowHeadersVisible = false;
			this.dataGridViewControl2.RowTemplate.Height = 23;
			this.dataGridViewControl2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewControl2.Size = new System.Drawing.Size(1534, 248);
			this.dataGridViewControl2.TabIndex = 3;
			this.dataGridViewControl2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewControl2_CellDoubleClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(513, 98);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "조회";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(594, 98);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "추가";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(675, 98);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 1;
			this.button3.Text = "삭제";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// AuthorityForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(1534, 761);
			this.Name = "AuthorityForm";
			this.Text = "권한 관리";
			this.Load += new System.EventHandler(this.AuthorityForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DataGridViewControl dataGridViewControl1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private DataGridViewControl dataGridViewControl2;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnAdd;
		private System.Windows.Forms.ToolStripButton btnDelete;
	}
}
