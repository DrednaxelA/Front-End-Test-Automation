using Students_Registry_POM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_POM.Tests
{
    public class HomePageTests : BaseTests
    {
        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();
            page.GetStudentsCount();

            Assert.That(page.GetPageTitle, Is.EqualTo("MVC Example"));
            Assert.That(page.GetPageHeadingText(), Is.EqualTo("Students Registry"));
            Assert.That(page.ElementStudentsCount, Is.Not.Zero);
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.True(new HomePage(driver).IsOpen());

            homePage.Open();
            homePage.LinkViewStudentsPage.Click();
            Assert.True(new ViewStudentsPage(driver).IsOpen());

            homePage.Open();
            homePage.LinkAddStudentPage.Click();
            Assert.True(new AddStudentPage(driver).IsOpen());
        }
    }
}
