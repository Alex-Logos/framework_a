using System;

namespace Com.ZimVie.Wcs.Framework
{
    [Serializable]
   public class MessageData
    {
        private readonly string[] messageParam;

        /// <summary>
        /// initialize SimpleMessageBuilder
        /// </summary>
        private readonly SimpleMessageBuilder messageBuilder = new SimpleMessageBuilder();

        /// <summary>
        /// initialize messagedata
        /// </summary>
        /// <param name="messageCode"></param>
        /// <param name="message"></param>
        /// <param name="messageParam"></param>
        public MessageData(string messageCode, string message, params string[] messageParam )
        {

            this.MessageCode = messageCode == null || messageCode.Trim().Length == 0 ? String.Empty : messageCode;

            this.Message = message == null || message.Trim().Length == 0 ? String.Empty : message;

            this.messageParam = messageParam == null || messageParam.Length == 0 ? null : (string[])messageParam.Clone();

        }

        public override string ToString()
        {

            return messageBuilder.BuildMessage(this);

        }

        /// <summary>
        /// get and set messagecode
        /// </summary>
        public string MessageCode { get; }

        /// <summary>
        /// get message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// get  the messageparam string[]
        /// </summary>
        public string[] MessageParam
        {
            get { return (string[])messageParam; }
        }

    }

}
