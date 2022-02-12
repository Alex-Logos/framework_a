using System;
using System.Diagnostics;

namespace Com.ZimVie.Wcs.Framework
{
    public class DefaultUnhandledExceptionHandler: UnhandledExceptionHandler
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultUnhandledExceptionHandler));

        /// <summary>
        /// initialize PopUpMessageController
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// Title name for unhandled message form
        /// </summary>
        private const string ERROR_MESSAGEFORM_TITLE = "Unhandled Error";

        /// <summary>
        /// private constructor
        /// </summary>
        private DefaultUnhandledExceptionHandler()
        {
        }

        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly DefaultUnhandledExceptionHandler instance 
                                                = new DefaultUnhandledExceptionHandler();

        /// <summary>
        /// returns the current instance
        /// </summary>
        /// <returns></returns>
        public static DefaultUnhandledExceptionHandler GetInstance()
        {
            return instance;
        }


        /// <summary>
        /// handle unhandled exception occured in the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e == null || e.ExceptionObject == null)
            {
                return;
            }
            try
            {
                Exception ex = e.ExceptionObject as Exception;

                HandleException(ex);
            }
            catch (Exception unExpectedExcepiton)
            {
                //logging only
                MessageData messageData = new MessageData("ffce00010", Properties.Resources.ffce00010, unExpectedExcepiton.Message);
                logger.Error(messageData, unExpectedExcepiton);
            }
            finally
            {
                try
                {
                    AbnormalEnd();
                }
                catch (Exception unExpectedExcepiton)
                {
                    //logging only
                    MessageData messageData = new MessageData("ffce00010", Properties.Resources.ffce00010, unExpectedExcepiton.Message);
                    logger.Error(messageData, unExpectedExcepiton);

                }
            }
        }


        /// <summary>
        /// popup for particular exception
        /// </summary>
        /// <param name="unhandledException"></param>
        private void HandleException(Exception unhandledException)
        {

            MessageData messageData = new MessageData("ffce00009", Properties.Resources.ffce00009, unhandledException.Message);

            logger.Error(messageData, unhandledException);

            if (unhandledException is Framework.SystemException)
            {
                SystemException sysEx = (SystemException)unhandledException;
                popUpMessage.SystemError(sysEx.GetMessageData(), ERROR_MESSAGEFORM_TITLE);
            }
            else if (unhandledException is Framework.ApplicationException)
            {
                ApplicationException appEx = (ApplicationException)unhandledException;
                popUpMessage.ApplicationError(appEx.GetMessageData(), ERROR_MESSAGEFORM_TITLE);
            }
            else
            {
                SystemException sysEx = new SystemException(messageData, unhandledException);
                popUpMessage.SystemError(sysEx.GetMessageData(), ERROR_MESSAGEFORM_TITLE);
            }
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
                MessageData messageData = new MessageData("ffce00008", Properties.Resources.ffce00008, ex.Message);
                popUpMessage.SystemError(messageData, ERROR_MESSAGEFORM_TITLE);
                logger.Error(messageData, ex);
            }
            catch (NotSupportedException ex)
            {
                MessageData messageData = new MessageData("ffce00008", Properties.Resources.ffce00008, ex.Message);
                popUpMessage.SystemError(messageData, ERROR_MESSAGEFORM_TITLE);
                logger.Error(messageData, ex);
            }
            catch (InvalidOperationException ex)
            {
                MessageData messageData = new MessageData("ffce00008", Properties.Resources.ffce00008, ex.Message);
                popUpMessage.SystemError(messageData, ERROR_MESSAGEFORM_TITLE);
                logger.Error(messageData, ex);
            }
        }

    }
}
