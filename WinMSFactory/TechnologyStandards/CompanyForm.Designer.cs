namespace WinMSFactory.Technology_Standards
{
    partial class CompanyForm
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
            this.btnClear = new WinMSFactory.ButtonControl();
            this.btnSelect = new WinMSFactory.ButtonControl();
            this.btnDelect = new WinMSFactory.ButtonControl();
            this.btnSave = new WinMSFactory.ButtonControl();
            this.cboCompany_Type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompany_Id = new System.Windows.Forms.TextBox();
            this.txtCompany_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCompanyList = new WinMSFactory.DataGridViewControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyList)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnDelect);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.cboCompany_Type);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCompany_Id);
            this.panel1.Controls.Add(this.txtCompany_Name);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Size = new System.Drawing.Size(1534, 160);
            this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.txtCompany_Name, 0);
            this.panel1.Controls.SetChildIndex(this.txtCompany_Id, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.cboCompany_Type, 0);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            this.panel1.Controls.SetChildIndex(this.btnDelect, 0);
            this.panel1.Controls.SetChildIndex(this.btnSelect, 0);
            this.panel1.Controls.SetChildIndex(this.btnClear, 0);
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.Location = new System.Drawing.Point(932, 40);
            // 
            // GuidLabel2
            // 
            this.GuidLabel2.Size = new System.Drawing.Size(422, 16);
            this.GuidLabel2.Text = "DGV 거래처리스트 거래처코드, 거래처유형, 거래처순번, 거래처사용여부, 최초 최종";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(890, 91);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 23);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "초기화";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.White;
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Location = new System.Drawing.Point(608, 91);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(57, 23);
            this.btnSelect.TabIndex = 32;
            this.btnSelect.Text = "조회";
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // btnDelect
            // 
            this.btnDelect.BackColor = System.Drawing.Color.White;
            this.btnDelect.ForeColor = System.Drawing.Color.Black;
            this.btnDelect.Location = new System.Drawing.Point(801, 91);
            this.btnDelect.Name = "btnDelect";
            this.btnDelect.Size = new System.Drawing.Size(46, 23);
            this.btnDelect.TabIndex = 31;
            this.btnDelect.Text = "삭제";
            this.btnDelect.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(708, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // cboCompany_Type
            // 
            this.cboCompany_Type.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompany_Type.FormattingEnabled = true;
            this.cboCompany_Type.Location = new System.Drawing.Point(134, 117);
            this.cboCompany_Type.Name = "cboCompany_Type";
            this.cboCompany_Type.Size = new System.Drawing.Size(151, 23);
            this.cboCompany_Type.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "거래처 유형";
            // 
            // txtCompany_Id
            // 
            this.txtCompany_Id.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany_Id.Location = new System.Drawing.Point(134, 57);
            this.txtCompany_Id.Name = "txtCompany_Id";
            this.txtCompany_Id.Size = new System.Drawing.Size(151, 22);
            this.txtCompany_Id.TabIndex = 26;
            // 
            // txtCompany_Name
            // 
            this.txtCompany_Name.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany_Name.Location = new System.Drawing.Point(416, 57);
            this.txtCompany_Name.Name = "txtCompany_Name";
            this.txtCompany_Name.Size = new System.Drawing.Size(151, 22);
            this.txtCompany_Name.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(344, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "거래처 명칭";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "거래처 코드";
            // 
            // dgvCompanyList
            // 
            this.dgvCompanyList.AllowUserToAddRows = false;
            this.dgvCompanyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompanyList.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompanyList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompanyList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCompanyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompanyList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCompanyList.Location = new System.Drawing.Point(0, 160);
            this.dgvCompanyList.MultiSelect = false;
            this.dgvCompanyList.Name = "dgvCompanyList";
            this.dgvCompanyList.RowTemplate.Height = 23;
            this.dgvCompanyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompanyList.Size = new System.Drawing.Size(1531, 577);
            this.dgvCompanyList.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCompanyList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1534, 761);
            this.panel2.TabIndex = 5;
            // 
            // CompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "CompanyForm";
            this.Text = "거래처관리";
            this.Load += new System.EventHandler(this.CompanyForm_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GuidLabel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonControl btnClear;
        private ButtonControl btnSelect;
        private ButtonControl btnDelect;
        private ButtonControl btnSave;
        private System.Windows.Forms.ComboBox cboCompany_Type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompany_Id;
        private System.Windows.Forms.TextBox txtCompany_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DataGridViewControl dgvCompanyList;
        private System.Windows.Forms.Panel panel2;
    }
}