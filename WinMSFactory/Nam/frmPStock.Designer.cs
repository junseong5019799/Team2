namespace WinMSFactory
{
    partial class frmPStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonControl2 = new WinMSFactory.ButtonControl();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoNumSearch = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonControl1 = new WinMSFactory.ButtonControl();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.fromToDateControl1 = new WinMSFactory.Control.FromToDateControl();
            this.buttonControl3 = new WinMSFactory.ButtonControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv = new WinMSFactory.DataGridViewControl();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.rdoNumSearch);
            this.panel2.Controls.SetChildIndex(this.GuidLabel1, 0);
            this.panel2.Controls.SetChildIndex(this.rdoNumSearch, 0);
            this.panel2.Controls.SetChildIndex(this.radioButton1, 0);
            this.panel2.Controls.SetChildIndex(this.radioButton2, 0);
            this.panel2.Controls.SetChildIndex(this.panel1, 0);
            this.panel2.Controls.SetChildIndex(this.panel3, 0);
            this.panel2.Controls.SetChildIndex(this.panel4, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.buttonControl2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(69, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 31);
            this.panel1.TabIndex = 25;
            // 
            // buttonControl2
            // 
            this.buttonControl2.BackColor = System.Drawing.Color.White;
            this.buttonControl2.ForeColor = System.Drawing.Color.Black;
            this.buttonControl2.Location = new System.Drawing.Point(204, 4);
            this.buttonControl2.Name = "buttonControl2";
            this.buttonControl2.Size = new System.Drawing.Size(95, 22);
            this.buttonControl2.TabIndex = 26;
            this.buttonControl2.Text = "검색";
            this.buttonControl2.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "명칭";
            // 
            // rdoNumSearch
            // 
            this.rdoNumSearch.AutoSize = true;
            this.rdoNumSearch.Location = new System.Drawing.Point(84, 41);
            this.rdoNumSearch.Name = "rdoNumSearch";
            this.rdoNumSearch.Size = new System.Drawing.Size(127, 16);
            this.rdoNumSearch.TabIndex = 24;
            this.rdoNumSearch.TabStop = true;
            this.rdoNumSearch.Text = "창고 명칭으로 검색";
            this.rdoNumSearch.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(47, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 20);
            this.comboBox1.TabIndex = 27;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(417, 41);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(127, 16);
            this.radioButton1.TabIndex = 24;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "품목 명칭으로 검색";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Controls.Add(this.buttonControl1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(402, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(304, 31);
            this.panel3.TabIndex = 25;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(47, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(152, 20);
            this.comboBox2.TabIndex = 27;
            // 
            // buttonControl1
            // 
            this.buttonControl1.BackColor = System.Drawing.Color.White;
            this.buttonControl1.ForeColor = System.Drawing.Color.Black;
            this.buttonControl1.Location = new System.Drawing.Point(204, 4);
            this.buttonControl1.Name = "buttonControl1";
            this.buttonControl1.Size = new System.Drawing.Size(95, 22);
            this.buttonControl1.TabIndex = 26;
            this.buttonControl1.Text = "검색";
            this.buttonControl1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "명칭";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(756, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(99, 16);
            this.radioButton2.TabIndex = 24;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "등록일로 검색";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // fromToDateControl1
            // 
            this.fromToDateControl1.Location = new System.Drawing.Point(1, 4);
            this.fromToDateControl1.Name = "fromToDateControl1";
            this.fromToDateControl1.Size = new System.Drawing.Size(205, 30);
            this.fromToDateControl1.TabIndex = 26;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.fromToDateControl1);
            this.panel4.Controls.Add(this.buttonControl3);
            this.panel4.Location = new System.Drawing.Point(755, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(318, 38);
            this.panel4.TabIndex = 27;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Location = new System.Drawing.Point(2, 175);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1532, 583);
            this.dgv.TabIndex = 5;
            // 
            // frmPStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.dgv);
            this.Name = "frmPStock";
            this.Text = "재고 현황";
            this.Load += new System.EventHandler(this.frmPStock_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private ButtonControl buttonControl2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoNumSearch;
        private Control.FromToDateControl fromToDateControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox2;
        private ButtonControl buttonControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel4;
        private ButtonControl buttonControl3;
        private DataGridViewControl dgv;
    }
}