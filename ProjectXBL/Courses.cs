using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
    public class Courses
    {
        string[] facultyMembers = new string[50];
        public void AddCourseInput()
        {
            AddCourse add = new AddCourse();

            Console.WriteLine("Choose your learning process: \nIL : Instructor learning  \nEL :E-learning");
            string learning = Console.ReadLine().ToUpper();
            if (learning != "EL" && learning != "IL")
                throw new ArgumentException();
            Console.WriteLine("Choose your track: \nSW: Software Engineering \nEM:Embedded Engineeering \nME: Mechanical Engineering \nPT: Plant Engineering");
            string track = Console.ReadLine().ToUpper();
            if (track != "SW" && track != "EM" && track != "ME" && track != "PT")
                throw new ArgumentException();
            Console.WriteLine("Outcome: (T/C): ");
            char outcome = char.ToUpper(Console.ReadLine()[0]);
            if (outcome != 'T' && outcome != 'C')
                throw new ArgumentException();
            Console.WriteLine("Choose category : \nI : Internal  \tEL :External ");
            char scope = char.ToUpper(Console.ReadLine()[0]);
            if (scope != 'I' && scope != 'E')
                throw new ArgumentException();

            Console.WriteLine("\nT : Technical  \tD :Domain \tP : Process");
            char type = char.ToUpper(Console.ReadLine()[0]);
            if (type != 'T' && type != 'D' && type != 'P')
                throw new ArgumentException();

            Console.WriteLine("\n Level: \tL1: Awareness \tL2: Supervised Practitioner \tL3: Practitioner");
            string level = Console.ReadLine().ToUpper();
            if (level != "L1" && level != "L2" && level != "L3")
                throw new ArgumentException();
            Console.WriteLine("\nEnter Course Title: ");
            string courseTitle = Console.ReadLine(); //check if course title is unique to be done.
            Console.WriteLine("\nEnter Course Duration: ");
            float courseDuration = float.Parse(Console.ReadLine());
            if (courseDuration.GetType() != typeof(float))
                throw new ArgumentException();
            Console.WriteLine("Course Owner: ");
            string courseOwner = Console.ReadLine();
            if (!add.CheckFaculty(courseOwner))
                throw new ArgumentException();
            Console.WriteLine("Number of faculties for the course: ");
            int facultyTotal = Convert.ToInt32(Console.ReadLine());

            if (facultyTotal.GetType() != typeof(int))
                throw new ArgumentException();
            for (int loop = 0; loop < facultyTotal; loop++)
            {
                Console.WriteLine($"Enter faculty {loop + 1}: ");
                string member = Console.ReadLine();
                if (add.CheckFaculty(member))
                    facultyMembers[loop] = member;
                else
                {
                    Console.WriteLine("Invalid faculty");
                    loop--;
                }

            }
            Console.WriteLine("Choose Mode: \t1 :Hands on \t2 :MCQ  \t3 :No Assessment Mode");
            Mode mode = (Mode)(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Address of the curriculum: ");
            string address = '@' + Console.ReadLine();
            AddCourse addCourse = new AddCourse(learning, track, outcome, type, scope, courseTitle, courseDuration, courseOwner, facultyMembers, mode, address);
            addCourse.facultyTotal = facultyTotal;
            addCourse.SetLevel(level);
            Task.Delay(1000);
            addCourse.ToFile();

            Console.WriteLine(addCourse.CourseId);
            Console.WriteLine(addCourse.Mode.ToString());
        }

        public void ModifyCourseInput()
        {
        }
}
