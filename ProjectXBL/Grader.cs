using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ProjectXBL
{
    public class Grader
    {
        
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Grader()
        {

        }
        public Grader(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public bool VerifyDetail(string courseName, string faculty)
        {
            //ws.Cells[4, 4].Value2 = "Hello";
            int j = 1;
            for (int i = 1; i < 1000; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    return false;
                }
                else
                {
                    if (((ws.Cells[i, j].Value2).Equals(courseName)) && ((ws.Cells[i, j + 1].Value2).Equals(faculty)))
                        return true;
                }

            }
            return false;
            //ws.Cells[i, j].Value2 = s;
        }

        /* public void GraderFeedback(string path, int sheet)
         {
             this.path = path;
             wbFeed = excel.Workbooks.Open(path);
             wsFeedback = wbBatches.Worksheets[sheet];
         }*/
        public string[,] ReadRange(int starti, int starty, int endi, int endy)
        {

            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            object[,] holder = range.Value2;
            string[,] returnstring = new string[endi - starti + 1, endy - starty + 1];
            for (int p = 1; p <= endi - starti; p++)
            {
                for (int q = 1; q <= endy - starty; q++)
                {
                    if (holder[p, q] == null)
                        return returnstring;
                    returnstring[p - 1, q - 1] = holder[p, q].ToString();

                }
            }
            return returnstring;
        }


        public void WriteRange(int starti, int starty, int endi, int endy, string[,] writestring)
        {
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            range.Value2 = writestring;


        }
        public void Close()
        {
            //excel.Workbooks.Close();
            //excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
            //wb.Close();

        }
        public void Save()
        {
            wb.Save();
        }
    }
}
