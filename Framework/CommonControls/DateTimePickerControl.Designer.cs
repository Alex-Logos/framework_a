namespace Com.ZimVie.Wcs.Framework.CommonControls
{
    partial class DateTimePickerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Time_dtp = new Com.ZimVie.Wcs.Framework.TimeControlCommon();
            this.Date_dtp = new Com.ZimVie.Wcs.Framework.DateTimePickerCommon();
            this.SuspendLayout();
            // 
            // Time_dtp
            // 
            this.Time_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.Time_dtp.ControlId = null;
            this.Time_dtp.CustomFormat = "HH:mm";
            this.Time_dtp.Dock = System.Windows.Forms.DockStyle.Right;
            this.Time_dtp.Font = new System.Drawing.Font("Arial", 9F);
            this.Time_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Time_dtp.Location = new System.Drawing.Point(91, 0);
            this.Time_dtp.Name = "Time_dtp";
            this.Time_dtp.ShowUpDown = true;
            this.Time_dtp.Size = new System.Drawing.Size(58, 21);
            this.Time_dtp.TabIndex = 1;
            // 
            // Date_dtp
            // 
            this.Date_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.Date_dtp.ControlId = null;
            this.Date_dtp.DisplayFormat = Com.ZimVie.Wcs.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.Date_dtp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Date_dtp.Font = new System.Drawing.Font("Arial", 9F);
            this.Date_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date_dtp.Location = new System.Drawing.Point(0, 0);
            this.Date_dtp.Name = "Date_dtp";
            this.Date_dtp.Size = new System.Drawing.Size(91, 21);
            this.Date_dtp.TabIndex = 0;
            // 
            // DateTimePickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Date_dtp);
            this.Controls.Add(this.Time_dtp);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "DateTimePickerControl";
            this.Size = new System.Drawing.Size(149, 20);
            this.Load += new System.EventHandler(this.DateTimePickerControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimePickerCommon Date_dtp;
        private TimeControlCommon Time_dtp;
    }
}
