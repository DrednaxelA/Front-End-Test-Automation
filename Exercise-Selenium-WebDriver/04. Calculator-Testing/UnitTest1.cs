using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _04._Calculator_Testing
{
    public class Tests
    {
        WebDriver driver;
        IWebElement textBoxNumber1;
        IWebElement textBoxNumber2;
        IWebElement dropDownOperations;
        IWebElement calculateButton;
        IWebElement resetButton;
        IWebElement divResult;

        [OneTimeSetUp] 
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [SetUp]
        public void Setup()
        {

            textBoxNumber1 = driver.FindElement(By.Id("number1"));
            textBoxNumber2 = driver.FindElement(By.XPath("//input[@id='number2']")); //just for practice
            dropDownOperations = driver.FindElement(By.XPath("//select[@id='operation']"));
            calculateButton = driver.FindElement(By.XPath("//input[@id='calcButton']"));
            resetButton = driver.FindElement(By.XPath("//input[@id='resetButton']"));
            divResult = driver.FindElement(By.XPath("//div[@id='result']"));
        }

        public void PerformTestLogic(string firstNumber, string secondNumber, string operation, string expected)
        {
            //click reset button
            resetButton.Click();

            if (!string.IsNullOrEmpty(firstNumber))
            {
                textBoxNumber1.SendKeys(firstNumber);
            }
            if (!string.IsNullOrEmpty(secondNumber))
            {
                textBoxNumber2.SendKeys(secondNumber);
            }
            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropDownOperations).SelectByText(operation);
            }

            calculateButton.Click();

            Assert.That(divResult.Text, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("5", "10", "+ (sum)", "Result: 15")]
        [TestCase("5", "5", "+ (sum)", "Result: 10")]
        [TestCase("5", "15", "+ (sum)", "Result: 20")]
        public void TestResults(string firstNumber, string secondNumber, string operation, string expected)
        {
            PerformTestLogic(firstNumber, secondNumber, operation, expected);
        }

        [OneTimeTearDown] 
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}