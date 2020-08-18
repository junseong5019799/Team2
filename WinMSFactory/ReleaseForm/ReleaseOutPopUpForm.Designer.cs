namespace WinMSFactory.ReleaseForm
{
    partial class ReleaseOutPopUpForm
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
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpOut = new System.Windows.Forms.DateTimePicker();
            this.lblPlanID = new System.Windows.Forms.Label();
            this.lblSeq = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 267);
            this.panel1.Size = new System.Drawing.Size(353, 42);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightBlue;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Location = new System.Drawing.Point(139, 3);
            this.btnConfirm.Size = new System.Drawing.Size(87, 27);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(232, 3);
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "거래처";
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(127, 89);
            this.cboProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(192, 24);
            this.cboProduct.TabIndex = 2;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(127, 38);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(192, 22);
            this.txtCompany.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "출고수량";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "품목";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(127, 193);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(85, 22);
            this.txtQuantity.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "출고일";
            // 
            // dtpOut
            // 
            this.dtpOut.Location = new System.Drawing.Point(127, 142);
            this.dtpOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpOut.Name = "dtpOut";
            this.dtpOut.Size = new System.Drawing.Size(192, 22);
            this.dtpOut.TabIndex = 14;
            // 
            // lblPlanID
            // 
            this.lblPlanID.AutoSize = true;
            this.lblPlanID.Location = new System.Drawing.Point(12, 9);
            this.lblPlanID.Name = "lblPlanID";
            this.lblPlanID.Size = new System.Drawing.Size(21, 16);
            this.lblPlanID.TabIndex = 16;
            this.lblPlanID.Text = "ID";
            this.lblPlanID.Visible = false;
            // 
            // lblSeq
            // 
            this.lblSeq.AutoSize = true;
            this.lblSeq.Location = new System.Drawing.Point(39, 9);
            this.lblSeq.Name = "lblSeq";
            this.lblSeq.Size = new System.Drawing.Size(36, 16);
            this.lblSeq.TabIndex = 17;
            this.lblSeq.Text = "SEQ";
            this.lblSeq.Visible = false;
            // 
            // ReleaseOutPopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 309);
            this.Controls.Add(this.lblSeq);
            this.Controls.Add(this.lblPlanID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpOut);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.label1);
            this.Name = "ReleaseOutPopUpForm";
            this.Text = "출고 등록";
            this.Load += new System.EventHandler(this.ReleaseExcelPopUpForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboProduct, 0);
            this.Controls.SetChildIndex(this.txtCompany, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtQuantity, 0);
            this.Controls.SetChildIndex(this.dtpOut, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblPlanID, 0);
            this.Controls.SetChildIndex(this.lblSeq, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpOut;
        private System.Windows.Forms.Label lblPlanID;
        private System.Windows.Forms.Label lblSeq;
    }
}