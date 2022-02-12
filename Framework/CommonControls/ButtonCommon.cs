
namespace Com.ZimVie.Wcs.Framework
{
    public class ButtonCommon : System.Windows.Forms.Button
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ButtonCommon()
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
            // ButtonCommon
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Size = new System.Drawing.Size(80, 33);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set controlid
        /// </summary>
        public string ControlId { get; set; }

    }
}
