using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    class Instructor
    {
        public Instructor(int iD, string name, string specialization)
        {
            ID = iD;
            Name = name;
            Specialization = specialization;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
