namespace WinMSFactory
{
    partial class BOMSelectForm
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
            this.Reserve = new System.Windows.Forms.TreeView();
            this.Right = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Margin = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(1534, 162);
            // 
            // Reserve
            // 
            this.Reserve.Indent = 25;
            this.Reserve.ItemHeight = 30;
            this.Reserve.Location = new System.Drawing.Point(770, 183);
            this.Reserve.Name = "Reserve";
            this.Reserve.Size = new System.Drawing.Size(752, 477);
            this.Reserve.TabIndex = 29;
            // 
            // Right
            // 
            this.Right.Indent = 40;
            this.Right.ItemHeight = 30;
            this.Right.Location = new System.Drawing.Point(12, 183);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(752, 477);
            this.Right.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(780, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "역전개";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(23, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "정전개";
            // 
            // BOMSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 761);
            this.Controls.Add(this.Reserve);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BOMSelectForm";
            this.Text = "BOMSelectForm";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Right, 0);
            this.Controls.SetChildIndex(this.Reserve, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView Reserve;
        private System.Windows.Forms.TreeView Right;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}