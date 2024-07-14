using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WorkingWIthWindows
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void HandleMultipleWindows()
        {
            driver.FindElement(By.LinkText("Click Here")).Click();

            //Get all window handles
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            //Assert that there are at least two windows open
            Assert.That(windowHandles.Count, Is.EqualTo(2), "There should be two window handles open");

            driver.SwitchTo().Window(windowHandles[1]);

            //IWebElement newWindowDiv = driver.FindElement(By.XPath("//div[@class='example']//h3"));
            //Assert.True(newWindowDiv.Displayed);
            //Assert.That(newWindowDiv.Text, Is.EqualTo("New Window"));

            string newWindowContent = driver.PageSource;
            Assert.True(newWindowContent.Contains("New Window"), "The content of the new window is not as expected!");

            //log the content of the new window>?
            string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
            if (File.Exists(path))
            {
                File.Delete(path);  
            }
            File.AppendAllText(path, "Window handle for new window: " + driver.CurrentWindowHandle + "\n\n");
            File.AppendAllText(path, "The page content: " + newWindowContent + "\n\n");

            driver.Close();

            driver.SwitchTo().Window(windowHandles[0]);

            string originalWindowContent = driver.PageSource;

            Assert.True(originalWindowContent.Contains("Opening a new window"), "The content of the original window is not as expected");

            File.AppendAllText(path, "Window handle for original window: " + driver.CurrentWindowHandle + "\n\n");
            File.AppendAllText(path, "The page content: " + "\n\n" + originalWindowContent + "\n\n");
        }

        [Test]
        public void HandleNoSuchWindowException ()
        {
            driver.FindElement(By.LinkText("Click Here")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            driver.SwitchTo().Window(windowHandles[1]);
            driver.Close();

            try
            {
                driver.SwitchTo().Window(windowHandles[1]);
               
            }
            catch (NoSuchWindowException ex)
            {
                //log the exception
                string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
                File.AppendAllText(path, "NoSuchWindowException caught: " + ex.Message + "\n\n");
                Assert.Pass("The expected NoSuchWindowException was thrown and handled correctly");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception thrown: " + ex.Message);
            }
            finally
            {
                driver.SwitchTo().Window(windowHandles[0]);
            }
            
        }

        [TearDown] 
        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}