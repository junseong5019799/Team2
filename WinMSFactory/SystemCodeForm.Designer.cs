namespace WinMSFactory
{
	partial class SystemCodeForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemCodeForm));
			this.dataGridViewControl1 = new WinMSFactory.DataGridViewControl();
			this.dataGridViewControl2 = new WinMSFactory.DataGridViewControl();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnInsert = new System.Windows.Forms.ToolStripButton();
			this.btnDelete = new System.Windows.Forms.ToolStripButton();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl2)).BeginInit();
			this.toolStrip1.SuspendLayout();
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
			// Guidlabel1
			// 
			this.Guidlabel1.Location = new System.Drawing.Point(284, 78);
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
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewControl1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewControl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewControl1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewControl1.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewControl1.MultiSelect = false;
			this.dataGridViewControl1.Name = "dataGridViewControl1";
			this.dataGridViewControl1.RowTemplate.Height = 23;
			this.dataGridViewControl1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewControl1.Size = new System.Drawing.Size(1534, 290);
			this.dataGridViewControl1.TabIndex = 0;
			// 
			// dataGridViewControl2
			// 
			this.dataGridViewControl2.AllowUserToAddRows = false;
			this.dataGridViewControl2.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewControl2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewControl2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewControl2.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewControl2.Location = new System.Drawing.Point(0, 53);
			this.dataGridViewControl2.MultiSelect = false;
			this.dataGridViewControl2.Name = "dataGridViewControl2";
			this.dataGridViewControl2.RowTemplate.Height = 23;
			this.dataGridViewControl2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewControl2.Size = new System.Drawing.Size(1534, 248);
			this.dataGridViewControl2.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(559, 43);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "추가";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(655, 43);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "삭제";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(746, 43);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 1;
			this.button3.Text = "저장";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInsert,
            this.btnDelete});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1534, 53);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnInsert
			// 
			this.btnInsert.AutoSize = false;
			this.btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.Image")));
			this.btnInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnInsert.Size = new System.Drawing.Size(50, 50);
			this.btnInsert.Text = "추가";
			this.btnInsert.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
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
			// 
			// SystemCodeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(1534, 761);
			this.Name = "SystemCodeForm";
			this.Load += new System.EventHandler(this.SystemCodeForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl2)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DataGridViewControl dataGridViewControl1;
		private DataGridViewControl dataGridViewControl2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnInsert;
		private System.Windows.Forms.ToolStripButton btnDelete;
	}
}
