using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ZimVie.Wcs.Framework
{
    public class ServerConfigurationDataTypeEnum
    {
        private string keyName;

        private static ConfigurationReader configurationReader = new DefaultStaticCachedConfigurationReader();

        private ServerConfigurationDataTypeEnum(string keyName)
        {
            this.keyName = keyName;

        }

        public override string ToString()
        {
            return this.keyName;
        }
        /// <summary>
        /// get the value give in the settings
        /// throw exception is the keyName is not available in the settings
        /// </summary>
        /// <returns>value in the settings</returns>
        public String GetValue()
        {
            return configurationReader.GetValue(this.keyName);
        }

        public static readonly ServerConfigurationDataTypeEnum APPLICATION_ENVIRONMENT_SETTINGS = new ServerConfigurationDataTypeEnum("APPLICATION_ENVIRONMENT_SETTINGS");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_REMOTE_MES_SERVER_HOST_IP = new ServerConfigurationDataTypeEnum("DEFAULT_REMOTE_MES_SERVER_HOST_IP");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_REMOTE_MES_SERVER_HOST_PORT = new ServerConfigurationDataTypeEnum("DEFAULT_REMOTE_MES_SERVER_HOST_PORT");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_CBM_LIST_XML = new ServerConfigurationDataTypeEnum("DEFAULT_CBM_LIST_XML");

        //SAP CONFIG
        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_MANDATORY_CHECK_ON = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_MANDATORY_CHECK_ON");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_PLANT_CODE = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_PLANT_CODE");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_NAME = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_NAME");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_LOGON_GROUP = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_LOGON_GROUP");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_MESSAGE_SERVER_HOST = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_MESSAGE_SERVER_HOST");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_SYSTEM_ID = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_SYSTEM_ID");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_SYSTEM_NUMBER = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_SYSTEM_NUMBER");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_CLIENT = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_CLIENT");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_LANGUAGE = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_LANGUAGE");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_POOL_SIZE = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_POOL_SIZE");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_PEAK_CONNECTIONS_LIMIT = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_PEAK_CONNECTIONS_LIMIT");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_IDLE_TIMEOUT = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_IDLE_TIMEOUT");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_SAP_CONFIG_IDLE_CHECKTIME = new ServerConfigurationDataTypeEnum("DEFAULT_SAP_CONFIG_IDLE_CHECKTIME");

        //PQM CONFIG
        public static readonly ServerConfigurationDataTypeEnum DEFAULT_PQM_CONFIG_MANDATORY_CHECK_ON = new ServerConfigurationDataTypeEnum("DEFAULT_PQM_CONFIG_MANDATORY_CHECK_ON");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_PQM_CONFIG_URL = new ServerConfigurationDataTypeEnum("DEFAULT_PQM_CONFIG_URL");

        public static readonly ServerConfigurationDataTypeEnum DEFAULT_CACHE_CLEANER_THREAD_MILLISECONDS_INTERVAL = new ServerConfigurationDataTypeEnum("DEFAULT_CACHE_CLEANER_THREAD_MILLISECONDS_INTERVAL");

    }

}
