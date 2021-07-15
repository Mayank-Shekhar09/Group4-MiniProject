using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
    public class Faculties
    {
        public void AddFaculty()
        {
            int psno;
            string emailId = "";
            string name = "";
            Console.WriteLine("Enter PSNo");
            psno = Convert.ToInt32(Console.ReadLine());
            if (psno.GetType() != typeof(int))
                throw new ArgumentException();
            Console.WriteLine("Enter EmailId");
            emailId = Console.ReadLine().ToUpper();
            if ((emailId == null) || (!emailId.Contains('@')) || (!emailId.Contains(".com")))
                throw new ArgumentException();
            else
            {
                foreach (char lt in emailId)
                {
                    if ((lt >= 'a' && lt <= 'z') || (lt >= 'A' && lt <= 'Z' || (lt == '@') || (lt == '.')))
                        continue;
                    else
                        throw new ArgumentException();
                }
            }
            Console.WriteLine("Enter Name");
            name = Console.ReadLine().ToUpper();
            if (name == null)
                throw new ArgumentException();
            else
            {
                foreach (char lt in name)
                {
                    if ((lt >= 'a' && lt <= 'z') || (lt >= 'A' && lt <= 'Z' || (lt == ' ')))
                        continue;
                    else
                        throw new ArgumentException();
                }
            }
            //FacultyManagement1 faculty = new FacultyManagement1(psno, emailId, name);
            //faculty.print();
            //Console.WriteLine("Enter path to the file");
            //string pathExcel = "@" + Console.ReadLine();

            Excelf excel = new Excelf(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Book1.xlsx", 1);
            excel.WriteToCell(psno, emailId, name);
            excel.Save();
            excel.Close();
        }
    }
}
