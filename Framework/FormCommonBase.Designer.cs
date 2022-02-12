namespace Com.ZimVie.Wcs.Framework
{
    partial class FormCommonBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommonBase));
            this.Title_chc = new Com.ZimVie.Wcs.Framework.CommonHeaderControl();
            this.SuspendLayout();
            // 
            // Title_chc
            // 
            this.Title_chc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Title_chc.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title_chc.Location = new System.Drawing.Point(0, 0);
            this.Title_chc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Title_chc.Name = "Title_chc";
            this.Title_chc.Size = new System.Drawing.Size(512, 65);
            this.Title_chc.TabIndex = 0;
            // 
            // FormCommonBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(512, 195);
            this.Controls.Add(this.Title_chc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCommonBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormCommonBase";
            this.ResumeLayout(false);

        }

        #endregion

        private CommonHeaderControl Title_chc;
    }
}