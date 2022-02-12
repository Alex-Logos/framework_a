using System;
using System.Data;
using Npgsql;

namespace Com.ZimVie.Wcs.Framework
{
    public class PqmCbmInvoker
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultCbmInvoker));

        /// <summary>
        /// executing transaction 
        /// </summary>
        /// <param name="cbm"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public static ValueObject Invoke(CbmController cbm, ValueObject vo, string connectionString)
        {
            if (connectionString == null || connectionString.Trim() == string.Empty)
            {
                //throw new SystemException
            }

            return DefaultCbmInvoker.Invoke(cbm, vo, connectionString);

        }
    }
}
