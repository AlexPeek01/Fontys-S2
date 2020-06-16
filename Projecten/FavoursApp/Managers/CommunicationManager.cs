using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class CommunicationManager
    {
        public void SendMail(string toEmail, string toName, string message)
        {
            var client = new RestClient("https://api.sendgrid.com/v3/mail/send");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer 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");
            request.AddParameter("application/json", "{\"personalizations\":[{\"to\":[{\"email\":\"" + toEmail + "\",\"name\":\"" + toName + "\"}],\"dynamic_template_data\":{\"message\":\"" + message + "\"},\"subject\":\"Wachtwoord reset\"}],\"from\":{\"email\":\"noreply@favours.com\",\"name\":\"Favours\"},\"reply_to\":{\"email\":\"noreply@favours.com\",\"name\":\"Favours\"},\"template_id\":\"d-19361b2c4c9643e3a98e1cc9b5496131\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}
