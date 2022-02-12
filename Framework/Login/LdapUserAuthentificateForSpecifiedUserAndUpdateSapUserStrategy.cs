using System;
using System.Net;
using System.DirectoryServices.Protocols;
using Com.ZimVie.Wcs.Framework.Login;

namespace Com.ZimVie.Wcs.Framework
{
    internal class LdapUserAuthentificateForSpecifiedUserAndUpdateSapUserStrategy : UserAuthentificateStrategy
    {

        /// <summary>
        /// instance for logger class
        /// </summary>
        private static CommonLogger logger = CommonLogger.GetInstance(typeof(LdapUserAuthentificateForSpecifiedUserAndUpdateSapUserStrategy));

        /// <summary>
        /// store the instance of LdapAuthentificateStrategy
        /// </summary>
        private UserAuthentificateStrategy ldapAuthentificateStrategy;

        /// <summary>
        /// store the instance of LocalAuthentificateStrategy
        /// </summary>
        private UserAuthentificateStrategy localAuthentificateStrategy;

        /// <summary>
        /// initialize CheckSapUserForLdapUserCbm
        /// </summary>
        //private readonly CbmController checkLdapUserCbm = new CheckLdapUserCbm();

        /// <summary>
        /// constructor wit ldapauthentificatestrategy instance
        /// </summary>
        /// <param name="ldapAuthentificateStrategy"></param>
        public LdapUserAuthentificateForSpecifiedUserAndUpdateSapUserStrategy(UserAuthentificateStrategy ldapAuthentificateStrategy,
                                                                              UserAuthentificateStrategy localAuthentificateStrategy)
        {
            this.ldapAuthentificateStrategy = ldapAuthentificateStrategy;
            this.localAuthentificateStrategy = localAuthentificateStrategy;
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

            //1.check the user is ldap authentificate
            LoginInVo checkLdapUserInVo = new LoginInVo();
            //checkLdapUserInVo.InputUserId = user;
            //checkLdapUserInVo.InputPassword = pass;

            //to store is the user required ldap authentificate
            //bool isLdapAuthetificateForThisUser;

            //check the ldapuser is exists or not
            //UpdateResultVo ldapUserOutVo = (UpdateResultVo)DefaultCbmInvoker.Invoke(checkLdapUserCbm, checkLdapUserInVo);
            //if (ldapUserOutVo == null || ldapUserOutVo.AffectedCount == 0)
            //{
            //    isLdapAuthetificateForThisUser = false;
            //}
            //else if (ldapUserOutVo.AffectedCount == 1)
            //{
            //    isLdapAuthetificateForThisUser = true;
            //}
            //else
            //{
            //    //system exception
            //    MessageData sysExMessageData = new MessageData("llce00025", Properties.Resources.llce00025.ToString(), user);
            //    logger.Info(sysExMessageData);
            //    throw new Framework.SystemException(sysExMessageData);
            //}

            //authetificate
            //if (isLdapAuthetificateForThisUser)
            //{
            //    //ldapauthentificate
            //    return ldapAuthentificateStrategy.Authentificate(user, pass);
            //}
            //else
            //{
            //    //localuserauthentificate
            //    return localAuthentificateStrategy.Authentificate(user, pass);
            //}

            return true;
        }
    }
}