using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Com.ZimVie.Wcs.Framework
{
    public partial class WaitProgressForm : Form
    {
        private string displayStatus;

        public WaitProgressForm(string status)
        {
            displayStatus = status;
            InitializeComponent();
        }

        private void WaitProgressForm_Load(object sender, EventArgs e)
        {
            Status_txt.Invoke(new Action(() => Status_txt.Text = displayStatus));
        }
    }
}
