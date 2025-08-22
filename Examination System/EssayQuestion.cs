using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    class EssayQuestion : Question
    {
        public EssayQuestion(string text, int marks) : base(text, marks)
        {
        }

        public override bool CheckAnswer(string answer)
        {
            return true;
        }
    }
}
