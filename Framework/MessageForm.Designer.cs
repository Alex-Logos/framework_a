namespace Com.ZimVie.Wcs.Framework
{
    partial class MessageForm  : FormCommonBase
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
            this.ErrorImage_pb = new System.Windows.Forms.PictureBox();
            this.Ok_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.Cancel_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.Yes_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.No_btn = new Com.ZimVie.Wcs.Framework.ButtonCommon();
            this.Error_txt = new Com.ZimVie.Wcs.Framework.TextBoxCommon();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImage_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorImage_pb
            // 
            this.ErrorImage_pb.Location = new System.Drawing.Point(47, 89);
            this.ErrorImage_pb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ErrorImage_pb.Name = "ErrorImage_pb";
            this.ErrorImage_pb.Size = new System.Drawing.Size(56, 46);
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
            this.Ok_btn.Location = new System.Drawing.Point(249, 337);
            this.Ok_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(107, 38);
            this.Ok_btn.TabIndex = 4;
            this.Ok_btn.Text = "OK";
            this.Ok_btn.UseVisualStyleBackColor = false;
            this.Ok_btn.Visible = false;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cancel_btn.BackColor = System.Drawing.Color.White;
            this.Cancel_btn.ControlId = null;
            this.Cancel_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Cancel_btn.Location = new System.Drawing.Point(384, 337);
            this.Cancel_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(107, 38);
            this.Cancel_btn.TabIndex = 5;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = false;
            this.Cancel_btn.Visible = false;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Yes_btn
            // 
            this.Yes_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Yes_btn.BackColor = System.Drawing.Color.White;
            this.Yes_btn.ControlId = null;
            this.Yes_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Yes_btn.Location = new System.Drawing.Point(115, 337);
            this.Yes_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Yes_btn.Name = "Yes_btn";
            this.Yes_btn.Size = new System.Drawing.Size(107, 38);
            this.Yes_btn.TabIndex = 6;
            this.Yes_btn.Text = "Yes";
            this.Yes_btn.UseVisualStyleBackColor = false;
            this.Yes_btn.Visible = false;
            this.Yes_btn.Click += new System.EventHandler(this.Yes_btn_Click);
            // 
            // No_btn
            // 
            this.No_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.No_btn.BackColor = System.Drawing.Color.White;
            this.No_btn.ControlId = null;
            this.No_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.No_btn.Location = new System.Drawing.Point(249, 337);
            this.No_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.No_btn.Name = "No_btn";
            this.No_btn.Size = new System.Drawing.Size(107, 38);
            this.No_btn.TabIndex = 7;
            this.No_btn.Text = "No";
            this.No_btn.UseVisualStyleBackColor = false;
            this.No_btn.Visible = false;
            this.No_btn.Click += new System.EventHandler(this.No_btn_Click);
            // 
            // Error_txt
            // 
            this.Error_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_txt.BackColor = System.Drawing.SystemColors.Window;
            this.Error_txt.ControlId = null;
            this.Error_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_txt.InputType = Com.ZimVie.Wcs.Framework.TextBoxCommon.InputTypeList.All;
            this.Error_txt.Location = new System.Drawing.Point(47, 142);
            this.Error_txt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Error_txt.Multiline = true;
            this.Error_txt.Name = "Error_txt";
            this.Error_txt.ReadOnly = true;
            this.Error_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Error_txt.Size = new System.Drawing.Size(499, 177);
            this.Error_txt.TabIndex = 8;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 399);
            this.Controls.Add(this.Error_txt);
            this.Controls.Add(this.No_btn);
            this.Controls.Add(this.Yes_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.ErrorImage_pb);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.Text = "PopUpForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.Controls.SetChildIndex(this.ErrorImage_pb, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Cancel_btn, 0);
            this.Controls.SetChildIndex(this.Yes_btn, 0);
            this.Controls.SetChildIndex(this.No_btn, 0);
            this.Controls.SetChildIndex(this.Error_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImage_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ErrorImage_pb;
        private ButtonCommon Ok_btn;
        private ButtonCommon Cancel_btn;
        private ButtonCommon Yes_btn;
        private ButtonCommon No_btn;
        private TextBoxCommon Error_txt;
    }
}