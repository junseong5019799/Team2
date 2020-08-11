namespace WinMSFactory
{
	partial class WorkOrderForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridViewControl1 = new WinMSFactory.DataGridViewControl();
			this.label1 = new System.Windows.Forms.Label();
			this.cboLine = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cboProcess = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cboProduct = new System.Windows.Forms.ComboBox();
			this.fromToDateControl1 = new WinMSFactory.Control.FromToDateControl();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cboFactory = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.fromToDateControl1);
			this.panel1.Controls.Add(this.cboProduct);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cboProcess);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cboFactory);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.cboLine);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Size = new System.Drawing.Size(1534, 130);
			this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
			this.panel1.Controls.SetChildIndex(this.label1, 0);
			this.panel1.Controls.SetChildIndex(this.cboLine, 0);
			this.panel1.Controls.SetChildIndex(this.label6, 0);
			this.panel1.Controls.SetChildIndex(this.cboFactory, 0);
			this.panel1.Controls.SetChildIndex(this.label2, 0);
			this.panel1.Controls.SetChildIndex(this.cboProcess, 0);
			this.panel1.Controls.SetChildIndex(this.label3, 0);
			this.panel1.Controls.SetChildIndex(this.cboProduct, 0);
			this.panel1.Controls.SetChildIndex(this.fromToDateControl1, 0);
			this.panel1.Controls.SetChildIndex(this.label4, 0);
			this.panel1.Controls.SetChildIndex(this.label5, 0);
			this.panel1.Controls.SetChildIndex(this.txtSearch, 0);
			// 
			// dataGridViewControl1
			// 
			this.dataGridViewControl1.AllowUserToAddRows = false;
			this.dataGridViewControl1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewControl1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewControl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewControl1.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewControl1.IsAllCheckColumnHeader = false;
			this.dataGridViewControl1.IsAutoGenerateColumns = false;
			this.dataGridViewControl1.Location = new System.Drawing.Point(0, 130);
			this.dataGridViewControl1.MultiSelect = false;
			this.dataGridViewControl1.Name = "dataGridViewControl1";
			this.dataGridViewControl1.RowHeadersVisible = false;
			this.dataGridViewControl1.RowTemplate.Height = 23;
			this.dataGridViewControl1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewControl1.Size = new System.Drawing.Size(1534, 631);
			this.dataGridViewControl1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(403, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "라인";
			// 
			// cboLine
			// 
			this.cboLine.FormattingEnabled = true;
			this.cboLine.Location = new System.Drawing.Point(439, 29);
			this.cboLine.Name = "cboLine";
			this.cboLine.Size = new System.Drawing.Size(121, 24);
			this.cboLine.TabIndex = 1;
			this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(756, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "공정";
			// 
			// cboProcess
			// 
			this.cboProcess.FormattingEnabled = true;
			this.cboProcess.Location = new System.Drawing.Point(792, 29);
			this.cboProcess.Name = "cboProcess";
			this.cboProcess.Size = new System.Drawing.Size(121, 24);
			this.cboProcess.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(403, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "품목";
			// 
			// cboProduct
			// 
			this.cboProduct.FormattingEnabled = true;
			this.cboProduct.Location = new System.Drawing.Point(439, 76);
			this.cboProduct.Name = "cboProduct";
			this.cboProduct.Size = new System.Drawing.Size(121, 24);
			this.cboProduct.TabIndex = 4;
			// 
			// fromToDateControl1
			// 
			this.fromToDateControl1.From = new System.DateTime(2020, 8, 10, 18, 2, 26, 742);
			this.fromToDateControl1.Location = new System.Drawing.Point(86, 73);
			this.fromToDateControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.fromToDateControl1.Name = "fromToDateControl1";
			this.fromToDateControl1.Size = new System.Drawing.Size(232, 29);
			this.fromToDateControl1.TabIndex = 3;
			this.fromToDateControl1.To = new System.DateTime(2020, 8, 11, 18, 2, 26, 742);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "작업일자";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(745, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "작업자";
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(792, 77);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(155, 22);
			this.txtSearch.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(50, 33);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "공장";
			// 
			// cboFactory
			// 
			this.cboFactory.FormattingEnabled = true;
			this.cboFactory.Location = new System.Drawing.Point(86, 29);
			this.cboFactory.Name = "cboFactory";
			this.cboFactory.Size = new System.Drawing.Size(121, 24);
			this.cboFactory.TabIndex = 0;
			this.cboFactory.SelectedIndexChanged += new System.EventHandler(this.cboFactory_SelectedIndexChanged);
			// 
			// WorkOrderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(1534, 761);
			this.Controls.Add(this.dataGridViewControl1);
			this.Name = "WorkOrderForm";
			this.Load += new System.EventHandler(this.WorkOrderForm_Load);
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
		private System.Windows.Forms.ComboBox cboProduct;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboProcess;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboLine;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private Control.FromToDateControl fromToDateControl1;
		private System.Windows.Forms.ComboBox cboFactory;
		private System.Windows.Forms.Label label6;
	}
}
