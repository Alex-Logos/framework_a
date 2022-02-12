using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ZimVie.Wcs.Framework
{
    public class SimpleGetDBProcessingTimeCbm : CbmController
    {//

        /// <summary>
        /// initialize LoginDao
        /// </summary>
        private readonly SimpleGetDBProcessingTimeDao simpleGetDBProcessingTimeDao = new SimpleGetDBProcessingTimeDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return simpleGetDBProcessingTimeDao.Execute(trxContext, vo);

        }
    }
}
