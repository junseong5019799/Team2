namespace WinMSFactory
{
    partial class StorageForm
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
            this.buttonControl5 = new WinMSFactory.ButtonControl();
            this.buttonControl4 = new WinMSFactory.ButtonControl();
            this.buttonControl3 = new WinMSFactory.ButtonControl();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonControl2 = new WinMSFactory.ButtonControl();
            this.cboFactoryName = new System.Windows.Forms.ComboBox();
            this.dgv = new WinMSFactory.DataGridViewControl();
            this.cboCorporation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtStorage);
            this.panel1.Controls.Add(this.cboCorporation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboFactoryName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonControl2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonControl5);
            this.panel1.Controls.Add(this.buttonControl4);
            this.panel1.Controls.Add(this.buttonControl3);
            this.panel1.Size = new System.Drawing.Size(1753, 170);
            this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
            this.panel1.Controls.SetChildIndex(this.buttonControl3, 0);
            this.panel1.Controls.SetChildIndex(this.buttonControl4, 0);
            this.panel1.Controls.SetChildIndex(this.buttonControl5, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.buttonControl2, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.cboFactoryName, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.cboCorporation, 0);
            this.panel1.Controls.SetChildIndex(this.txtStorage, 0);
            // 
            // GuidLabel2
            // 
            this.GuidLabel2.Size = new System.Drawing.Size(515, 16);
            this.GuidLabel2.Text = "DGV 법인코드, 법인명칭, 공징코드 , 공장명칭, 창고코드, 창고명칭, 창고순번, 창고사용여부, 최초, 최종";
            // 
            // buttonControl5
            // 
            this.buttonControl5.BackColor = System.Drawing.Color.White;
            this.buttonControl5.ForeColor = System.Drawing.Color.Black;
            this.buttonControl5.Location = new System.Drawing.Point(1296, 96);
            this.buttonControl5.Name = "buttonControl5";
            this.buttonControl5.Size = new System.Drawing.Size(55, 23);
            this.buttonControl5.TabIndex = 27;
            this.buttonControl5.Text = "초기화";
            this.buttonControl5.UseVisualStyleBackColor = false;
            // 
            // buttonControl4
            // 
            this.buttonControl4.BackColor = System.Drawing.Color.White;
            this.buttonControl4.ForeColor = System.Drawing.Color.Black;
            this.buttonControl4.Location = new System.Drawing.Point(896, 96);
            this.buttonControl4.Name = "buttonControl4";
            this.buttonControl4.Size = new System.Drawing.Size(57, 23);
            this.buttonControl4.TabIndex = 26;
            this.buttonControl4.Text = "조회";
            this.buttonControl4.UseVisualStyleBackColor = false;
            this.buttonControl4.Click += new System.EventHandler(this.buttonControl4_Click);
            // 
            // buttonControl3
            // 
            this.buttonControl3.BackColor = System.Drawing.Color.White;
            this.buttonControl3.ForeColor = System.Drawing.Color.Black;
            this.buttonControl3.Location = new System.Drawing.Point(1167, 96);
            this.buttonControl3.Name = "buttonControl3";
            this.buttonControl3.Size = new System.Drawing.Size(46, 23);
            this.buttonControl3.TabIndex = 25;
            this.buttonControl3.Text = "삭제";
            this.buttonControl3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "공장 명칭";
            // 
            // buttonControl2
            // 
            this.buttonControl2.BackColor = System.Drawing.Color.White;
            this.buttonControl2.ForeColor = System.Drawing.Color.Black;
            this.buttonControl2.Location = new System.Drawing.Point(1036, 96);
            this.buttonControl2.Name = "buttonControl2";
            this.buttonControl2.Size = new System.Drawing.Size(48, 23);
            this.buttonControl2.TabIndex = 32;
            this.buttonControl2.Text = "저장";
            this.buttonControl2.UseVisualStyleBackColor = false;
            // 
            // cboFactoryName
            // 
            this.cboFactoryName.FormattingEnabled = true;
            this.cboFactoryName.Location = new System.Drawing.Point(408, 80);
            this.cboFactoryName.Name = "cboFactoryName";
            this.cboFactoryName.Size = new System.Drawing.Size(138, 24);
            this.cboFactoryName.TabIndex = 33;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.IsAllCheckColumnHeader = false;
            this.dgv.IsAutoGenerateColumns = false;
            this.dgv.Location = new System.Drawing.Point(0, 168);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1753, 846);
            this.dgv.TabIndex = 4;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // cboCorporation
            // 
            this.cboCorporation.FormattingEnabled = true;
            this.cboCorporation.Location = new System.Drawing.Point(163, 79);
            this.cboCorporation.Name = "cboCorporation";
            this.cboCorporation.Size = new System.Drawing.Size(138, 24);
            this.cboCorporation.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "법인 명칭";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(581, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "창고 명칭";
            // 
            // txtStorage
            // 
            this.txtStorage.Location = new System.Drawing.Point(653, 82);
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Size = new System.Drawing.Size(208, 22);
            this.txtStorage.TabIndex = 36;
            // 
            // StorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1753, 1015);
            this.Controls.Add(this.dgv);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "StorageForm";
            this.Text = "창고관리";
            this.Load += new System.EventHandler(this.StorageForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GuidLabel2, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonControl buttonControl5;
        private ButtonControl buttonControl4;
        private ButtonControl buttonControl3;
        private System.Windows.Forms.Label label1;
        private ButtonControl buttonControl2;
        private System.Windows.Forms.ComboBox cboFactoryName;
        private DataGridViewControl dgv;
        private System.Windows.Forms.ComboBox cboCorporation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStorage;
    }
}