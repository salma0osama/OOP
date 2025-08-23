namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Instructor> instructors = new List<Instructor>();
            List<Course> courses = new List<Course>();
            while (true)
            {
                Console.WriteLine("--- Examination System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Assign Exam to Course");
                Console.WriteLine("5. Enroll Student in Course");
                Console.WriteLine("6. Start Exam");
                Console.WriteLine("7. Student Answer Exam");
                Console.WriteLine("8. Show Report");
                Console.WriteLine("9. Exit");
                string Choice = Console.ReadLine();
                switch (Choice)
                {
                    case "1":
                        Console.WriteLine("Enter Student ID: ");
                        int sid = int.Parse(Console.ReadLine());
                        Console.Write("Enter Student Name: ");
                        string sname = Console.ReadLine();
                        Console.Write("Enter Student Email: ");
                        string semail = Console.ReadLine();
                        Student st = new Student(sid, sname, semail);
                        Console.WriteLine("Student added");
                        students.Add(st);
                        break;
                    case "2":
                        Console.Write("Enter Instructor ID: ");
                        int iid = int.Parse(Console.ReadLine());
                        Console.Write("Enter Instructor Name: ");
                        string iname = Console.ReadLine();
                        Console.Write("Enter Specialization: ");
                        string spec = Console.ReadLine();
                        instructors.Add(new Instructor(iid, iname, spec));
                        Console.WriteLine("Instructor added");
                        break;
                    case "3":
                        Console.Write("Enter Course Title: ");
                        string ctitle = Console.ReadLine();
                        Console.Write("Enter Description: ");
                        string desc = Console.ReadLine();
                        Console.Write("Enter Max Degree: ");
                        int maxdeg = int.Parse(Console.ReadLine());
                        courses.Add(new Course(ctitle, desc, maxdeg));
                        Console.WriteLine("Course added.");
                        break;
                    case "4":
                        if (courses.Count == 0)
                        {
                            Console.WriteLine("No Courses available");
                            break;
                        }
                        Console.WriteLine("Select Course: ");
                        for (int i = 0; i < courses.Count; i++)
                            Console.WriteLine($"{i + 1}. {courses[i].Title}");
                        int cidx = int.Parse(Console.ReadLine());
                        Course selectedCourse = courses[cidx - 1];
                        Console.WriteLine("Enter the Exam Name");
                        string exname = Console.ReadLine();
                        Exam exam = new Exam(exname, selectedCourse);
                        Console.WriteLine("How many Questions you want to add");
                        int numofque = int.Parse(Console.ReadLine());
                        for (int i = 0; i < numofque; i++)
                        {
                            Console.WriteLine("Choose Question Type: 1) True/False  2) Essay  3) Multiple Choice");
                            string qType = Console.ReadLine();
                            Console.Write("Enter Question Text: ");
                            string qText = Console.ReadLine();
                            Console.Write("Enter Marks: ");
                            int qmarks = int.Parse(Console.ReadLine());
                            if (qType == "1")
                            {
                                Console.Write("Enter correct answer (true/false): ");
                                bool correct = bool.Parse(Console.ReadLine());
                                exam.AddQuestion(new TrueFalseQuestion(qText, qmarks, correct));
                            }
                            else if (qType == "2")
                            {
                                exam.AddQuestion(new EssayQuestion(qText, qmarks));
                            }
                            else if (qType == "3")
                            {
                                Console.Write("Enter number of options: ");
                                int optCount = int.Parse(Console.ReadLine());
                                List<string> options = new List<string>();
                                for (int j = 0; j < optCount; j++)
                                {
                                    Console.Write($"Option {j + 1}: ");
                                    options.Add(Console.ReadLine());
                                }
                                Console.Write("Enter correct option: ");
                                string correctOpt = Console.ReadLine();
                                exam.AddQuestion(new MultipleChoiceQuestion(qText, qmarks, options, correctOpt));
                            }
                        }
                        selectedCourse.exam = exam;
                        break;
                    case "5":
                        if (students.Count == 0 || courses.Count == 0)
                        {
                            Console.WriteLine("Add students and courses first.");
                            break;
                        }
                        Console.WriteLine("Select Student: ");
                        for (int i = 0; i < students.Count; i++)
                            Console.WriteLine($"{i + 1}. {students[i].Name}");
                        int sti = int.Parse(Console.ReadLine());
                        Student selectedStudent = students[sti - 1];
                        Console.WriteLine("Select Course: ");
                        for (int i = 0; i < courses.Count; i++)
                            Console.WriteLine($"{i + 1}. {courses[i].Title}");
                        int coursei = int.Parse(Console.ReadLine());
                        Course chosenCourse = courses[coursei - 1];
                        selectedStudent.EnrolledCourses.Add(chosenCourse);
                        chosenCourse.Students.Add(selectedStudent);
                        Console.WriteLine("Student enrolled in course.");
                        break;
                    case "6":
                        if (courses.Count==0)
                        {
                            Console.WriteLine("No courses available , Add course first");
                            break;
                        }
                        Console.WriteLine("Select Course to Start Exam:");
                        for (int i = 0; i < courses.Count; i++)
                            Console.WriteLine($"{i + 1}. {courses[i].Title}");
                        int courseExamIndex = int.Parse(Console.ReadLine());
                        Course courseWithExam = courses[courseExamIndex - 1];
                        if (!courseWithExam.HasExam())
                        {
                            Console.WriteLine("This course has no exam.");
                        }
                        else
                        {
                            courseWithExam.exam.StartExam();
                            Console.WriteLine("Exam started.");
                        }
                        break;
                    case "7":
                        if (students.Count == 0)
                        {
                            Console.WriteLine("there is no students enrolled in any course.");
                            break;
                        }
                        Console.WriteLine("Select Student:");
                        for (int i = 0; i < students.Count; i++)
                            Console.WriteLine($"{i + 1}. {students[i].Name}");
                        int stuIndex = int.Parse(Console.ReadLine());
                        Student answeringStudent = students[stuIndex - 1];
                       

                        Console.WriteLine("Select Course:");
                        for (int i = 0; i < answeringStudent.EnrolledCourses.Count; i++)
                            Console.WriteLine($"{i + 1}. {answeringStudent.EnrolledCourses[i].Title}");
                        int stuCourseIndex = int.Parse(Console.ReadLine());
                        Course stuCourse = answeringStudent.EnrolledCourses[stuCourseIndex - 1];
                        if (!stuCourse.HasExam() || !stuCourse.exam.Started)
                        {
                            Console.WriteLine("Exam not available or not started.");
                            break;
                        }
                        foreach (var q in stuCourse.exam.Questions)
                        {
                            Console.WriteLine(q.Text);
                            if (q is MultipleChoiceQuestion mcq)
                            {
                                for (int j = 0; j < mcq.Options.Count; j++)
                                    Console.WriteLine($"{j + 1}. {mcq.Options[j]}");
                            }
                            Console.Write("Your Answer: ");
                            string ans = Console.ReadLine();
                            answeringStudent.AnswerQuestion(stuCourse.exam, q, ans);
                        }
                        Console.WriteLine("Answers submitted.");
                        break;
                    case "8":
                        if (students.Count == 0)
                        {
                            Console.WriteLine("There is no students");
                            break;
                        }
                        Console.WriteLine("Select Student:");
                        for (int i = 0; i < students.Count; i++)
                            Console.WriteLine($"{i + 1}. {students[i].Name}");
                        int repStuIndex = int.Parse(Console.ReadLine());
                        Student reportStudent = students[repStuIndex - 1];

                        Console.WriteLine("Select Course:");
                        for (int i = 0; i < reportStudent.EnrolledCourses.Count; i++)
                            Console.WriteLine($"{i + 1}. {reportStudent.EnrolledCourses[i].Title}");
                        int repCourseIndex = int.Parse(Console.ReadLine());
                        Course repCourse = reportStudent.EnrolledCourses[repCourseIndex - 1];
                        if (!repCourse.HasExam())
                        {
                            Console.WriteLine("Course has no exam.");
                        }
                        else
                        {
                            repCourse.exam.ShowReport(reportStudent);
                        }
                        break;
                    case "9":
                        Console.WriteLine("Exiting the system");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
