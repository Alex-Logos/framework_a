
namespace Com.ZimVie.Wcs.Framework
{
   public class UserDataSpecifiedTransactionContextFactory : TransactionContextFactory
    {

        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly UserDataSpecifiedTransactionContextFactory instance = new UserDataSpecifiedTransactionContextFactory();

        /// <summary>
        /// get the userdata
        /// </summary>
        /// <returns></returns>
        public TransactionContext GetTransactionContext(UserData userData)
        {
            //get userData from input
            TransactionContext trxContext = new TransactionContext();
            trxContext.UserData = userData;

            //sample. need to get userdata from memory(Static area).
            return trxContext;
        }

        public CbmController GetDBProcessingTimeCbm()
        {

            return new SimpleGetDBProcessingTimeCbm();

        }
        /// <summary>
        /// private constructor
        /// </summary>
        private UserDataSpecifiedTransactionContextFactory()
        {
        }

        /// <summary>
        /// returns the current instance 
        /// </summary>
        /// <returns></returns>
        public static UserDataSpecifiedTransactionContextFactory GetInstance()
        {
            return instance;
        }
    }
}
