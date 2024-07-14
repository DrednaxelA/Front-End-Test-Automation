using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V124.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumTwoNumbersPOM.POM
{
    public class SumNumbersPage
    {
        private readonly IWebDriver driver;

        //constructor
        public SumNumbersPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().
                ImplicitWait = TimeSpan.FromSeconds(2);
        }

        //define URL in a constant
        const string pageUrl = "https://389898f8-d57b-4daa-a1a3-1954b10a5c05-00-2bqz3z0g4p8co.kirk.replit.dev/";

        //map all relevant elements
        public IWebElement FieldNum1 => driver.FindElement(By.CssSelector("input#number1"));
        public IWebElement FieldNum2 => driver.FindElement(By.CssSelector("input#number2"));
        public IWebElement CalculateButton => driver.FindElement(By.CssSelector("input#calcButton"));
        public IWebElement ResetButton => driver.FindElement(By.CssSelector("input#resetButton"));
        public IWebElement ResultElement => driver.FindElement(By.CssSelector("div#result"));

        //map all page actions to methods
        public void OpenApplicationPage()
        {
            driver.Navigate().GoToUrl(pageUrl);
        }

        public string AddNumbers(string num1, string num2)
        {
            FieldNum1.SendKeys(num1);
            FieldNum2.SendKeys(num2);
            CalculateButton.Click();
            string result = ResultElement.Text;
            return result;
        }

        public void ResetForm()
        {
            ResetButton.Click();
        }

        public bool IsFormEmpty()
        {
            return FieldNum1.Text + FieldNum2.Text + ResultElement.Text == string.Empty;
        }
    }
}
