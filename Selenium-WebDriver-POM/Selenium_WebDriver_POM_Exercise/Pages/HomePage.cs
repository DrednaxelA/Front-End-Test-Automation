using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_POM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/";
        public IWebElement ElementStudentsCount => driver.FindElement(By.TagName("b"));

        public string GetStudentsCount()
        {
            return ElementStudentsCount.Text;
        }
    }
}
