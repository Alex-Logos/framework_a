using System;
using System.Drawing;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework
{
    public partial class MessageForm
    {

        /// <summary>
        /// Enum for message types
        /// </summary>
        public enum MessageTypeEnum
        {

            SystemError,
            ApplicationError,
            Warning,
            Information,
            ConfirmationOkCancel,
            ConfirmationYesNoCancel,
            ConfirmationYesNo
        }


        /// <summary>
        /// initialize dialogresult
        /// </summary>
        private DialogResult answer;

        /// <summary>
        /// initialize messagedata class
        /// </summary>
        private readonly MessageData messageData;

        /// <summary>
        /// initialize messagetypeenum
        /// </summary>
        private readonly MessageTypeEnum messageType;


        private readonly SimpleMessageBuilder messageBuilder = new SimpleMessageBuilder();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="messagetype"></param>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        public MessageForm(MessageTypeEnum messagetype, MessageData messagedata, string title, Size pgSize = new Size())
        {
            InitializeComponent();

            messageType = messagetype;

            messageData = messagedata;

            this.Text = title;

            if (!pgSize.IsEmpty) { this.Size = pgSize; }

        }

        /// <summary>
        /// load message form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageForm_Load(object sender, EventArgs e)
        {
            Error_txt.Text = messageBuilder.BuildMessage(messageData);

            switch (messageType)
            {
                case MessageTypeEnum.SystemError:

                    Ok_btn.Visible = true;
                    Ok_btn.Select();
                    break;
                case MessageTypeEnum.ApplicationError:
                    Ok_btn.Visible = true;
                    Ok_btn.Select();
                    break;
                case MessageTypeEnum.Warning:
                    Ok_btn.Visible = true;
                    Ok_btn.Select();
                    break;
                case MessageTypeEnum.Information:

                    Ok_btn.Visible = true;
                    Ok_btn.Select();
                    break;
                case MessageTypeEnum.ConfirmationOkCancel:
                    Ok_btn.Visible = true;
                    Cancel_btn.Visible = true;
                    Ok_btn.Location = new System.Drawing.Point(Ok_btn.Location.X - 40, Ok_btn.Location.Y);
                    Cancel_btn.Location = new System.Drawing.Point(Ok_btn.Location.X + Ok_btn.Width + 20, Cancel_btn.Location.Y);

                    Ok_btn.Select();

                    break;
                case MessageTypeEnum.ConfirmationYesNoCancel:
                    Yes_btn.Visible = true;
                    No_btn.Visible = true;
                    Cancel_btn.Visible = true;
                    Yes_btn.Select();

                    break;
                case MessageTypeEnum.ConfirmationYesNo:
                    Yes_btn.Visible = true;
                    No_btn.Visible = true;
                    Yes_btn.Location = new System.Drawing.Point(Yes_btn.Location.X + 40, Yes_btn.Location.Y);
                    No_btn.Location = new System.Drawing.Point(Yes_btn.Location.X + Yes_btn.Width + 20, No_btn.Location.Y);
                    Yes_btn.Select();

                    break;
            }
        }

        /// <summary>
        /// get dialog result of this form
        /// </summary>
        internal DialogResult Answer
        {
            get { return answer; }
        }


        /// <summary>
        /// click OK button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            answer = DialogResult.OK;

            this.Close();
        }

        /// <summary>
        /// Click Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            answer = DialogResult.Cancel;

            this.Close();
        }

        /// <summary>
        /// Click No button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void No_btn_Click(object sender, EventArgs e)
        {
            answer = DialogResult.No;

            this.Close();
        }

        /// <summary>
        /// Click Yes button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Yes_btn_Click(object sender, EventArgs e)
        {
            answer = DialogResult.Yes;

            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorImage_pb_Paint(object sender, PaintEventArgs e)
        {
            switch (messageType)
            {
                case MessageTypeEnum.SystemError:

                    e.Graphics.DrawIcon(SystemIcons.Error, 0, 0);

                    break;
                case MessageTypeEnum.ApplicationError:

                    e.Graphics.DrawIcon(SystemIcons.Error, 0, 0);

                    break;
                case MessageTypeEnum.Warning:

                    e.Graphics.DrawIcon(SystemIcons.Warning, 0, 0);

                    break;
                case MessageTypeEnum.Information:

                    e.Graphics.DrawIcon(SystemIcons.Information, 0, 0);

                    break;
                case MessageTypeEnum.ConfirmationYesNoCancel:

                    e.Graphics.DrawIcon(SystemIcons.Question, 0, 0);

                    break;
                case MessageTypeEnum.ConfirmationOkCancel:

                    e.Graphics.DrawIcon(SystemIcons.Question, 0, 0);

                    break;
            }

        }
    }
}
