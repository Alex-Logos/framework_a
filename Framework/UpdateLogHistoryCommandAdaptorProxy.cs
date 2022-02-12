using System;
using System.Collections.Generic;
using System.Data;

using Npgsql;

namespace Com.ZimVie.Wcs.Framework
{
    internal class UpdateLogHistoryCommandAdaptorProxy :  DbCommandAdaptor
    {

        private DbCommandAdaptor internalAdaptor;
        internal UpdateLogHistoryCommandAdaptorProxy(DbCommandAdaptor dbCommandAdaptor)
        {
            internalAdaptor = dbCommandAdaptor;
        }


        /// <summary>
        /// store idbcommand
        /// </summary>
        //private readonly IDbCommand dbCommand;



        /// <summary>
        /// execute with ExecuteNonQuery
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbParameterList parameterList)
        {


            return internalAdaptor.ExecuteNonQuery(parameterList);
        }


        /// <summary>
        /// execute with ExecuteReader
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(TransactionContext trxContext, DbParameterList parameterList)
        {


            return internalAdaptor.ExecuteReader(trxContext, parameterList);


        }

        /// <summary>
        /// execute with ExecuteScalar
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public object ExecuteScalar(DbParameterList parameterList)
        {
            return internalAdaptor.ExecuteScalar(parameterList);
        }

        /// <summary>
        /// execute with dataadapter
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbParameterList parameterList)
        {

            return internalAdaptor.ExecuteDataSet(parameterList);

           

        }

        /// <summary>
        /// create parameterlist object
        /// </summary>
        /// <returns></returns>
        public DbParameterList CreateParameterList()
        {
            return internalAdaptor.CreateParameterList();

        }

    }
}
