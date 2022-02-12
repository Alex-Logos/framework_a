using System;
using System.Drawing;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework
{
    public partial class InitializationErrorMessageForm
    {

        /// <summary>
        /// initialize messagedata class
        /// </summary>
        private readonly MessageData messageData;

        private readonly SimpleMessageBuilder messageBuilder = new SimpleMessageBuilder();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="messagetype"></param>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        public InitializationErrorMessageForm(MessageData messageData)
        {
            InitializeComponent();
            this.messageData = messageData;
        }

        /// <summary>
        /// load message form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageForm_Load(object sender, EventArgs e)
        {
            Error_txt.Text = messageBuilder.BuildMessage(messageData);

        }

        /// <summary>
        /// click OK button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorImage_pb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Error, 0, 0);
        }

    }
}
