using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewTexter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(1 * 60 * 1000);
                Console.WriteLine(DateTime.Now);
                TextMeAQuestion();
            }
        }

        public static void TextMeAQuestion()
        {
            Console.WriteLine("cool");
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            //2
            var request = new RestRequest("Accounts/" + EnvironmentVariables.AccountSid + "/Messages", Method.POST);
            //3
            request.AddParameter("To", EnvironmentVariables.OwnPhone);
            request.AddParameter("From", EnvironmentVariables.TwilioPhone);
            request.AddParameter("Body", "Hello world!");
            //4
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            //5
            client.ExecuteAsync(request, response =>
            {
                Console.WriteLine(response.Content);
            });
            //Console.ReadLine();
        }
    }  
}
