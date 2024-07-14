using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Waits_Exercises
{
    public class WebDriverImplicitWaitTests
    {
        IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void SearchProduct_Keyboard_ShouldAddToCart()
        {
            //enter keyword into the search field
            driver.FindElement(By.Name("keywords")).SendKeys("keyboard");
            //click on the magnifying icon to search
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {
                driver.FindElement(By.LinkText("Buy Now")).Click();

                Assert.IsTrue(driver.PageSource.Contains("keyboard"), "The product 'keyboard' was not found on the cart page.");
                Console.WriteLine("Scenario completed.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }

        [Test]
        public void SearchProduct_Junk_ShouldThrowNoSuchElementException()
        {
            //enter keyword into the search field
            driver.FindElement(By.Name("keywords")).SendKeys("junk");
            //click on the magnifying icon to search
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {
                driver.FindElement(By.LinkText("Buy Now")).Click();

            }
            catch (NoSuchElementException ex)
            {
                Assert.Pass("Expected NoSuchElementException was thrown");
                Console.WriteLine("Timeout - " + ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }

            IWebElement noProductFoundDiv = driver.FindElement(By.XPath("//div[@class='contentText']//p"));

            Assert.That(noProductFoundDiv.Text, Is.EqualTo("There is no product that matches the search criteria."));
        }

        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}