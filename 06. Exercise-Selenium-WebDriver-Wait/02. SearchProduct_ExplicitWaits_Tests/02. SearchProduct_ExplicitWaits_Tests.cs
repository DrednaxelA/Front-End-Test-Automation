using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _02._SearchProduct_ExplicitWaits_Tests
{
    public class SearchProduct_ExplicitWaits_Tests
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
            driver.FindElement(By.Name("keywords")).SendKeys("keyboard");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement buyNowButton = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Buy Now")));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                buyNowButton.Click();

                IWebElement cartContents = driver.FindElement(By.XPath("//span[@class='ui-button-text']"));
                IWebElement checkoutButton = driver.FindElement(By.LinkText("Checkout"));

                Assert.IsTrue(driver.PageSource.Contains("keyboard"));
                Assert.That(cartContents.Text.Contains("1"));
                Assert.That(checkoutButton.Displayed, Is.True);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " +  ex.Message);
            }
        }

        [Test]
        public void SearchProduct_Junk_ShouldThrowNoSuchElementException()
        {
            driver.FindElement(By.Name("keywords")).SendKeys("junk");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement buyNowButton = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Buy Now")));
                buyNowButton.Click();
                Assert.Fail("The 'Buy Now' button was found for a non-existing product!");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Pass("The expected NoSuchElementException was thrown.");
            }
            catch  (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
            finally 
            {
                //Reset the implicit wait
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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