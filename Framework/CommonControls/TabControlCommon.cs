
namespace Com.ZimVie.Wcs.Framework
{
    public class TabControlCommon : System.Windows.Forms.TabControl
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TabControlCommon()
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
            // TabControlCommon
            // 
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeLayout(false);

        }
     
        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }

    }

}

