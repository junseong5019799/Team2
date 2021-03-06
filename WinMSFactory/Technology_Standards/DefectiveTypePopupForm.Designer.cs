﻿namespace WinMSFactory
{
    partial class DefectiveTypePopupForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoUnUse = new System.Windows.Forms.RadioButton();
            this.rdoUse = new System.Windows.Forms.RadioButton();
            this.txtDefectiveString = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 230);
            this.panel1.Size = new System.Drawing.Size(326, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightBlue;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Location = new System.Drawing.Point(28, 4);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(187, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "불량 명칭";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoUnUse);
            this.groupBox1.Controls.Add(this.rdoUse);
            this.groupBox1.Location = new System.Drawing.Point(28, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "사용여부";
            // 
            // rdoUnUse
            // 
            this.rdoUnUse.AutoSize = true;
            this.rdoUnUse.Location = new System.Drawing.Point(159, 30);
            this.rdoUnUse.Name = "rdoUnUse";
            this.rdoUnUse.Size = new System.Drawing.Size(59, 20);
            this.rdoUnUse.TabIndex = 0;
            this.rdoUnUse.TabStop = true;
            this.rdoUnUse.Text = "미사용";
            this.rdoUnUse.UseVisualStyleBackColor = true;
            // 
            // rdoUse
            // 
            this.rdoUse.AutoSize = true;
            this.rdoUse.Location = new System.Drawing.Point(72, 30);
            this.rdoUse.Name = "rdoUse";
            this.rdoUse.Size = new System.Drawing.Size(48, 20);
            this.rdoUse.TabIndex = 0;
            this.rdoUse.TabStop = true;
            this.rdoUse.Text = "사용";
            this.rdoUse.UseVisualStyleBackColor = true;
            // 
            // txtDefectiveString
            // 
            this.txtDefectiveString.Location = new System.Drawing.Point(100, 33);
            this.txtDefectiveString.Name = "txtDefectiveString";
            this.txtDefectiveString.Size = new System.Drawing.Size(146, 22);
            this.txtDefectiveString.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(100, 82);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "순번";
            // 
            // DefectiveTypePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 270);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.txtDefectiveString);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "DefectiveTypePopupForm";
            this.Text = "불량 타입 등록/ 변경";
            this.Load += new System.EventHandler(this.DefectiveTypePopupForm_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtDefectiveString, 0);
            this.Controls.SetChildIndex(this.numericUpDown1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoUnUse;
        private System.Windows.Forms.RadioButton rdoUse;
        private System.Windows.Forms.TextBox txtDefectiveString;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
    }
}