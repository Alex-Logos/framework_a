
namespace Com.ZimVie.Wcs.Framework
{
    public class TreeViewCommon : System.Windows.Forms.TreeView
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TreeViewCommon()
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.Size = new System.Drawing.Size(187, 21);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }
    }
}
