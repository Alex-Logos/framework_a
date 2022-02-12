using System;
using System.Data;
using Npgsql;

namespace Com.ZimVie.Wcs.Framework
{
    public class DefaultCbmInvoker
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultCbmInvoker));

        /// <summary>
        /// get the instance of DefaultTransactionContextFactory
        /// </summary>
        private static readonly TransactionContextFactory defaultTrxFactory = new DefaultTransactionContextFactory();

        /// <summary>
        /// executing transaction 
        /// </summary>
        /// <param name="cbm">cbm  to be executed</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <returns>output vo will be returned/ exception will be thrown for error cases</returns>
        public static ValueObject Invoke(CbmController cbm, ValueObject vo)
        {

            string connectionString = ConfigurationDataTypeEnum.CONNECTION_STRING.GetValue();

            return Invoke(cbm, vo, connectionString);

        }

        /// <summary>
        /// invoking transaction for execution
        /// </summary>
        /// <param name="cbm">cbm instance to be executed</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <param name="connectionString">connectionstring of thedb in which cbm to be execute</param>
        /// <exception cref="System.NullReferenceException">NullReferenceException has been thrown as system exception in case of connectionstring is null</exception>
        /// <returns>output vo will be returned/ exception will be thrown for error cases</returns>
        public static ValueObject Invoke(CbmController cbm, ValueObject vo, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageData messageData = new MessageData("ffce00019", Properties.Resources.ffce00019);
                logger.Error(messageData, new NullReferenceException());
                throw new SystemException(messageData, new NullReferenceException());
            }

            return Invoke(cbm, vo, null, defaultTrxFactory, connectionString);

        }

        /// <summary>
        /// invoking and executing transaction using userdata and transaxtioncontextfacctory
        /// </summary>
        /// <param name="cbm">cbm  to be executed</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <param name="userData">userdata</param>
        /// <param name="trxFactory">TransactionContextFactory to get transactioncontext using userdata</param>
        /// <returns>output vo will be returned / exception will be thrown for error cases</returns>
        public static ValueObject Invoke(CbmController cbm, ValueObject vo, UserData userData, TransactionContextFactory trxFactory)
        {

            string connectionString = ConfigurationDataTypeEnum.CONNECTION_STRING.GetValue();

            return Invoke(cbm, vo, userData, trxFactory, connectionString);

        }


        /// <summary>
        /// executing transaction 
        /// </summary>
        /// <param name="cbm">cbm  to be executed</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <param name="userData">userdata</param>
        /// <param name="trxFactory">TransactionContextFactory to get transactioncontext using userdata</param>
        /// <param name="connectionString">connectionString for connecting with another database</param>
        /// <exception cref="Com.ZimVie.Wcs.Framework.ApplicationException">application exception handled in cbm access and cbm invoke</exception>
        /// <exception cref="Com.ZimVie.Wcs.Framework.SystemException">system exception handled in cbm access and cbm invoke</exception>
        /// <exception cref="System.Exception">Unhandled exception occured has been thrown as system exception in cbm access and cbm invoke</exception>
        /// <returns>output vo will be returned / exception will be thrown for error cases</returns>
        internal static ValueObject Invoke(CbmController cbm, ValueObject vo, UserData userData, TransactionContextFactory trxFactory, string connectionString)
        {

            if (cbm == null)
            {

                MessageData messageData = new MessageData("ffce00001", Properties.Resources.ffce00001, System.Reflection.MethodBase.GetCurrentMethod().Name);
                logger.Error(messageData, new NullReferenceException());
                throw new SystemException(messageData, new NullReferenceException());

            }

            if (trxFactory == null)
            {
                //please write code here
                defaultTrxFactory.GetTransactionContext(userData);
                trxFactory = defaultTrxFactory;
            }


            IDbTransaction dbTransaction = null;
            IDbConnection connection = null;
            //Get TransactionContext
            TransactionContext trxContext = trxFactory.GetTransactionContext(userData);

            try
            {

                connection = new NpgsqlConnection(connectionString);

                trxContext.DbConnection = connection;
                trxContext.DbConnection.Open();

                dbTransaction = trxContext.DbConnection.BeginTransaction();

                //Get DB Processing Time
                CbmController GetDBProcessingTimeCbm = trxFactory.GetDBProcessingTimeCbm();

                //get the servertime
                TimeVo time = (TimeVo)GetDBProcessingTimeCbm.Execute(trxContext, vo);

                trxContext.ProcessingDBDateTime = time.CurrentDateTime;

                //Start transaction
                ValueObject returnedVo = cbm.Execute(trxContext, vo);

                //commit
                dbTransaction.Commit();

                return returnedVo;

            }
            catch (ApplicationException appEx)
            {

                //rollback
                DbTransactionRollback(dbTransaction);

                MessageData messageData = new MessageData("ffce00023", Properties.Resources.ffce00023, appEx.Message);
                logger.Error(messageData, appEx);

                throw appEx; //throw original app exception

            }
            catch (SystemException sysEx)
            {
                //rollback
                DbTransactionRollback(dbTransaction);

                MessageData messageData = new MessageData("ffce00024", Properties.Resources.ffce00024, sysEx.Message);
                logger.Error(messageData, sysEx);

                throw sysEx; //throw original sys exception
            }
            catch (Exception Ex)
            {

                //rollback
                DbTransactionRollback(dbTransaction);

                MessageData messageData = new MessageData("ffce00025", Properties.Resources.ffce00025, Ex.Message);
                logger.Error(messageData, Ex);

                throw new SystemException(messageData, Ex); //throw original exception as sys exception
            }
            finally
            {

                try
                {
                    if (connection != null) connection.Close();
                }
                catch (Exception ex)
                {
                    //need to be implemented
                    MessageData messageData = new MessageData("ffce00027", Properties.Resources.ffce00027, ex.Message);
                    logger.Error(messageData, ex);

                    throw new SystemException(messageData,ex); //throw original exception as sys exception
                }
            }
        }

        /// <summary>
        /// rollback transaction in exception
        /// </summary>
        /// <param name="dbTransaction">IDbTransaction to be rollback</param>
        /// <exception cref="System.InvalidOperationException">logging the InvalidOperationException occured when rollback the transaction</exception>
        /// <exception cref="System.Exception">logging the Exception occured when rollback the transaction</exception>
        private static void DbTransactionRollback(IDbTransaction dbTransaction)
        {
            if (dbTransaction == null) return; //do nothing

            try
            {
                dbTransaction.Rollback();
            }
            catch (InvalidOperationException InvalidEx)
            {
                MessageData messageData = new MessageData("ffce00028", Properties.Resources.ffce00028, InvalidEx.Message);
                logger.Error(messageData, InvalidEx); //only logging
            }
            catch (Exception Ex)
            {
                MessageData messageData = new MessageData("ffce00026", Properties.Resources.ffce00026, Ex.Message);
                logger.Error(messageData, Ex); //only logging

            }

        }
    }
}
