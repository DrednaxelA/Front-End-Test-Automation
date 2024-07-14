using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriver_Waits_Lab_Tests
{
    public class WebDriverWaitTests
    {
        IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
        }

        [Test, Order(1)]
        public void AddBoxWithoutWaitsFails()
        {
            driver.FindElement(By.XPath("//input[@id='adder']")).Click();

            Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.XPath("//div[@id='box0']")));
        }

        [Test, Order(2)]
        public void RevealInputWithoutWaitsFails()
        {
            driver.FindElement(By.XPath("//input[@id='reveal']")).Click();

            IWebElement revealedInput = driver.FindElement(By.XPath("//input[@id='revealed']"));         

            Assert.Throws<ElementNotInteractableException>(() => revealedInput.SendKeys("Field revealed!"));
        }

        [Test, Order(3)]
        public void AddBoxWithThreadSleep()
        {
            driver.FindElement(By.XPath("//input[@id='adder']")).Click();
            Thread.Sleep(3000);

            IWebElement boxDiv = driver.FindElement(By.XPath("//div[@id='box0']"));

            Assert.True(boxDiv.Displayed);
        }

        [Test, Order(4)]

        public void AddBoxWithImplicitWait()
        {
            driver.FindElement(By.XPath("//input[@id='adder']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement boxDiv = driver.FindElement(By.XPath("//div[@id='box0']"));

            Assert.True(boxDiv.Displayed);
        }

        [Test, Order(5)]
        public void RevealInputWithImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.XPath("//input[@id='reveal']")).Click();
            
            IWebElement revealedInput = driver.FindElement(By.XPath("//input[@id='revealed']"));
            revealedInput.SendKeys("Field Revealed!");

            Assert.That(revealedInput.GetAttribute("value"), Is.EqualTo("Field Revealed!"));
            Assert.That(revealedInput.TagName, Is.EqualTo("input"));
        }

        [Test, Order(6)]
        public void RevealInputWithExplicitWait()
        {
            driver.FindElement(By.XPath("//input[@id='reveal']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            IWebElement revealedInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='revealed']")));

            revealedInput.SendKeys("Field Revealed!");

            Assert.That(revealedInput.GetAttribute("value"), Is.EqualTo("Field Revealed!"));
            Assert.That(revealedInput.TagName, Is.EqualTo("input"));
        }

        [Test, Order(7)]
        public void AddBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions()
        {
            driver.FindElement(By.XPath("//input[@id='adder']")).Click();

            //WebDriverWait fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Message = "10 seconds have passed!"
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement boxDiv = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='box0']")));

            Assert.True(boxDiv.Displayed);
        }

        [Test, Order(8)]
        public void RevealInputWithCustomFluentWait()
        {
            driver.FindElement(By.XPath("//input[@id='reveal']")).Click();
            IWebElement revealedInput = driver.FindElement(By.XPath("//input[@id='revealed']"));

            WebDriverWait fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(200);
            fluentWait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            fluentWait.Until(d =>
            {
                revealedInput.SendKeys("Field Revealed!");
                return true;
            });


            Assert.That(revealedInput.GetAttribute("value"), Is.EqualTo("Field Revealed!"));
            Assert.That(revealedInput.TagName, Is.EqualTo("input"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}