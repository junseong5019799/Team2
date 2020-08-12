namespace WinMSFactory
{
    partial class ProcessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvProcess = new WinMSFactory.DataGridViewControl();
            this.cboCorporationName = new System.Windows.Forms.ComboBox();
            this.cboLineName = new System.Windows.Forms.ComboBox();
            this.cboFactoryName = new System.Windows.Forms.ComboBox();
            this.cboStorageName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboStorageName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboFactoryName);
            this.panel1.Controls.Add(this.cboLineName);
            this.panel1.Controls.Add(this.cboCorporationName);
            this.panel1.Controls.Add(this.txtProcessName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Size = new System.Drawing.Size(1753, 80);
            this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.txtProcessName, 0);
            this.panel1.Controls.SetChildIndex(this.cboCorporationName, 0);
            this.panel1.Controls.SetChildIndex(this.cboLineName, 0);
            this.panel1.Controls.SetChildIndex(this.cboFactoryName, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.cboStorageName, 0);
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.Location = new System.Drawing.Point(932, 9);
            // 
            // GuidLabel2
            // 
            this.GuidLabel2.Size = new System.Drawing.Size(532, 16);
            this.GuidLabel2.Text = "DGV 법인명칭, 공장명칭, 라인명칭, 공정코드, 공정명칭, 공정순번, 비고1, 비고2, 공정사용여부, 최초, 최종";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "라인 명칭";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(320, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "공장 명칭";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "법인 명칭";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcessName.Location = new System.Drawing.Point(397, 50);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(151, 22);
            this.txtProcessName.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(320, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "공정 명칭";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvProcess);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1753, 935);
            this.panel2.TabIndex = 4;
            // 
            // dgvProcess
            // 
            this.dgvProcess.AllowUserToAddRows = false;
            this.dgvProcess.BackgroundColor = System.Drawing.Color.White;
            this.dgvProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProcess.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProcess.IsAllCheckColumnHeader = false;
            this.dgvProcess.IsAutoGenerateColumns = false;
            this.dgvProcess.Location = new System.Drawing.Point(0, 0);
            this.dgvProcess.MultiSelect = false;
            this.dgvProcess.Name = "dgvProcess";
            this.dgvProcess.RowHeadersVisible = false;
            this.dgvProcess.RowTemplate.Height = 23;
            this.dgvProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcess.Size = new System.Drawing.Size(1753, 935);
            this.dgvProcess.TabIndex = 5;
            this.dgvProcess.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcess_CellClick);
            this.dgvProcess.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcess_CellDoubleClick);
            this.dgvProcess.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProcess_DataBindingComplete);
            // 
            // cboCorporationName
            // 
            this.cboCorporationName.FormattingEnabled = true;
            this.cboCorporationName.Location = new System.Drawing.Point(115, 16);
            this.cboCorporationName.Name = "cboCorporationName";
            this.cboCorporationName.Size = new System.Drawing.Size(151, 24);
            this.cboCorporationName.TabIndex = 36;
            this.cboCorporationName.SelectedIndexChanged += new System.EventHandler(this.cboCorporationName_SelectedIndexChanged);
            // 
            // cboLineName
            // 
            this.cboLineName.FormattingEnabled = true;
            this.cboLineName.Location = new System.Drawing.Point(115, 50);
            this.cboLineName.Name = "cboLineName";
            this.cboLineName.Size = new System.Drawing.Size(151, 24);
            this.cboLineName.TabIndex = 37;
            // 
            // cboFactoryName
            // 
            this.cboFactoryName.FormattingEnabled = true;
            this.cboFactoryName.Location = new System.Drawing.Point(397, 16);
            this.cboFactoryName.Name = "cboFactoryName";
            this.cboFactoryName.Size = new System.Drawing.Size(151, 24);
            this.cboFactoryName.TabIndex = 38;
            this.cboFactoryName.SelectedIndexChanged += new System.EventHandler(this.cboFactoryName_SelectedIndexChanged);
            // 
            // cboStorageName
            // 
            this.cboStorageName.FormattingEnabled = true;
            this.cboStorageName.Location = new System.Drawing.Point(677, 16);
            this.cboStorageName.Name = "cboStorageName";
            this.cboStorageName.Size = new System.Drawing.Size(151, 24);
            this.cboStorageName.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(600, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "창고 명칭";
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1753, 1015);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "ProcessForm";
            this.Text = "공정관리";
            this.Load += new System.EventHandler(this.ProcessForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GuidLabel2, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFactoryName;
        private System.Windows.Forms.ComboBox cboLineName;
        private System.Windows.Forms.ComboBox cboCorporationName;
        private System.Windows.Forms.Panel panel2;
        private DataGridViewControl dgvProcess;
        private System.Windows.Forms.ComboBox cboStorageName;
        private System.Windows.Forms.Label label4;
    }
}