using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT
{
    public class Class1
    {

        [Test]
        public void TestMethod()
        {
            IWebDriver driver = new ChromeDriver(@"F:\Automation\Project\Automation\PART2\AT\Driver");
            driver.Url = @"file:F:\Automation\Pages\homepage.html";

            // Assert.AreEqual("Home page", driver.Title);
            StringAssert.AreEqualIgnoringCase("Home page", driver.Title);

            IWebElement emailField = driver.FindElement(By.Id("email"));
            IWebElement pwdField = driver.FindElement(By.Id("password"));

            emailField.SendKeys("admin@domain.org");
            pwdField.SendKeys("111111");

            IWebElement loginButton = driver.FindElement(By.Id("Login"));

            loginButton.Click();

            driver.Quit();


         

            



            

            





        }
        

        

    }
}
