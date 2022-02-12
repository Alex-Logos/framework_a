/*
 * Copyright 2020 by Nidec Corporation, All rights reserved.
 *
 *  Change Tracking
 *  2020/6/2 <Change NO.0001> LocalUserAuthentificateStrategy updated: Authentificate method password encryption removed by Takusuke Fujii (Nidec)
 */
using System;
using Com.ZimVie.Wcs.Framework.Login;

namespace Com.ZimVie.Wcs.Framework
{
    internal class LocalUserAuthentificateStrategy : UserAuthentificateStrategy
    {
        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static CommonLogger logger = CommonLogger.GetInstance(typeof(LocalUserAuthentificateStrategy));


        /// <summary>
        /// initialize PopUpMessageController
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();


        /// <summary>
        /// local user authentication
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

            LoginInVo inVo = new LoginInVo
            {
                //InputUserId = user,
                //InputPassword = encryptedPass
            };

            try
            {
                LoginOutVo loginOutVo = (LoginOutVo)DefaultCbmInvoker.Invoke(new CheckLoginCbm(), inVo);
                //if (loginOutVo.ResultCount > 0) return true;
            }
            catch (ApplicationException exception)//password error.
            {
                logger.Error(exception.GetMessageData(), exception);
                throw exception;
            }
            return false;

        }
    }
}