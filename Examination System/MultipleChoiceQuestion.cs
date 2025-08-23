using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    class MultipleChoiceQuestion : Question
    {
        public MultipleChoiceQuestion(string text, int marks, List<string> options, string correctAnswer) : base(text, marks)
        {
            Options = options;
            CorrectAnswer = correctAnswer;
        }

        public List<string> Options { get; set; } = new List<string>();
        public string CorrectAnswer { get; set; }
        public override bool CheckAnswer(string answer) 
        {
            return string.Equals(answer , CorrectAnswer,StringComparison.OrdinalIgnoreCase);
        }
    }
}
