using System;
using System.Text;

namespace JetCoders.Shared
{
    /// <summary>
    /// Represents extensions to the Byte types.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Converts an UNicoded string to a Byte Array.
        /// </summary>
        /// <param name="textToConvert"></param>
        /// <returns></returns>
        public static byte[] ConvertUnicodeStringToByteArray(this String textToConvert)
        {
            var utf8 = new UTF8Encoding();
            Byte[] bytes = utf8.GetBytes(textToConvert);
            return bytes;
        }

        /// <summary>
        /// Converts an Ascii string to a Byte Array
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] ConvertAsciiStringToByteArray(this String text)
        {
            var ascii = new ASCIIEncoding();
            Byte[] bytes = ascii.GetBytes(text);
            return bytes;
        }

        /// <summary> 
        /// Converts a byte array to a string using ASCII.
        /// </summary> 
        /// <param name="bytes">Array of bytes to be converted.</param> 
        /// <returns>string</returns> 
        public static string ConvertToString(this byte[] bytes)
        {
            return ConvertToString(bytes, EncodingType.Ascii);
        }
        /// <summary> 
        /// Converts a byte array to a string using specified encoding. 
        /// </summary> 
        /// <param name="bytes">Array of bytes to be converted.</param> 
        /// <param name="encodingType">EncodingType enum.</param> 
        /// <returns>string</returns> 
        public static string ConvertToString(this byte[] bytes, EncodingType encodingType)
        {
            if (bytes == null)
                return null;

            Encoding encoding;
            switch (encodingType)
            {
                case EncodingType.Ascii:
                    encoding = new ASCIIEncoding();
                    break;
                case EncodingType.Unicode:
                    encoding = new UnicodeEncoding();
                    break;
                case EncodingType.Utf7:
                    encoding = new UTF7Encoding();
                    break;
                case EncodingType.Utf8:
                    encoding = new UTF8Encoding();
                    break;
                default:
                    encoding = new UTF8Encoding();
                    break;
            }
            return encoding.GetString(bytes);
        }

        public enum EncodingType
        {
            Ascii,
            Unicode,
            Utf7,
            Utf8
        }
    }
}
