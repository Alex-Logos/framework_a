/*
 * Copyright 2020 by Nidec Corporation, All rights reserved.
 *
 *  Change Tracking
 *  2020/6/2 <Change NO.0001> LdapUserAuthentificateStrategy updated: Authentificate method password decryptipn added by Takusuke Fujii (Nidec)
 */
using System;
using System.Net;
using System.DirectoryServices.Protocols;

namespace Com.ZimVie.Wcs.Framework
{
    internal class LdapUserAuthentificateStrategy : UserAuthentificateStrategy
    {

        private static CommonLogger logger = CommonLogger.GetInstance(typeof(LdapUserAuthentificateStrategy));


        /// <summary>
        /// ldap authentication
        /// </summary>
        /// <param name="user"></param>
        /// <param name="encryptedPass"></param>
        /// <returns></returns>
        public Boolean Authentificate(string user, string encryptedPass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(encryptedPass))
            {
                return false;
            }

            string ldapConnectionHost = ConfigurationDataTypeEnum.LDAP_CONNECTION_HOST.GetValue(); //Properties.Settings.Default.LdapConnectionHost;
            string searchDN = "dc=nidec,dc=com";
            string searchFilterFormat = "(&(exgEnabledFlag=enabled)(uid={0}))";
            string distinguishedName = string.Empty;

            // search DistinguishedName
            LdapConnection ldapconnection = new LdapConnection(ldapConnectionHost);
            ldapconnection.AuthType = AuthType.Anonymous;
            ldapconnection.SessionOptions.ProtocolVersion = 3;
            ldapconnection.Bind();

            SearchRequest searchRequest = new SearchRequest(
                                                 searchDN,
                                                 string.Format(searchFilterFormat, user),
                                                 SearchScope.Subtree
                                                   );
            SearchResponse response = null;
            try
            {
                response = (SearchResponse)ldapconnection.SendRequest(searchRequest);
            }
            catch (ObjectDisposedException ex)
            {
                MessageData messageData = new MessageData("llce00014", Properties.Resources.llce00014, ex.Message);
                logger.Info(messageData, ex);
                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (ArgumentNullException ex)
            {
                MessageData messageData = new MessageData("llce00015", Properties.Resources.llce00015, ex.Message);
                logger.Info(messageData, ex);
                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (NotSupportedException ex)
            {
                MessageData messageData = new MessageData("llce00016", Properties.Resources.llce00016, ex.Message);
                logger.Info(messageData, ex);
                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (LdapException ex)
            {
                MessageData messageData = new MessageData("llce00017", Properties.Resources.llce00017, ex.Message);
                logger.Info(messageData, ex);
                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (DirectoryOperationException ex)
            {
                MessageData messageData = new MessageData("llce00018", Properties.Resources.llce00018, ex.Message);
                logger.Info(messageData, ex);
                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }


            if (response != null)
            {
                SearchResultEntryCollection collection = response.Entries;

                foreach (SearchResultEntry searchResultEntry in collection)
                {
                    distinguishedName = searchResultEntry.DistinguishedName;
                    break;
                }
            }

            // authenticate
            if (string.IsNullOrEmpty(distinguishedName))
            {
                return false;// user does not exist.
            }

            EncryptDecrypt encryptDecrypt = new EncryptDecrypt(); // Password decryption added in accordance with login form side encryption addition by Fujii 2020/6/2
            string decryptedPass = encryptDecrypt.Decrypt(encryptedPass);

            ldapconnection.AuthType = AuthType.Basic;
            ldapconnection.SessionOptions.ProtocolVersion = 3;
            try
            {
                ldapconnection.Bind(new NetworkCredential(distinguishedName, decryptedPass));
            }
            catch (ObjectDisposedException ex)
            {
                MessageData messageData = new MessageData("llce00019", Properties.Resources.llce00019, ex.Message);
                logger.Info(messageData, ex);
                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (LdapException ex)
            {
                if (ex.ErrorCode == 49)
                {
                    return false;
                }
                MessageData messageData = new MessageData("llce00020", Properties.Resources.llce00020, ex.Message);
                logger.Info(messageData, ex);
                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (InvalidOperationException ex)
            {
                MessageData messageData = new MessageData("llce00021", Properties.Resources.llce00021, ex.Message);
                logger.Info(messageData, ex);
                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            return true;

        }
    }
}