using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Com.ZimVie.Wcs.Framework
{
    public class EncryptDecrypt
    {
        private const string SECURITYKEY = "ABCD";

        private const string MODE_ENCRYPT = "0";

        private const string MODE_DECRYPT = "1";

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(EncryptDecrypt));

        /// <summary>
        ///  get message data
        /// </summary>
        private static MessageData messageData;

        /// <summary>
        /// Encrpt the parameter value
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public string Encrypt(string stringToEncrypt)
        {

            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(stringToEncrypt);

            byte[] resultArray = CryptoServiceValue(toEncryptArray, MODE_ENCRYPT);

            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// Decrypt the parameter value
        /// </summary>
        /// <param name="cipherString"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public string Decrypt(string stringToDecrypt)
        {

            byte[] toDecryptArray = Convert.FromBase64String(stringToDecrypt);

            byte[] resultArray = CryptoServiceValue(toDecryptArray, MODE_DECRYPT);

            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private byte[] CryptoServiceValue(byte[] inputArray, string mode)
        {

            byte[] keyArray;

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            try
            {
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(SECURITYKEY));
            }
            catch (ArgumentNullException ex)
            {
                messageData = new MessageData("ffce00020", Properties.Resources.ffce00020);
                logger.Info(messageData);
                throw new Framework.SystemException(messageData, ex);
            }
            catch (ObjectDisposedException ex)
            {
                messageData = new MessageData("ffce00020", Properties.Resources.ffce00020);
                logger.Info(messageData);
                throw new Framework.SystemException(messageData, ex);
            }
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;

            //ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;

            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform;

            if (string.Equals(mode, MODE_DECRYPT))
            {
                cTransform = tdes.CreateDecryptor();
            }
            else
            {
                cTransform = tdes.CreateEncryptor();
            }

            byte[] resultArray = cTransform.TransformFinalBlock(
                                 inputArray, 0, inputArray.Length);
              
            tdes.Clear();

            return resultArray;
        }

    }
}
