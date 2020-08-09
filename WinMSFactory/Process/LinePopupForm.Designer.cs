namespace WinMSFactory
{
    partial class LinePopupForm
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Size = new System.Drawing.Size(408, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirm.Location = new System.Drawing.Point(77, 4);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(239, 4);
            // 
            // LinePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 450);
            this.Name = "LinePopupForm";
            this.Text = "LinePopupForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}