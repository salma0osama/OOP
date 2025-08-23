using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string text, int marks,bool correctAnswer) : base(text, marks)
        {
            CorrectAnswer = correctAnswer;
        }

        public bool CorrectAnswer { get; set; }
        public override bool CheckAnswer(string answer)
        {
            return answer.ToLower() == "true" && CorrectAnswer ||
                   answer.ToLower() == "false" && !CorrectAnswer;          
        }
    }
}
