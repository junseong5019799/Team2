namespace WinMSFactory.ResultForm
{
    partial class ResultListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblStorageID = new System.Windows.Forms.Label();
            this.dgv = new WinMSFactory.DataGridViewControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStorage = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboStorage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 194);
            this.panel1.Size = new System.Drawing.Size(613, 46);
            this.panel1.Controls.SetChildIndex(this.btnCancel, 0);
            this.panel1.Controls.SetChildIndex(this.btnConfirm, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.cboStorage, 0);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.Location = new System.Drawing.Point(345, 3);
            this.btnConfirm.Size = new System.Drawing.Size(102, 31);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(464, 3);
            this.btnCancel.Size = new System.Drawing.Size(102, 31);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStorageID
            // 
            this.lblStorageID.AutoSize = true;
            this.lblStorageID.Location = new System.Drawing.Point(580, 170);
            this.lblStorageID.Name = "lblStorageID";
            this.lblStorageID.Size = new System.Drawing.Size(21, 16);
            this.lblStorageID.TabIndex = 31;
            this.lblStorageID.Text = "ID";
            this.lblStorageID.Visible = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.IsAllCheckColumnHeader = false;
            this.dgv.IsAutoGenerateColumns = false;
            this.dgv.Location = new System.Drawing.Point(13, 13);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(588, 138);
            this.dgv.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "이동 할 창고";
            // 
            // cboStorage
            // 
            this.cboStorage.FormattingEnabled = true;
            this.cboStorage.Location = new System.Drawing.Point(126, 0);
            this.cboStorage.Name = "cboStorage";
            this.cboStorage.Size = new System.Drawing.Size(121, 24);
            this.cboStorage.TabIndex = 34;
            // 
            // ResultListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 240);
            this.Controls.Add(this.lblStorageID);
            this.Controls.Add(this.dgv);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "ResultListForm";
            this.Text = "재고 이동";
            this.Load += new System.EventHandler(this.ResultListForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.lblStorageID, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStorageID;
        private DataGridViewControl dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStorage;
    }
}