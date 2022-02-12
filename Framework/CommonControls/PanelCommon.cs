
namespace Com.ZimVie.Wcs.Framework
{
    public class PanelCommon : System.Windows.Forms.Panel
    {
        /// <summary>
        /// constructor
        /// </summary>
        public PanelCommon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// initialize the control
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }
    }
}
