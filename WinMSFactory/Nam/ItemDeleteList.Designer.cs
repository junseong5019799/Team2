namespace WinMSFactory.Nam
{
    partial class ItemDeleteList
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
            this.UpList = new System.Windows.Forms.ListBox();
            this.DownList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonControl1 = new WinMSFactory.ButtonControl();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UpList
            // 
            this.UpList.FormattingEnabled = true;
            this.UpList.ItemHeight = 12;
            this.UpList.Location = new System.Drawing.Point(21, 106);
            this.UpList.Name = "UpList";
            this.UpList.Size = new System.Drawing.Size(341, 172);
            this.UpList.TabIndex = 0;
            // 
            // DownList
            // 
            this.DownList.FormattingEnabled = true;
            this.DownList.ItemHeight = 12;
            this.DownList.Location = new System.Drawing.Point(21, 311);
            this.DownList.Name = "DownList";
            this.DownList.Size = new System.Drawing.Size(341, 172);
            this.DownList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 13F);
            this.label1.Location = new System.Drawing.Point(30, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "삭제된 BOM 목록입니다.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(30, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "상위 BOM 목록";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(30, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "하위 BOM 목록";
            // 
            // buttonControl1
            // 
            this.buttonControl1.BackColor = System.Drawing.Color.White;
            this.buttonControl1.ForeColor = System.Drawing.Color.Black;
            this.buttonControl1.Location = new System.Drawing.Point(270, 489);
            this.buttonControl1.Name = "buttonControl1";
            this.buttonControl1.Size = new System.Drawing.Size(82, 31);
            this.buttonControl1.TabIndex = 2;
            this.buttonControl1.Text = "확인";
            this.buttonControl1.UseVisualStyleBackColor = false;
            this.buttonControl1.Click += new System.EventHandler(this.buttonControl1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 13F);
            this.label4.Location = new System.Drawing.Point(30, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "제품이 삭제되었습니다.";
            // 
            // ItemDeleteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 532);
            this.Controls.Add(this.buttonControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownList);
            this.Controls.Add(this.UpList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemDeleteList";
            this.Text = "BOM 삭제 목록";
            this.Load += new System.EventHandler(this.ItemDeleteList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UpList;
        private System.Windows.Forms.ListBox DownList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ButtonControl buttonControl1;
        private System.Windows.Forms.Label label4;
    }
}