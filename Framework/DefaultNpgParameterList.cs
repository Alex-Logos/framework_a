using System.Collections.Generic;
using System.Data;
using System;
namespace Com.ZimVie.Wcs.Framework
{
    partial class DefaultNpgParameterList : DbParameterList
    {

        /// <summary>
        /// initialize parameterlist
        /// </summary>
        private List<IDataParameter> parameterList = new List<IDataParameter>();


        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultNpgParameterList));

        /// <summary>
        /// get and set  parameter
        /// </summary>
        public IDataParameter[] Parameters
        {
            get
            { return parameterList?.ToArray(); }

            set
            {
                if (value == null) parameterList = null;
                if (value != null) parameterList = new List<IDataParameter>(value);
            }
        }

        /// <summary>
        /// create IDataparamter with parameter details
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private IDataParameter CreateParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input, int size = 0)
        {
            IDataParameter dataparameter = new Npgsql.NpgsqlParameter();

            if (name == null)
            {
                MessageData messageData = new MessageData("ffce00002", Properties.Resources.ffce00002, null);
                logger.Error(messageData, new NullReferenceException());
                throw new SystemException(messageData, new NullReferenceException());
            }
            dataparameter.ParameterName = name;
            dataparameter.Value = value == null ? DBNull.Value : value;
            dataparameter.Direction = direction;

            return dataparameter;
        }

        /// <summary>
        /// add  parameter without datatype
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public void AddParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input, int size = 0)
        {
            IDataParameter dataparameter = CreateParameter(name, value, direction, size);

            parameterList.Add(dataparameter);
        }

        /// <summary>
        /// add parameter for integer
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public void AddParameterInteger(string name, int value, ParameterDirection direction = ParameterDirection.Input, int size = 0)
        {
            IDataParameter dataparameter = CreateParameter(name, value, direction, size);
            dataparameter.DbType = DbType.Int32;

            parameterList.Add(dataparameter);
        }

        /// <summary>
        /// add parameter for string
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public void AddParameterString(string name, string value, ParameterDirection direction = ParameterDirection.Input, int size = 0)
        {
            IDataParameter dataparameter = CreateParameter(name, value, direction, size);
            dataparameter.DbType = DbType.String;

            parameterList.Add(dataparameter);
        }

        /// <summary>
        /// add parameter for datetime
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public void AddParameterDateTime(string name, DateTime value, ParameterDirection direction = ParameterDirection.Input, int size = 0)
        {
            IDataParameter dataparameter = CreateParameter(name, value, direction, size);
            dataparameter.DbType = DbType.DateTime;

            parameterList.Add(dataparameter);
        }

        /// <summary>
        /// add parameter for decimal
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public void AddParameterDecimal(string name, Decimal value, ParameterDirection direction = ParameterDirection.Input, int size = 0)
        {
            IDataParameter dataparameter = CreateParameter(name, value, direction, size);
            dataparameter.DbType = DbType.Decimal;

            parameterList.Add(dataparameter);
        }

    }
}
