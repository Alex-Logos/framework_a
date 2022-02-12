using System;
using System.Data;

namespace Com.ZimVie.Wcs.Framework
{//
    public abstract class AbstractUpdateLogDataAccessObject : AbstractDataAccessObject
    {
  

        //
        /// <summary>
        /// get DefaultNpgCommandAdaptor
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        protected new DbCommandAdaptor GetDbCommandAdaptor(TransactionContext trxContext, String sqlText)
        {
            
//            if (trxContext == null) throw new SystemException(new NullReferenceException());
            IDbConnection dbConnection = trxContext.DbConnection;
            DbCommandAdaptor dbCommandAdapter = new UpdateLogHistoryCommandAdaptorProxy(new DefaultNpgCommandAdaptor(sqlText, dbConnection));


            return dbCommandAdapter;
        }
 
    }
}
