/*
 * Copyright 2019 by Nidec Corporation, All rights reserved.
 *
 *  Change Tracking
 *  2020/03/27 <Change NO.0001> created by Saori Yamanouchi (Nidec)
 */
using System;

namespace Com.ZimVie.Wcs.Framework
{
    /// <summary>
    /// Cbm to get DateTime of DB server.
    /// </summary>
    public class DBServerDateTimeCbm : CbmController
    {
        /// <summary>
        /// Get DB Server DateTime.
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DBServerDateTimeVo dBServerDateTimeVo = new DBServerDateTimeVo();
            dBServerDateTimeVo.ServerDateTime = trxContext.ProcessingDBDateTime;

            return dBServerDateTimeVo;
        }

        /// <summary>
        /// Vo of the inner class used to get DateTime of DB server.
        /// </summary>
        public class DBServerDateTimeVo : ValueObject
        {
            /// <summary>
            /// Get DB Server DateTime.
            /// </summary>
            public DateTime ServerDateTime { get; set; }
        }
    }
}
