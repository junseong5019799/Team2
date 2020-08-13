namespace WinMSFactory
{
    partial class CompanyProductPopupForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompany_Id = new System.Windows.Forms.TextBox();
            this.txtCompany_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new WinMSFactory.ButtonControl();
            this.btnProductAdd = new WinMSFactory.ButtonControl();
            this.listBoxProduct = new System.Windows.Forms.ListBox();
            this.cboCompany_Product = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboCompany_Type = new System.Windows.Forms.ComboBox();
            this.nudCompany_seq = new WinMSFactory.NumericControl();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompany_seq)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 326);
            this.panel1.Size = new System.Drawing.Size(432, 43);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.Location = new System.Drawing.Point(84, 4);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 4);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "거래처 품목";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "거래처 유형";
            // 
            // txtCompany_Id
            // 
            this.txtCompany_Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany_Id.Location = new System.Drawing.Point(145, 3);
            this.txtCompany_Id.Name = "txtCompany_Id";
            this.txtCompany_Id.Size = new System.Drawing.Size(151, 22);
            this.txtCompany_Id.TabIndex = 47;
            this.txtCompany_Id.Visible = false;
            // 
            // txtCompany_Name
            // 
            this.txtCompany_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany_Name.Location = new System.Drawing.Point(145, 40);
            this.txtCompany_Name.Name = "txtCompany_Name";
            this.txtCompany_Name.Size = new System.Drawing.Size(151, 22);
            this.txtCompany_Name.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "거래처 명칭";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "거래처 코드";
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnProductAdd);
            this.groupBox1.Controls.Add(this.listBoxProduct);
            this.groupBox1.Controls.Add(this.cboCompany_Product);
            this.groupBox1.Location = new System.Drawing.Point(135, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 117);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(176, 43);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(54, 25);
            this.btnDelete.TabIndex = 57;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnProductAdd
            // 
            this.btnProductAdd.BackColor = System.Drawing.Color.White;
            this.btnProductAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductAdd.ForeColor = System.Drawing.Color.Black;
            this.btnProductAdd.Location = new System.Drawing.Point(176, 12);
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.Size = new System.Drawing.Size(54, 25);
            this.btnProductAdd.TabIndex = 56;
            this.btnProductAdd.Text = "추가";
            this.btnProductAdd.UseVisualStyleBackColor = false;
            this.btnProductAdd.Click += new System.EventHandler(this.btnProductAdd_Click);
            // 
            // listBoxProduct
            // 
            this.listBoxProduct.FormattingEnabled = true;
            this.listBoxProduct.ItemHeight = 16;
            this.listBoxProduct.Location = new System.Drawing.Point(9, 43);
            this.listBoxProduct.Name = "listBoxProduct";
            this.listBoxProduct.Size = new System.Drawing.Size(151, 68);
            this.listBoxProduct.TabIndex = 55;
            // 
            // cboCompany_Product
            // 
            this.cboCompany_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompany_Product.FormattingEnabled = true;
            this.cboCompany_Product.Location = new System.Drawing.Point(9, 12);
            this.cboCompany_Product.Name = "cboCompany_Product";
            this.cboCompany_Product.Size = new System.Drawing.Size(151, 24);
            this.cboCompany_Product.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(59, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 64;
            this.label9.Text = "거래처 순번";
            // 
            // cboCompany_Type
            // 
            this.cboCompany_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompany_Type.FormattingEnabled = true;
            this.cboCompany_Type.Location = new System.Drawing.Point(145, 85);
            this.cboCompany_Type.Name = "cboCompany_Type";
            this.cboCompany_Type.Size = new System.Drawing.Size(151, 24);
            this.cboCompany_Type.TabIndex = 49;
            this.cboCompany_Type.SelectedIndexChanged += new System.EventHandler(this.cboCompany_Type_SelectedIndexChanged);
            // 
            // nudCompany_seq
            // 
            this.nudCompany_seq.BackColor = System.Drawing.Color.White;
            this.nudCompany_seq.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudCompany_seq.Location = new System.Drawing.Point(145, 134);
            this.nudCompany_seq.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCompany_seq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCompany_seq.Name = "nudCompany_seq";
            this.nudCompany_seq.Size = new System.Drawing.Size(63, 22);
            this.nudCompany_seq.TabIndex = 65;
            this.nudCompany_seq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCompany_seq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CompanyProductPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 369);
            this.Controls.Add(this.nudCompany_seq);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCompany_Type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompany_Id);
            this.Controls.Add(this.txtCompany_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "CompanyProductPopupForm";
            this.Text = "CompanyProductPOPForm";
            this.Load += new System.EventHandler(this.CompanyProductPopupForm_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCompany_Name, 0);
            this.Controls.SetChildIndex(this.txtCompany_Id, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboCompany_Type, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.nudCompany_seq, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCompany_seq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompany_Id;
        private System.Windows.Forms.TextBox txtCompany_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ButtonControl btnProductAdd;
        private System.Windows.Forms.ListBox listBoxProduct;
        private System.Windows.Forms.ComboBox cboCompany_Product;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboCompany_Type;
        private ButtonControl btnDelete;
        private NumericControl nudCompany_seq;
    }
}