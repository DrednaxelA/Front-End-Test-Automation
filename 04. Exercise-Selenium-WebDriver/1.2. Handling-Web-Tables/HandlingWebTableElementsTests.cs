using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace _1._2._Handling_Web_Tables
{
    public class Tests
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //make sure to allow the page to load
        }

        [Test]
        public void WorkingWithTableElements()
        {
            //locate product table
            IWebElement productsTable = driver.FindElement(By.XPath("//div[@class='contentText']//table"));

            ReadOnlyCollection<IWebElement> tableRows = productsTable.FindElements(By.XPath("//tbody//tr"));

            string path = System.IO.Directory.GetCurrentDirectory() + "/productinformation.csv";

            if (File.Exists(path))
            {
                File.Delete(path);
            };

            foreach (IWebElement row in tableRows)
            {
                ReadOnlyCollection<IWebElement> tableData = row.FindElements(By.XPath(".//td")); //search in the CURRENT row as we have 9 - using "." before XPath

                foreach (IWebElement tData in tableData)
                {
                    string data = tData.Text;
                    string[] productInfo = data.Split("\n");

                    File.AppendAllText(path, productInfo[0].Trim() + ", " + productInfo[1].Trim() + "\n");

                    Assert.IsTrue(File.Exists(path));
                    Assert.IsTrue(new FileInfo(path).Length > 0);
                }
            }

        }

        [TearDown] 
        public void Teardown() 
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}