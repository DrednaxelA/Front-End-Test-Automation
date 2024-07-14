using Students_Registry_POM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_POM.Tests
{
    public class ViewStudentsPageTests : BaseTests
    {
        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            var viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.Open();
            Assert.That(viewStudentsPage.GetPageTitle(), Is.EqualTo("Students"));
            Assert.That(viewStudentsPage.GetPageHeadingText, Is.EqualTo("Registered Students"));

            var students = viewStudentsPage.GetRegisteredStudents();

            foreach (string student in students)
            {
                Assert.That(student, Is.Not.Empty);
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.IndexOf(")") == student.Length - 1);
            }

            Assert.That(students.Count, Is.Not.Zero);
        }
    }
}
