using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
    class FacultyManagement : CourseManagement
    {
        private string PSNo;
        private string name;
        private string emailId;
        public string PSNO { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
    }
}
