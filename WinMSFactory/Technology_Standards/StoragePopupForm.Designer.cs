﻿namespace WinMSFactory
{
    partial class StoragePopupForm
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
            this.cboCorporation = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoUnUse = new System.Windows.Forms.RadioButton();
            this.rdoUse = new System.Windows.Forms.RadioButton();
            this.cboFactory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.nudStorage_seq = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStorage_seq)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 361);
            this.panel1.Size = new System.Drawing.Size(327, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightBlue;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Location = new System.Drawing.Point(29, 4);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(191, 4);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboCorporation
            // 
            this.cboCorporation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCorporation.FormattingEnabled = true;
            this.cboCorporation.Location = new System.Drawing.Point(112, 52);
            this.cboCorporation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCorporation.Name = "cboCorporation";
            this.cboCorporation.Size = new System.Drawing.Size(151, 24);
            this.cboCorporation.TabIndex = 11;
            this.cboCorporation.SelectedIndexChanged += new System.EventHandler(this.cboCorporation_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoUnUse);
            this.groupBox1.Controls.Add(this.rdoUse);
            this.groupBox1.Location = new System.Drawing.Point(46, 245);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(241, 73);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "사용 여부";
            // 
            // rdoUnUse
            // 
            this.rdoUnUse.AutoSize = true;
            this.rdoUnUse.Location = new System.Drawing.Point(158, 32);
            this.rdoUnUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.rdoUse.Location = new System.Drawing.Point(57, 32);
            this.rdoUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoUse.Name = "rdoUse";
            this.rdoUse.Size = new System.Drawing.Size(48, 20);
            this.rdoUse.TabIndex = 0;
            this.rdoUse.TabStop = true;
            this.rdoUse.Text = "사용";
            this.rdoUse.UseVisualStyleBackColor = true;
            // 
            // cboFactory
            // 
            this.cboFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFactory.FormattingEnabled = true;
            this.cboFactory.Location = new System.Drawing.Point(112, 100);
            this.cboFactory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboFactory.Name = "cboFactory";
            this.cboFactory.Size = new System.Drawing.Size(151, 24);
            this.cboFactory.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "창고명칭";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "공장 명칭";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "법인명";
            // 
            // txtStorage
            // 
            this.txtStorage.Location = new System.Drawing.Point(112, 148);
            this.txtStorage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Size = new System.Drawing.Size(151, 22);
            this.txtStorage.TabIndex = 5;
            // 
            // nudStorage_seq
            // 
            this.nudStorage_seq.Location = new System.Drawing.Point(112, 197);
            this.nudStorage_seq.Name = "nudStorage_seq";
            this.nudStorage_seq.Size = new System.Drawing.Size(77, 22);
            this.nudStorage_seq.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "순번";
            // 
            // StoragePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 401);
            this.Controls.Add(this.nudStorage_seq);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCorporation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboFactory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStorage);
            this.Name = "StoragePopupForm";
            this.Text = "창고  등록/ 변경";
            this.Load += new System.EventHandler(this.StoragePopupForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.txtStorage, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboFactory, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cboCorporation, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.nudStorage_seq, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStorage_seq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCorporation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoUnUse;
        private System.Windows.Forms.RadioButton rdoUse;
        private System.Windows.Forms.ComboBox cboFactory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStorage;
        private System.Windows.Forms.NumericUpDown nudStorage_seq;
        private System.Windows.Forms.Label label4;
    }
}