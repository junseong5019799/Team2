namespace WinMSFactory
{
    partial class frmMItem
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMItem));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new WinMSFactory.ButtonControl();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdoUnUse = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoUse = new System.Windows.Forms.RadioButton();
            this.btnEnroll = new WinMSFactory.ButtonControl();
            this.btn_Delete = new WinMSFactory.ButtonControl();
            this.dgv = new WinMSFactory.DataGridViewControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnBomShow = new WinMSFactory.ButtonControl();
            this.btnBOMCopy = new WinMSFactory.ButtonControl();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnBOMCopy);
            this.panel1.Controls.Add(this.btnBomShow);
            this.panel1.Controls.Add(this.btn_Delete);
            this.panel1.Controls.Add(this.btnEnroll);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Size = new System.Drawing.Size(1534, 179);
            this.panel1.Controls.SetChildIndex(this.GuidLabel1, 0);
            this.panel1.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.Controls.SetChildIndex(this.btnEnroll, 0);
            this.panel1.Controls.SetChildIndex(this.btn_Delete, 0);
            this.panel1.Controls.SetChildIndex(this.btnBomShow, 0);
            this.panel1.Controls.SetChildIndex(this.btnBOMCopy, 0);
            this.panel1.Controls.SetChildIndex(this.pictureBox1, 0);
            this.panel1.Controls.SetChildIndex(this.pictureBox2, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.cboProductType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtProductSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(75, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(967, 127);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색 조건";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.Location = new System.Drawing.Point(870, 89);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 31;
            this.btnConfirm.Text = "검색";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.buttonControl2_Click);
            // 
            // cboProductType
            // 
            this.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(405, 56);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(172, 24);
            this.cboProductType.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(629, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "사용 여부";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "제품 그룹명";
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Location = new System.Drawing.Point(120, 58);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.Size = new System.Drawing.Size(169, 22);
            this.txtProductSearch.TabIndex = 29;
            this.txtProductSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductSearch_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "제품명";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rdoUnUse);
            this.panel5.Controls.Add(this.rdoAll);
            this.panel5.Controls.Add(this.rdoUse);
            this.panel5.Location = new System.Drawing.Point(713, 54);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(176, 33);
            this.panel5.TabIndex = 27;
            // 
            // rdoUnUse
            // 
            this.rdoUnUse.AutoSize = true;
            this.rdoUnUse.Location = new System.Drawing.Point(128, 8);
            this.rdoUnUse.Name = "rdoUnUse";
            this.rdoUnUse.Size = new System.Drawing.Size(44, 20);
            this.rdoUnUse.TabIndex = 20;
            this.rdoUnUse.TabStop = true;
            this.rdoUnUse.Text = "No";
            this.rdoUnUse.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(5, 7);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(41, 20);
            this.rdoAll.TabIndex = 21;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoUse
            // 
            this.rdoUse.AutoSize = true;
            this.rdoUse.Location = new System.Drawing.Point(62, 8);
            this.rdoUse.Name = "rdoUse";
            this.rdoUse.Size = new System.Drawing.Size(50, 20);
            this.rdoUse.TabIndex = 21;
            this.rdoUse.TabStop = true;
            this.rdoUse.Text = "Yes";
            this.rdoUse.UseVisualStyleBackColor = true;
            // 
            // btnEnroll
            // 
            this.btnEnroll.BackColor = System.Drawing.Color.White;
            this.btnEnroll.ForeColor = System.Drawing.Color.Black;
            this.btnEnroll.Location = new System.Drawing.Point(1066, 69);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(126, 43);
            this.btnEnroll.TabIndex = 6;
            this.btnEnroll.Text = "제품 등록";
            this.btnEnroll.UseVisualStyleBackColor = false;
            this.btnEnroll.Click += new System.EventHandler(this.buttonControl1_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.White;
            this.btn_Delete.ForeColor = System.Drawing.Color.Black;
            this.btn_Delete.Location = new System.Drawing.Point(1198, 69);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(144, 43);
            this.btn_Delete.TabIndex = 6;
            this.btn_Delete.Text = "제품 삭제";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
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
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.IsAllCheckColumnHeader = false;
            this.dgv.IsAutoGenerateColumns = false;
            this.dgv.Location = new System.Drawing.Point(0, 179);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1534, 582);
            this.dgv.TabIndex = 4;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(1008, 156);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "이 제품이 만들어지는 시간");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(1104, 156);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 17);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "발주할 원재료가 오는 시간");
            // 
            // btnBomShow
            // 
            this.btnBomShow.BackColor = System.Drawing.Color.White;
            this.btnBomShow.ForeColor = System.Drawing.Color.Black;
            this.btnBomShow.Location = new System.Drawing.Point(1377, 48);
            this.btnBomShow.Name = "btnBomShow";
            this.btnBomShow.Size = new System.Drawing.Size(135, 43);
            this.btnBomShow.TabIndex = 6;
            this.btnBomShow.Text = "BOM 확인";
            this.btnBomShow.UseVisualStyleBackColor = false;
            this.btnBomShow.Click += new System.EventHandler(this.buttonControl2_Click_1);
            // 
            // btnBOMCopy
            // 
            this.btnBOMCopy.BackColor = System.Drawing.Color.White;
            this.btnBOMCopy.ForeColor = System.Drawing.Color.Black;
            this.btnBOMCopy.Location = new System.Drawing.Point(1377, 112);
            this.btnBOMCopy.Name = "btnBOMCopy";
            this.btnBOMCopy.Size = new System.Drawing.Size(135, 43);
            this.btnBOMCopy.TabIndex = 6;
            this.btnBOMCopy.Text = "BOM 복사";
            this.btnBOMCopy.UseVisualStyleBackColor = false;
            this.btnBOMCopy.Click += new System.EventHandler(this.btnBOMCopy_Click);
            // 
            // frmMItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.dgv);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmMItem";
            this.Text = "제품 관리";
            this.Load += new System.EventHandler(this.frmMItem_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GuidLabel2, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rdoUnUse;
        private System.Windows.Forms.RadioButton rdoUse;
        private System.Windows.Forms.TextBox txtProductSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.Label label2;
        private ButtonControl btnEnroll;
        private ButtonControl btn_Delete;
        private ButtonControl btnConfirm;
        private System.Windows.Forms.RadioButton rdoAll;
        private DataGridViewControl dgv;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private ButtonControl btnBomShow;
        private ButtonControl btnBOMCopy;
    }
}
