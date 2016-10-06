using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InterviewTexter.Models;

namespace InterviewTexter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Would you like to add a question? (Y/N)");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo == "Y" || yesOrNo == "y" || yesOrNo == "Yes" || yesOrNo == "yes")
            {
                using (var db = new QuestionContext())
                {
                    Console.WriteLine("What is your new question?");
                    string newQuestion = Console.ReadLine();
                    Console.WriteLine("Please specify a category for this question.");
                    string newQuestionCategory = Console.ReadLine();
                    db.Question.Add(new Question { question = newQuestion, category = newQuestionCategory });
                    var count = db.SaveChanges();
                    Console.WriteLine("{0} records saved to database", count);
                    Console.WriteLine();
                    Console.WriteLine("All questions in database:");
                    foreach (var question in db.Question)
                    {
                        Console.WriteLine(" - {0}", question.question);
                    }
                }
            }




            //TO IMPLEMENT: ask user for interval and how many, then do it.
            Console.WriteLine("Welcome to Epicodus interview question texter v 1.0!");
            Console.WriteLine("How often (in minutes) would you like to be asked a question?");
            int minutes = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How many times would you like to be sent a question?");
            int questionsAmt = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < questionsAmt; i ++)
            {
                string questionToText;
                string categoryToText;
                using (var db = new QuestionContext())
                {
                    Random rand = new Random();
                    int toSkip = rand.Next(1, db.Question.Count());
                    Question randomQuestion = db.Question.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).First();
                    questionToText = randomQuestion.question;
                    categoryToText = randomQuestion.category;
                }
                    Thread.Sleep(minutes * 60 * 1000);
                Console.WriteLine("--Alert-- '" + questionToText + "' is the question we'll send out or the category " + categoryToText.ToUpper());
                Console.WriteLine(DateTime.Now);
                TextMeAQuestion(questionToText, categoryToText);
            }

            Console.WriteLine("Goodbye.");
            Console.ReadLine();
        }

        public static void TextMeAQuestion(string questlove, string category)
        {
            Console.WriteLine("cool");
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/" + EnvironmentVariables.AccountSid + "/Messages", Method.POST);
            request.AddParameter("To", EnvironmentVariables.OwnPhone);
            request.AddParameter("From", EnvironmentVariables.TwilioPhone);
            request.AddParameter("Body", category.ToUpper() + ": " + questlove);
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            client.ExecuteAsync(request, response =>
            {
                //Console.WriteLine(response.Content);
                Console.WriteLine("Heads up!  Question text coming your way.");
            });
        }
    }  
}
