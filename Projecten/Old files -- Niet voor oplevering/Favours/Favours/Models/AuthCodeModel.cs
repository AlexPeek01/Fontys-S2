using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Models
{
    public class AuthCodeModel
    {
        private static Random random = new Random();
        public string GenerateAuthToken()
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789-_";
            return new string(Enumerable.Repeat(chars, 11)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
