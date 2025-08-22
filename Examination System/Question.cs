using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    abstract class Question
    {
        protected Question(string text, int marks)
        {
            Text = text;
            Marks = marks;
        }

        public string Text { get; set; }
        public int Marks { get; set; }
        public abstract bool CheckAnswer(string answer);

    }
}
