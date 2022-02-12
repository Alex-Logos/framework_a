using System;
using System.Collections.Generic;
using System.Data;

namespace Com.ZimVie.Wcs.Framework
{
    public interface DbParameterList
    {
        /// <summary>
        /// get and set the parameters
        /// </summary>
        IDataParameter[] Parameters { get; set; }

        /// <summary>
        /// method definition for AddParameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        void AddParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input, int size = 0);

        /// <summary>
        /// method definition for AddParameterInteger
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        void AddParameterInteger(string name, int value, ParameterDirection direction = ParameterDirection.Input, int size = 0);

        /// <summary>
        /// method definition for AddParameterString
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        void AddParameterString(string name, string value, ParameterDirection direction = ParameterDirection.Input, int size = 0);

        /// <summary>
        /// method definition for AddParameterDateTime
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        void AddParameterDateTime(string name, DateTime value, ParameterDirection direction = ParameterDirection.Input, int size = 0);

        /// <summary>
        /// method definition for AddParameterDecimal
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        void AddParameterDecimal(string name, Decimal value, ParameterDirection direction = ParameterDirection.Input, int size = 0);


    }
}
