using System;
using System.Collections.Generic;
using System.Data;

using Npgsql;

namespace Com.ZimVie.Wcs.Framework
{
    internal class DefaultNpgCommandAdaptor : IDisposable, DbCommandAdaptor
    {
        /// <summary>
        /// store idbcommand
        /// </summary>
        private readonly IDbCommand dbCommand;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dbConnection"></param>
        internal DefaultNpgCommandAdaptor(string sql, IDbConnection dbConnection)
        {//
            this.dbCommand = new NpgsqlCommand(sql, (NpgsqlConnection)dbConnection);

        }
        public void Dispose()
        {
            dbCommand.Dispose();
        }

        /// <summary>
        /// execute with ExecuteNonQuery
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbParameterList parameterList)
        {
            SetCommandParameter(dbCommand, parameterList);

            return this.dbCommand.ExecuteNonQuery();
        }

        private IDbCommand SetCommandParameter(IDbCommand command, DbParameterList parameterList)
        {
            foreach (IDataParameter parameter in parameterList.Parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        /// <summary>
        /// execute with ExecuteReader
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(TransactionContext trxContext, DbParameterList parameterList)
        {

            SetCommandParameter(dbCommand, parameterList);

            IDataReader dataReader = this.dbCommand.ExecuteReader();

            return dataReader;


        }

        /// <summary>
        /// execute with ExecuteScalar
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public object ExecuteScalar(DbParameterList parameterList)
        {
            SetCommandParameter(dbCommand, parameterList);

            return this.dbCommand.ExecuteScalar();
        }

        /// <summary>
        /// execute with dataadapter
        /// </summary>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbParameterList parameterList)
        {
            SetCommandParameter(dbCommand, parameterList);

            DataSet returnDataSet = new DataSet();

            IDbDataAdapter dataadapter = new NpgsqlDataAdapter((NpgsqlCommand)dbCommand);

            dataadapter.Fill(returnDataSet);

            return returnDataSet;

        }

        /// <summary>
        /// create parameterlist object
        /// </summary>
        /// <returns></returns>
        public DbParameterList CreateParameterList()
        {
            return new DefaultNpgParameterList();

        }

    }
}
