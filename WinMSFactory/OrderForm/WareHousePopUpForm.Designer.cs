namespace WinMSFactory.OrderForm
{
    partial class WareHousePopUpForm
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
            this.lblseq = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpIN = new System.Windows.Forms.DateTimePicker();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStorage = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 365);
            this.panel1.Size = new System.Drawing.Size(826, 62);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.Location = new System.Drawing.Point(521, 3);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(655, 3);
            // 
            // lblseq
            // 
            this.lblseq.AutoSize = true;
            this.lblseq.Location = new System.Drawing.Point(56, 56);
            this.lblseq.Name = "lblseq";
            this.lblseq.Size = new System.Drawing.Size(62, 20);
            this.lblseq.TabIndex = 31;
            this.lblseq.Text = "주문 순서";
            this.lblseq.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "입고일";
            // 
            // dtpIN
            // 
            this.dtpIN.Location = new System.Drawing.Point(536, 170);
            this.dtpIN.Name = "dtpIN";
            this.dtpIN.Size = new System.Drawing.Size(216, 26);
            this.dtpIN.TabIndex = 29;
            // 
            // txtquantity
            // 
            this.txtquantity.Location = new System.Drawing.Point(536, 112);
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(95, 26);
            this.txtquantity.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "품목";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "입고량";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(143, 114);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(216, 26);
            this.txtOrderID.TabIndex = 19;
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(143, 171);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(216, 28);
            this.cboProduct.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "주문번호";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(461, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "창고";
            // 
            // cboStorage
            // 
            this.cboStorage.FormattingEnabled = true;
            this.cboStorage.Location = new System.Drawing.Point(536, 228);
            this.cboStorage.Name = "cboStorage";
            this.cboStorage.Size = new System.Drawing.Size(216, 28);
            this.cboStorage.TabIndex = 32;
            // 
            // WareHousePopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 427);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboStorage);
            this.Controls.Add(this.lblseq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpIN);
            this.Controls.Add(this.txtquantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "WareHousePopUpForm";
            this.Text = "입고 처리";
            this.Load += new System.EventHandler(this.WareHousePopUpForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboProduct, 0);
            this.Controls.SetChildIndex(this.txtOrderID, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtquantity, 0);
            this.Controls.SetChildIndex(this.dtpIN, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblseq, 0);
            this.Controls.SetChildIndex(this.cboStorage, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblseq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpIN;
        private System.Windows.Forms.TextBox txtquantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStorage;
    }
}