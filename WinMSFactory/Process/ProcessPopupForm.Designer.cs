namespace WinMSFactory
{
    partial class ProcessPopupForm
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
            this.cboCorporationName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNote2 = new System.Windows.Forms.TextBox();
            this.txtNote1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFactoryName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoProcess_useN = new System.Windows.Forms.RadioButton();
            this.rdoProcess_useY = new System.Windows.Forms.RadioButton();
            this.nudProcess_seq = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboLineName = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboStorageName = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProcess_seq)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Size = new System.Drawing.Size(366, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightBlue;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Location = new System.Drawing.Point(52, 4);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(211, 4);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboCorporationName
            // 
            this.cboCorporationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCorporationName.FormattingEnabled = true;
            this.cboCorporationName.Location = new System.Drawing.Point(133, 10);
            this.cboCorporationName.Name = "cboCorporationName";
            this.cboCorporationName.Size = new System.Drawing.Size(147, 24);
            this.cboCorporationName.TabIndex = 68;
            this.cboCorporationName.SelectedIndexChanged += new System.EventHandler(this.cboCorporationName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 67;
            this.label7.Text = "법인 명칭";
            // 
            // txtNote2
            // 
            this.txtNote2.Location = new System.Drawing.Point(133, 341);
            this.txtNote2.Multiline = true;
            this.txtNote2.Name = "txtNote2";
            this.txtNote2.Size = new System.Drawing.Size(187, 69);
            this.txtNote2.TabIndex = 66;
            // 
            // txtNote1
            // 
            this.txtNote1.Location = new System.Drawing.Point(133, 252);
            this.txtNote1.Multiline = true;
            this.txtNote1.Name = "txtNote1";
            this.txtNote1.Size = new System.Drawing.Size(187, 69);
            this.txtNote1.TabIndex = 65;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 64;
            this.label6.Text = "비고2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 63;
            this.label5.Text = "비고1";
            // 
            // cboFactoryName
            // 
            this.cboFactoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFactoryName.FormattingEnabled = true;
            this.cboFactoryName.Location = new System.Drawing.Point(133, 46);
            this.cboFactoryName.Name = "cboFactoryName";
            this.cboFactoryName.Size = new System.Drawing.Size(147, 24);
            this.cboFactoryName.TabIndex = 62;
            this.cboFactoryName.SelectedIndexChanged += new System.EventHandler(this.cboFactoryName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 61;
            this.label1.Text = "공장 명칭";
            // 
            // rdoProcess_useN
            // 
            this.rdoProcess_useN.AutoSize = true;
            this.rdoProcess_useN.Location = new System.Drawing.Point(210, 219);
            this.rdoProcess_useN.Name = "rdoProcess_useN";
            this.rdoProcess_useN.Size = new System.Drawing.Size(76, 20);
            this.rdoProcess_useN.TabIndex = 57;
            this.rdoProcess_useN.Text = "사용 안 함";
            this.rdoProcess_useN.UseVisualStyleBackColor = true;
            // 
            // rdoProcess_useY
            // 
            this.rdoProcess_useY.AutoSize = true;
            this.rdoProcess_useY.Checked = true;
            this.rdoProcess_useY.Location = new System.Drawing.Point(133, 219);
            this.rdoProcess_useY.Name = "rdoProcess_useY";
            this.rdoProcess_useY.Size = new System.Drawing.Size(48, 20);
            this.rdoProcess_useY.TabIndex = 56;
            this.rdoProcess_useY.TabStop = true;
            this.rdoProcess_useY.Text = "사용";
            this.rdoProcess_useY.UseVisualStyleBackColor = true;
            // 
            // nudProcess_seq
            // 
            this.nudProcess_seq.Location = new System.Drawing.Point(133, 185);
            this.nudProcess_seq.Name = "nudProcess_seq";
            this.nudProcess_seq.Size = new System.Drawing.Size(77, 22);
            this.nudProcess_seq.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "사용여부";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "라인 명칭";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 59;
            this.label2.Text = "순번";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 70;
            this.label8.Text = "창고 명칭";
            // 
            // cboLineName
            // 
            this.cboLineName.FormattingEnabled = true;
            this.cboLineName.Location = new System.Drawing.Point(133, 82);
            this.cboLineName.Name = "cboLineName";
            this.cboLineName.Size = new System.Drawing.Size(147, 24);
            this.cboLineName.TabIndex = 71;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 152);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(147, 22);
            this.txtName.TabIndex = 72;
            this.txtName.Tag = "권한그룹 명칭을 입력해주세요.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 73;
            this.label9.Text = "공정 명칭";
            // 
            // cboStorageName
            // 
            this.cboStorageName.FormattingEnabled = true;
            this.cboStorageName.Location = new System.Drawing.Point(133, 115);
            this.cboStorageName.Name = "cboStorageName";
            this.cboStorageName.Size = new System.Drawing.Size(147, 24);
            this.cboStorageName.TabIndex = 74;
            // 
            // ProcessPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 467);
            this.Controls.Add(this.cboStorageName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboLineName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboCorporationName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNote2);
            this.Controls.Add(this.txtNote1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboFactoryName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoProcess_useN);
            this.Controls.Add(this.rdoProcess_useY);
            this.Controls.Add(this.nudProcess_seq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "ProcessPopupForm";
            this.Text = "공정 등록/ 변경";
            this.Load += new System.EventHandler(this.ProcessPopupForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.nudProcess_seq, 0);
            this.Controls.SetChildIndex(this.rdoProcess_useY, 0);
            this.Controls.SetChildIndex(this.rdoProcess_useN, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboFactoryName, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtNote1, 0);
            this.Controls.SetChildIndex(this.txtNote2, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cboCorporationName, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cboLineName, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.cboStorageName, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudProcess_seq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCorporationName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNote2;
        private System.Windows.Forms.TextBox txtNote1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFactoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoProcess_useN;
        private System.Windows.Forms.RadioButton rdoProcess_useY;
        private System.Windows.Forms.NumericUpDown nudProcess_seq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboLineName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboStorageName;
    }
}