using System.Windows.Forms;
using System.Drawing;
namespace Com.ZimVie.Wcs.Framework
{
    public class PopUpMessageController
    {

        /// <summary>
        /// shows message dialog and return dialog result
        /// </summary>
        /// <param name="messagetype"></param>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        private DialogResult ShowMessage(MessageForm.MessageTypeEnum messagetype, MessageData messagedata, string title, Size pgSize = new Size())
        {
            MessageForm messageform = new MessageForm(messagetype, messagedata, title, pgSize);

            messageform.ShowDialog();

            return messageform.Answer;
        }
        /// <summary>
        /// shows application  error
        /// </summary>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult ApplicationError(MessageData messagedata, string title, Size pgSize = new Size())
        {
            return ShowMessage(MessageForm.MessageTypeEnum.ApplicationError,messagedata,title, pgSize);
        }

        /// <summary>
        /// shows information error
        /// </summary>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult Information(MessageData messagedata, string title)
        {
            return ShowMessage(MessageForm.MessageTypeEnum.Information, messagedata, title);
        }


        /// <summary>
        /// shows system  error
        /// </summary>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult SystemError(MessageData messagedata, string title)
        {
            return ShowMessage(MessageForm.MessageTypeEnum.SystemError, messagedata, title);
        }


        /// <summary>
        /// shows warning  error
        /// </summary>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult Warning(MessageData messagedata, string title)
        {
            return ShowMessage(MessageForm.MessageTypeEnum.Warning, messagedata, title);
        }


        /// <summary>
        /// shows  dialog for  confirmation
        /// </summary>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult ConfirmationOkCancel(MessageData messagedata, string title)
        {
            return ShowMessage(MessageForm.MessageTypeEnum.ConfirmationOkCancel, messagedata, title);
        }

        /// <summary>
        /// shows confirmation error  with Yes/No/Cancel
        /// </summary>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult ConfirmationYesNoCancel(MessageData messagedata, string title)
        {
            return ShowMessage(MessageForm.MessageTypeEnum.ConfirmationYesNoCancel, messagedata, title);
        }

        /// <summary>
        /// shows confirmation error  with Yes/No/Cancel
        /// </summary>
        /// <param name="messagedata"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult ConfirmationYesNo(MessageData messagedata, string title)
        {
            return ShowMessage(MessageForm.MessageTypeEnum.ConfirmationYesNo, messagedata, title);
        }
    }
}
