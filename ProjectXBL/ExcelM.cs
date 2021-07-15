using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ProjectXBL
{
    public class ExcelM
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public ExcelM(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public string[,] ReadRange(int startx, int starty, int endx, int endy)
        {
            Range range = (Range)ws.Range[ws.Cells[startx, starty], ws.Cells[endx, endy]];
            object[,] holder = range.Value2;
            string[,] returnstring = new string[endx - startx + 1, endy - starty + 1];
            for (int i = 1; i <= endx - startx; i++)
            {
                for (int j = 1; j <= endy - starty; j++)
                {
                    returnstring[i - 1, j - 1] = holder[i, j].ToString();
                }
            }
            return returnstring;
        }

        public void Save()
        {
            wb.Save();
        }

        public void ModifyDuration(string courseid, int hours)
        {
            // ReadRange(1, 1, 12, 5);
            for (int i = 1; i <= 100; i++)
            {
                if (ws.Cells[i, 1].Value == courseid)
                {
                    ws.Cells[i, 3].Value = hours;
                }
            }
        }

        public void ModifyPrimaryFaculty(string courseid, string faculty)
        {
            Range range = (Range)ws.Range[ws.Cells[1, 1], ws.Cells[100, 1]];
            for (int i = 1; i <= 100; i++)
            {
                if (ws.Cells[i, 1].Value == courseid)
                {
                    ws.Cells[i, 4].Value = faculty;
                }
            }
        }
        public void ModifyOtherFaculty(string courseid, string faculties)
        {
            Range range = (Range)ws.Range[ws.Cells[1, 1], ws.Cells[100, 1]];
            for (int i = 1; i <= 100; i++)
            {
                if (ws.Cells[i, 1].Value == courseid)
                {
                    ws.Cells[i, 5].Value = faculties;
                }
            }
        }

        public void Close()
        {
            excel.Workbooks.Close();
            //wb.Close();
            excel.Quit();
        }

    }
}
