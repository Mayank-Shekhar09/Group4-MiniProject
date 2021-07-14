using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
    public class Participants
    {
        private int PS_No;
        private string email_Id;
        public int PSNO { get; set; }
        public string EmailId { get; set; }

        public void print(string psno)
        {
            PSNO = psno;
            Console.WriteLine(PS_No);
            Console.WriteLine(PSNO);
        }
        Grader grader = new Grader();
        //grader.ShowFeedBack(PSNo);
    }
}
