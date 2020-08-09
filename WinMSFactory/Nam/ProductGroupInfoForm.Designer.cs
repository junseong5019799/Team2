namespace WinMSFactory
{
    partial class ProductGroupInfoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numSEQ = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNote2 = new System.Windows.Forms.TextBox();
            this.txtNote1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoUnUse = new System.Windows.Forms.RadioButton();
            this.rdoUse = new System.Windows.Forms.RadioButton();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSEQ)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Size = new System.Drawing.Size(688, 42);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numSEQ);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNote2);
            this.groupBox1.Controls.Add(this.txtNote1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 285);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // numSEQ
            // 
            this.numSEQ.Location = new System.Drawing.Point(523, 80);
            this.numSEQ.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numSEQ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSEQ.Name = "numSEQ";
            this.numSEQ.Size = new System.Drawing.Size(94, 24);
            this.numSEQ.TabIndex = 50;
            this.numSEQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSEQ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(547, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 18);
            this.label4.TabIndex = 49;
            this.label4.Text = "순번";
            // 
            // txtNote2
            // 
            this.txtNote2.Location = new System.Drawing.Point(154, 208);
            this.txtNote2.Multiline = true;
            this.txtNote2.Name = "txtNote2";
            this.txtNote2.Size = new System.Drawing.Size(432, 54);
            this.txtNote2.TabIndex = 46;
            // 
            // txtNote1
            // 
            this.txtNote1.Location = new System.Drawing.Point(154, 132);
            this.txtNote1.Multiline = true;
            this.txtNote1.Name = "txtNote1";
            this.txtNote1.Size = new System.Drawing.Size(432, 54);
            this.txtNote1.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 45;
            this.label6.Text = "비고 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 44;
            this.label5.Text = "비고 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rdoUnUse);
            this.groupBox2.Controls.Add(this.rdoUse);
            this.groupBox2.Location = new System.Drawing.Point(386, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 90);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "사용여부 지정";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(92, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoUnUse
            // 
            this.rdoUnUse.AutoSize = true;
            this.rdoUnUse.Location = new System.Drawing.Point(29, 56);
            this.rdoUnUse.Name = "rdoUnUse";
            this.rdoUnUse.Size = new System.Drawing.Size(65, 22);
            this.rdoUnUse.TabIndex = 28;
            this.rdoUnUse.TabStop = true;
            this.rdoUnUse.Text = "미사용";
            this.rdoUnUse.UseVisualStyleBackColor = true;
            this.rdoUnUse.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdoUse
            // 
            this.rdoUse.AutoSize = true;
            this.rdoUse.Location = new System.Drawing.Point(30, 19);
            this.rdoUse.Name = "rdoUse";
            this.rdoUse.Size = new System.Drawing.Size(52, 22);
            this.rdoUse.TabIndex = 27;
            this.rdoUse.Text = "사용";
            this.rdoUse.UseVisualStyleBackColor = true;
            this.rdoUse.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(154, 56);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(206, 24);
            this.txtProductName.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(103, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 29);
            this.label2.TabIndex = 29;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "제품 그룹명";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(587, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 29);
            this.label7.TabIndex = 48;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductGroupInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 346);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ProductGroupInfoForm";
            this.Text = "제품 그룹 등록";
            this.Load += new System.EventHandler(this.ProductGroupInfoForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSEQ)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoUnUse;
        private System.Windows.Forms.RadioButton rdoUse;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNote2;
        private System.Windows.Forms.TextBox txtNote1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSEQ;
        private System.Windows.Forms.Label label7;
    }
}