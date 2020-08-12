namespace WinMSFactory
{
    partial class ProcessWorkerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProcess = new WinMSFactory.DataGridViewControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvWorker = new WinMSFactory.DataGridViewControl();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(1534, 80);
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.Location = new System.Drawing.Point(52, 9);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProcess);
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Size = new System.Drawing.Size(715, 681);
            this.panel1.Controls.SetChildIndex(this.dgvProcess, 0);
            this.panel1.Controls.SetChildIndex(this.GuidLabel2, 0);
            // 
            // GuidLabel2
            // 
            this.GuidLabel2.Location = new System.Drawing.Point(34, 15);
            this.GuidLabel2.Size = new System.Drawing.Size(201, 16);
            this.GuidLabel2.Text = "DGV공정리스트 법인, 공장, 라인, 공정";
            // 
            // GuidLabel3
            // 
            this.GuidLabel3.Location = new System.Drawing.Point(755, 195);
            this.GuidLabel3.Size = new System.Drawing.Size(206, 16);
            this.GuidLabel3.Text = "DGV작업자 리스트 작업자 코드, 작업자";
            // 
            // dgvProcess
            // 
            this.dgvProcess.AllowUserToAddRows = false;
            this.dgvProcess.BackgroundColor = System.Drawing.Color.White;
            this.dgvProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProcess.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProcess.IsAllCheckColumnHeader = false;
            this.dgvProcess.IsAutoGenerateColumns = false;
            this.dgvProcess.Location = new System.Drawing.Point(0, 0);
            this.dgvProcess.MultiSelect = false;
            this.dgvProcess.Name = "dgvProcess";
            this.dgvProcess.RowHeadersVisible = false;
            this.dgvProcess.RowTemplate.Height = 23;
            this.dgvProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcess.Size = new System.Drawing.Size(715, 681);
            this.dgvProcess.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvWorker);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(713, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(821, 681);
            this.panel3.TabIndex = 6;
            // 
            // dgvWorker
            // 
            this.dgvWorker.AllowUserToAddRows = false;
            this.dgvWorker.BackgroundColor = System.Drawing.Color.White;
            this.dgvWorker.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorker.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorker.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorker.IsAllCheckColumnHeader = false;
            this.dgvWorker.IsAutoGenerateColumns = false;
            this.dgvWorker.Location = new System.Drawing.Point(0, 0);
            this.dgvWorker.MultiSelect = false;
            this.dgvWorker.Name = "dgvWorker";
            this.dgvWorker.RowHeadersVisible = false;
            this.dgvWorker.RowTemplate.Height = 23;
            this.dgvWorker.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorker.Size = new System.Drawing.Size(821, 681);
            this.dgvWorker.TabIndex = 8;
            // 
            // ProcessWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ProcessWorkerForm";
            this.Text = "공정 별 작업자 관리";
            this.Load += new System.EventHandler(this.ProcessWorkerForm_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.GuidLabel3, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewControl dgvProcess;
        private System.Windows.Forms.Panel panel3;
        private DataGridViewControl dgvWorker;
    }
}