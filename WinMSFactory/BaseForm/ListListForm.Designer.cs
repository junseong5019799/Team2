namespace WinMSFactory
{
    partial class ListListForm
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
			this.Guidlabel1 = new System.Windows.Forms.Label();
			this.Guidlabel2 = new System.Windows.Forms.Label();
			this.Guidlabel3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.Guidlabel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1534, 170);
			this.panel1.TabIndex = 2;
			// 
			// Guidlabel1
			// 
			this.Guidlabel1.AutoSize = true;
			this.Guidlabel1.Location = new System.Drawing.Point(204, 81);
			this.Guidlabel1.Name = "Guidlabel1";
			this.Guidlabel1.Size = new System.Drawing.Size(199, 16);
			this.Guidlabel1.TabIndex = 0;
			this.Guidlabel1.Text = "검색 영역 (필요에 따라 높이 조절 가능)";
			this.Guidlabel1.Visible = false;
			// 
			// Guidlabel2
			// 
			this.Guidlabel2.AutoSize = true;
			this.Guidlabel2.Location = new System.Drawing.Point(113, 214);
			this.Guidlabel2.Name = "Guidlabel2";
			this.Guidlabel2.Size = new System.Drawing.Size(44, 16);
			this.Guidlabel2.TabIndex = 1;
			this.Guidlabel2.Text = "DGV1";
			this.Guidlabel2.Visible = false;
			// 
			// Guidlabel3
			// 
			this.Guidlabel3.AutoSize = true;
			this.Guidlabel3.Location = new System.Drawing.Point(113, 512);
			this.Guidlabel3.Name = "Guidlabel3";
			this.Guidlabel3.Size = new System.Drawing.Size(44, 16);
			this.Guidlabel3.TabIndex = 3;
			this.Guidlabel3.Text = "DGV2";
			this.Guidlabel3.Visible = false;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1534, 460);
			this.panel2.TabIndex = 4;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 460);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1534, 301);
			this.panel3.TabIndex = 5;
			// 
			// ListListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1534, 761);
			this.Controls.Add(this.Guidlabel3);
			this.Controls.Add(this.Guidlabel2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ListListForm";
			this.Text = "ListListForm";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label Guidlabel2;
        protected System.Windows.Forms.Label Guidlabel3;
		protected System.Windows.Forms.Label Guidlabel1;
		protected System.Windows.Forms.Panel panel2;
		protected System.Windows.Forms.Panel panel3;
	}
}