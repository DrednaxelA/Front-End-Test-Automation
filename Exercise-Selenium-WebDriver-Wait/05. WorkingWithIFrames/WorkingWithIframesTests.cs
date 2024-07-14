using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace _05._WorkingWithIFrames
{
    public class WorkingWithIframesTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);         
        }

        [Test]
        public void TestIFrameByIndex()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

            IWebElement dropDownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dropdown']//button")));

            dropDownButton.Click();

            ReadOnlyCollection<IWebElement> dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-content']//a")));

            foreach (IWebElement link in dropDownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.True(link.Displayed, "Link inside the dropdown is not displayed as expected");
            }

            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void TestFrameById()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("result"));

            IWebElement dropDownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dropdown']//button")));

            dropDownButton.Click();

            ReadOnlyCollection<IWebElement> dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-content']//a")));

            foreach (IWebElement link in dropDownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.True(link.Displayed, "Link inside the dropdown is not displayed as expected");
            }

            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void TestFrameByWebElement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var frameElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#result")));
            driver.SwitchTo().Frame(frameElement);

            IWebElement dropDownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dropdown']//button")));

            dropDownButton.Click();

            ReadOnlyCollection<IWebElement> dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-content']//a")));

            foreach (IWebElement link in dropDownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.True(link.Displayed, "Link inside the dropdown is not displayed as expected");
            }

            driver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}