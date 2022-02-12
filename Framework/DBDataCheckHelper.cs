using System;

namespace Com.ZimVie.Wcs.Framework
{
    public static class DBDataCheckHelper
    {

        /// <summary>
        /// to check whether the value isdbnull or null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDBNullOrNull(object value)
        {
            return Convert.IsDBNull(value) || value == null;
        }

        /// <summary>
        /// to convert the dbnull value to string null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertDBNullToStringNull(object value)
        {
            return Convert.IsDBNull(value) ? null : value.ToString();
        }

    }
}
