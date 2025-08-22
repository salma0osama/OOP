using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    class Student
    {
        public Student(int iD, string name, string email)
        {
            ID = iD;
            Name = name;
            Email = email;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();
        public Dictionary<Question, string> Answers { get; set; } = new Dictionary<Question, string>();
        public void AnswerQuestion(Exam exam,Question q, string answer)
        {
            if (exam.Started == false)
            {
                throw new Exception("The Exam has not started yet");
            }
            if (Answers.ContainsKey(q))
            {
                Answers[q] = answer;
            }
            else
                Answers.Add(q, answer);
        }
        public int GetFinalScore()
        {
            int score = 0;
            foreach (var a in Answers)
            {
                if (a.Key.CheckAnswer(a.Value))
                {
                    score += a.Key.Marks;
                }
            }
            return score;
        }
        public bool IsEnrolledInExam(Exam exam)
        {
            return EnrolledCourses.Contains(exam.course);
        }
    }
}
