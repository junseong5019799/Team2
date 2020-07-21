namespace WinMSFactory
{
    partial class frmABad
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
            this.dgv = new WinMSFactory.DataGridViewControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonControl1 = new WinMSFactory.ButtonControl();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkFactory = new System.Windows.Forms.CheckBox();
            this.chkCoporation = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonControl2 = new WinMSFactory.ButtonControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoNumSearch = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoNameSearch = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.Location = new System.Drawing.Point(146, 4);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 176);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1534, 585);
            this.dgv.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.rdoNumSearch);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.rdoNameSearch);
            this.groupBox1.Location = new System.Drawing.Point(75, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색 조건";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radioButton3);
            this.panel5.Controls.Add(this.radioButton2);
            this.panel5.Location = new System.Drawing.Point(815, 67);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(135, 33);
            this.panel5.TabIndex = 27;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(79, 6);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(44, 20);
            this.radioButton3.TabIndex = 20;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "No";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 6);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(50, 20);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Yes";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonControl1);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Location = new System.Drawing.Point(408, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(314, 32);
            this.panel4.TabIndex = 26;
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(191, 22);
            this.textBox2.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox2);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.chkFactory);
            this.panel3.Controls.Add(this.chkCoporation);
            this.panel3.Location = new System.Drawing.Point(497, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(234, 26);
            this.panel3.TabIndex = 25;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(177, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(49, 20);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "라인";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(122, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 20);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "공정";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // chkFactory
            // 
            this.chkFactory.AutoSize = true;
            this.chkFactory.Location = new System.Drawing.Point(67, 3);
            this.chkFactory.Name = "chkFactory";
            this.chkFactory.Size = new System.Drawing.Size(49, 20);
            this.chkFactory.TabIndex = 21;
            this.chkFactory.Text = "공장";
            this.chkFactory.UseVisualStyleBackColor = false;
            // 
            // chkCoporation
            // 
            this.chkCoporation.AutoSize = true;
            this.chkCoporation.Location = new System.Drawing.Point(12, 3);
            this.chkCoporation.Name = "chkCoporation";
            this.chkCoporation.Size = new System.Drawing.Size(49, 20);
            this.chkCoporation.TabIndex = 22;
            this.chkCoporation.Text = "법인";
            this.chkCoporation.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonControl2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(46, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 31);
            this.panel2.TabIndex = 23;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "불량 번호";
            // 
            // rdoNumSearch
            // 
            this.rdoNumSearch.AutoSize = true;
            this.rdoNumSearch.Location = new System.Drawing.Point(61, 31);
            this.rdoNumSearch.Name = "rdoNumSearch";
            this.rdoNumSearch.Size = new System.Drawing.Size(109, 20);
            this.rdoNumSearch.TabIndex = 22;
            this.rdoNumSearch.TabStop = true;
            this.rdoNumSearch.Text = "불량 번호로 검색";
            this.rdoNumSearch.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(778, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(109, 20);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "사용 여부로 검색";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdoNameSearch
            // 
            this.rdoNameSearch.AutoSize = true;
            this.rdoNameSearch.Location = new System.Drawing.Point(396, 31);
            this.rdoNameSearch.Name = "rdoNameSearch";
            this.rdoNameSearch.Size = new System.Drawing.Size(95, 20);
            this.rdoNameSearch.TabIndex = 17;
            this.rdoNameSearch.TabStop = true;
            this.rdoNameSearch.Text = "명칭으로 검색";
            this.rdoNameSearch.UseVisualStyleBackColor = true;
            // 
            // frmABad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.dgv);
            this.Name = "frmABad";
            this.Text = "불량 현황";
            this.Load += new System.EventHandler(this.frmABad_Load);
            this.Controls.SetChildIndex(this.GuidLabel2, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewControl dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoNameSearch;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel4;
        private ButtonControl buttonControl1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkFactory;
        private System.Windows.Forms.CheckBox chkCoporation;
        private System.Windows.Forms.Panel panel2;
        private ButtonControl buttonControl2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoNumSearch;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
