namespace WinMSFactory
{
    partial class BOMSelectAllForm
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
            this.dgv = new WinMSFactory.DataGridViewControl();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSelect = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDelete = new WinMSFactory.ButtonControl();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSelectType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSelectName = new System.Windows.Forms.ComboBox();
            this.buttonControl2 = new WinMSFactory.ButtonControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonControl2);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.cboSelectName);
            this.panel2.Controls.Add(this.cboSelectType);
            this.panel2.Controls.Add(this.cboSelect);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Size = new System.Drawing.Size(1326, 80);
            this.panel2.Controls.SetChildIndex(this.label12, 0);
            this.panel2.Controls.SetChildIndex(this.label2, 0);
            this.panel2.Controls.SetChildIndex(this.label3, 0);
            this.panel2.Controls.SetChildIndex(this.cboSelect, 0);
            this.panel2.Controls.SetChildIndex(this.cboSelectType, 0);
            this.panel2.Controls.SetChildIndex(this.cboSelectName, 0);
            this.panel2.Controls.SetChildIndex(this.btnDelete, 0);
            this.panel2.Controls.SetChildIndex(this.GuidLabel1, 0);
            this.panel2.Controls.SetChildIndex(this.buttonControl2, 0);
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.Location = new System.Drawing.Point(12, 9);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.IsAllCheckColumnHeader = false;
            this.dgv.IsAutoGenerateColumns = false;
            this.dgv.Location = new System.Drawing.Point(0, 87);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 45;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1326, 603);
            this.dgv.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 542);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "제품 목록에는 완제품, 반제품, 재료 모두 보여줌";
            this.label4.Visible = false;
            // 
            // cboSelect
            // 
            this.cboSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelect.FormattingEnabled = true;
            this.cboSelect.Location = new System.Drawing.Point(217, 34);
            this.cboSelect.Name = "cboSelect";
            this.cboSelect.Size = new System.Drawing.Size(121, 20);
            this.cboSelect.TabIndex = 37;
            this.cboSelect.SelectedIndexChanged += new System.EventHandler(this.cboSelect_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(87, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 12);
            this.label12.TabIndex = 36;
            this.label12.Text = "정전개/ 역전개 선택";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(1046, 27);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(136, 33);
            this.btnDelete.TabIndex = 39;
            this.btnDelete.Text = "품목 전체 BOM 삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.buttonControl2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "품목 타입";
            // 
            // cboSelectType
            // 
            this.cboSelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectType.FormattingEnabled = true;
            this.cboSelectType.Location = new System.Drawing.Point(456, 34);
            this.cboSelectType.Name = "cboSelectType";
            this.cboSelectType.Size = new System.Drawing.Size(122, 20);
            this.cboSelectType.TabIndex = 37;
            this.cboSelectType.SelectedIndexChanged += new System.EventHandler(this.cboSelectType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "품목 이름";
            // 
            // cboSelectName
            // 
            this.cboSelectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectName.FormattingEnabled = true;
            this.cboSelectName.Location = new System.Drawing.Point(676, 34);
            this.cboSelectName.Name = "cboSelectName";
            this.cboSelectName.Size = new System.Drawing.Size(344, 20);
            this.cboSelectName.TabIndex = 37;
            // 
            // buttonControl2
            // 
            this.buttonControl2.BackColor = System.Drawing.Color.White;
            this.buttonControl2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonControl2.ForeColor = System.Drawing.Color.Black;
            this.buttonControl2.Location = new System.Drawing.Point(1195, 27);
            this.buttonControl2.Name = "buttonControl2";
            this.buttonControl2.Size = new System.Drawing.Size(109, 33);
            this.buttonControl2.TabIndex = 40;
            this.buttonControl2.Text = "부분 BOM 삭제";
            this.buttonControl2.UseVisualStyleBackColor = false;
            this.buttonControl2.Click += new System.EventHandler(this.buttonControl2_Click_1);
            // 
            // BOMSelectAllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 690);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv);
            this.Name = "BOMSelectAllForm";
            this.Text = "BOM 정전개 / 역전개";
            this.Load += new System.EventHandler(this.BOMSelectAllForm_Load);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewControl dgv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSelect;
        private System.Windows.Forms.Label label12;
        private ButtonControl btnDelete;
        private System.Windows.Forms.ComboBox cboSelectName;
        private System.Windows.Forms.ComboBox cboSelectType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ButtonControl buttonControl2;
    }
}