namespace Com.ZimVie.Wcs.Framework
{
    partial class WaitProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitProgressForm));
            this.Display_pnl = new Com.ZimVie.Wcs.Framework.PanelCommon();
            this.Status_txt = new Com.ZimVie.Wcs.Framework.TextBoxCommon();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Display_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Display_pnl
            // 
            this.Display_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Display_pnl.ControlId = null;
            this.Display_pnl.Controls.Add(this.Status_txt);
            this.Display_pnl.Controls.Add(this.pictureBox1);
            this.Display_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display_pnl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Display_pnl.Location = new System.Drawing.Point(0, 0);
            this.Display_pnl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Display_pnl.Name = "Display_pnl";
            this.Display_pnl.Size = new System.Drawing.Size(407, 104);
            this.Display_pnl.TabIndex = 5;
            // 
            // Status_txt
            // 
            this.Status_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Status_txt.ControlId = null;
            this.Status_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status_txt.InputType = Com.ZimVie.Wcs.Framework.TextBoxCommon.InputTypeList.All;
            this.Status_txt.Location = new System.Drawing.Point(101, 3);
            this.Status_txt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Status_txt.Multiline = true;
            this.Status_txt.Name = "Status_txt";
            this.Status_txt.ReadOnly = true;
            this.Status_txt.Size = new System.Drawing.Size(297, 91);
            this.Status_txt.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // WaitProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(407, 104);
            this.Controls.Add(this.Display_pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "WaitProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WaitProgressForm";
            this.Load += new System.EventHandler(this.WaitProgressForm_Load);
            this.Display_pnl.ResumeLayout(false);
            this.Display_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private TextBoxCommon Status_txt;
        private PanelCommon Display_pnl;
    }
}