using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _04._WorkingWithAlerts
{
    public class WorkingWithAlertsTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void HandleBasicAlert()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Alert')]")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            alert.Accept();

            IWebElement resultParagraph = driver.FindElement(By.XPath("//p[@id='result']"));

            Assert.That(resultParagraph.Text, Is.EqualTo("You successfully clicked an alert"));
        }

        [Test]
        public void HandleConfirmAlert()
        {
            IWebElement actionButton = driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Confirm')]"));
            actionButton.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            IWebElement okParagraph = driver.FindElement(By.XPath("//p[@id='result']"));
            Assert.That(okParagraph.Text, Is.EqualTo("You clicked: Ok"));

            actionButton.Click();
            alert.Dismiss();

            IWebElement cancelParagraph = driver.FindElement(By.XPath("//p[@id='result']"));
            Assert.That(cancelParagraph.Text, Is.EqualTo("You clicked: Cancel"));
        }

        [Test]
        public void HandlePromptAlert()
        {
            IWebElement actionButton = driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Prompt')]"));
            actionButton.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys("asd");
            alert.Accept();

            IWebElement resultDiv = driver.FindElement(By.XPath("//p[@id='result']"));

            Assert.That(resultDiv.Text, Is.EqualTo("You entered: asd"));
        }

        [TearDown] public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}