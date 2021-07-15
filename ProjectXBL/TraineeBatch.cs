using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL

{
    public class TraineeBatch
    {
        string batchName;
        string month;
        int NoofParticipants;
        string facultyAssign;
        string modelAssign;
        Excel excel = new Excel(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Models2.xlsx", 1);
        Excel writeobj = new Excel(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Batch.xlsx", 1);
        Excel newobj = new Excel(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Book.xlsx", 1);
        public void createBatch()
        {

            Console.WriteLine("Enter batch Year: ");
            batchName = Console.ReadLine();
            Console.WriteLine("When batch will start (month)");
            month = Console.ReadLine();
            Console.WriteLine("How many participants in this batch");
            NoofParticipants = Convert.ToInt32(Console.ReadLine());

            




        }
        public void assignModel()
        {

            Console.WriteLine("Enter the Model name you want to assign to this Batch");
            modelAssign = Console.ReadLine();

            if ( excel.ReadModelName(modelAssign))
            {
                string s = month + batchName + "_" + modelAssign;
                if (writeobj.WriteToBatch(s,1))
                    Console.WriteLine("Model Assigned!!!");
            }
            else
            {
                Console.WriteLine("Model not Found");
            }
        }
        public void assignFaculty()
        {
            Console.WriteLine("Enter the faculty name you want to assign to this Batch");
            facultyAssign = Console.ReadLine();
            if (newobj.ReadFacultyName(facultyAssign))
            {
                
                if(writeobj.WriteToBatch(facultyAssign,2))
                    Console.WriteLine("Faculty Assigned!!!");
            }
            else
            {
                Console.WriteLine("Faculty not found!!!");
            }

        }


    }
}
