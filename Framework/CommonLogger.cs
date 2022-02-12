using System;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.xml", Watch = true)]
namespace Com.ZimVie.Wcs.Framework
{
    public class CommonLogger
    {

        /// <summary>
        /// store logger of the log4net
        /// </summary>
        private readonly log4net.ILog logger;

        /// <summary>
        /// initialize SimpleMessageBuilder
        /// </summary>
        private readonly SimpleMessageBuilder messageBuilder = new SimpleMessageBuilder();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger"></param>
        private CommonLogger(log4net.ILog logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// get the instance of this  clasee
        /// </summary>
        /// <param name="loggerName"></param>
        /// <returns></returns>
        public static CommonLogger GetInstance(string loggerName)
        {

            //need to Change
            return new CommonLogger(log4net.LogManager.GetLogger(loggerName));
        }

        /// <summary>
        /// get the instance of this  clasee
        /// </summary>
        /// <param name="loggerType"></param>
        /// <returns></returns>
        public static CommonLogger GetInstance(Type loggerType)
        {

            //need to Change
            return new CommonLogger(log4net.LogManager.GetLogger(loggerType));
        }

        /// <summary>
        /// logging the fatal error
        /// </summary>
        /// <param name="messageData"></param>
        public void Fatal(MessageData messageData)
        {
            logger.Fatal(messageBuilder.BuildMessage(messageData));
        }

        /// <summary>
        /// logging the fatal error
        /// </summary>
        /// <param name="messageData"></param>
        /// <param name="ex"></param>
        public void Fatal(MessageData messageData, Exception ex)
        {

            if (ex == null)

                logger.Fatal(messageBuilder.BuildMessage(messageData));

            else

                logger.Fatal(messageBuilder.BuildMessage(messageData), ex);

        }

        /// <summary>
        /// logging the error
        /// </summary>
        /// <param name="messageData"></param>
        public void Error(MessageData messageData)
        {
            logger.Error(messageBuilder.BuildMessage(messageData));
        }

        /// <summary>
        /// logging the error
        /// </summary>
        /// <param name="messageData"></param>
        /// <param name="ex"></param>
        public void Error(MessageData messageData, Exception ex)
        {
            if (ex == null)

                logger.Error(messageBuilder.BuildMessage(messageData));

            else

                logger.Error(messageBuilder.BuildMessage(messageData), ex);

        }

        /// <summary>
        /// logging the warning
        /// </summary>
        /// <param name="messageData"></param>
        public void Warn(MessageData messageData)
        {
            logger.Warn(messageBuilder.BuildMessage(messageData));
        }

        /// <summary>
        /// logging the warning
        /// </summary>
        /// <param name="messageData"></param>
        /// <param name="ex"></param>
        public void Warn(MessageData messageData, Exception ex)
        {
            if (ex == null)

                logger.Warn(messageBuilder.BuildMessage(messageData));

            else

                logger.Warn(messageBuilder.BuildMessage(messageData), ex);
        }

        /// <summary>
        /// logging the information
        /// </summary>
        /// <param name="messageData"></param>
        public void Info(MessageData messageData)
        {
            logger.Info(messageBuilder.BuildMessage(messageData));
        }

        /// <summary>
        /// logging the information
        /// </summary>
        /// <param name="messageData"></param>
        /// <param name="ex"></param>
        public void Info(MessageData messageData, Exception ex)
        {
            if (ex == null)

                logger.Info(messageBuilder.BuildMessage(messageData));

            else

                logger.Info(messageBuilder.BuildMessage(messageData), ex);
        }

        /// <summary>
        /// logging the debugging info
        /// </summary>
        /// <param name="messageData"></param>
        public void Debug(MessageData messageData)
        {
            if (!logger.IsDebugEnabled)
            {
                return;
            }
            logger.Debug(messageBuilder.BuildMessage(messageData));
        }

        /// <summary>
        ///  logging the debugging info
        /// </summary>
        /// <param name="messageData"></param>
        /// <param name="ex"></param>
        public void Debug(MessageData messageData, Exception ex)
        {
            if (!logger.IsDebugEnabled)
            {
                return;
            }
            if (ex == null)

                logger.Debug(messageBuilder.BuildMessage(messageData));

            else

                logger.Debug(messageBuilder.BuildMessage(messageData), ex);

        }


        /// <summary>
        ///  get the IsInfoEnabled
        /// </summary>
        /// <returns></returns>
        public bool IsInfoEnabled()
        {
            return logger.IsInfoEnabled;
        }

        /// <summary>
        ///  get the IsDebugEnabled
        /// </summary>
        /// <returns></returns>
        public bool IsDebugEnabled()
        {
            return logger.IsDebugEnabled;
        }



    }
}
