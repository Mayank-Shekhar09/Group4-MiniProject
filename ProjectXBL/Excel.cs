using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ProjectXBL
{
    public class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }
        public bool Readusername(string s)
        {

            int j = 1;
            for (int i = 1; i < 10; i++)
            {
                string b = ws.Cells[i, j].Value2.ToString();
                if (b == s)
                    return true;
            }

            return false;
        }

        public bool Readpassword(string s)
        {

            int j = 2;
            for (int i = 1; i < 10; i++)
            {
                string b = ws.Cells[i, j].Value2.ToString();
                if (b == s)
                    return true;
            }

            return false;
        }
        public bool setuser(string s)
        {
            int j = 1;
            for (int i = 1; i < 10; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    ws.Cells[i, j].Value2 = s;
                    return true;
                }


            }

            return false;

        }
        public bool setpass(string s)
        {
            int j = 2;
            for (int i = 1; i < 10; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    ws.Cells[i, j].Value2 = s;
                    return true;
                }


            }

            return false;
        }
        public bool ReadCourseId(string s)
        {

            int j = 1;
            for (int i = 1; i < 10; i++)
            {
                string b = ws.Cells[i, j].Value2.ToString();
                if (b == s)
                    return true;
            }

            return false;
        }
        public bool WriteModelName(string s)
        {

            int j = 1;
            for (int i = 1; i < 10; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    ws.Cells[i, j].Value2 = s;
                    return true;
                }


            }

            return false;

        }
        public bool WriteCourseId(string s)
        {
            int j = 2;
            for (int i = 1; i < 10; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    ws.Cells[i, j].Value2 = s;
                    return true;
                }


            }

            return false;

        }
        public bool ReadModelName(string s)
        {
            int j = 1;
            for (int i = 1; i < 10; i++)
            {
                string b = ws.Cells[i, j].Value2.ToString();
                if (b == s)
                    return true;
            }

            return false;
        }
        public bool ReadFacultyName(string s)
        {
            int j = 4;
            for (int i = 1; i < 10; i++)
            {
                string b = ws.Cells[i, j].Value2.ToString();
                if (b == s)
                    return true;
            }

            return false;
        }
        public bool WriteToBatch(string s, int k)
        {
            int j = k;
            for (int i = 1; i < 10; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    ws.Cells[i, j].Value2 = s;
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
            wb.Close();
        }
    }
}
