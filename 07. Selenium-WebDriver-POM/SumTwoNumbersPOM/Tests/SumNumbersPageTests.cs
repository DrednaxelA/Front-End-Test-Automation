using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SumTwoNumbersPOM.POM;

namespace SumTwoNumbersPOM.Tests
{
    public class SumNumbersPageTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            
        }

        [Test]
        public void SumNumbers_WithValidPositiveNumbers_ReturnsResult()
        {
            var sumPage = new SumNumbersPage(driver);
            sumPage.OpenApplicationPage();
            string result = sumPage.AddNumbers("5", "5");
            Assert.That(result, Is.EqualTo("Sum: 10"));
        }

        [Test]
        public void SumNumbers_WithInvalidPositiveNumbers_ReturnsError()
        {
            var sumPage = new SumNumbersPage(driver);
            sumPage.OpenApplicationPage();
            string result = sumPage.AddNumbers("one", "two");
            Assert.That(result, Is.EqualTo("Sum: invalid input"));
        }

        [Test]
        public void SumNumbers_WithValidNegativeNumbers_ReturnsResult()
        {
            var sumPage = new SumNumbersPage(driver);
            sumPage.OpenApplicationPage();
            string result = sumPage.AddNumbers("-10", "-15");
            Assert.That(result, Is.EqualTo("Sum: -25"));
        }

        [Test]
        public void SumNumbers_WithValidLargeNumbers_ReturnsResult()
        {
            var sumPage = new SumNumbersPage(driver);
            sumPage.OpenApplicationPage();
            string result = sumPage.AddNumbers("100000000001000000000010000000000", "10000000000100000000001000000000010000000000");
            Assert.That(result, Is.EqualTo("Sum: 1.0000000000199999e+43"));
        }

        [Test]
        public void SumNumbers_WithValidTooLargeNumbers_ReturnsInfinity()
        {
            var sumPage = new SumNumbersPage(driver);
            sumPage.OpenApplicationPage();
            string result = sumPage.AddNumbers("100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000100000000001000000000010000000000", "1000000000000000000000000010000000000001000000000010000000000");
            Assert.That(result, Is.EqualTo("Sum: Infinity"));
        }

        [Test]
        public void ResetButton_ResetsForm_AfterCalculation()
        {
            var sumPage = new SumNumbersPage(driver);
            sumPage.OpenApplicationPage();

            sumPage.AddNumbers("5", "5");
            sumPage.ResetForm();

            Assert.That(sumPage.FieldNum1.Text, Is.EqualTo(string.Empty));
            Assert.That(sumPage.FieldNum2.Text, Is.EqualTo(string.Empty));
            Assert.False(sumPage.ResultElement.Displayed);
        }

        [Test]
        public void ResetButton_ResetsForm_WithoutCalculation()
        {
            var sumPage = new SumNumbersPage(driver);
            sumPage.OpenApplicationPage();

            sumPage.FieldNum1.SendKeys("1");
            sumPage.FieldNum2.SendKeys("2");
            sumPage.ResetForm();

            Assert.That(sumPage.FieldNum1.Text, Is.EqualTo(string.Empty));
            Assert.That(sumPage.FieldNum2.Text, Is.EqualTo(string.Empty));
            Assert.False(sumPage.ResultElement.Displayed);
        }       

        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}