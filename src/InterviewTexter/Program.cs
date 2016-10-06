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
                Thread.Sleep(10000);
                Console.WriteLine(DateTime.Now);
                TextMeAQuestion();
            }
        }

        public static void TextMeAQuestion()
        {
            Console.WriteLine("cool");
        }
    }  
}
