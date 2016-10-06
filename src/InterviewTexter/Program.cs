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
            //TO IMPLEMENT: ask user for interval and how many, then do it.
            Console.WriteLine("Welcome to Epicodus interview question texter v 1.0!");
            Console.WriteLine("How often (in minutes) would you like to be asked a question?");
            int minutes = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How many times would you like to be sent a question?");
            int questionsAmt = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < questionsAmt; i ++)
            {
                Thread.Sleep(i * 60 * 1000);
                Console.WriteLine(DateTime.Now);
                TextMeAQuestion();
            }

            Console.WriteLine("Goodbye.");
            Console.ReadLine();
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
        }
    }  
}
