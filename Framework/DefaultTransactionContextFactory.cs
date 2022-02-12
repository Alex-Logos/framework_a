
namespace Com.ZimVie.Wcs.Framework
{
   internal class DefaultTransactionContextFactory : TransactionContextFactory
    {

        /// <summary>
        /// get the userdata
        /// </summary>
        /// <returns></returns>
        public TransactionContext GetTransactionContext(UserData userData)
        {
            //get userData from memory 
            TransactionContext trxContext = new TransactionContext {UserData = UserData.GetUserData()};

            //sample. need to get userdata from memory(Static area).
            return trxContext;
        }

        public CbmController GetDBProcessingTimeCbm()
        {

            return new SimpleGetDBProcessingTimeCbm();

        }
    }
}
