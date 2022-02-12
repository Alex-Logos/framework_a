using System;
using System.Data;

namespace Com.ZimVie.Wcs.Framework
{
    public abstract class AbstractDataAccessObject : DataAccessObject
    {
        /// <summary>
        /// method definition for Execute
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public abstract ValueObject Execute(TransactionContext trxContext, ValueObject vo);

        //
        /// <summary>
        /// get DefaultNpgCommandAdaptor
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        protected DbCommandAdaptor GetDbCommandAdaptor(TransactionContext trxContext, String sqlText)
        {
            IDbConnection dbConnection = trxContext.DbConnection;
            DbCommandAdaptor dbCommandAdapter = new DefaultNpgCommandAdaptor(sqlText, dbConnection);


            return dbCommandAdapter;
        }

        protected Type ConvertDBNull<Type>(IDataReader dr, String columName)
        {
            return (Type)(dr[columName].Equals(DBNull.Value) ? default(Type) : dr[columName]);
        }

        /// <summary>
        /// Replace wildcard string (_) (%) and escape string (/) with string
        /// </summary>
        /// <param name="replacementString">Character string to be searched for fuzzy searchS/param>
        /// <returns>If there is (%), (_), or (/), it is an escaped string.
        /// If there is no null, space, or (%), (_), (/), the original character string is returned.</returns>
        protected string ReplaceWildCardForLikeSearch(string replacementString)
        {
            if (string.IsNullOrEmpty(replacementString?.Trim()))
            {
                return replacementString;
            }

            string stReplacedString = replacementString;

            if (stReplacedString.Contains("/")) // / (Backslash) is an escape string and is replaced first
            {
                stReplacedString = stReplacedString.Replace("/", "//").ToString();
            }
            if (stReplacedString.Contains("%"))
            {
                stReplacedString = stReplacedString.Replace("%", "/%");
            }
            if (stReplacedString.Contains("_"))
            {
                stReplacedString = stReplacedString.Replace("_", "/_");
            }

            return stReplacedString;
        }

        /// <summary>
        /// Method that returns the backslash(/) specified by the escape string
        /// </summary>
        /// <returns>Returns the escape character string backslash(/)</returns>
        protected string GetEscapeStringWithSingleQuotationForLikeSearch()
        {
            return "'/'";
        }
    }
}
