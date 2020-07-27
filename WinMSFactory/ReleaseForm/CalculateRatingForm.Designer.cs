namespace WinMSFactory
{
    partial class CalculateRatingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new WinMSFactory.DataGridViewControl();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fromToDateControl1 = new WinMSFactory.Control.FromToDateControl();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fromToDateControl2 = new WinMSFactory.Control.FromToDateControl();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCalculate = new WinMSFactory.ButtonControl();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPlanID = new System.Windows.Forms.ComboBox();
            this.btnSearch = new WinMSFactory.ButtonControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboPlanID);
            this.panel1.Controls.Add(this.btnCalculate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Size = new System.Drawing.Size(1364, 170);
            this.panel1.Controls.SetChildIndex(this.label9, 0);
            this.panel1.Controls.SetChildIndex(this.label7, 0);
            this.panel1.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.Controls.SetChildIndex(this.btnCalculate, 0);
            this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
            this.panel1.Controls.SetChildIndex(this.cboPlanID, 0);
            this.panel1.Controls.SetChildIndex(this.label6, 0);
            this.panel1.Controls.SetChildIndex(this.btnSearch, 0);
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.Location = new System.Drawing.Point(811, 57);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Location = new System.Drawing.Point(0, 170);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1364, 591);
            this.dgv.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "작업일자";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(154, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "출고 계획 번호";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(441, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 21);
            this.textBox2.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "품목";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.fromToDateControl1);
            this.panel3.Location = new System.Drawing.Point(149, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 33);
            this.panel3.TabIndex = 27;
            // 
            // fromToDateControl1
            // 
            this.fromToDateControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromToDateControl1.From = new System.DateTime(2020, 7, 26, 13, 2, 38, 720);
            this.fromToDateControl1.Location = new System.Drawing.Point(0, 0);
            this.fromToDateControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.fromToDateControl1.Name = "fromToDateControl1";
            this.fromToDateControl1.Size = new System.Drawing.Size(230, 33);
            this.fromToDateControl1.TabIndex = 17;
            this.fromToDateControl1.To = new System.DateTime(2020, 7, 27, 13, 2, 38, 720);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "자재 소요 계획";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fromToDateControl2);
            this.panel2.Location = new System.Drawing.Point(168, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 33);
            this.panel2.TabIndex = 29;
            // 
            // fromToDateControl2
            // 
            this.fromToDateControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromToDateControl2.From = new System.DateTime(2020, 7, 26, 13, 50, 26, 790);
            this.fromToDateControl2.Location = new System.Drawing.Point(0, 0);
            this.fromToDateControl2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.fromToDateControl2.Name = "fromToDateControl2";
            this.fromToDateControl2.Size = new System.Drawing.Size(230, 33);
            this.fromToDateControl2.TabIndex = 17;
            this.fromToDateControl2.To = new System.DateTime(2020, 7, 27, 13, 50, 26, 790);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "출고계획 번호";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(100, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "작업일자";
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.White;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.ForeColor = System.Drawing.Color.Black;
            this.btnCalculate.Location = new System.Drawing.Point(814, 124);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(88, 26);
            this.btnCalculate.TabIndex = 32;
            this.btnCalculate.Text = "발주";
            this.btnCalculate.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "출고 계획 번호 : 기생성된 수요 계획 PlanID 리스트 ";
            // 
            // cboPlanID
            // 
            this.cboPlanID.FormattingEnabled = true;
            this.cboPlanID.Location = new System.Drawing.Point(173, 100);
            this.cboPlanID.Name = "cboPlanID";
            this.cboPlanID.Size = new System.Drawing.Size(121, 24);
            this.cboPlanID.TabIndex = 33;
            this.cboPlanID.SelectedIndexChanged += new System.EventHandler(this.cboPlanID_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(452, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "찾기";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // CalculateRatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 761);
            this.Controls.Add(this.dgv);
            this.Name = "CalculateRatingForm";
            this.Text = "수요 계획";
            this.Load += new System.EventHandler(this.CalculateRatingForm_Load);
            this.Controls.SetChildIndex(this.GuidLabel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridViewControl dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private Control.FromToDateControl fromToDateControl1;
        private System.Windows.Forms.Panel panel2;
        private Control.FromToDateControl fromToDateControl2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private ButtonControl btnCalculate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPlanID;
        private ButtonControl btnSearch;
    }
}