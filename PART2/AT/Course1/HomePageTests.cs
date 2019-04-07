using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Course1
{
    class HomePageTests
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver(@"F:\Automation\Project\Automation\PART2\AT\Driver");
            driver.Url = @"file:F:\Automation\Pages\homepage.html";
        }
        [TearDown]
        public void  CleanUp()
        {
            driver.Quit();
        }
        

        [Test]
       public void CheckHeaderItems()
        {
           
            IWebElement headerImage = driver.FindElement(By.XPath("//*[@id='header']/a/img"));
            IWebElement wikiLink = driver.FindElement(By.XPath("//ul/a[@href='wikipage.html']"));
            IWebElement homeLink = driver.FindElement(By.XPath("//ul/a[@href='homepage.html']"));

            Assert.IsTrue(headerImage.Displayed);
            Assert.IsTrue(wikiLink.Displayed);
            Assert.IsTrue(homeLink.Displayed);
 
 
        }

        [Test]
        public void TitlePage()
        {
           StringAssert.AreEqualIgnoringCase("Home page", driver.Title);

        }

        [Test]
        public void FrontPageTitle()
        {
            IWebElement frontPageTitle = driver.FindElement(By.XPath("//h1"));

            StringAssert.AreEqualIgnoringCase("HTML", frontPageTitle.Text);

        }

        [Test]
        public void DefaultCredentialsCorrectedDisplayed()
        {
            IWebElement defaultEmail = driver.FindElement(By.XPath("//html/body/b/p[1]"));
            IWebElement defaultPassword = driver.FindElement(By.XPath("//html/body/b/p[2]"));

            Assert.IsTrue(defaultEmail.Displayed);
            Assert.IsTrue(defaultPassword.Displayed);

            StringAssert.Contains("admin@domain.org", defaultEmail.Text);
            StringAssert.Contains("111111", defaultPassword.Text);

        }

        [Test]

        public void LoginFieldsDisplay()
        {
            IWebElement emailField = driver.FindElement(By.Id("email"));
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement buttonLogin = driver.FindElement(By.Id("Login"));

            Assert.IsTrue(emailField.Displayed);
            Assert.IsTrue(passwordField.Displayed);
            Assert.IsTrue(buttonLogin.Displayed);

        }

        [Test]
        public void LoginWithoutCredentialsErrorMessages()
        {
            IWebElement emailNoDataLoginError = driver.FindElement(By.Id("emailErrorText"));
            IWebElement passwordNoDataLoginError = driver.FindElement(By.Id("passwordErrorText"));


            IWebElement buttonLogin = driver.FindElement(By.Id("Login"));
            buttonLogin.Click();

            StringAssert.AreEqualIgnoringCase("Email address can't be null", emailNoDataLoginError.Text);
            StringAssert.AreEqualIgnoringCase("Password can't be null", passwordNoDataLoginError.Text);
        }

        [Test]
        public void InvalidEmailAddressErrorMessage()
        {
            IWebElement invalidEmailAddress = driver.FindElement(By.Id("emailErrorText"));
            IWebElement emailField = driver.FindElement(By.Id("email"));

            IWebElement buttonLogin = driver.FindElement(By.Id("Login"));
            buttonLogin.Click();

            emailField.SendKeys("maria");
           
            buttonLogin.Click();

            StringAssert.AreEqualIgnoringCase("Email address format is not valid", invalidEmailAddress.Text);

        }
        [Test]
        public void InvalidPasswordErrorMessage()
        {
            IWebElement invalidPasswordErrorMessasge = driver.FindElement(By.Id("passwordErrorText"));
            IWebElement passwordField = driver.FindElement(By.Id("password"));


            IWebElement buttonLogin = driver.FindElement(By.Id("Login"));
            buttonLogin.Click();

            passwordField.SendKeys("123");

            buttonLogin.Click();

            StringAssert.AreEqualIgnoringCase("Invalid password/email", invalidPasswordErrorMessasge.Text);

        }

        [Test]
        public void LoginWithValidCredentialsAndCheckLadingPageTitle()
        {
            IWebElement emailField = driver.FindElement(By.Id("email"));
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement buttonLogin = driver.FindElement(By.Id("Login"));

            emailField.SendKeys("admin@domain.org");
            passwordField.SendKeys("111111");

            buttonLogin.Click();

            StringAssert.AreEqualIgnoringCase("Dashboard Page", driver.Title);

    
        }

        [Test]
        public void NavigateOnWikiPageAndCheckLandingPageTitle()
        {
            IWebElement wikiLink = driver.FindElement(By.XPath("//ul/a[@href='wikipage.html']"));

            wikiLink.Click();

            StringAssert.AreEqualIgnoringCase("Wiki Page", driver.Title);

        }
        //li/a[@href='homepage.html']

            [Test]
        public void CheckFooterItems()
        {

            IWebElement homePageLink = driver.FindElement(By.XPath("//li/a[@href='homepage.html']"));
            IWebElement wikiPageLink= driver.FindElement(By.XPath("//li/a[@href='wikipage.html']"));
            IWebElement contactLink = driver.FindElement(By.LinkText("Contact (NA)"));

            Assert.IsTrue(homePageLink.Displayed);
            Assert.IsTrue(wikiPageLink.Displayed);
            Assert.IsTrue(contactLink.Displayed);


        }


    }
}
