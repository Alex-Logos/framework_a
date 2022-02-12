using System.Text;
using System;
namespace Com.ZimVie.Wcs.Framework
{
    [Serializable]
    internal class SimpleMessageBuilder : MessageBuilder
    {
        private const string LEFT_BRACKET = "[";

        private const string RIGHT_BRACKET = "]";

        /// <summary>
        /// message formation using messagedata
        /// </summary>
        /// <param name="messageData"></param>
        /// <returns></returns>
        public string BuildMessage(MessageData messageData)
        {
            if (messageData == null) return string.Empty;

            StringBuilder sb = new StringBuilder();

            sb.Append(LEFT_BRACKET);
            sb.Append(messageData.MessageCode);
            sb.Append(RIGHT_BRACKET);
            sb.Append(messageData.Message);

            string[] messageParam = messageData.MessageParam;

            string builtMessage;

            if (messageParam != null && messageParam.Length != 0)
            {
                builtMessage = string.Format(sb.ToString(), messageParam);
            }else
            {
                builtMessage = sb.ToString();
            }

            return builtMessage;


        }
    }
}
