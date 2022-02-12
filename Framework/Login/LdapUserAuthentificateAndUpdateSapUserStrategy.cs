using System;
using System.Net;
using System.DirectoryServices.Protocols;
using Com.ZimVie.Wcs.Framework.Login;

namespace Com.ZimVie.Wcs.Framework
{
    internal class LdapUserAuthentificateAndUpdateSapUserStrategy : UserAuthentificateStrategy
    {

        /// <summary>
        /// instance of logger class
        /// </summary>
        private static CommonLogger logger = CommonLogger.GetInstance(typeof(LdapUserAuthentificateAndUpdateSapUserStrategy));

        /// <summary>
        /// store LdapAuthentificateStrategy instance
        /// </summary>
        private UserAuthentificateStrategy ldapAuthentificateStrategy;

        ///// <summary>
        ///// intialize CheckAndUpdateLdapPasswordForSapUserCbm
        ///// </summary>
        //private readonly CbmController checkAndUpdateLdapPasswordForSapUserCbm = new CheckAndUpdateLdapPasswordForSapUserCbm();

        /// <summary>
        /// constructor wit ldapauthentificatestrategy instance
        /// </summary>
        /// <param name="ldapAuthentificateStrategy"></param>
        public LdapUserAuthentificateAndUpdateSapUserStrategy(UserAuthentificateStrategy ldapAuthentificateStrategy)
        {
            this.ldapAuthentificateStrategy = ldapAuthentificateStrategy;
        }

        /// <summary>
        /// ldap for specified user authentication and update sap password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Boolean Authentificate(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                return false;
            }

            //ldapauthentificate
            bool isAuthentifcate = ldapAuthentificateStrategy.Authentificate(user, pass);

            //authentification failed due to input username or password
            if (!isAuthentifcate)
            {
                return false;
            }

            //based on the ldap authentificate for sap flag, update the sapuser password
            LoginInVo userLoginInVo = new LoginInVo();
            //userLoginInVo.InputUserId = user;
            //userLoginInVo.InputPassword = pass;

            ////update sap loggin password based on the ldap password
            //UpdateResultVo sapUserUpdateOutVo = (UpdateResultVo)DefaultCbmInvoker.Invoke(checkAndUpdateLdapPasswordForSapUserCbm, userLoginInVo);

            return true;
        }
    }
}