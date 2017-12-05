using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoreEntites.Common
{
    public class CommonFunction
    {
        /// <summary>
        /// CreatedDate:22-Nov-2017
        /// Desc:Function is used to encrypt the password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptPassword(string plaintext)
        {
            string EncryptedPassword = string.Empty;
            if (!string.IsNullOrEmpty(plaintext))
            {
                byte[] encode = new byte[plaintext.Length];
                encode = Encoding.UTF8.GetBytes(plaintext);
                EncryptedPassword = Convert.ToBase64String(encode);
            }
            return EncryptedPassword;
        }
        /// <summary>
        /// CreatedDate:22-Nov-2017
        /// Desc:Function is used to Decrypt the password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DecryptPassword(string encryptedtext)
        {
            string DecryptedPassword = string.Empty;
            if (!string.IsNullOrEmpty(encryptedtext))
            {
                UTF8Encoding encodepwd = new UTF8Encoding();
                Decoder Decode = encodepwd.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encryptedtext);
                int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                DecryptedPassword = new String(decoded_char);
            }
            return DecryptedPassword;
        }
        public static List<SelectListItem> GetPrefix()
        {
            List<SelectListItem> _Prefix = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Value="1",Text="Mr."},
                 new SelectListItem{ Value="2",Text="Ms."}
                             };
            _Prefix = data.ToList();
            return _Prefix;
        }
    }
}
