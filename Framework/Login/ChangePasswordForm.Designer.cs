namespace Com.ZimVie.Wcs.Framework.Login
{
    partial class ChangePasswordForm:FormCommonBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.ConfirmPassword_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.ConfPwd_txt = new Com.ZimVie.Wcs.Framework.TextBoxCommon();
            this.NewPwd_txt = new Com.ZimVie.Wcs.Framework.TextBoxCommon();
            this.NewPassword_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.Ok_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.Cancel_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.Password_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.Password_txt = new Com.ZimVie.Wcs.Framework.TextBoxCommon();
            this.SuspendLayout();
            // 
            // ConfirmPassword_lbl
            // 
            this.ConfirmPassword_lbl.ControlId = null;
            resources.ApplyResources(this.ConfirmPassword_lbl, "ConfirmPassword_lbl");
            this.ConfirmPassword_lbl.Name = "ConfirmPassword_lbl";
            // 
            // ConfPwd_txt
            // 
            this.ConfPwd_txt.ControlId = null;
            resources.ApplyResources(this.ConfPwd_txt, "ConfPwd_txt");
            this.ConfPwd_txt.InputType = Com.ZimVie.Wcs.Framework.TextBoxCommon.InputTypeList.All;
            this.ConfPwd_txt.Name = "ConfPwd_txt";
            this.ConfPwd_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ConfPwd_txt_KeyUp);
            // 
            // NewPwd_txt
            // 
            this.NewPwd_txt.ControlId = null;
            resources.ApplyResources(this.NewPwd_txt, "NewPwd_txt");
            this.NewPwd_txt.InputType = Com.ZimVie.Wcs.Framework.TextBoxCommon.InputTypeList.All;
            this.NewPwd_txt.Name = "NewPwd_txt";
            this.NewPwd_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewPwd_txt_KeyUp);
            // 
            // NewPassword_lbl
            // 
            this.NewPassword_lbl.ControlId = null;
            resources.ApplyResources(this.NewPassword_lbl, "NewPassword_lbl");
            this.NewPassword_lbl.Name = "NewPassword_lbl";
            // 
            // Ok_btn
            // 
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            resources.ApplyResources(this.Ok_btn, "Ok_btn");
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
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
            // Password_lbl
            // 
            this.Password_lbl.ControlId = null;
            resources.ApplyResources(this.Password_lbl, "Password_lbl");
            this.Password_lbl.Name = "Password_lbl";
            // 
            // Password_txt
            // 
            this.Password_txt.ControlId = null;
            resources.ApplyResources(this.Password_txt, "Password_txt");
            this.Password_txt.InputType = Com.ZimVie.Wcs.Framework.TextBoxCommon.InputTypeList.All;
            this.Password_txt.Name = "Password_txt";
            this.Password_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Password_txt_KeyUp);
            // 
            // ChangePasswordForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Password_lbl);
            this.Controls.Add(this.Password_txt);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.ConfirmPassword_lbl);
            this.Controls.Add(this.ConfPwd_txt);
            this.Controls.Add(this.NewPwd_txt);
            this.Controls.Add(this.NewPassword_lbl);
            this.Name = "ChangePasswordForm";
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.Controls.SetChildIndex(this.NewPassword_lbl, 0);
            this.Controls.SetChildIndex(this.NewPwd_txt, 0);
            this.Controls.SetChildIndex(this.ConfPwd_txt, 0);
            this.Controls.SetChildIndex(this.ConfirmPassword_lbl, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Cancel_btn, 0);
            this.Controls.SetChildIndex(this.Password_txt, 0);
            this.Controls.SetChildIndex(this.Password_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LabelCommon ConfirmPassword_lbl;
        private TextBoxCommon ConfPwd_txt;
        private TextBoxCommon NewPwd_txt;
        private LabelCommon NewPassword_lbl;
        private ButtonCommon Ok_btn;
        private ButtonCommon Cancel_btn;
        private LabelCommon Password_lbl;
        private TextBoxCommon Password_txt;
    }
}