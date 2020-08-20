namespace WinMSFactory
{
    partial class LinePopupForm
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
            this.txtNote2 = new System.Windows.Forms.TextBox();
            this.txtNote1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFactoryName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoLine_useN = new System.Windows.Forms.RadioButton();
            this.rdoLine_useY = new System.Windows.Forms.RadioButton();
            this.nudLine_seq = new System.Windows.Forms.NumericUpDown();
            this.txtLineName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCorporationName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLine_seq)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Size = new System.Drawing.Size(364, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightBlue;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Location = new System.Drawing.Point(54, 4);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(205, 4);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtNote2
            // 
            this.txtNote2.Location = new System.Drawing.Point(129, 310);
            this.txtNote2.Multiline = true;
            this.txtNote2.Name = "txtNote2";
            this.txtNote2.Size = new System.Drawing.Size(187, 69);
            this.txtNote2.TabIndex = 51;
            // 
            // txtNote1
            // 
            this.txtNote1.Location = new System.Drawing.Point(129, 216);
            this.txtNote1.Multiline = true;
            this.txtNote1.Name = "txtNote1";
            this.txtNote1.Size = new System.Drawing.Size(187, 69);
            this.txtNote1.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "비고2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "비고1";
            // 
            // cboFactoryName
            // 
            this.cboFactoryName.FormattingEnabled = true;
            this.cboFactoryName.Location = new System.Drawing.Point(129, 48);
            this.cboFactoryName.Name = "cboFactoryName";
            this.cboFactoryName.Size = new System.Drawing.Size(147, 24);
            this.cboFactoryName.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "라인 명칭";
            // 
            // rdoLine_useN
            // 
            this.rdoLine_useN.AutoSize = true;
            this.rdoLine_useN.Location = new System.Drawing.Point(206, 175);
            this.rdoLine_useN.Name = "rdoLine_useN";
            this.rdoLine_useN.Size = new System.Drawing.Size(76, 20);
            this.rdoLine_useN.TabIndex = 42;
            this.rdoLine_useN.Text = "사용 안 함";
            this.rdoLine_useN.UseVisualStyleBackColor = true;
            // 
            // rdoLine_useY
            // 
            this.rdoLine_useY.AutoSize = true;
            this.rdoLine_useY.Checked = true;
            this.rdoLine_useY.Location = new System.Drawing.Point(129, 175);
            this.rdoLine_useY.Name = "rdoLine_useY";
            this.rdoLine_useY.Size = new System.Drawing.Size(48, 20);
            this.rdoLine_useY.TabIndex = 41;
            this.rdoLine_useY.TabStop = true;
            this.rdoLine_useY.Text = "사용";
            this.rdoLine_useY.UseVisualStyleBackColor = true;
            // 
            // nudLine_seq
            // 
            this.nudLine_seq.Location = new System.Drawing.Point(129, 132);
            this.nudLine_seq.Name = "nudLine_seq";
            this.nudLine_seq.Size = new System.Drawing.Size(77, 22);
            this.nudLine_seq.TabIndex = 40;
            // 
            // txtLineName
            // 
            this.txtLineName.Location = new System.Drawing.Point(129, 92);
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Size = new System.Drawing.Size(147, 22);
            this.txtLineName.TabIndex = 39;
            this.txtLineName.Tag = "권한그룹 명칭을 입력해주세요.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "사용여부";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "공장 명칭";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "순번";
            // 
            // cboCorporationName
            // 
            this.cboCorporationName.FormattingEnabled = true;
            this.cboCorporationName.Location = new System.Drawing.Point(129, 8);
            this.cboCorporationName.Name = "cboCorporationName";
            this.cboCorporationName.Size = new System.Drawing.Size(147, 24);
            this.cboCorporationName.TabIndex = 53;
            this.cboCorporationName.SelectedIndexChanged += new System.EventHandler(this.cboCorporationName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 52;
            this.label7.Text = "법인 명칭";
            // 
            // LinePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 450);
            this.Controls.Add(this.cboCorporationName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNote2);
            this.Controls.Add(this.txtNote1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboFactoryName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoLine_useN);
            this.Controls.Add(this.rdoLine_useY);
            this.Controls.Add(this.nudLine_seq);
            this.Controls.Add(this.txtLineName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "LinePopupForm";
            this.Text = "라인 등록/ 변경";
            this.Load += new System.EventHandler(this.LinePopupForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtLineName, 0);
            this.Controls.SetChildIndex(this.nudLine_seq, 0);
            this.Controls.SetChildIndex(this.rdoLine_useY, 0);
            this.Controls.SetChildIndex(this.rdoLine_useN, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboFactoryName, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtNote1, 0);
            this.Controls.SetChildIndex(this.txtNote2, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cboCorporationName, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLine_seq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNote2;
        private System.Windows.Forms.TextBox txtNote1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFactoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoLine_useN;
        private System.Windows.Forms.RadioButton rdoLine_useY;
        private System.Windows.Forms.NumericUpDown nudLine_seq;
        private System.Windows.Forms.TextBox txtLineName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCorporationName;
        private System.Windows.Forms.Label label7;
    }
}