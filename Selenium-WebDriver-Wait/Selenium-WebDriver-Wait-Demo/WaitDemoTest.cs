using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_WebDriver_Wait_Demo
{
    public class WaitDemoTest
    {
        IWebDriver driver;

        //[SetUp]
        //public void Setup()
        //{
        //    driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        //}

        [Test]
        public void TestAddABoxButton()
        {
            driver.FindElement(By.XPath("//input[@id='adder']")).Click();

            IWebElement boxDiv = driver.FindElement(By.XPath("//div[@id='box0']"));

            Assert.True(boxDiv.Displayed);
        }

        [Test]
        public void TestRevealNewInputButton()
        {
            driver.FindElement(By.Id("reveal")).Click();

            IWebElement inputField = driver.FindElement(By.Id("revealed"));

            Assert.True(inputField.Displayed);
        }

        [Test]
        public void ExplicitWait_ElementCreatedButNotVisible()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");

            driver.FindElement(By.XPath("//div[@class='example']//div[@id='start']//button")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement finishDiv = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']//div[@id='finish']")));

            Assert.True(finishDiv.Displayed);
        }

        [Test]
        public void ImplicitWait_ElementNotCreated()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.XPath("//div[@class='example']//div[@id='start']/button")).Click();

            var resultDiv = driver.FindElement(By.XPath("//div[@class='example']//div[@id='finish']"));

            Assert.True(resultDiv.Displayed);
        }

        [Test]
        public void PageLoadTimeOut()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            var startButton = driver.FindElement(By.XPath("//div[@class='example']//div[@id='start']/button"));

            Assert.True(startButton.Displayed);

        }
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}