
using System.Linq;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework
{
    public partial class CommonHeaderControl : UserControl
    {

        
        public CommonHeaderControl()
        {
            
             InitializeComponent();
             
        }

        private void CommonHeaderControl_Load(object sender, System.EventArgs e)
        {
            if (!this.DesignMode)
            {
                Header_lbl.Text = ConfigurationDataTypeEnum.APPLICATION_HEADER.GetValue();
                
            }
        }

    }
}
