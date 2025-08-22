using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    class Course
    {
        public Course(string title, string description, int maxDegree)
        {
            Title = title;
            Description = description;
            MaxDegree = maxDegree;
            exam = null;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxDegree { get; set; }
        public Exam exam { get; set; }

        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public List<Student> Students { get; set; } = new List<Student>();
        public bool HasExam()
        {
            return exam != null;
        }

    }
}
