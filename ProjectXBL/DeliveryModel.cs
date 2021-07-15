using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
    public class DeliveryModel
    {
        string modelName;
        int n, j = 1;
        string courseID;
        Excel obj = new Excel(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Book.xlsx", 1);
        Excel writeobj = new Excel(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Models.xlsx", 1);
        public void createmodel()
        {
            Console.WriteLine("Enter Model Name:");
            modelName = Console.ReadLine();
            Console.WriteLine("How many course you want to add");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Type a courseID you want to add in model");
                courseID = Console.ReadLine();
                if (obj.ReadCourseId(courseID))
                {
                    if (writeobj.WriteModelName(modelName) && writeobj.WriteCourseId(courseID))
                    {
                        writeobj.save();
                        writeobj.saveas(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Models.xlsx");
                        Console.WriteLine("Course Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Operation");
                    }



                }
                else
                {
                    Console.WriteLine("The course you want to add is not in Course List");
                }


            }
        }


    }
}
