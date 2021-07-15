using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXBL;

namespace ProjectXUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            DeliveryModel deliveryModel = new DeliveryModel();
            Courses courses = new Courses();
            Faculties faculties = new Faculties();
            TraineeBatch traineebatch = new TraineeBatch();
            Excel excel = new Excel(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Login.xlsx", 1);
            string user, pass;
            Console.WriteLine("Choose option.\n1.Sign Up\n2. Login");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Set your  username");
                    user = Console.ReadLine();
                    Console.WriteLine("Set your  Password");
                    pass = Console.ReadLine();
                    if (excel.setuser(user) && excel.setpass(pass))
                    {
                        Console.WriteLine("Set Successfully!!!");
                    }
                    else
                    {
                        Console.WriteLine("Something Went wrong!!!");
                    }
                    excel.save();
                    excel.close();

                    break;
                case 2:
                    Console.WriteLine("Enter your Username");
                    user = Console.ReadLine();
                    Console.WriteLine("Enter your Password");
                    pass = Console.ReadLine();
                    bool flag1 = excel.Readusername(user);
                    bool flag2 = excel.Readpassword(pass);
                    if (flag1 && flag2)
                    {
                        Console.WriteLine("Login Successful!!!");
                          Console.WriteLine("Choose Operations\n1.Add Faculty\n2.Add New Course \n 3.Modify Course \n4.Add Delivery Model\n5.CreateModule\n6.Assign Module\n7.Assign Faculty\n8Upload Grades\n9.Exit ");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice.GetType() != typeof(int))
                                throw new ArgumentException();
                            int edit = 0;
                            while (edit != 1)
                            {
                                switch (choice)
                                {
                                    case 1:
                                        faculties.AddFaculty();
                                        break;
                                    case 2:
                                        courses.AddCourseInput();
                                        break;
                                    case 3:
                                        courses.ModifyCourseInput();
                                        break;
                                    case 4:
                                        deliveryModel.createmodel();
                                        break;
                                    case 5:
                                    traineebatch.createBatch();
                                    break;
                                    case 6:
                                    traineebatch.assignModel();
                                    break;
                                    case 7:
                                    traineebatch.assignFaculty();
                                    break;
                                    case 8:
                                    Graderf graderf = new Graderf();
                                    break;
                                    case 9:
                                        edit = 1;
                                        //stem.Environment.Exit(1000);
                                        break;
                                    default:
                                        Console.WriteLine("Enter Input between 1 to 5");
                                        continue;
                                }
                            } 
                        
                    }



                    else
                        Console.WriteLine("Invalid Credentials");
                    excel.save();

                    excel.saveas(@"C:\Users\mmsha\OneDrive\Desktop\Group4-MiniProject\Resources\Login.xlsx");
                    excel.close();


                    break;
                default:
                    Console.WriteLine("its is default Case");
                    break;


            }

        }
    
    }
}
