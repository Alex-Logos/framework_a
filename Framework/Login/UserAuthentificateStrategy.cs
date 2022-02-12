
namespace Com.ZimVie.Wcs.Framework
{
    /// <summary>
    ///
    /// </summary>
    internal interface UserAuthentificateStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="encryptedPass"></param>
        /// <returns></returns>
        bool Authentificate(string user, string encryptedPass);

    }
}
