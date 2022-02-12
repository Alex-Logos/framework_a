using System;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework
{
    public class DateTimePickerCommon : DateTimePicker
    {
        /// <summary>
        /// constructor
        /// </summary>
        public DateTimePickerCommon()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode
                                 != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                SetFormat();
            }
        }


        /// <summary>
        /// enum for DisplayFormat
        /// </summary>
        public enum DisplayFormatList
        {
            ShortDatePattern,
            LongDatePattern
        }

        /// <summary>
        /// get and set the DisplayFormat
        /// </summary>
        public DisplayFormatList DisplayFormat { get; set; }


        /// <summary>
        /// initialize the control
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DateTimePickerCommon
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            this.Size = new System.Drawing.Size(124, 21);
            this.ValueChanged += new EventHandler(this.DateTimePickerCommon_ValueChanged);
            this.KeyDown += new KeyEventHandler(this.DateTimePickerCommon_KeyDown);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }

        /// <summary>
        /// set the datetimepicker value to null
        /// </summary>
        public void Clear()
        {
            this.switchFormat(null);
        }

        //public new DateTime? Value { get; set; }
        /// <summary>
        /// clear the date on backspace and delete key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerCommon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
            {
                this.switchFormat(null);

            }

        }

        /// <summary>
        /// formating on value change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerCommon_ValueChanged(object sender, EventArgs e)
        {

            this.switchFormat(this.Value);

        }

        private void SetFormat()
        {

            if (DisplayFormat.Equals(DisplayFormatList.ShortDatePattern))
            {
                this.CustomFormat = UserData.GetUserData().DateTimeFormat.ShortDatePattern;
            }
            else if (DisplayFormat.Equals(DisplayFormatList.LongDatePattern))
            {
                this.CustomFormat = UserData.GetUserData().DateTimeFormat.LongDatePattern;
            }

        }
        /// <summary>
        /// change the customformat by its value
        /// </summary>
        /// <param name="datetime"></param>
        private void switchFormat(DateTime? datetime)
        {
            if (datetime == null)
            {
                this.Value = DateTime.Today;
                this.CustomFormat = " ";
            }
            else
            {
                SetFormat();

            }
        }
    }
}
