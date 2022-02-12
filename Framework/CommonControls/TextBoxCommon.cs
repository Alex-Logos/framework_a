using System;
using System.Globalization;

namespace Com.ZimVie.Wcs.Framework
{

    public class TextBoxCommon : System.Windows.Forms.TextBox
    {

        /// <summary>
        /// enum for inputtype
        /// Mode Numberic is only integer can be entered.
        /// Mode Decimal is decimal can be entered.
        /// Mode All is all characters can be entered.
        /// </summary>
        ///
        public enum InputTypeList
        {
            Numeric,
            Decimal,
            All
        }

        /// <summary>
        /// set the inputtype as All
        /// </summary>
        private InputTypeList inputType = InputTypeList.All;


        /// <summary>
        /// Decimal separator.This is instanticated as required in the method <see cref="OnKeyPress"/>
        /// </summary>
        char? USER_NUMBER_DECIMAL_SEPARATOR;

        /// <summary>
        /// constructor
        /// </summary>
        public TextBoxCommon()
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
            // TextBoxCommon
            //
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(187, 21);
            this.ResumeLayout(false);

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
        /// overrides ongotfocus event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(EventArgs e)
        {
            if (inputType == InputTypeList.Numeric)
            {

                this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                if (this.Text.Length > 0)
                {
                    this.Select(this.Text.Length, 0);
                }
            }
        }
        /// <summary>
        /// overrides onkeydown event for avoid Ctrl + V
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (inputType == InputTypeList.Numeric)
            {
                // if (e.KeyCode == System.Windows.Forms.Keys.V && e.Modifiers == System.Windows.Forms.Keys.Control)
                if (e.Control && e.KeyCode == System.Windows.Forms.Keys.V)
                {
                    e.SuppressKeyPress = true;
                }
            }
            base.OnKeyDown(e);

        }


        /// <summary>
        /// overrides onkeypress for accepting numeric values
        /// </summary>
        /// When "Numeric" is selected integer can be entered
        /// When "Decimal" is selected decimal can be entered
        /// When "All" is selected all characters can be entered
        /// <param name="e"></param> "e" is argument of KeyPressEventArgs
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (inputType == InputTypeList.Numeric || inputType == InputTypeList.Decimal)
            {

                if (USER_NUMBER_DECIMAL_SEPARATOR == null) //instantiate as required for performance.
                {
                    NumberFormatInfo userNumberFormat = UserData.GetUserData()?.NumberFormat;
                    USER_NUMBER_DECIMAL_SEPARATOR = userNumberFormat?.NumberDecimalSeparator.ToCharArray()?[0];

                    if (USER_NUMBER_DECIMAL_SEPARATOR == null)
                    {
                        MessageData messageData = new MessageData("ffce00060", Properties.Resources.ffce00060);
                        CommonLogger.GetInstance(this.GetType()).Error(messageData);
                        throw new SystemException(messageData);
                    }

                }

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != USER_NUMBER_DECIMAL_SEPARATOR))
                {
                    e.Handled = true;
                }

                if (inputType == InputTypeList.Decimal)
                {
                    if (e.KeyChar == USER_NUMBER_DECIMAL_SEPARATOR && this.Text.IndexOf(USER_NUMBER_DECIMAL_SEPARATOR.ToString()) > -1)
                    {
                        e.Handled = true;
                    }

                }
                else if (inputType == InputTypeList.Numeric)
                {
                    if (e.KeyChar == USER_NUMBER_DECIMAL_SEPARATOR)
                    {
                        e.Handled = true;
                    }
                }

            }


            base.OnKeyPress(e);
        }
    }
}
