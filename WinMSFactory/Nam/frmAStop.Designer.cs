namespace WinMSFactory
{
    partial class frmAStop
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
            this.dgv = new WinMSFactory.DataGridViewControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.fromToDateControl1 = new WinMSFactory.Control.FromToDateControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkFactory = new System.Windows.Forms.CheckBox();
            this.chkCoporation = new System.Windows.Forms.CheckBox();
            this.rdoNameSearch = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Size = new System.Drawing.Size(1753, 191);
            this.panel2.Controls.SetChildIndex(this.GuidLabel1, 0);
            this.panel2.Controls.SetChildIndex(this.groupBox1, 0);
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.Location = new System.Drawing.Point(90, 10);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.Location = new System.Drawing.Point(0, 191);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 45;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1753, 632);
            this.dgv.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.rdoNameSearch);
            this.groupBox1.Location = new System.Drawing.Point(93, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1411, 131);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색 조건";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(491, 34);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(175, 18);
            this.radioButton2.TabIndex = 32;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "비가동 시작일자로 검색";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.fromToDateControl1);
            this.panel4.Location = new System.Drawing.Point(491, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(363, 41);
            this.panel4.TabIndex = 33;
            // 
            // fromToDateControl1
            // 
            this.fromToDateControl1.Location = new System.Drawing.Point(1, 4);
            this.fromToDateControl1.Name = "fromToDateControl1";
            this.fromToDateControl1.Size = new System.Drawing.Size(234, 33);
            this.fromToDateControl1.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Location = new System.Drawing.Point(43, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(243, 35);
            this.panel3.TabIndex = 31;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(218, 22);
            this.textBox2.TabIndex = 22;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checkBox2);
            this.panel5.Controls.Add(this.checkBox1);
            this.panel5.Controls.Add(this.chkFactory);
            this.panel5.Controls.Add(this.chkCoporation);
            this.panel5.Location = new System.Drawing.Point(145, 31);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(267, 28);
            this.panel5.TabIndex = 30;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(202, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(54, 18);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "라인";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(139, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 18);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "공정";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // chkFactory
            // 
            this.chkFactory.AutoSize = true;
            this.chkFactory.Location = new System.Drawing.Point(77, 3);
            this.chkFactory.Name = "chkFactory";
            this.chkFactory.Size = new System.Drawing.Size(54, 18);
            this.chkFactory.TabIndex = 21;
            this.chkFactory.Text = "공장";
            this.chkFactory.UseVisualStyleBackColor = false;
            // 
            // chkCoporation
            // 
            this.chkCoporation.AutoSize = true;
            this.chkCoporation.Location = new System.Drawing.Point(14, 3);
            this.chkCoporation.Name = "chkCoporation";
            this.chkCoporation.Size = new System.Drawing.Size(54, 18);
            this.chkCoporation.TabIndex = 22;
            this.chkCoporation.Text = "법인";
            this.chkCoporation.UseVisualStyleBackColor = false;
            // 
            // rdoNameSearch
            // 
            this.rdoNameSearch.AutoSize = true;
            this.rdoNameSearch.Location = new System.Drawing.Point(30, 35);
            this.rdoNameSearch.Name = "rdoNameSearch";
            this.rdoNameSearch.Size = new System.Drawing.Size(114, 18);
            this.rdoNameSearch.TabIndex = 29;
            this.rdoNameSearch.TabStop = true;
            this.rdoNameSearch.Text = "명칭으로 검색";
            this.rdoNameSearch.UseVisualStyleBackColor = true;
            // 
            // frmAStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1753, 824);
            this.Controls.Add(this.dgv);
            this.Name = "frmAStop";
            this.Text = "비가동 현황";
            this.Load += new System.EventHandler(this.frmAStop_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewControl dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkFactory;
        private System.Windows.Forms.CheckBox chkCoporation;
        private System.Windows.Forms.RadioButton rdoNameSearch;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel4;
        private Control.FromToDateControl fromToDateControl1;
    }
}