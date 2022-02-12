using System;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework.CommonControls
{
    public partial class DateTimePickerControl : UserControl
    {
        /// <summary>
        /// enum for inputtype
        /// </summary>
        public enum InputTypeList
        {
            FromDate,
            ToDate,
            Now,
            NowWithZeroMin
        }

        /// <summary>
        /// set the inputtype as All
        /// </summary>
        private InputTypeList inputType = InputTypeList.Now;

        /// <summary>
        /// to check for default loading the datetime control
        /// </summary>
        //private bool isDefaultLoading;

        /// <summary>
        /// 
        /// </summary>
        public DateTimePickerControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// usercontrol load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                Date_dtp.ValueChanged += new EventHandler(this.DateTimePickerCommon_ValueChanged);
                Date_dtp.KeyDown += new KeyEventHandler(this.DateTimePickerCommon_KeyDown);

                this.SetDefaultDateTime();
            }
        }

        /// <summary>
        /// clear the date on backspace and delete key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerCommon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
            {
                this.TimeValueChange(null);
            }
        }

        /// <summary>
        /// formating on value change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerCommon_ValueChanged(object sender, EventArgs e)
        {
            if (Time_dtp.Enabled == false || string.IsNullOrWhiteSpace(Time_dtp.Text))
            {
                this.TimeValueChange(Date_dtp.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        private void TimeValueChange(DateTime? datetime)
        {
            if (datetime == null)
            {
                Time_dtp.CustomFormat = " ";
                Time_dtp.Enabled = false;
                return;
            }
            Time_dtp.Enabled = true;
            Time_dtp.CustomFormat = "HH:mm";

            Time_dtp.Value = new DateTime(Date_dtp.Value.Year, Date_dtp.Value.Month, Date_dtp.Value.Day, Date_dtp.Value.Hour, Date_dtp.Value.Minute, 0);
        }

        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }

        /// <summary>
        /// get and set the inputtype
        /// </summary>
        public InputTypeList InputType
        {
            get
            { return inputType; }
            set
            { inputType = value; }
        }

        /// <summary>
        /// set datetime.now as default value
        /// </summary>
        public void SetDefaultDateTime()
        {
            Date_dtp.Value = DateTime.Now;
            this.TimeValueChange(Date_dtp.Value);
        }

        /// <summary>
        /// set datetime for the datetimepicker
        /// </summary>
        public void SetDateTime(DateTime datetime)
        {
            Date_dtp.Value = datetime;
            this.TimeValueChange(Date_dtp.Value);
        }

        /// <summary>
        /// set datetime days after
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="daysprior"></param>
        public void SetDateTime(DateTime datetime, int daysLater)
        {
            Date_dtp.Value = datetime.AddDays(daysLater);
            this.TimeValueChange(Date_dtp.Value);
        }

        /// <summary>
        /// get the selected datetime
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {
            return new DateTime(Date_dtp.Value.Year, Date_dtp.Value.Month, Date_dtp.Value.Day,
                                Time_dtp.Value.Hour, Time_dtp.Value.Minute, Time_dtp.Value.Second);
        }

        /// <summary>
        /// to get the text of the datetimepicker
        /// </summary>
        /// <returns></returns>
        public new string Text
        {
            get
            {
                return Date_dtp.Text;
            }
        }

        /// <summary>
        /// clear the datetime value
        /// </summary>
        public void Clear()
        {
            Date_dtp.Clear();
            this.TimeValueChange(null);
        }
    }
}
