namespace WinMSFactory
{
	partial class EmployeeForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridViewControl1 = new WinMSFactory.DataGridViewControl();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Size = new System.Drawing.Size(1534, 80);
			this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
			this.panel1.Controls.SetChildIndex(this.label1, 0);
			this.panel1.Controls.SetChildIndex(this.txtSearch, 0);
			// 
			// dataGridViewControl1
			// 
			this.dataGridViewControl1.AllowUserToAddRows = false;
			this.dataGridViewControl1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewControl1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewControl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewControl1.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewControl1.IsAllCheckColumnHeader = false;
			this.dataGridViewControl1.IsAutoGenerateColumns = false;
			this.dataGridViewControl1.Location = new System.Drawing.Point(0, 80);
			this.dataGridViewControl1.MultiSelect = false;
			this.dataGridViewControl1.Name = "dataGridViewControl1";
			this.dataGridViewControl1.RowHeadersVisible = false;
			this.dataGridViewControl1.RowTemplate.Height = 23;
			this.dataGridViewControl1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewControl1.Size = new System.Drawing.Size(1534, 681);
			this.dataGridViewControl1.TabIndex = 4;
			this.dataGridViewControl1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewControl1_CellDoubleClick);
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(88, 30);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(183, 22);
			this.txtSearch.TabIndex = 10;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmployee_name_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "사원";
			// 
			// EmployeeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(1534, 761);
			this.Controls.Add(this.dataGridViewControl1);
			this.Name = "EmployeeForm";
			this.Text = "사원 관리";
			this.Load += new System.EventHandler(this.EmployeeForm_Load);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.GuidLabel2, 0);
			this.Controls.SetChildIndex(this.dataGridViewControl1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DataGridViewControl dataGridViewControl1;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label label1;
	}
}
