namespace WinMSFactory
{
    partial class CorporationPopupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.rboUse = new System.Windows.Forms.RadioButton();
            this.rboNotUse = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.txtNote1 = new System.Windows.Forms.TextBox();
            this.txtNote2 = new System.Windows.Forms.TextBox();
            this.dtpFirst = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 531);
            this.panel1.Size = new System.Drawing.Size(387, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.Location = new System.Drawing.Point(80, 7);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 7);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "법인코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "법인명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "법인순번";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "비고1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "비고2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "법인 사용여부";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "최초등록시각";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "최초등록사원";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 446);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "최종등록시각";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 484);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "최종등록사원";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(126, 17);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(119, 22);
            this.txtID.TabIndex = 11;
            // 
            // rboUse
            // 
            this.rboUse.AutoSize = true;
            this.rboUse.Location = new System.Drawing.Point(141, 331);
            this.rboUse.Name = "rboUse";
            this.rboUse.Size = new System.Drawing.Size(48, 20);
            this.rboUse.TabIndex = 12;
            this.rboUse.TabStop = true;
            this.rboUse.Text = "사용";
            this.rboUse.UseVisualStyleBackColor = true;
            // 
            // rboNotUse
            // 
            this.rboNotUse.AutoSize = true;
            this.rboNotUse.Location = new System.Drawing.Point(207, 331);
            this.rboNotUse.Name = "rboNotUse";
            this.rboNotUse.Size = new System.Drawing.Size(73, 20);
            this.rboNotUse.TabIndex = 13;
            this.rboNotUse.TabStop = true;
            this.rboNotUse.Text = "사용 안함";
            this.rboNotUse.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(126, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(119, 22);
            this.txtName.TabIndex = 14;
            // 
            // txtSeq
            // 
            this.txtSeq.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSeq.Location = new System.Drawing.Point(126, 96);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(119, 22);
            this.txtSeq.TabIndex = 15;
            this.txtSeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeq_KeyPress);
            // 
            // txtNote1
            // 
            this.txtNote1.Location = new System.Drawing.Point(126, 134);
            this.txtNote1.Multiline = true;
            this.txtNote1.Name = "txtNote1";
            this.txtNote1.Size = new System.Drawing.Size(223, 80);
            this.txtNote1.TabIndex = 16;
            // 
            // txtNote2
            // 
            this.txtNote2.Location = new System.Drawing.Point(126, 231);
            this.txtNote2.Multiline = true;
            this.txtNote2.Name = "txtNote2";
            this.txtNote2.Size = new System.Drawing.Size(223, 80);
            this.txtNote2.TabIndex = 17;
            // 
            // dtpFirst
            // 
            this.dtpFirst.Location = new System.Drawing.Point(126, 365);
            this.dtpFirst.Name = "dtpFirst";
            this.dtpFirst.Size = new System.Drawing.Size(200, 22);
            this.dtpFirst.TabIndex = 18;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Location = new System.Drawing.Point(126, 441);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(200, 22);
            this.dtpFinal.TabIndex = 19;
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(126, 405);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(119, 22);
            this.txtFirst.TabIndex = 20;
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(126, 478);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(119, 22);
            this.txtFinal.TabIndex = 21;
            // 
            // CorporationPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 571);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.dtpFirst);
            this.Controls.Add(this.txtNote2);
            this.Controls.Add(this.txtNote1);
            this.Controls.Add(this.txtSeq);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.rboNotUse);
            this.Controls.Add(this.rboUse);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CorporationPopupForm";
            this.Text = "CorporationPopupForm";
            this.Load += new System.EventHandler(this.CorporationPopupForm_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.rboUse, 0);
            this.Controls.SetChildIndex(this.rboNotUse, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txtSeq, 0);
            this.Controls.SetChildIndex(this.txtNote1, 0);
            this.Controls.SetChildIndex(this.txtNote2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dtpFirst, 0);
            this.Controls.SetChildIndex(this.dtpFinal, 0);
            this.Controls.SetChildIndex(this.txtFirst, 0);
            this.Controls.SetChildIndex(this.txtFinal, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.RadioButton rboUse;
        private System.Windows.Forms.RadioButton rboNotUse;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.TextBox txtNote1;
        private System.Windows.Forms.TextBox txtNote2;
        private System.Windows.Forms.DateTimePicker dtpFirst;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtFinal;
    }
}