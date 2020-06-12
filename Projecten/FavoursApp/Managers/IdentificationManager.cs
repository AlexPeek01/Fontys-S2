using AdditionalFiles.Interfaces.IManagers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Managers
{
    public class IdentificationManager : IIdentificationManager
    {
        // Set useable characters for keys
        internal static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_".ToCharArray();

        public string GetUniqueKey()
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

            // Add date in milliseconds to the key
            string dateMs = DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds.ToString();
            dateMs = dateMs.Substring(4, dateMs.Length-9);
            string endResult = dateMs + result.ToString();
            return endResult;
        }
        public string Encrypt(string data)
        {
            // Encrypt password one way using SHA256
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(data));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
