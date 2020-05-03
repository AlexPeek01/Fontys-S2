using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Managers
{
    public class IdentificationManager
    {
        internal static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_".ToCharArray();

        public static string GetUniqueKey()
        {
            byte[] data = new byte[4 * 11];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(11);
            for (int i = 0; i < 11; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }
            string dateMs = DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds.ToString();
            dateMs = dateMs.Substring(4, dateMs.Length-9);
            string endResult = dateMs + result.ToString();
            return endResult;
        }
    }
}
