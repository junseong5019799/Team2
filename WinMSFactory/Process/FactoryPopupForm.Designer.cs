namespace WinMSFactory
{
    partial class FactoryPopupForm
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
            this.rdoFactory_useN = new System.Windows.Forms.RadioButton();
            this.rdoFactory_useY = new System.Windows.Forms.RadioButton();
            this.nudFactory_seq = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNote1 = new System.Windows.Forms.TextBox();
            this.txtNote2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFactory_seq)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 385);
            this.panel1.Size = new System.Drawing.Size(344, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightBlue;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Location = new System.Drawing.Point(49, 4);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(198, 4);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rdoFactory_useN
            // 
            this.rdoFactory_useN.AutoSize = true;
            this.rdoFactory_useN.Location = new System.Drawing.Point(199, 169);
            this.rdoFactory_useN.Name = "rdoFactory_useN";
            this.rdoFactory_useN.Size = new System.Drawing.Size(76, 20);
            this.rdoFactory_useN.TabIndex = 29;
            this.rdoFactory_useN.Text = "사용 안 함";
            this.rdoFactory_useN.UseVisualStyleBackColor = true;
            // 
            // rdoFactory_useY
            // 
            this.rdoFactory_useY.AutoSize = true;
            this.rdoFactory_useY.Checked = true;
            this.rdoFactory_useY.Location = new System.Drawing.Point(122, 169);
            this.rdoFactory_useY.Name = "rdoFactory_useY";
            this.rdoFactory_useY.Size = new System.Drawing.Size(48, 20);
            this.rdoFactory_useY.TabIndex = 28;
            this.rdoFactory_useY.TabStop = true;
            this.rdoFactory_useY.Text = "사용";
            this.rdoFactory_useY.UseVisualStyleBackColor = true;
            // 
            // nudFactory_seq
            // 
            this.nudFactory_seq.Location = new System.Drawing.Point(122, 119);
            this.nudFactory_seq.Name = "nudFactory_seq";
            this.nudFactory_seq.Size = new System.Drawing.Size(77, 22);
            this.nudFactory_seq.TabIndex = 27;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 68);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(147, 22);
            this.txtName.TabIndex = 26;
            this.txtName.Tag = "권한그룹 명칭을 입력해주세요.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "사용여부";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "공장 명칭";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "순번";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "법인 명칭";
            // 
            // cboName
            // 
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(122, 21);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(147, 24);
            this.cboName.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "비고1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "비고2";
            // 
            // txtNote1
            // 
            this.txtNote1.Location = new System.Drawing.Point(122, 210);
            this.txtNote1.Multiline = true;
            this.txtNote1.Name = "txtNote1";
            this.txtNote1.Size = new System.Drawing.Size(187, 69);
            this.txtNote1.TabIndex = 37;
            // 
            // txtNote2
            // 
            this.txtNote2.Location = new System.Drawing.Point(122, 304);
            this.txtNote2.Multiline = true;
            this.txtNote2.Name = "txtNote2";
            this.txtNote2.Size = new System.Drawing.Size(187, 69);
            this.txtNote2.TabIndex = 38;
            // 
            // FactoryPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 425);
            this.Controls.Add(this.txtNote2);
            this.Controls.Add(this.txtNote1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoFactory_useN);
            this.Controls.Add(this.rdoFactory_useY);
            this.Controls.Add(this.nudFactory_seq);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "FactoryPopupForm";
            this.Text = "공장 등록/ 변경";
            this.Load += new System.EventHandler(this.FactoryPopupForm_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.nudFactory_seq, 0);
            this.Controls.SetChildIndex(this.rdoFactory_useY, 0);
            this.Controls.SetChildIndex(this.rdoFactory_useN, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.cboName, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtNote1, 0);
            this.Controls.SetChildIndex(this.txtNote2, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFactory_seq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoFactory_useN;
        private System.Windows.Forms.RadioButton rdoFactory_useY;
        private System.Windows.Forms.NumericUpDown nudFactory_seq;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNote1;
        private System.Windows.Forms.TextBox txtNote2;
    }
}