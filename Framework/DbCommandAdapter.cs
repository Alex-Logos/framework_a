using System;
using System.Data;

namespace Com.ZimVie.Wcs.Framework
{
   public interface DbCommandAdaptor
    {


        /// <summary>
        /// method definition for ExecuteNonQuery
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        int ExecuteNonQuery(DbParameterList parameterList);


        /// <summary>
        /// method definition for ExecuteReader
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        IDataReader ExecuteReader(TransactionContext trxContext, DbParameterList parameterList);

        /// <summary>
        /// method definition for ExecuteScalar
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        Object ExecuteScalar(DbParameterList parameterList);

        /// <summary>
        /// method definition for ExecuteDataSet
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        DataSet ExecuteDataSet(DbParameterList parameterList);

        /// <summary>
        /// method definition for CreateParameterList
        /// </summary>
        /// <returns></returns>
        DbParameterList CreateParameterList();

    }
}
