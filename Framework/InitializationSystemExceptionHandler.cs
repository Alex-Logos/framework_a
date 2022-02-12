using System;
using System.Diagnostics;

namespace Com.ZimVie.Wcs.Framework
{
    public class InitializationSystemExceptionHandler
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InitializationSystemExceptionHandler));

        /// <summary>
        /// private constructor
        /// </summary>
        private InitializationSystemExceptionHandler()
        {
        }

        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly InitializationSystemExceptionHandler instance
                                                = new InitializationSystemExceptionHandler();

        /// <summary>
        /// returns the current instance
        /// </summary>
        /// <returns></returns>
        public static InitializationSystemExceptionHandler GetInstance()
        {
            return instance;
        }


        /// <summary>
        /// popup for particular exception
        /// </summary>
        /// <param name="unhandledException"></param>
        public void HandleException(SystemException sysException)
        {

            logger.Error(sysException.GetMessageData(), sysException);
            ShowMessage(sysException.GetMessageData());

            AbnormalEnd();
        }

        private void ShowMessage(MessageData messageData)
        {
            InitializationErrorMessageForm messageForm = new InitializationErrorMessageForm(messageData);
            messageForm.ShowDialog();

        }
        /// <summary>
        /// Method to call the kill current process
        /// </summary>
        private void AbnormalEnd()
        {
            KillProcess(Process.GetCurrentProcess());
        }

        /// <summary>
        /// kill the running process
        /// </summary>
        /// <param name="targetProcess"></param>
        private void KillProcess(Process targetProcess)
        {
            try
            {
                targetProcess.Kill();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageData messageData = new MessageData("ffce00011", Properties.Resources.ffce00011, ex.Message);
                ShowMessage(messageData);
                logger.Error(messageData, ex);
            }
            catch (NotSupportedException ex)
            {
                MessageData messageData = new MessageData("ffce00011", Properties.Resources.ffce00011, ex.Message);
                ShowMessage(messageData);
                logger.Error(messageData, ex);
            }
            catch (InvalidOperationException ex)
            {
                MessageData messageData = new MessageData("ffce00011", Properties.Resources.ffce00011, ex.Message);
                ShowMessage(messageData);
                logger.Error(messageData, ex);
            }
        }
    }
}
