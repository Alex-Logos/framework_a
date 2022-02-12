using System;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework
{
    public class TimeControlCommon : DateTimePicker
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TimeControlCommon()
        {
            InitializeComponent();
        }



        /// <summary>
        /// initialize the control
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TimeControlCommon
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CustomFormat = "HH:mm";
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ShowUpDown = true;
            this.Size = new System.Drawing.Size(58, 21);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }

    }
}
