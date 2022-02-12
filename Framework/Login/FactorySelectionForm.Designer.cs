namespace Com.ZimVie.Wcs.Framework
{
    partial class FactorySelectionForm : FormCommon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactorySelectionForm));
            this.Factory_cmb = new Com.ZimVie.Wcs.Framework.ComboBoxCommon();
            this.Factory_lbl = new Com.ZimVie.Wcs.Framework.LabelCommon();
            this.Ok_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.Exit_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.SuspendLayout();
            // 
            // Factory_cmb
            // 
            this.Factory_cmb.ControlId = null;
            resources.ApplyResources(this.Factory_cmb, "Factory_cmb");
            this.Factory_cmb.FormattingEnabled = true;
            this.Factory_cmb.Name = "Factory_cmb";
            // 
            // Factory_lbl
            // 
            resources.ApplyResources(this.Factory_lbl, "Factory_lbl");
            this.Factory_lbl.ControlId = null;
            this.Factory_lbl.Name = "Factory_lbl";
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
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // FactorySelectionForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Factory_lbl);
            this.Controls.Add(this.Factory_cmb);
            this.Name = "FactorySelectionForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.FactorySelectionForm_Load);
            this.Controls.SetChildIndex(this.Factory_cmb, 0);
            this.Controls.SetChildIndex(this.Factory_lbl, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBoxCommon Factory_cmb;
        private LabelCommon Factory_lbl;
        private ButtonCommon Ok_btn;
        private ButtonCommon Exit_btn;
    }
}
