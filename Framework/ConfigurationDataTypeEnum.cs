using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ZimVie.Wcs.Framework
{
    public class ConfigurationDataTypeEnum
    {
        private string keyName;

        private static ConfigurationReader configurationReader = new DefaultStaticCachedConfigurationReader();

        private ConfigurationDataTypeEnum(string keyName)
        {
            this.keyName = keyName;

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

        public static readonly ConfigurationDataTypeEnum APPLICATION_ENVIRONMENT_SETTINGS = new ConfigurationDataTypeEnum("APPLICATION_ENVIRONMENT_SETTINGS");

        public static readonly ConfigurationDataTypeEnum CONNECTION_STRING = new ConfigurationDataTypeEnum("CONNECTION_STRING");

        public static readonly ConfigurationDataTypeEnum SERVER_TIME_ZONE = new ConfigurationDataTypeEnum("SERVER_TIME_ZONE");

        internal static readonly ConfigurationDataTypeEnum APPLICATION_HEADER = new ConfigurationDataTypeEnum("APPLICATION_HEADER");

        internal static readonly ConfigurationDataTypeEnum LDAP_CONNECTION_HOST = new ConfigurationDataTypeEnum("LDAP_CONNECTION_HOST");

        public static readonly ConfigurationDataTypeEnum AUTHENTIFICATE_FLAG = new ConfigurationDataTypeEnum("AUTHENTIFICATE_FLAG");

        internal static readonly ConfigurationDataTypeEnum APPLICATION_ENVIRONMENT_HEADER = new ConfigurationDataTypeEnum("APPLICATION_ENVIRONMENT_HEADER");

        internal static readonly ConfigurationDataTypeEnum DEFAULT_REMOTE_MES_SERVER_HOST_IP = new ConfigurationDataTypeEnum("DEFAULT_REMOTE_MES_SERVER_HOST_IP");

        internal static readonly ConfigurationDataTypeEnum DEFAULT_REMOTE_MES_SERVER_HOST_PORT = new ConfigurationDataTypeEnum("DEFAULT_REMOTE_MES_SERVER_HOST_PORT");

    }
}
