
namespace Com.ZimVie.Wcs.Framework
{
    public interface DataAccessObject
    {
        /// <summary>
        /// method to execute
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        ValueObject Execute(TransactionContext trxContext, ValueObject arg);
    }
}
