namespace WinMSFactory
{
    partial class frmAWoHis
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new WinMSFactory.DataGridViewControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rdoNumSearch = new System.Windows.Forms.RadioButton();
            this.buttonControl3 = new WinMSFactory.ButtonControl();
            this.fromToDateControl1 = new WinMSFactory.Control.FromToDateControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonControl2 = new WinMSFactory.ButtonControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoNameSearch = new System.Windows.Forms.RadioButton();
            this.chkCoporation = new System.Windows.Forms.CheckBox();
            this.chkFactory = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonControl1 = new WinMSFactory.ButtonControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel2.Controls.SetChildIndex(this.GuidLabel1, 0);
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.Location = new System.Drawing.Point(57, 9);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(4, 176);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1518, 573);
            this.dgv.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.rdoNumSearch);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.rdoNameSearch);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(59, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1235, 116);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색 조건";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(26, 33);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(111, 16);
            this.radioButton2.TabIndex = 27;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "생산일자로 검색";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rdoNumSearch
            // 
            this.rdoNumSearch.AutoSize = true;
            this.rdoNumSearch.Location = new System.Drawing.Point(922, 33);
            this.rdoNumSearch.Name = "rdoNumSearch";
            this.rdoNumSearch.Size = new System.Drawing.Size(127, 16);
            this.rdoNumSearch.TabIndex = 24;
            this.rdoNumSearch.TabStop = true;
            this.rdoNumSearch.Text = "품목 명칭으로 검색";
            this.rdoNumSearch.UseVisualStyleBackColor = true;
            // 
            // buttonControl3
            // 
            this.buttonControl3.BackColor = System.Drawing.Color.White;
            this.buttonControl3.ForeColor = System.Drawing.Color.Black;
            this.buttonControl3.Location = new System.Drawing.Point(212, 7);
            this.buttonControl3.Name = "buttonControl3";
            this.buttonControl3.Size = new System.Drawing.Size(95, 22);
            this.buttonControl3.TabIndex = 26;
            this.buttonControl3.Text = "검색";
            this.buttonControl3.UseVisualStyleBackColor = false;
            // 
            // fromToDateControl1
            // 
            this.fromToDateControl1.Location = new System.Drawing.Point(1, 4);
            this.fromToDateControl1.Name = "fromToDateControl1";
            this.fromToDateControl1.Size = new System.Drawing.Size(205, 30);
            this.fromToDateControl1.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.fromToDateControl1);
            this.panel4.Controls.Add(this.buttonControl3);
            this.panel4.Location = new System.Drawing.Point(26, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(318, 38);
            this.panel4.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "품명";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 25;
            // 
            // buttonControl2
            // 
            this.buttonControl2.BackColor = System.Drawing.Color.White;
            this.buttonControl2.ForeColor = System.Drawing.Color.Black;
            this.buttonControl2.Location = new System.Drawing.Point(200, 4);
            this.buttonControl2.Name = "buttonControl2";
            this.buttonControl2.Size = new System.Drawing.Size(95, 22);
            this.buttonControl2.TabIndex = 26;
            this.buttonControl2.Text = "검색";
            this.buttonControl2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonControl2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(907, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 31);
            this.panel1.TabIndex = 25;
            // 
            // rdoNameSearch
            // 
            this.rdoNameSearch.AutoSize = true;
            this.rdoNameSearch.Location = new System.Drawing.Point(457, 32);
            this.rdoNameSearch.Name = "rdoNameSearch";
            this.rdoNameSearch.Size = new System.Drawing.Size(99, 16);
            this.rdoNameSearch.TabIndex = 29;
            this.rdoNameSearch.TabStop = true;
            this.rdoNameSearch.Text = "명칭으로 검색";
            this.rdoNameSearch.UseVisualStyleBackColor = true;
            // 
            // chkCoporation
            // 
            this.chkCoporation.AutoSize = true;
            this.chkCoporation.Location = new System.Drawing.Point(12, 3);
            this.chkCoporation.Name = "chkCoporation";
            this.chkCoporation.Size = new System.Drawing.Size(48, 16);
            this.chkCoporation.TabIndex = 22;
            this.chkCoporation.Text = "법인";
            this.chkCoporation.UseVisualStyleBackColor = false;
            // 
            // chkFactory
            // 
            this.chkFactory.AutoSize = true;
            this.chkFactory.Location = new System.Drawing.Point(67, 3);
            this.chkFactory.Name = "chkFactory";
            this.chkFactory.Size = new System.Drawing.Size(48, 16);
            this.chkFactory.TabIndex = 21;
            this.chkFactory.Text = "공장";
            this.chkFactory.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(122, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "공정";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(177, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "라인";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checkBox2);
            this.panel5.Controls.Add(this.checkBox1);
            this.panel5.Controls.Add(this.chkFactory);
            this.panel5.Controls.Add(this.chkCoporation);
            this.panel5.Location = new System.Drawing.Point(558, 29);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(234, 26);
            this.panel5.TabIndex = 30;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(191, 21);
            this.textBox2.TabIndex = 22;
            // 
            // buttonControl1
            // 
            this.buttonControl1.BackColor = System.Drawing.Color.White;
            this.buttonControl1.ForeColor = System.Drawing.Color.Black;
            this.buttonControl1.Location = new System.Drawing.Point(208, 5);
            this.buttonControl1.Name = "buttonControl1";
            this.buttonControl1.Size = new System.Drawing.Size(95, 22);
            this.buttonControl1.TabIndex = 23;
            this.buttonControl1.Text = "검색";
            this.buttonControl1.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonControl1);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Location = new System.Drawing.Point(469, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(314, 32);
            this.panel3.TabIndex = 31;
            // 
            // frmAWoHis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.dgv);
            this.Name = "frmAWoHis";
            this.Text = "생산 실적 현황";
            this.Load += new System.EventHandler(this.frmAWoHis_Load);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewControl dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel3;
        private ButtonControl buttonControl1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton rdoNumSearch;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkFactory;
        private System.Windows.Forms.CheckBox chkCoporation;
        private System.Windows.Forms.Panel panel4;
        private Control.FromToDateControl fromToDateControl1;
        private ButtonControl buttonControl3;
        private System.Windows.Forms.RadioButton rdoNameSearch;
        private System.Windows.Forms.Panel panel1;
        private ButtonControl buttonControl2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}