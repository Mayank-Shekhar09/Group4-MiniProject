using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ProjectXBL
{
    public enum Mode { HandsOn = 1, MCQ, NoAssessment };

    public class AddCourse
    {

        private string courseId;
        static int L1, L2, L3;
        private string courseTitle;
        private float courseDuration;
        private string courseOwner;
        private string[] facultyMembers = new string[100];
        private Mode mode;
        public int facultyTotal;
        private string address;

        ExcelOp facultyExcel = new ExcelOp(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Book1.xlsx", 1);

        public string CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public string CourseTitle
        {
            get { return courseTitle; }
            set { courseTitle = value; }
        }

        public float CourseDuration
        {
            get { return courseDuration; }
            set { courseDuration = value; }
        }

        public string CourseOwner
        {
            get { return courseOwner; }
            set { courseOwner = value; }
        }

        public string[] FacultyMembers
        {
            get { return facultyMembers; }
            set { facultyMembers = value; }
        }

        public Mode Mode
        {
            get { return mode; }
            set { mode = value; }

        }



        static AddCourse()
        {
            L1 = 100;
            L2 = 500;
            L3 = 800;
        }

        public AddCourse() { }

        public AddCourse(string learning, string track, char outcome, char type, char scope, string courseTitle, float courseDuration, string courseOwner, string[] facultyMembers, Mode mode, string address)
        {
            courseId = learning + track + outcome + type + scope;
            this.courseTitle = courseTitle;
            this.courseDuration = courseDuration;
            this.courseOwner = courseOwner;
            this.facultyMembers = facultyMembers;
            this.mode = mode;
            this.address = address;

        }

        public string SetLevel(string level)
        {
            if (level == "L1")
            {
                Console.WriteLine("set level loop");
                courseId += L1;
                Console.WriteLine($"set level loop {courseId}");
                Console.WriteLine($"set level loop new L1: {L1}");
            }
            else if (level == "L2")
            {
                courseId += L2;
                if (L2 != 500)
                    L2++;
            }
            else if (level == "L3")
            {
                courseId += L3;
                if (L3 != 800)
                    L3++;
            }
            else
                throw new ArgumentException("Invalid Input");
            return courseId;
        }

        public bool CheckFaculty(string s)
        {
            if (facultyExcel.ValidateFaculty(s))
                return true;
            return false;
        }



        public bool ToFile()
        {
            int flag = 0;
            ExcelOp excel = new ExcelOp(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Book.xlsx", 1);

            if (excel.ReadcourseId(courseId))
            {
                Console.WriteLine("loop entered");
                char num = courseId[7];
                Console.WriteLine(num);
                int level = num - 48;
                Console.WriteLine(level);
                if (level >= 1 && level < 5)
                {
                    while (excel.ReadcourseId(courseId))
                    {
                        Console.WriteLine("L1 loop entered");
                        Console.WriteLine($"Current value: {L1}");
                        L1++;
                        courseId = courseId.Substring(0, 7) + L1.ToString();
                        Console.WriteLine($"CourseId: {courseId}");
                    }
                }

                else if (level >= 5 && level < 8)
                {
                    while (excel.ReadcourseId(courseId))
                    {
                        L2++;
                        courseId = courseId.Substring(0, 7) + L2.ToString();
                    }
                }

                else if (level >= 8 && level < 10)
                {
                    while (excel.ReadcourseId(courseId))
                    {
                        L3++;
                        courseId = courseId.Substring(0, 7) + L3.ToString();
                    }
                }
                else
                {
                    //throw new ArgumentException("Invalid: ");
                    flag = 0;
                }
            }

            if (excel.Setcourse(courseId, courseTitle, courseDuration, courseOwner) &&
            excel.setfaculty(facultyMembers, facultyTotal) &&
            excel.setMode(mode) &&
            excel.setAddress(address.Substring(1)))
                flag = 1;
            excel.save();
            excel.saveas(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Book.xlsx");
            Task.Delay(1000);
            excel.close();
            if (flag == 1)
                return true;
            else
                return false;


        }


    }
}
