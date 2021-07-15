using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ProjectXBL
{
    class ExcelOp
    {

        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        

        public ExcelOp(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }

        public bool ReadcourseId(string s)
        {

            int j = 1;
            for (int i = 1; i < 100; i++)
            {

                if (ws.Cells[i, j].Value2 == null)
                {
                    Console.WriteLine("Null");
                    break;
                }
                else if (s.Equals(ws.Cells[i, j].Value2.ToString()))
                    return true;

                else
                    continue;
            }

            return false;
        }

        public bool ValidateFaculty(string s)
        {

            int j = 3;
            for (int i = 1; i < 100; i++)
            {

                if (ws.Cells[i, j].Value2 == null)
                {
                    Console.WriteLine("No Faculty");
                    break;
                }
                else if (s.Equals(ws.Cells[i, j].Value2.ToString()))
                    return true;

                else
                    continue;
            }

            return false;
        }


        public bool Setcourse(string courseId,string courseTitle,float courseDuration,string courseOwner)
        {
            int flag = 0;
            string[] courseInfo = new string[] { courseId, courseTitle, courseDuration.ToString(), courseOwner };
            for (int j = 1; j < 5; j++)
            {
                string s = courseInfo[j - 1];
                for (int i = 2; i < 100; i++)
                {
                    if (ws.Cells[i, j].Value2 == null)
                    {
                        ws.Cells[i, j].Value2 = s;
                        break;
                    }


                }
                flag = 1;
            }
            if (flag == 1)
                return true;
            else
                return false;
        }

        

        public bool setfaculty(string[] s,int facultyTotal)
        {
            string input="";
            int j = 5;
            for (int index = 0; index < facultyTotal-1; index++)
                input += s[index] + ',';
            input += s[facultyTotal - 1];
            Console.WriteLine(input);
            for (int i = 2; i < 100; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    ws.Cells[i, j].Value2 = input;
                    return true;
                }


            }

            return false;
        }

        public bool setMode(Mode mode)
        {
            int j = 6;
            for (int i = 2; i < 100; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    ws.Cells[i, j].Value2 = mode.ToString();
                    return true;
                }


            }

            return false;
        }

        public bool setAddress(string address)
        {
            int j = 7;
            for (int i = 2; i < 100; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    ws.Cells[i, j].Value2 = address;
                    return true;
                }


            }

            return false;
        }

        public void save()
        {
            wb.Save();
        }
        public void saveas(string path)
        {
            wb.SaveAs(path);
        }
        public void close()
        {
            excel.Workbooks.Close();
            excel.Quit();
            Task.Delay(1000);
           // wb.Close();
        }
    }
}


    

