
namespace Com.ZimVie.Wcs.Framework
{
    public class LabelCommon : System.Windows.Forms.Label
    {
        /// <summary>
        /// constructor
        /// </summary>
        public LabelCommon()
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
            this.Size = new System.Drawing.Size(100, 23);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }
    }
}
