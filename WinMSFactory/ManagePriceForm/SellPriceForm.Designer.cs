namespace WinMSFactory.ManagePriceForm
{
    partial class SellPriceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewControl1 = new WinMSFactory.DataGridViewControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.fromToDateControl1 = new WinMSFactory.Control.FromToDateControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Size = new System.Drawing.Size(1364, 170);
            this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
            this.panel1.Controls.SetChildIndex(this.panel4, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.comboBox1, 0);
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.Location = new System.Drawing.Point(999, 73);
            // 
            // dataGridViewControl1
            // 
            this.dataGridViewControl1.AllowUserToAddRows = false;
            this.dataGridViewControl1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewControl1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewControl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewControl1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewControl1.Location = new System.Drawing.Point(0, 170);
            this.dataGridViewControl1.MultiSelect = false;
            this.dataGridViewControl1.Name = "dataGridViewControl1";
            this.dataGridViewControl1.RowTemplate.Height = 23;
            this.dataGridViewControl1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewControl1.Size = new System.Drawing.Size(1364, 591);
            this.dataGridViewControl1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(175, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 24);
            this.comboBox1.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "품목";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "기준 일자";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.fromToDateControl1);
            this.panel4.Location = new System.Drawing.Point(171, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 33);
            this.panel4.TabIndex = 54;
            // 
            // fromToDateControl1
            // 
            this.fromToDateControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromToDateControl1.Location = new System.Drawing.Point(0, 0);
            this.fromToDateControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.fromToDateControl1.Name = "fromToDateControl1";
            this.fromToDateControl1.Size = new System.Drawing.Size(230, 33);
            this.fromToDateControl1.TabIndex = 17;
            // 
            // SellPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 761);
            this.Controls.Add(this.dataGridViewControl1);
            this.Name = "SellPriceForm";
            this.Text = "영업 단가 관리";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GuidLabel2, 0);
            this.Controls.SetChildIndex(this.dataGridViewControl1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewControl dataGridViewControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private Control.FromToDateControl fromToDateControl1;
    }
}