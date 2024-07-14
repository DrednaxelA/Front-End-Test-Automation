using Students_Registry_POM.Pages;

namespace Students_Registry_POM.Tests
{
    public class AddStudentsPageTests : BaseTests
    {
        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            Assert.True(addStudentPage.NameField.Displayed);
            Assert.True(addStudentPage.EmailField.Displayed);
            Assert.True(addStudentPage.AddButton.Displayed);
            
            Assert.That(addStudentPage.GetPageTitle(), Is.EqualTo("Add Student"));
            Assert.That(addStudentPage.GetPageHeadingText(), Is.EqualTo("Register New Student"));
        }

        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            Assert.True(addStudentPage.LinkHomePage.Displayed);
            Assert.True(addStudentPage.LinkHomePage.Enabled);
            Assert.True(addStudentPage.LinkViewStudentsPage.Displayed);
            Assert.True(addStudentPage.LinkViewStudentsPage.Enabled);
            Assert.True(addStudentPage.LinkAddStudentPage.Displayed);
            Assert.True(addStudentPage.LinkAddStudentPage.Enabled);
        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();
            string testName = "New Student" + DateTime.Now.Ticks;
            string testEmail = "email" + DateTime.Now.Ticks + "@email.com";

            addStudentPage.AddNewStudent(testName, testEmail);

            var viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.Open();

            Assert.That(new ViewStudentsPage(driver).IsOpen, Is.True);

            var registeredStudents = viewStudentsPage.GetRegisteredStudents();
            CollectionAssert.Contains(registeredStudents, $"{testName} ({testEmail})");
        }

        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();
            string testName = "";
            string testEmail = "email" + DateTime.Now.Ticks + "@email.com";

            addStudentPage.AddNewStudent(testName, testEmail);
            Assert.That(addStudentPage.IsOpen, Is.True);

            Assert.That(addStudentPage.ErrorElement.Text, Is.EqualTo("Cannot add student. Name and email fields are required!"));
            Console.WriteLine(addStudentPage.GetErrorMsg());
        }
    }
}