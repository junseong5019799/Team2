namespace WinMSFactory
{
    partial class ProcessWorkerPopupForm
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
            this.cboProcessName = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboLineName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCorporationName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFactoryName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 217);
            this.panel1.Size = new System.Drawing.Size(337, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.Location = new System.Drawing.Point(35, 3);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(203, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboProcessName
            // 
            this.cboProcessName.FormattingEnabled = true;
            this.cboProcessName.Location = new System.Drawing.Point(137, 136);
            this.cboProcessName.Name = "cboProcessName";
            this.cboProcessName.Size = new System.Drawing.Size(147, 24);
            this.cboProcessName.TabIndex = 84;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(137, 173);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(147, 22);
            this.txtName.TabIndex = 82;
            this.txtName.Tag = "권한그룹 명칭을 입력해주세요.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 83;
            this.label9.Text = "작업자 명";
            // 
            // cboLineName
            // 
            this.cboLineName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineName.FormattingEnabled = true;
            this.cboLineName.Location = new System.Drawing.Point(137, 103);
            this.cboLineName.Name = "cboLineName";
            this.cboLineName.Size = new System.Drawing.Size(147, 24);
            this.cboLineName.TabIndex = 81;
            this.cboLineName.SelectedIndexChanged += new System.EventHandler(this.cboLineName_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 80;
            this.label8.Text = "공정 명칭";
            // 
            // cboCorporationName
            // 
            this.cboCorporationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCorporationName.FormattingEnabled = true;
            this.cboCorporationName.Location = new System.Drawing.Point(137, 31);
            this.cboCorporationName.Name = "cboCorporationName";
            this.cboCorporationName.Size = new System.Drawing.Size(147, 24);
            this.cboCorporationName.TabIndex = 79;
            this.cboCorporationName.SelectedIndexChanged += new System.EventHandler(this.cboCorporationName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 78;
            this.label7.Text = "법인 명칭";
            // 
            // cboFactoryName
            // 
            this.cboFactoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFactoryName.FormattingEnabled = true;
            this.cboFactoryName.Location = new System.Drawing.Point(137, 67);
            this.cboFactoryName.Name = "cboFactoryName";
            this.cboFactoryName.Size = new System.Drawing.Size(147, 24);
            this.cboFactoryName.TabIndex = 77;
            this.cboFactoryName.SelectedIndexChanged += new System.EventHandler(this.cboFactoryName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 76;
            this.label1.Text = "공장 명칭";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 75;
            this.label4.Text = "라인 명칭";
            // 
            // ProcessWorkerPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 257);
            this.Controls.Add(this.cboProcessName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboLineName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboCorporationName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboFactoryName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "ProcessWorkerPopupForm";
            this.Text = "ProcessWorkerPopupForm";
            this.Load += new System.EventHandler(this.ProcessWorkerPopupForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboFactoryName, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cboCorporationName, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cboLineName, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.cboProcessName, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProcessName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboLineName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCorporationName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFactoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}