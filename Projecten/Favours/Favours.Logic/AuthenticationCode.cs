using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Favours.Logic
{
    public class AuthenticationCode
    {
        private static Random random = new Random();
        public AuthenticationCode()
        {
        }
        public string GenerateAuthToken()
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789!@#$%^&*()_+";
            return new string(Enumerable.Repeat(chars, 15)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
