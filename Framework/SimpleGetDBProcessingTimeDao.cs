using System;
using System.Text;
using System.Data;

namespace Com.ZimVie.Wcs.Framework
{
    internal class SimpleGetDBProcessingTimeDao : AbstractDataAccessObject
    {

        /// <summary>
        /// Execute the query
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select now() currentdatetime ");

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            TimeVo outVo = null;
            while (dataReader.Read())
            {
                outVo = new TimeVo();
                outVo.CurrentDateTime = ConvertDBNull<DateTime>(dataReader, "currentdatetime");
                break;
            }

            dataReader.Close();
            return outVo;
        }
    }
}
