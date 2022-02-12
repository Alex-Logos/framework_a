
namespace Com.ZimVie.Wcs.Framework
{
   public interface TransactionContextFactory
    {

        /// <summary>
        /// get the userdata
        /// </summary>
        /// <returns></returns>
        TransactionContext GetTransactionContext(UserData userData);


        CbmController GetDBProcessingTimeCbm();
    }
}
