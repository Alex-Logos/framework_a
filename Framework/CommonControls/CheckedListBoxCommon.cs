using System.Collections.Generic;

namespace Com.ZimVie.Wcs.Framework
{
    public class CheckedListBoxCommon : System.Windows.Forms.CheckedListBox
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CheckedListBoxCommon()
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
            // CheckedListBoxCommon
            // 
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(238, 35);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set controlid
        /// </summary>
        public string ControlId { get; set; }


    }
}
