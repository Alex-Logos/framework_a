namespace Com.ZimVie.Wcs.Framework
{
    partial class InitializationErrorMessageForm: System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitializationErrorMessageForm));
            this.ErrorImage_pb = new System.Windows.Forms.PictureBox();
            this.Ok_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.Error_txt = new Com.ZimVie.Wcs.Framework.TextBoxCommon();
            this.panelCommon1 = new Com.ZimVie.Wcs.Framework.PanelCommon();
            this.Header_lbl = new System.Windows.Forms.Label();
            this.Icon_pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImage_pb)).BeginInit();
            this.panelCommon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorImage_pb
            // 
            this.ErrorImage_pb.Location = new System.Drawing.Point(35, 87);
            this.ErrorImage_pb.Name = "ErrorImage_pb";
            this.ErrorImage_pb.Size = new System.Drawing.Size(42, 40);
            this.ErrorImage_pb.TabIndex = 3;
            this.ErrorImage_pb.TabStop = false;
            this.ErrorImage_pb.Paint += new System.Windows.Forms.PaintEventHandler(this.ErrorImage_pb_Paint);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ok_btn.BackColor = System.Drawing.Color.White;
            this.Ok_btn.ControlId = null;
            this.Ok_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Ok_btn.Location = new System.Drawing.Point(163, 301);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(80, 33);
            this.Ok_btn.TabIndex = 4;
            this.Ok_btn.Text = "OK";
            this.Ok_btn.UseVisualStyleBackColor = false;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Error_txt
            // 
            this.Error_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Error_txt.BackColor = System.Drawing.SystemColors.Window;
            this.Error_txt.ControlId = null;
            this.Error_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_txt.InputType = Com.ZimVie.Wcs.Framework.TextBoxCommon.InputTypeList.All;
            this.Error_txt.Location = new System.Drawing.Point(35, 133);
            this.Error_txt.Multiline = true;
            this.Error_txt.Name = "Error_txt";
            this.Error_txt.ReadOnly = true;
            this.Error_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Error_txt.Size = new System.Drawing.Size(375, 154);
            this.Error_txt.TabIndex = 8;
            // 
            // panelCommon1
            // 
            this.panelCommon1.ControlId = null;
            this.panelCommon1.Controls.Add(this.Header_lbl);
            this.panelCommon1.Controls.Add(this.Icon_pb);
            this.panelCommon1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCommon1.Location = new System.Drawing.Point(0, 0);
            this.panelCommon1.Name = "panelCommon1";
            this.panelCommon1.Size = new System.Drawing.Size(463, 76);
            this.panelCommon1.TabIndex = 9;
            // 
            // Header_lbl
            // 
            this.Header_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Header_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Header_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Header_lbl.Location = new System.Drawing.Point(149, 0);
            this.Header_lbl.Name = "Header_lbl";
            this.Header_lbl.Size = new System.Drawing.Size(314, 76);
            this.Header_lbl.TabIndex = 2;
            this.Header_lbl.Text = "Error";
            this.Header_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Icon_pb
            // 
            this.Icon_pb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Icon_pb.BackgroundImage")));
            this.Icon_pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Icon_pb.Dock = System.Windows.Forms.DockStyle.Left;
            this.Icon_pb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Icon_pb.InitialImage = null;
            this.Icon_pb.Location = new System.Drawing.Point(0, 0);
            this.Icon_pb.Name = "Icon_pb";
            this.Icon_pb.Size = new System.Drawing.Size(149, 76);
            this.Icon_pb.TabIndex = 1;
            this.Icon_pb.TabStop = false;
            // 
            // InitializationErrorMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 346);
            this.Controls.Add(this.panelCommon1);
            this.Controls.Add(this.Error_txt);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.ErrorImage_pb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitializationErrorMessageForm";
            this.Text = "PopUpForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImage_pb)).EndInit();
            this.panelCommon1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Icon_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ErrorImage_pb;
        private ButtonCommon Ok_btn;
        private TextBoxCommon Error_txt;
        private PanelCommon panelCommon1;
        private System.Windows.Forms.PictureBox Icon_pb;
        private System.Windows.Forms.Label Header_lbl;
    }
}