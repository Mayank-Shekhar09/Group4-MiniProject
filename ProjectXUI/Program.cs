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
            Excel excel = new Excel(@"E:\Genesis_C#\SampleLogin\SampleLoginUI\Login.xlsx", 1);
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
                        

                    }



                    else
                        Console.WriteLine("Invalid Credentials");
                    excel.save();

                    excel.saveas(@"E:\Genesis_C#\SampleLogin\SampleLoginUI\Login.xlsx");
                    excel.close();


                    break;
                default:
                    Console.WriteLine("its is default Case");
                    break;


            }

        }
    
    }
}
