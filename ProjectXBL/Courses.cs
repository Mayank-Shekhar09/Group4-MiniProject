using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
    public class Courses
    {
        private string courseId;
        private string courseTitle;
        private float duration;
        private string courseOwnerName;
        List<string> courseFaculties = new List<string>();
        class Enums
        {
            enum assessmentMode
            {
                hands_on,
                mcq,
                no_assessment
            };
        }
    }
}
