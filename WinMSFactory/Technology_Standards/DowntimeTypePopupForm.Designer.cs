namespace WinMSFactory
{
    partial class DowntimeTypePopupForm
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
            this.nudDowntimeType_seq = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rboTimeNotuse = new System.Windows.Forms.RadioButton();
            this.rboTimeuse = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoDowntimeType_useN = new System.Windows.Forms.RadioButton();
            this.rdoDowntimeType_useY = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDowntimeType_seq)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 256);
            this.panel1.Size = new System.Drawing.Size(358, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.Location = new System.Drawing.Point(57, 3);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nudDowntimeType_seq
            // 
            this.nudDowntimeType_seq.Location = new System.Drawing.Point(155, 74);
            this.nudDowntimeType_seq.Name = "nudDowntimeType_seq";
            this.nudDowntimeType_seq.Size = new System.Drawing.Size(77, 22);
            this.nudDowntimeType_seq.TabIndex = 34;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(155, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(147, 22);
            this.txtName.TabIndex = 33;
            this.txtName.Tag = "권한그룹 명칭을 입력해주세요.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "비가동 명칭";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "순번";
            // 
            // rboTimeNotuse
            // 
            this.rboTimeNotuse.AutoSize = true;
            this.rboTimeNotuse.Location = new System.Drawing.Point(198, 12);
            this.rboTimeNotuse.Name = "rboTimeNotuse";
            this.rboTimeNotuse.Size = new System.Drawing.Size(59, 20);
            this.rboTimeNotuse.TabIndex = 41;
            this.rboTimeNotuse.Text = "미적용";
            this.rboTimeNotuse.UseVisualStyleBackColor = true;
            // 
            // rboTimeuse
            // 
            this.rboTimeuse.AutoSize = true;
            this.rboTimeuse.Checked = true;
            this.rboTimeuse.Location = new System.Drawing.Point(121, 12);
            this.rboTimeuse.Name = "rboTimeuse";
            this.rboTimeuse.Size = new System.Drawing.Size(48, 20);
            this.rboTimeuse.TabIndex = 40;
            this.rboTimeuse.TabStop = true;
            this.rboTimeuse.Text = "적용";
            this.rboTimeuse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "시간계산적용";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rboTimeNotuse);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rboTimeuse);
            this.panel2.Location = new System.Drawing.Point(39, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 38);
            this.panel2.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdoDowntimeType_useN);
            this.panel3.Controls.Add(this.rdoDowntimeType_useY);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(39, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 35);
            this.panel3.TabIndex = 46;
            // 
            // rdoDowntimeType_useN
            // 
            this.rdoDowntimeType_useN.AutoSize = true;
            this.rdoDowntimeType_useN.Location = new System.Drawing.Point(198, 7);
            this.rdoDowntimeType_useN.Name = "rdoDowntimeType_useN";
            this.rdoDowntimeType_useN.Size = new System.Drawing.Size(76, 20);
            this.rdoDowntimeType_useN.TabIndex = 39;
            this.rdoDowntimeType_useN.Text = "사용 안 함";
            this.rdoDowntimeType_useN.UseVisualStyleBackColor = true;
            // 
            // rdoDowntimeType_useY
            // 
            this.rdoDowntimeType_useY.AutoSize = true;
            this.rdoDowntimeType_useY.Checked = true;
            this.rdoDowntimeType_useY.Location = new System.Drawing.Point(121, 7);
            this.rdoDowntimeType_useY.Name = "rdoDowntimeType_useY";
            this.rdoDowntimeType_useY.Size = new System.Drawing.Size(48, 20);
            this.rdoDowntimeType_useY.TabIndex = 38;
            this.rdoDowntimeType_useY.TabStop = true;
            this.rdoDowntimeType_useY.Text = "사용";
            this.rdoDowntimeType_useY.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "사용여부";
            // 
            // DowntimeTypePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 296);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.nudDowntimeType_seq);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "DowntimeTypePopupForm";
            this.Text = "비동기  등록/ 변경";
            this.Load += new System.EventHandler(this.DowntimePopupForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.nudDowntimeType_seq, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDowntimeType_seq)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudDowntimeType_seq;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rboTimeNotuse;
        private System.Windows.Forms.RadioButton rboTimeuse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdoDowntimeType_useN;
        private System.Windows.Forms.RadioButton rdoDowntimeType_useY;
        private System.Windows.Forms.Label label3;
    }
}