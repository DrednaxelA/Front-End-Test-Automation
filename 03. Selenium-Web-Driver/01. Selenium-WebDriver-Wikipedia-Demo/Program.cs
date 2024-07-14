using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _01._Selenium_WebDriver_Wikipedia_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a new object (Browser instance). convention is to call it "driver"
            var driver = new ChromeDriver(); 

            //Navigate to the URL
            driver.Url = "https://wikipedia.org";

            //Find on the search field
            var searchField = driver.FindElement(By.Id("searchInput"));

            //Click on the search field:
            searchField.Click();

            //Type "Quality Assurance" and press "Enter":
            searchField.SendKeys("Quality Assurance" + Keys.Enter);

            //Get the web page title
            var currentPageTitle = driver.Title;

            //Print the page title
            Console.WriteLine("Current page title is: " + currentPageTitle);

            driver.Quit(); // kill the entire instance, .Close() will close the current tab only
        }
    }
}