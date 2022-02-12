using System;
using System.Runtime.Serialization;
namespace Com.ZimVie.Wcs.Framework
{
    [Serializable]
    public class ApplicationException : System.ApplicationException
    {

        /// <summary>
        /// store the messagedata
        /// </summary>
        private readonly MessageData messageData;

        /// <summary>
        /// form messagedata for application exception
        /// </summary>
        /// <param name="messageData"></param>
        /// <param name="exception"></param>
        public ApplicationException(MessageData messageData, Exception exception) : base(messageData == null ? null : messageData.ToString(),
                exception)
        {
            this.messageData = messageData;

        }

        /// <summary>
        /// form messagedata for application exception
        /// </summary>
        /// <param name="messageData"></param>
        public ApplicationException(MessageData messageData) : base(messageData == null ? null : messageData.ToString())
        {
            this.messageData = messageData;//
        }//

        /// <summary>
        /// getmessagedata from this class
        /// </summary>
        /// <returns></returns>
        public MessageData GetMessageData()
        {
            return messageData;
        }


        // Without this constructor, deserialization will fail
        protected ApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            messageData = (MessageData)info.GetValue("messageData", typeof(MessageData));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("messageData", messageData);
        }

    }
}
