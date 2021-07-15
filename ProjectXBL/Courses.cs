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
        string cid, faculty, other;
        int ch, hrs;
        int edit = 0;
        ExcelM obj = new ExcelM(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Book.xlsx", 1);
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
            try
            {
                Console.WriteLine("Enter the CourseID of course you want to modify: ");
                cid = Console.ReadLine().ToUpper();
                if (cid == "")
                    throw new ArgumentException();
                while (edit != 1)
                {
                    Console.WriteLine("\nFor Modifying Duration, Press 1:");
                    Console.WriteLine("For Modifying Primary Faculty, Press 2:");
                    Console.WriteLine("For Displaying List of Other Faculties: Press 3");
                    Console.WriteLine("To Exit From here, Press 4");
                    ch = Convert.ToInt32(Console.ReadLine());
                    if (ch.GetType() != typeof(int))
                        throw new ArgumentException();
                    switch (ch)
                    {
                        case 1:
                            {
                                Console.WriteLine("\nEnter the number of hours you want your course to have:");
                                hrs = Convert.ToInt32(Console.ReadLine());
                                obj.ModifyDuration(cid, hrs);
                                obj.Save();
                                //obj.Close();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("\nEnter the name of faculty you want your course to have:");
                                faculty = Console.ReadLine();
                                if (faculty == null)
                                    throw new ArgumentException();
                                if (faculty != null)
                                {
                                    foreach (char lt in faculty)
                                    {
                                        if ((lt >= 'a' && lt <= 'z') || (lt >= 'A' && lt <= 'Z'))
                                            continue;
                                        else
                                            throw new ArgumentException();
                                    }
                                }
                                obj.ModifyPrimaryFaculty(cid, faculty);
                                obj.Save();
                                //obj.Close();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("\nEnter the list of faculties you want your course to have and separate them with the help of a comma:");
                                other = Console.ReadLine();
                                if (other == null)
                                    throw new ArgumentException();
                                if (other != null)
                                {
                                    foreach (char lt in other)
                                    {
                                        if ((lt >= 'a' && lt <= 'z') || (lt >= 'A' && lt <= 'Z') || (lt == ','))
                                            continue;
                                        else
                                            throw new ArgumentException();
                                    }
                                }
                                obj.ModifyOtherFaculty(cid, other);
                                obj.Save();
                                //obj.Close();
                                break;
                            }

                        case 4:
                            {
                                Console.WriteLine("\nOops!! You have exited the modification module:");
                                edit = 1;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("\nIncorrect!!!.Enter a Valid Option");
                                Console.WriteLine("Please Enter Again!");
                                break;
                            }
                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("\nInvalid!");
            }
            finally
            {
                obj.Close();
                Console.WriteLine("\nByebye!");
                Console.ReadLine();
                

            }
        }
    }
}
