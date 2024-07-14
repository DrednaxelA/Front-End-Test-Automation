using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver_Demo_Tests
{
    public class Tests
    {
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://wikipedia.org");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void CheckPageTitle()
        {        
            Assert.That(driver.Title, Is.EqualTo("Wikipedia"));

        }

        [Test]
        public void CheckQualityAssurancePageTitle()
        {
            //Arrange

            //Act
            driver.FindElement(By.Id("searchInput")).SendKeys("Quality Assurance" + Keys.Enter);

            //Assert
            Assert.That(driver.Title, Is.EqualTo("Quality assurance - Wikipedia"));
        }
    }
}