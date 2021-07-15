using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddCourseBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCourseBL.Tests
{
    [TestClass()]
    public class AddCourseTests
    {

        [TestMethod()]
        public void PSetLevelTest()
        {
            AddCourse a = new AddCourse();
            string expected = "ILSWITTI500";
            a.CourseId = "ILSWITTI";
            string actual = a.SetLevel("L2");
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void NSetLevelTest()
        {
            AddCourse a = new AddCourse();
            string expected = "ILSWITTI500";
            a.CourseId = "ILSWITTI";
            string actual = a.SetLevel("L1");
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod()]
        public void PAddCourseTest()
        {
            string[] faculty = new string[] { "Ramesh", "Suresh" };
            Mode mode = Mode.HandsOn;
            AddCourse a = new AddCourse("IL", "SW", 'T', 'T', 'I', "Java", 8.0F, "Rajat",faculty,mode,"abc");
            string expected = "ILSWTTI";
            string actual = a.CourseId;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NAddCourseTest()
        {
            string[] faculty = new string[] { "Ramesh", "Suresh" };
            Mode mode = Mode.HandsOn;
            AddCourse a = new AddCourse("IL", "SW", 'T', 'T', 'I', "Java", 8.0F, "Rajat", faculty, mode, "abc");
            string expected = "ILSWTI";
            string actual = a.CourseId;
            Assert.AreNotEqual(expected, actual);
        }
    }
}