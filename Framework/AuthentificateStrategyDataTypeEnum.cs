using System;

namespace Com.ZimVie.Wcs.Framework
{
    /// <summary>
    ///
    /// </summary>
    internal class AuthentificateStrategyDataTypeEnum
    {
        /// <summary>
        /// initialize UserAuthentificateStrategy
        /// </summary>
        private UserAuthentificateStrategy userAuthentificateStrategy;

        /// <summary>
        /// get keyname from the user
        /// </summary>
        private string keyName;

        /// <summary>
        /// private constructor
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="userAuthentificateStrategy"></param>
        private AuthentificateStrategyDataTypeEnum(string keyName, UserAuthentificateStrategy userAuthentificateStrategy)
        {
            this.keyName = keyName;
            this.userAuthentificateStrategy = userAuthentificateStrategy;
        }

        /// <summary>
        /// Get the authentificatestrategy instance by the authentificate flag from user
        /// 1- Ldap
        /// 2- local user
        /// 3- ldap and update sap passwork
        /// 4- ldap for specified user and update sap password
        /// default - null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static AuthentificateStrategyDataTypeEnum GetAuthentificateStrategyDataTypeEnum(String value)
        {
            if (value == null) return null;

            switch (value.Trim())
            {
                case "1":
                    return LDAP_AUTHENTIFICATE;
                case "2":
                    return LOCAL_USER_AUTHENTIFICATE;
                case "3":
                    return LDAP_AUTHENTIFICATE_AND_UPDATE_SAP_USER;
                case "4":
                    return LDAP_AUTHENTIFICATE_FOR_SPECIFIED_USER_AND_SPECIFIED_USER;
                default:
                    return null;

            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal String GetKeyName()
        {
            return this.keyName;
        }


        /// <summary>
        /// create new instance of the UserAuthentificateStrategy based on the input in application settings file
        /// </summary>
        /// <returns></returns>
        internal UserAuthentificateStrategy CreateAuthentificateStrategy()
        {
            return userAuthentificateStrategy;
        }

        //All Ldap USer
        internal static readonly AuthentificateStrategyDataTypeEnum LDAP_AUTHENTIFICATE = new AuthentificateStrategyDataTypeEnum("1", new LdapUserAuthentificateStrategy());

        //All Local User
        internal static readonly AuthentificateStrategyDataTypeEnum LOCAL_USER_AUTHENTIFICATE = new AuthentificateStrategyDataTypeEnum("2", new LocalUserAuthentificateStrategy());

        //All Ldap, update sap
        internal static readonly AuthentificateStrategyDataTypeEnum LDAP_AUTHENTIFICATE_AND_UPDATE_SAP_USER = new AuthentificateStrategyDataTypeEnum("3", new LdapUserAuthentificateAndUpdateSapUserStrategy(new LdapUserAuthentificateStrategy()));

        //check ldap for specified user and update sap
        internal static readonly AuthentificateStrategyDataTypeEnum LDAP_AUTHENTIFICATE_FOR_SPECIFIED_USER_AND_SPECIFIED_USER = new AuthentificateStrategyDataTypeEnum("4", new LdapUserAuthentificateForSpecifiedUserAndUpdateSapUserStrategy(LDAP_AUTHENTIFICATE_AND_UPDATE_SAP_USER.CreateAuthentificateStrategy(),
                                                                                                                                                                                                                                                new LocalUserAuthentificateStrategy()));
    }

}
