
namespace Com.ZimVie.Wcs.Framework
{
    public class GroupBoxCommon : System.Windows.Forms.GroupBox
    {
        /// <summary>
        /// constructor
        /// </summary>
        public GroupBoxCommon()
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
