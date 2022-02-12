using System;
using System.Configuration;
using System.Reflection;
using System.Collections;

namespace Com.ZimVie.Wcs.Framework
{
    public class BatchStaticCachedConfigurationReader : DefaultStaticCachedConfigurationReader
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(BatchStaticCachedConfigurationReader));

        public BatchStaticCachedConfigurationReader(String batchMainSettingsFileName)
        {
            if (string.IsNullOrWhiteSpace(batchMainSettingsFileName))
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00050", Properties.Resources.ffce00050);
                Exception nullEx = new NullReferenceException();
                logger.Error(messageData, nullEx);

                throw new Framework.SystemException(messageData, nullEx);
            }

            base.SetApplicationEnvironmentSettingsFileName(batchMainSettingsFileName);
        }
    }
}