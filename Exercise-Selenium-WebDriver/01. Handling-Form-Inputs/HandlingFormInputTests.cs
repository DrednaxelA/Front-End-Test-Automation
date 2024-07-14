using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _01._Handling_Form_Inputs
{
    public class HandlingFormInputTests
    {
        //TODO: Group tests in suites!

        //always create webdriver object outside 
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }

        [Test]
        public void HandlingFormInputs()
        {
            //click on "My Account" button
            driver.FindElements(By.XPath("//span[@class='ui-button-text']"))[2].Click();

            //click on "Continue" button
            driver.FindElement(By.LinkText("Continue")).Click();

            //click on the "Male" radio button
            driver.FindElement(By.XPath("//input[@type='radio'][@value='m']")).Click();

            //fill out the "First" and "Last" name fields
            driver.FindElement(By.XPath("//input[@type='text'][@name='firstname']")).SendKeys("Alexander");
            driver.FindElement(By.XPath("//input[@type='text'][@name='lastname']")).SendKeys("Dimitrov");

            //fill out the "Date of Birth field
            driver.FindElement(By.Id("dob")).SendKeys("04/18/1998");

            //fill out the "E-Mail Address" field:
            //1. build random email address
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999); //creates a num from .... to .....
            string email = "alex" + randomNumber.ToString() + "@gmail.com";
            //2. fill out email field
            driver.FindElement(By.Name("email_address")).SendKeys($"{email}");


            //fill out the "Company" field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='company']")).SendKeys("Ander's Company");

            //fill out the "Street Address" field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='street_address']")).SendKeys("ul. Belasitsa 71");

            //fill out the "Suburb" field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='suburb']")).SendKeys("Center");

            //fill out the "Post Code" field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='postcode']")).SendKeys("4000");

            //fill out the "City" field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='city']")).SendKeys("Plovdiv");

            //fill out the "State/Province" field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='state']")).SendKeys("Plovdiv");

            //choose a country from the "Country" drop-down:
            //1. locate the "Country" drop-down
            //2. create a SelectElement object
            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("Bulgaria");
            

            //fill out the "Telephone Number" field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='telephone']")).SendKeys("0888 888 888");

            //fill out the "Fax Number" field
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='fax']")).SendKeys("123-321-123");

            //mark the "Newsletter" checkbox
            driver.FindElement(By.XPath("//input[@type='checkbox'][@name='newsletter']")).Click();

            //fill out the "Password" and "Repeat Password" fields
            driver.FindElement(By.XPath("//input[@type='password'][@name='password']")).SendKeys("Password123");
            driver.FindElement(By.XPath("//input[@type='password'][@name='confirmation']")).SendKeys("Password123");

            //click on the "Continue" button
            driver.FindElements(By.XPath("//span[@class='ui-button-text']"))[3].Click();

            //assert that you see the "Log Off" button
            //assert that the "Continue" button is visible
            //assert that the account confirmation text is visible
            var confirmationMessage = driver.FindElement(By.XPath("//div[@id='bodyContent']//h1")).Text;
            Assert.That(confirmationMessage, Is.EqualTo("Your Account Has Been Created!"));

            //var confirmationText = driver.FindElement(By.XPath("//div[@class='contentText']")).Text;
            //Assert.Contains(confirmationText, "Congratulations!");

            var continueBtn = driver.FindElement(By.XPath("//span[@class='ui-button-icon-primary ui-icon ui-icon-triangle-1-e']"));
            Assert.That(continueBtn, Is.Not.Null, "Continue button not found!");

            driver.FindElement(By.LinkText("Log Off")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();

            Console.WriteLine("User Created Successfully!");
        }

        [TearDown] 
        public void TearDown()
        {
            driver.Quit(); //closes all tabs and browser but doesnt clear all memory
            driver.Dispose(); //clears all references in the network/memory/any reference created
        }
    }
}