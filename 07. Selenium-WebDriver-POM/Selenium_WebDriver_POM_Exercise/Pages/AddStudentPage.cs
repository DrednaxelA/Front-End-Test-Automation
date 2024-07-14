using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_POM.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver) { }
        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/add-student";
        public IWebElement ErrorElement => driver.FindElement(By.XPath("//*[contains(text(),'Cannot add student')]"));

        public IWebElement NameField => driver.FindElement(By.Id("name"));
        public IWebElement EmailField => driver.FindElement(By.Id("email"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public void AddNewStudent(string name, string email)
        {
            this.NameField.SendKeys(name);
            this.EmailField.SendKeys(email);
            this.AddButton.Click();
        }

        ////div[@id='fcehaejdgfifffajjicaefefdeaiajdc']
        public string GetErrorMsg()
        {
            return this.ErrorElement.Text;
        }
    }
}
