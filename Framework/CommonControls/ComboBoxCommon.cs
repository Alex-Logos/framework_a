
namespace Com.ZimVie.Wcs.Framework
{


    public class ComboBoxCommon:System.Windows.Forms.ComboBox
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ComboBoxCommon()
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
            // ComboBoxCommon
            // 
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(187, 20);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set controlid
        /// </summary>
        public string ControlId { get; set; }
    }

}
