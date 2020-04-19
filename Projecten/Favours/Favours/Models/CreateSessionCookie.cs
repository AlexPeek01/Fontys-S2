using Favours.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Models
{
    public class CreateSessionCookie
    {
        public static string getAuthToken(string email)
        {
            string authCode;
            string userID;
            userID = GetUserID(email);
            authCode = GetAuthCode(userID);
            return authCode;
        }

        private static string GetAuthCode(string UserID)
        {
            List<string> authCode = SQLConnection.ExecuteSearchQuery($"SELECT AuthCode FROM Users WHERE UserID = '{UserID}'");
            if (authCode.Count == 0)
            {
                return "0";
            }
            else
            {
                return authCode[0];
            }
        }

        private static string GetUserID(string email)
        {
            List<string> userID = SQLConnection.ExecuteSearchQuery($"SELECT UserID FROM Users WHERE Email = '{email}'");
            if (userID.Count == 0)
            {
                return "0";
            }
            else
            {
                return userID[0];
            }
        }
    }
}
