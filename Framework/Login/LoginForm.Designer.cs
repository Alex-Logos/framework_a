namespace Com.ZimVie.Wcs.Framework.Login
{
    partial class LoginForm:FormCommonBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.Password_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.Password_txt = new Com.ZimVie.Wcs.Framework.TextBoxCommon();
            this.LoginName_txt = new Com.ZimVie.Wcs.Framework.TextBoxCommon();
            this.LoginName_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.Login_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.Cancel_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.Version_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // Password_lbl
            // 
            resources.ApplyResources(this.Password_lbl, "Password_lbl");
            this.Password_lbl.ControlId = null;
            this.Password_lbl.Name = "Password_lbl";
            // 
            // Password_txt
            // 
            this.Password_txt.ControlId = null;
            resources.ApplyResources(this.Password_txt, "Password_txt");
            this.Password_txt.InputType = Com.ZimVie.Wcs.Framework.TextBoxCommon.InputTypeList.All;
            this.Password_txt.Name = "Password_txt";
            // 
            // LoginName_txt
            // 
            this.LoginName_txt.ControlId = null;
            resources.ApplyResources(this.LoginName_txt, "LoginName_txt");
            this.LoginName_txt.InputType = Com.ZimVie.Wcs.Framework.TextBoxCommon.InputTypeList.All;
            this.LoginName_txt.Name = "LoginName_txt";
            this.LoginName_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginName_txt_KeyUp);
            // 
            // LoginName_lbl
            // 
            resources.ApplyResources(this.LoginName_lbl, "LoginName_lbl");
            this.LoginName_lbl.ControlId = null;
            this.LoginName_lbl.Name = "LoginName_lbl";
            // 
            // Login_btn
            // 
            this.Login_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Login_btn.ControlId = null;
            resources.ApplyResources(this.Login_btn, "Login_btn");
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.UseVisualStyleBackColor = true;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Cancel_btn.ControlId = null;
            resources.ApplyResources(this.Cancel_btn, "Cancel_btn");
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Version_lbl
            // 
            resources.ApplyResources(this.Version_lbl, "Version_lbl");
            this.Version_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
            this.Version_lbl.ControlId = null;
            this.Version_lbl.Name = "Version_lbl";
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Version_lbl);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.Password_lbl);
            this.Controls.Add(this.Password_txt);
            this.Controls.Add(this.LoginName_txt);
            this.Controls.Add(this.LoginName_lbl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Controls.SetChildIndex(this.LoginName_lbl, 0);
            this.Controls.SetChildIndex(this.LoginName_txt, 0);
            this.Controls.SetChildIndex(this.Password_txt, 0);
            this.Controls.SetChildIndex(this.Password_lbl, 0);
            this.Controls.SetChildIndex(this.Login_btn, 0);
            this.Controls.SetChildIndex(this.Cancel_btn, 0);
            this.Controls.SetChildIndex(this.Version_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LabelCommon Password_lbl;
        private TextBoxCommon Password_txt;
        private TextBoxCommon LoginName_txt;
        private LabelCommon LoginName_lbl;
        private ButtonCommon Login_btn;
        private ButtonCommon Cancel_btn;
        private LabelCommon Version_lbl;
    }
}