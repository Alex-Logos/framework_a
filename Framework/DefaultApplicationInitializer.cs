using System;
using System.Windows.Forms;
using System.Threading;

namespace Com.ZimVie.Wcs.Framework
{
    internal class DefaultApplicationInitializer : ApplicationInitializer
    {
        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly DefaultApplicationInitializer instance = new DefaultApplicationInitializer();

        /// <summary>
        /// initialize PopUpMessageController
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// Initialize methods to be called
        /// </summary>
        public void Init()
        {
            //check mandatory application setting values.
            PreInit();

            // Set the unhandled exception mode to force all Windows Forms errors
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            // Add the event handler for handling non-UI thread exceptions to the event.
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(
                            DefaultUnhandledExceptionHandler.GetInstance().HandleException);

        }

        /// <summary>
        /// check mandatory settings
        /// </summary>
        private void PreInit()
        {

            //application environment settings check
            CheckMandatorySettings(ConfigurationDataTypeEnum.APPLICATION_ENVIRONMENT_SETTINGS, "ffce00030", Properties.Resources.ffce00030);

            //applicationenvironmentheader check
            CheckMandatorySettings(ConfigurationDataTypeEnum.APPLICATION_ENVIRONMENT_HEADER, "ffce00037", Properties.Resources.ffce00037);

            //applicationheader check
            CheckMandatorySettings(ConfigurationDataTypeEnum.APPLICATION_HEADER, "ffce00012", Properties.Resources.ffce00012);

            //connectionstring check
            CheckMandatorySettings(ConfigurationDataTypeEnum.CONNECTION_STRING, "ffce00013", Properties.Resources.ffce00013);

            //servertimezone check
            CheckMandatorySettings(ConfigurationDataTypeEnum.SERVER_TIME_ZONE, "ffce00015", Properties.Resources.ffce00015);
          
        }

        /// <summary>
        /// check mandatory applicationsettings value
        /// </summary>
        private void CheckMandatorySettings(ConfigurationDataTypeEnum settingsdata,
                                                    string messageCode, string message)
        {
            try
            {
                string settingValue = settingsdata.GetValue();

                if (string.IsNullOrWhiteSpace(settingValue))
                {
                    MessageData messageData = new MessageData(messageCode, message, Properties.Resources.ffce00016);
                    SystemException sysEx = new SystemException(messageData);

                    InitializationSystemExceptionHandler.GetInstance().HandleException(sysEx);
                }
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData(messageCode, message, Properties.Resources.ffce00017);
                SystemException sysEx = new SystemException(messageData, ex);

                InitializationSystemExceptionHandler.GetInstance().HandleException(sysEx);

            }
        }

        /// <summary>
        /// private constructor
        /// </summary>
        private DefaultApplicationInitializer()
        {
        }

        /// <summary>
        /// returns the current instance 
        /// </summary>
        /// <returns></returns>
        internal static DefaultApplicationInitializer GetInstance()
        {
            return instance;
        }
    }
}
