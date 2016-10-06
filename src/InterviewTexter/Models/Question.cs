using System;
using System.Collections.Generic;

namespace InterviewTexter.Models
{
    public partial class Question
    {
        public Question()
        {
        }
        public int QuestionID { get; set; }
        public string question { get; set; }
        public string category { get; set; }

    
    }
}
