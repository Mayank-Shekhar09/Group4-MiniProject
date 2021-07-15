using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ProjectXBL
{
    public class Excelf
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excelf(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }
        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null)
                return ws.Cells[i, j].Value2;
            else
                return " ";
        }

        public void WriteToCell(int psno, string emailId, string name)
        {

            int j = 1;
            for (int i = 1; i < 1000; i++)
            {
                if (ws.Cells[i, j].Value2 == null)
                {
                    ws.Cells[i, j++].Value2 = psno;
                    ws.Cells[i, j++].Value2 = emailId;
                    ws.Cells[i, j].Value2 = name;
                    break;
                }

            }
            //ws.Cells[i, j].Value2 = s;
        }

        public void Save()
        {
            wb.Save();
        }

        public void Close()
        {
            wb.Close();
        }
    }
}
