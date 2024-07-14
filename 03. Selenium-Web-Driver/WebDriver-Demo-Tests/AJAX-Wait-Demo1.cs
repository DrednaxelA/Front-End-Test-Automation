using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver_Demo_Tests
{
    public class AJAX_Wait_Demo1
    {
        private ChromeDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            // set once at the beginning of the test. in this time period it will constantly the element to appear
        }
        [Test]
        public void WaitExample()
        {

            driver.Navigate().GoToUrl("http://uitestingplayground.com/ajax");

            driver.FindElement(By.Id("ajaxButton")).Click();

            string fieldText = driver.FindElement(By.ClassName("bg-success")).Text;
            
            Assert.That(fieldText, Is.EqualTo("Data loaded with AJAX get request."));
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
