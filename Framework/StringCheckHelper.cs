using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Com.ZimVie.Wcs.Framework
{
    public class StringCheckHelper
    {

        /// <summary>
        /// constructor
        /// </summary>
        private StringCheckHelper()
        {
        }

        /// <summary>
        /// initialize this class
        /// </summary>
        private static readonly StringCheckHelper instance = new StringCheckHelper();



        /// <summary>
        /// get the instance of this class
        /// </summary>
        /// <returns></returns>
        public static StringCheckHelper GetInstance()
        {
            return instance;
        }


        /// <summary>
        /// to check the inputvalue for numeric
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public bool IsNumber(string inputValue)
        {
            if (inputValue == null || inputValue.Trim().Equals(string.Empty))
            {
                return false;
            }

            return Regex.IsMatch(inputValue, "^[0-9]+$");
        }

        /// <summary>
        /// to check the inputvalue for alphabet
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public bool IsAlphabet(string inputValue)
        {
            if (inputValue == null || inputValue.Trim().Equals(string.Empty))
            {
                return false;
            }
            return Regex.IsMatch(inputValue, "^[a-zA-Z]+$");

        }

        /// <summary>
        /// to check the inputvalue for alphabetnumeric
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public bool IsAlphabetOrNumeric(string inputValue)
        {
            if (inputValue == null || inputValue.Trim().Equals(string.Empty))
            {
                return false;
            }
            return Regex.IsMatch(inputValue, @"^[a-zA-Z0-9\s]*$");

        }
        public bool IsSmallAlphabetOrNumeric(string inputValue)
        {
            if (inputValue == null || inputValue.Trim().Equals(string.Empty))
            {
                return false;
            }
            return Regex.IsMatch(inputValue, @"^[a-z0-9\s]*$");

        }

        /// <summary>
        /// to check the inputvalue for ascii
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public bool IsASCII(string inputValue)
        {
            if (inputValue == null || inputValue.Trim().Equals(string.Empty))
            {
                return false;
            }

            return !Regex.IsMatch(inputValue, "[^\x20-\x7E]");
        }

    }
}
