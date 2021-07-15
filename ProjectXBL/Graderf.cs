using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
   public class Graderf
    {
        public void AddGrading() {

        Console.WriteLine("Enter Path to TrainingBatch");
                    string pathBatch = "@" + Console.ReadLine();
        Console.WriteLine("Enter Sheet Number you want to access");
                    int sheet = Convert.ToInt32(Console.ReadLine());
                    if (sheet.GetType() != typeof(int))
                        throw new ArgumentException();
        Grader grader = new Grader(@"C:\Users\mmsha\OneDrive\Desktop\Test1.xlsx", 1);
        //grader.GraderBatch(pathBatch, sheet);
        Console.WriteLine("Enter course Name and Faculty Name");
                    string courseName = Console.ReadLine().ToUpper();
            if (courseName == null)
                throw new ArgumentException();
            else
            {
                foreach (char lt in courseName)
                {
                    if ((lt >= 'a' && lt <= 'z') || (lt >= 'A' && lt <= 'Z' || (lt == ' ')))
                        continue;
                    else
                        throw new ArgumentException();
                }
            }
            string faculty_ = Console.ReadLine().ToUpper();
        if (faculty_ == null)
            throw new ArgumentException();
        else
        {
            foreach (char lt in faculty_)
            {
                if ((lt >= 'a' && lt <= 'z') || (lt >= 'A' && lt <= 'Z' || (lt == ' ')))
                    continue;
                else
                    throw new ArgumentException();
            }
        }
        bool isPresent = grader.VerifyDetail(courseName, faculty_);
        
        GC.Collect();
        //grader.Save();
        
        Task.Delay(1000);
        grader.Close();
        if (isPresent)
        {
            Console.WriteLine("Enter path of the file to be uploaded");
            string pathupload = "@" + Console.ReadLine();
        
            Grader graderFeedback = new Grader(@"C:\Users\mmsha\OneDrive\Desktop\Test.xlsx", 1);
            string[,] read = graderFeedback.ReadRange(1, 1, 2, 2);
            graderFeedback.Save();
            Task.Delay(1000);
            GC.Collect();
            graderFeedback.Close();
        
            Grader graderFeedbackupload = new Grader(@"C:\Users\mmsha\OneDrive\Desktop\Test2.xlsx", 1);
            graderFeedbackupload.WriteRange(1, 1, 2, 2, read);
        
            // graderFeedback.Close();
            graderFeedbackupload.Save();
            GC.Collect();
            graderFeedbackupload.Close();
        }
        else
        {
            Console.WriteLine("No such courses exists");
        }
        
        GC.Collect();
        
        Console.ReadLine();
        }
            }
}
