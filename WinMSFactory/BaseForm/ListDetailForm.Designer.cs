namespace WinMSFactory
{
    partial class ListDetailForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.GuidLabel1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GuidLabel2 = new System.Windows.Forms.Label();
            this.GuidLabel3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GuidLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1534, 170);
            this.panel2.TabIndex = 3;
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.AutoSize = true;
            this.GuidLabel1.Location = new System.Drawing.Point(82, 41);
            this.GuidLabel1.Name = "GuidLabel1";
            this.GuidLabel1.Size = new System.Drawing.Size(231, 20);
            this.GuidLabel1.TabIndex = 4;
            this.GuidLabel1.Text = "검색 영역 (필요에 따라 높이 조절 가능)";
            this.GuidLabel1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GuidLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 591);
            this.panel1.TabIndex = 4;
            // 
            // GuidLabel2
            // 
            this.GuidLabel2.AutoSize = true;
            this.GuidLabel2.Location = new System.Drawing.Point(171, 158);
            this.GuidLabel2.Name = "GuidLabel2";
            this.GuidLabel2.Size = new System.Drawing.Size(230, 20);
            this.GuidLabel2.TabIndex = 6;
            this.GuidLabel2.Text = "패널(treeview 등 다양하게 사용가능)";
            this.GuidLabel2.Visible = false;
            // 
            // GuidLabel3
            // 
            this.GuidLabel3.AutoSize = true;
            this.GuidLabel3.Location = new System.Drawing.Point(707, 370);
            this.GuidLabel3.Name = "GuidLabel3";
            this.GuidLabel3.Size = new System.Drawing.Size(55, 20);
            this.GuidLabel3.TabIndex = 5;
            this.GuidLabel3.Text = "DGV1";
            this.GuidLabel3.Visible = false;
            // 
            // ListDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.GuidLabel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ListDetailForm";
            this.Text = "ListDetailForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Label GuidLabel1;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label GuidLabel2;
        protected System.Windows.Forms.Label GuidLabel3;
    }
}