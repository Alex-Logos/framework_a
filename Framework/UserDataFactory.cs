
namespace Com.ZimVie.Wcs.Framework
{
   public interface UserDataFactory
    {

        /// <summary>
        /// get the userdata
        /// </summary>
        /// <returns></returns>
        UserData CreateUserData(ValueObject vo);

    }
}
