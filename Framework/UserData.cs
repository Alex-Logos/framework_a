using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System;
namespace Com.ZimVie.Wcs.Framework
{
    /// <summary>
    /// set the common values to be used in whole system
    /// </summary>
    [Serializable]
    public class UserData
    {

        /// <summary>
        /// 
        /// </summary>
        private UserData() { }

        /// <summary>
        /// 
        /// </summary>
        private static readonly UserData userData = new UserData();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UserData GetUserData()
        {
            return userData;
        }


        /// <summary>
        /// get and set the usercode
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// get and set the username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// get and set the languagecode
        /// </summary>
        public int LocaleId { get; set; }

        /// <summary>
        /// get and set the languagecode
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// get and set the factorycode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// get and set the country list
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// get and set the country list
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// get and set the usercode
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// get and set the dateTimeFormat
        /// </summary>
        public DateTimeFormatInfo DateTimeFormat { get; set; }

        /// <summary>
        /// get and set the NumberFormat
        /// </summary>
        public NumberFormatInfo NumberFormat { get; set; }

        /// <summary>
        /// get and set the FactoryCodeList
        /// </summary>
        public List<string> FactoryCodeList { get; set; } = new List<string>();

        /// <summary>
        /// get and set the ControlList
        /// </summary>
        public List<string> ControlList { get; set; } = new List<string>();
    }
}
