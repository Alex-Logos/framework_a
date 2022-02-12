using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;

namespace Com.ZimVie.Wcs.Framework
{
   public class RemoteCbmInvoker
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(RemoteCbmInvoker));

        /// <summary>
        /// set the RemoteCbmInvokerProxy instance
        /// </summary>
        private static RemoteCbmInvokerProxy remoteCbmInvokerProxy;

        public static ValueObject Invoke(string cbmId, UserData userdata, ValueObject vo)
        {
            //check if null lock
            lock (typeof(RemoteCbmInvoker))
            {
                if (remoteCbmInvokerProxy == null)
                {
                    remoteCbmInvokerProxy = GetRemoteCbmInvokerProxyObject();
                }
            }
            try
            {
                remoteCbmInvokerProxy.IsServerRunning();
            }
            catch(Exception exception)
            {
                MessageData messageData = new MessageData("ffce00022", Properties.Resources.ffce00022, exception.Message);
                logger.Error(messageData, exception);

                throw new Framework.ApplicationException(messageData, exception);
            }
            try
            {
                return remoteCbmInvokerProxy.Execute(cbmId, userdata, vo);
            }
            catch (Framework.ApplicationException ex)
            {
                throw ex;
            }
            catch (Framework.SystemException ex)
            {
                throw new Framework.ApplicationException(ex.GetMessageData());
            }
        }


        private static RemoteCbmInvokerProxy GetRemoteCbmInvokerProxyObject()
        {
            StringBuilder serverurl = new StringBuilder();
            serverurl.Append("tcp://");
            serverurl.Append(ConfigurationDataTypeEnum.DEFAULT_REMOTE_MES_SERVER_HOST_IP.GetValue());
            serverurl.Append(":");
            serverurl.Append(ConfigurationDataTypeEnum.DEFAULT_REMOTE_MES_SERVER_HOST_PORT.GetValue());
            serverurl.Append("/");
            serverurl.Append(Properties.Settings.Default.DEFAULT_REMOTE_MES_SERVER_DEFAULT_SERVICE_NAME);
            //server url tcp://

            try
            {
                return (RemoteCbmInvokerProxy)Activator.GetObject(typeof(RemoteCbmInvokerProxy), serverurl.ToString());
            }
            catch (ArgumentNullException exception)
            {
                MessageData messageData = new MessageData("ffce00018", Properties.Resources.ffce00018, exception.Message);
                logger.Error(messageData, exception);

                throw new Framework.ApplicationException(messageData, exception);
            }
            catch (RemotingException exception)
            {
                MessageData messageData = new MessageData("ffce00018", Properties.Resources.ffce00018, exception.Message);
                logger.Error(messageData, exception);

                throw new Framework.ApplicationException(messageData, exception);
            }
            catch (MemberAccessException exception)
            {
                MessageData messageData = new MessageData("ffce00018", Properties.Resources.ffce00018, exception.Message);
                logger.Error(messageData, exception);

                throw new Framework.ApplicationException(messageData, exception);
            }

        }
    }
}
