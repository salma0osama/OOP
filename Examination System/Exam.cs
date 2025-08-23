using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    class Exam
    {
        public Exam(string title, Course course, bool started=false)
        {
            Title = title;
            this.course = course;
            Started = started;
        }

        public string Title { get; set; }
        public Course course { get; set; }
        public bool Started { get; private set; } = false;
        public List<Question> Questions { get; set; } = new List<Question>();
        
        public void AddQuestion(Question q)
        {
            int Totalsum = 0;
            foreach (var que in Questions)
            {
                Totalsum += que.Marks;
            }
            if (Totalsum + q.Marks > course.MaxDegree) throw new Exception("Cannot exceed course maximum degree");
            if (Started) throw new Exception("Can not modify the exam after it starts");
            Questions.Add(q);

        }
        public void StartExam()
        {
            Started = true;
        }
        public void EndExam()
        {
            Started = false;
        }
        public Exam Duplicate(Course newCourse)
        {
            return new Exam(Title, course, Started)
            {
                Title = this.Title + "Copy",
                course = newCourse,
                Questions = new List<Question>(this.Questions)
            };
        }
        public void ShowReport(Student se)
        {
            int score = se.GetFinalScore();
            Console.WriteLine("---- Exam Report ----");
            Console.WriteLine($"Exam Title : {Title}");
            Console.WriteLine($"Student Name : {se.Name}");
            Console.WriteLine($"Course Title : {course.Title}");
            Console.WriteLine($"Student Score : {score}/{course.MaxDegree}");
            if(score>=course.MaxDegree/2)
                Console.WriteLine($"Status : Pass");
            else
                Console.WriteLine($"Status : Fail");
            Console.WriteLine("---------------------");
        }
    }
}
