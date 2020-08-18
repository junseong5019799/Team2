namespace WinMSFactory
{
    partial class ListForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.GuidLabel1 = new System.Windows.Forms.Label();
            this.GuidLabel2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.separatorControl1);
            this.panel1.Controls.Add(this.GuidLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1534, 170);
            this.panel1.TabIndex = 1;
            // 
            // separatorControl1
            // 
            this.separatorControl1.BackColor = System.Drawing.Color.LightBlue;
            this.separatorControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separatorControl1.Location = new System.Drawing.Point(0, 163);
            this.separatorControl1.Margin = new System.Windows.Forms.Padding(4);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Padding = new System.Windows.Forms.Padding(11);
            this.separatorControl1.Size = new System.Drawing.Size(1534, 7);
            this.separatorControl1.TabIndex = 5;
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.AutoSize = true;
            this.GuidLabel1.Location = new System.Drawing.Point(72, 33);
            this.GuidLabel1.Name = "GuidLabel1";
            this.GuidLabel1.Size = new System.Drawing.Size(231, 20);
            this.GuidLabel1.TabIndex = 4;
            this.GuidLabel1.Text = "검색 영역 (필요에 따라 높이 조절 가능)";
            this.GuidLabel1.Visible = false;
            // 
            // GuidLabel2
            // 
            this.GuidLabel2.AutoSize = true;
            this.GuidLabel2.Location = new System.Drawing.Point(121, 259);
            this.GuidLabel2.Name = "GuidLabel2";
            this.GuidLabel2.Size = new System.Drawing.Size(55, 20);
            this.GuidLabel2.TabIndex = 3;
            this.GuidLabel2.Text = "DGV1";
            this.GuidLabel2.Visible = false;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.GuidLabel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ListForm";
            this.Text = "ListForm";
            this.Load += new System.EventHandler(this.ListForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label GuidLabel1;
        protected System.Windows.Forms.Label GuidLabel2;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
    }
}