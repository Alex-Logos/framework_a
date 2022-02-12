using System;
using System.Runtime.Serialization;
namespace Com.ZimVie.Wcs.Framework
{
    [Serializable]
    public class SystemException : System.SystemException
    {

        /// <summary>
        /// store the messagedata
        /// </summary>
        private readonly MessageData messageData;

        /// <summary>
        /// form messagedata for systemexception
        /// </summary>
        /// <param name="messageData"></param>
        /// <param name="exception"></param>
        public SystemException(MessageData messageData, Exception exception) : base(messageData?.ToString(),
                exception)
        {
            this.messageData = messageData;

        }

        /// <summary>
        /// form messagedata for systemexception
        /// </summary>
        /// <param name="messageData"></param>
        public SystemException(MessageData messageData) : base(messageData?.ToString())
        {
            this.messageData = messageData;
        }

        /// <summary>
        /// get the messagedata stored
        /// </summary>
        /// <returns></returns>
        public MessageData GetMessageData()
        {
            return messageData;
        }

        // Without this constructor, deserialization will fail
        protected SystemException(SerializationInfo info, StreamingContext context)
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
