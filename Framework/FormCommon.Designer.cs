namespace Com.ZimVie.Wcs.Framework
{
    partial class FormCommon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommon));
            this.Title_pnl = new System.Windows.Forms.Panel();
            this.LogOut_btn = new System.Windows.Forms.Button();
            this.UserName_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.FactoryCode_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.Title_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.Title_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title_pnl
            // 
            this.Title_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Title_pnl.Controls.Add(this.LogOut_btn);
            this.Title_pnl.Controls.Add(this.UserName_lbl);
            this.Title_pnl.Controls.Add(this.FactoryCode_lbl);
            this.Title_pnl.Controls.Add(this.Title_lbl);
            resources.ApplyResources(this.Title_pnl, "Title_pnl");
            this.Title_pnl.Name = "Title_pnl";
            // 
            // LogOut_btn
            // 
            resources.ApplyResources(this.LogOut_btn, "LogOut_btn");
            this.LogOut_btn.BackColor = System.Drawing.Color.Transparent;
            this.LogOut_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogOut_btn.Name = "LogOut_btn";
            this.LogOut_btn.TabStop = false;
            this.LogOut_btn.UseVisualStyleBackColor = false;
            this.LogOut_btn.Click += new System.EventHandler(this.LogOut_btn_Click);
            // 
            // UserName_lbl
            // 
            resources.ApplyResources(this.UserName_lbl, "UserName_lbl");
            this.UserName_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.UserName_lbl.ControlId = null;
            this.UserName_lbl.Name = "UserName_lbl";
            // 
            // FactoryCode_lbl
            // 
            resources.ApplyResources(this.FactoryCode_lbl, "FactoryCode_lbl");
            this.FactoryCode_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.FactoryCode_lbl.ControlId = null;
            this.FactoryCode_lbl.Name = "FactoryCode_lbl";
            // 
            // Title_lbl
            // 
            resources.ApplyResources(this.Title_lbl, "Title_lbl");
            this.Title_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Title_lbl.ControlId = null;
            this.Title_lbl.Name = "Title_lbl";
            // 
            // FormCommon
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
            this.Controls.Add(this.Title_pnl);
            this.Name = "FormCommon";
            this.Load += new System.EventHandler(this.FormCommon_Load);
            this.Controls.SetChildIndex(this.Title_pnl, 0);
            this.Title_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Title_pnl;
        private LabelCommon UserName_lbl;
        private LabelCommon FactoryCode_lbl;
        private System.Windows.Forms.Button LogOut_btn;
        private LabelCommon Title_lbl;
    }
}