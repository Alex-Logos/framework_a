
namespace Com.ZimVie.Wcs.Framework
{
    public class RadioButtonCommon : System.Windows.Forms.RadioButton
    {
        /// <summary>
        /// constructor
        /// </summary>
        public RadioButtonCommon()
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
            // LabelCommon
            // 
            //this.AutoSize = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }
    }
}
