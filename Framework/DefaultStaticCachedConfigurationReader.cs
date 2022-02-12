using System;
using System.Configuration;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Com.ZimVie.Wcs.Framework
{
    public class DefaultStaticCachedConfigurationReader : ConfigurationReader
    {

        /// <summary>
        /// store the section group name of the configuration file. userSettings for windows application settings/applicationSettings for webservices
        /// </summary>
        private string SECTION_GROUP_NAME = "userSettings";

        /// <summary>
        /// Constant string of the application environment settings as defined in the default settings file
        /// </summary>
        private const string APPLICATION_ENVIRONMENT_SETTINGS = "APPLICATION_ENVIRONMENT_SETTINGS";

        /// <summary>
        /// constant string of the default settings file name
        /// </summary>
        private const string DEFAULT_SETTINGS_NAME = ".Settings";

        /// <summary>
        /// store the section group name of the configuration file. userSettings for windows application settings/applicationSettings for webservices
        /// </summary>
        private const string SECTION_GROUP_NAME_APPLICATION_SETTINGS = "applicationSettings";

        /// <summary>
        /// store the configuration value in cache memory
        /// </summary>
        private static Hashtable configValueMap = new Hashtable();

        /// <summary>
        /// store the configuration value list in cache memory
        /// </summary>
        private static IDictionary<string, IList<string>> configValueListMap = new Dictionary<string, IList<string>>();

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultStaticCachedConfigurationReader));

        /// <summary>
        /// update the applicationenvironmentsettings filename
        /// </summary>
        /// <param name="applicationSettingsFileName"></param>
        internal void SetApplicationEnvironmentSettingsFileName(String applicationSettingsFileName)
        {
            if (string.IsNullOrWhiteSpace(applicationSettingsFileName))
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00048", Properties.Resources.ffce00048);
                Exception nullEx = new NullReferenceException();
                logger.Error(messageData, nullEx);

                throw new SystemException(messageData, nullEx);
            }

            if (configValueMap == null)
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00049", Properties.Resources.ffce00049);
                Exception nullEx = new NullReferenceException();
                logger.Error(messageData, nullEx);

                throw new SystemException(messageData, nullEx);
            }

            //update applicationenvironmentsettings value if available in map
            if (configValueMap.ContainsKey(APPLICATION_ENVIRONMENT_SETTINGS))
            {
                configValueMap[APPLICATION_ENVIRONMENT_SETTINGS] = applicationSettingsFileName;
            }
            else
            {
                //add applicationenvironmentsettings value if not available in map
                configValueMap.Add(APPLICATION_ENVIRONMENT_SETTINGS, applicationSettingsFileName);
            }


        }


        /// <summary>
        /// Synchronized method
        /// </summary>
        /// <param name="keyName">keyName to be found from the settings file</param>
        /// <returns>value from the settings file for the keyname input</returns>
        public string GetValue(string keyName)
        {
            //check null for keyname parameter
            if (string.IsNullOrWhiteSpace(keyName))
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00031", Properties.Resources.ffce00031, new string[] { keyName });
                logger.Error(messageData, new NullReferenceException());

                throw new SystemException(messageData, new NullReferenceException());
            }

            lock (configValueMap)  //lock the following process
            {
                return GetValueImple(keyName);
            }

        }

        /// <summary>
        ///  Get List Values form setting file.
        ///  If the value is single value, the list which has only one element is returned.
        /// </summary>
        /// <param name="keyName">keyName to be found from the settings file</param>
        /// <returns>value list</returns>
        public IList<string> GetValueList(string keyName)
        {
            //check null for keyname parameter
            if (string.IsNullOrWhiteSpace(keyName))
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00031", Properties.Resources.ffce00031, new string[] { keyName });
                logger.Error(messageData, new NullReferenceException());

                throw new SystemException(messageData, new NullReferenceException());
            }

            lock (configValueListMap)  //lock the following process
            {
                return GetValueListImple(keyName);
            }

        }


        /// <summary>
        /// need to execute from Synchronized method
        /// </summary>
        /// <param name="keyName">keyName to be found from the settings file</param>
        /// <returns>value from the settings file for the keyname input</returns>
        private string GetValueImple(string keyName)
        {
            //check keyname available in cache memory
            if (configValueMap.ContainsKey(keyName))
            {
                return (string)configValueMap[keyName];
            }

            //get configuration value for the keyname paramter
            string value = GetConfigurationValue(keyName);

            //set to cache
            configValueMap.Add(keyName, value);

            return value; //return the value

        }

        /// <summary>
        /// need to execute from Synchronized method
        /// </summary>
        /// <param name="keyName">keyName to be found from the settings file</param>
        /// <returns>value list from the settings file for the keyname input</returns>
        private IList<string> GetValueListImple(string keyName)
        {
            //check keyname available in cache memory
            if (configValueListMap.ContainsKey(keyName))
            {
                return configValueListMap[keyName];
            }

            //get configuration value for the keyname paramter
            string value = GetConfigurationValue(keyName);

            //convert to value list
            IList<string> valueList = GetValueListFrom2015Settings(value);

            //set to cache
            configValueListMap.Add(keyName, valueList);

            return valueList; //return the value

        }

        /// <summary>
        /// need to execute from Synchronized method
        /// </summary>
        /// <param name="keyName">keyName to be found from the settings file</param>
        /// <exception cref="System.NullReferenceException">if configuration file not found throws null exception</exception>
        /// <returns>value from the settings file for the keyname input </returns>
        private string GetConfigurationValue(string keyName)
        {
            //get the configuration of the executing assembly
            Configuration config = GetConfiguration();

            if (config == null) //if config is null return NullReferenceException
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00032", Properties.Resources.ffce00032);
                logger.Error(messageData, new NullReferenceException());

                throw new SystemException(messageData, new NullReferenceException());

            }

            //store the value of the configuration settings for keyname in cache memory
            return GetConfigurationValue(config, keyName);

        }

        /// <summary>
        /// get settings of the executing assembly
        /// </summary>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">handles ConfigurationErrorsException while getting the section from configuration file</exception>
        /// <exception cref="Com.ZimVie.Wcs.Framework.SystemException">if configuration file not found</exception>
        /// <returns>Configuration settings of the executing assembly</returns>
        private Configuration GetConfiguration()
        {
            Configuration config;
            try
            {
                Assembly ass = Assembly.GetEntryAssembly();
                if (ass != null)
                {
                    config = ConfigurationManager.OpenExeConfiguration(ass.Location);
                }
                else //if assembly is null try to get web service webconfig
                {
                    config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                    SECTION_GROUP_NAME = SECTION_GROUP_NAME_APPLICATION_SETTINGS;
                }

            }
            catch (ConfigurationErrorsException ex)
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00003", Properties.Resources.ffce00003, ex.Message);
                logger.Error(messageData, ex);

                throw new SystemException(messageData, ex);
            }

            if (!config.HasFile) //if config file is not available
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00004", Properties.Resources.ffce00004);
                logger.Error(messageData);

                throw new SystemException(messageData);
            }

            return config;
        }

        /// <summary>
        /// get and return the value of the configuration settings for keyname
        /// </summary>
        /// <param name="config">Configuration of the assembly</param>
        /// <param name="keyName">keyName to be found from the settings file</param>
        /// <exception cref="System.NullReferenceException">if keyname not found in the configuration file</exception>
        /// <exception cref="System.NullReferenceException">if DEFAULT_APPLICATION_ENVIRONMENT_SETTINGS not found in the configuration file</exception>
        /// <exception cref="System.NullReferenceException">if element is not found </exception>
        /// <exception cref="System.NullReferenceException">if value is not found </exception>
        /// <returns>return the value in the configuration for the keyname</returns>
        private string GetConfigurationValue(Configuration config, string keyName)
        {

            //userSettings for windows application settings/applicationSettings for webservices
            ConfigurationSectionGroup sectionGroup = config.SectionGroups[SECTION_GROUP_NAME];

            if (sectionGroup == null) // failed to get sectiongroup
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00005", Properties.Resources.ffce00005);
                logger.Error(messageData, new NullReferenceException());

                throw new SystemException(messageData, new NullReferenceException());
            }

            //read default settings file first
            SettingElement element = GetConfigurationElement(sectionGroup, DEFAULT_SETTINGS_NAME, keyName);

            if (element == null)  // if element not found in default settings file then get from applicatoin setting file
            {
                string applicationSettingsFileName = configValueMap.ContainsKey(APPLICATION_ENVIRONMENT_SETTINGS) ? (string)configValueMap[APPLICATION_ENVIRONMENT_SETTINGS] : null;

                if (applicationSettingsFileName == null) //if APPLICATION_ENVIRONMENT_SETTINGS not found in cache memory throw exception
                {
                    //temporary solution to get APPLICATION_ENVIRONMENT_SETTINGS
                    applicationSettingsFileName = GetConfigurationValue(config, APPLICATION_ENVIRONMENT_SETTINGS);

                    if (applicationSettingsFileName == null)
                    {
                        //implement system exception
                        MessageData messageData = new MessageData("ffce00030", Properties.Resources.ffce00030, keyName);
                        logger.Error(messageData, new NullReferenceException());

                        throw new SystemException(messageData, new NullReferenceException());
                    }
                }

                element = GetConfigurationElement(sectionGroup, applicationSettingsFileName, keyName);

            }

            if (element == null) // failed to get element
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00036", Properties.Resources.ffce00036, keyName);
                logger.Error(messageData, new NullReferenceException());

                throw new SystemException(messageData, new NullReferenceException());
            }

            //get the exact value from innertext of the element
            string value = element.Value.ValueXml.InnerText;

            if (value == null) //value is not available for the keyname
            {
                //implement system exception
                MessageData messageData = new MessageData("ffce00034", Properties.Resources.ffce00034, keyName);
                logger.Error(messageData, new NullReferenceException());

                throw new SystemException(messageData, new NullReferenceException());
            }

            return value;

        }

        /// <summary>
        /// method to read configuration settings data
        /// </summary>
        /// <param name="sectionGroup">ConfigurationSectionGroup of the settings file</param>
        /// <param name="settingsName">settingsName to be fetch and find the value</param>
        /// <param name="keyName">keyName to be found from the settings file</param>
        /// <exception cref="System.NullReferenceException">if sectionName not found </exception>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">handles ConfigurationErrorsException while getting the section from configuration file</exception>
        /// <exception cref="System.NullReferenceException">if section is null throws systemexception </exception>
        /// <returns>SettingElement of the keyname</returns>
        private SettingElement GetConfigurationElement(ConfigurationSectionGroup sectionGroup, string settingsName, string keyName)
        {

            // Check Default Settings section
            foreach (ConfigurationSection configurationSection in sectionGroup.Sections)
            {
                string sectionName = configurationSection.SectionInformation.SectionName;

                if (sectionName == null) // failed to get value
                {
                    //implement system exception
                    MessageData messageData = new MessageData("ffce00033", Properties.Resources.ffce00033);
                    logger.Error(messageData, new NullReferenceException());

                    throw new SystemException(messageData, new NullReferenceException());
                }

                if (!sectionName.ToUpper().EndsWith(settingsName.ToUpper()))
                {
                    continue;
                }

                ClientSettingsSection section;
                try
                {
                    section = (ClientSettingsSection)ConfigurationManager.GetSection(sectionName);
                }
                catch (ConfigurationErrorsException ex)
                {
                    //implement system exception
                    MessageData messageData = new MessageData("ffce00006", Properties.Resources.ffce00006, ex.Message);
                    logger.Error(messageData, ex);

                    throw new SystemException(messageData, ex);
                }

                if (section == null) // failed to get section
                {
                    //implement system exception
                    MessageData messageData = new MessageData("ffce00035", Properties.Resources.ffce00035, sectionName);
                    logger.Error(messageData, new NullReferenceException());

                    throw new SystemException(messageData, new NullReferenceException());
                }

                return section.Settings.Get(keyName);

            }

            return null; // return null if failed to get element in the settings file
        }

        /// <summary>
        /// Get the value list from setting file XML of VisualStudio 2015.
        /// </summary>
        /// <param name="value">inner value of XML</param>
        /// <returns>List of value. return empty list if the parameter is null.</returns>
        private IList<string> GetValueListFrom2015Settings(string value)
        {
            IList<string> valueList = new List<string>();

            if (value == null) return valueList; //return empty list

            if (value.Contains("\r\n")) // list value
            {

                string[] editingValue = value.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string eachValue in editingValue)
                {
                    if (string.IsNullOrWhiteSpace(eachValue)) continue; //skip the empty entries

                    valueList.Add(eachValue.Trim()); //add values with trimming.
                }

            }
            else  //single value
            {
                valueList.Add(value);
            }

            return valueList;

        }

    }

}
