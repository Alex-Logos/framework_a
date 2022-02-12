/*
 * Copyright 2019 by Nidec Corporation, All rights reserved.
 *
 *  Change Tracking                                         
 *  2016/12/01 <Change NO.0001> created by Nobuo Fukuda (Nidec) 
 *  2019/08/28 <Change NO.0002> Add IDbTransaction by Chida (NTPL) , review by Fukuda (Nidec)   
 */

using System.Data;
using System;

namespace Com.ZimVie.Wcs.Framework
{

    /// <summary>
    /// Transactioncontext to store userdata, processingdbdatetime,connection, trancation to be used in cbm execution
    /// </summary>
    public class TransactionContext
    {

        /// <summary>
        /// get and set the userdata
        /// </summary>
        public UserData UserData { set; get; }

        /// <summary>
        /// get processing datetime. This is DB server date time (not PC).
        /// </summary>
        public DateTime ProcessingDBDateTime { internal set; get; }

        /// <summary>
        /// get and set dbconnection
        /// </summary>
        internal IDbConnection DbConnection { set; get; }

        /// <summary>
        /// get and set dbtransaction (used for particular DBMS)
        /// </summary>
        internal IDbTransaction DbTransaction { set; get; }

    }
}
