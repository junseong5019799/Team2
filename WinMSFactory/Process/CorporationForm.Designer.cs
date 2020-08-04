namespace WinMSFactory
{
    partial class CorporationForm
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
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new WinMSFactory.ButtonControl();
            this.btnSelect = new WinMSFactory.ButtonControl();
            this.btnDelere = new WinMSFactory.ButtonControl();
            this.btnSave = new WinMSFactory.ButtonControl();
            this.lblCorporationid = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCorporationlist = new WinMSFactory.DataGridViewControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorporationlist)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnDelere);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtNameSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblCorporationid);
            this.panel1.Size = new System.Drawing.Size(1534, 142);
            this.panel1.Controls.SetChildIndex(this.lblCorporationid, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.txtNameSearch, 0);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            this.panel1.Controls.SetChildIndex(this.btnDelere, 0);
            this.panel1.Controls.SetChildIndex(this.btnSelect, 0);
            this.panel1.Controls.SetChildIndex(this.btnClear, 0);
            this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
            // 
            // GuidLabel2
            // 
            this.GuidLabel2.Size = new System.Drawing.Size(360, 16);
            this.GuidLabel2.Text = "DGV법인코드, 법인, 법인순번, 비고1, 비고2, 법인 사용여부, 최초 ,최종";
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(214, 73);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(151, 22);
            this.txtNameSearch.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "법인 명칭";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(1148, 73);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 23);
            this.btnClear.TabIndex = 37;
            this.btnClear.Text = "초기화";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.White;
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Location = new System.Drawing.Point(866, 73);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(57, 23);
            this.btnSelect.TabIndex = 36;
            this.btnSelect.Text = "조회";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnDelere
            // 
            this.btnDelere.BackColor = System.Drawing.Color.White;
            this.btnDelere.ForeColor = System.Drawing.Color.Black;
            this.btnDelere.Location = new System.Drawing.Point(1059, 73);
            this.btnDelere.Name = "btnDelere";
            this.btnDelere.Size = new System.Drawing.Size(46, 23);
            this.btnDelere.TabIndex = 35;
            this.btnDelere.Text = "삭제";
            this.btnDelere.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(966, 73);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "추가";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCorporationid
            // 
            this.lblCorporationid.AutoSize = true;
            this.lblCorporationid.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorporationid.Location = new System.Drawing.Point(72, 76);
            this.lblCorporationid.Name = "lblCorporationid";
            this.lblCorporationid.Size = new System.Drawing.Size(59, 15);
            this.lblCorporationid.TabIndex = 12;
            this.lblCorporationid.Text = "법인 코드";
            this.lblCorporationid.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCorporationlist);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1534, 619);
            this.panel2.TabIndex = 4;
            // 
            // dgvCorporationlist
            // 
            this.dgvCorporationlist.AllowUserToAddRows = false;
            this.dgvCorporationlist.BackgroundColor = System.Drawing.Color.White;
            this.dgvCorporationlist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCorporationlist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCorporationlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCorporationlist.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCorporationlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCorporationlist.IsAllCheckColumnHeader = false;
            this.dgvCorporationlist.IsAutoGenerateColumns = false;
            this.dgvCorporationlist.Location = new System.Drawing.Point(0, 0);
            this.dgvCorporationlist.MultiSelect = false;
            this.dgvCorporationlist.Name = "dgvCorporationlist";
            this.dgvCorporationlist.RowHeadersVisible = false;
            this.dgvCorporationlist.RowTemplate.Height = 23;
            this.dgvCorporationlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCorporationlist.Size = new System.Drawing.Size(1534, 619);
            this.dgvCorporationlist.TabIndex = 5;
            this.dgvCorporationlist.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCorporationlist_CellDoubleClick);
            // 
            // CorporationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "CorporationForm";
            this.Text = "법인관리";
            this.Load += new System.EventHandler(this.CorporationForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GuidLabel2, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorporationlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Label label2;
        private ButtonControl btnClear;
        private ButtonControl btnSelect;
        private ButtonControl btnDelere;
        private ButtonControl btnSave;
        private System.Windows.Forms.Label lblCorporationid;
        private System.Windows.Forms.Panel panel2;
        private DataGridViewControl dgvCorporationlist;
    }
}