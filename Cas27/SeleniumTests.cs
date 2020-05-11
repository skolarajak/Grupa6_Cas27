using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Cas27
{
    class SeleniumTests
    {
        IWebDriver driver;

        WebDriverWait wait;

        private string TestData_Email = UsefulFunctions.RandomEmail();
        private string TestData_Password = UsefulFunctions.RandomPassword();

        [Test]        public void Search()        {
            IWebElement buttonSearch = driver.FindElement(By.Name("submit_search"));            if (buttonSearch.Displayed && buttonSearch.Enabled)            {                IWebElement searchInput = driver.FindElement(By.Name("search_query"));                if (searchInput.Displayed && searchInput.Enabled)                {                    searchInput.SendKeys("faded");                }                buttonSearch.Click();                Assert.Pass();                System.Threading.Thread.Sleep(5000);            }        }


        [Test]
        public void TestHomePage()
        {
            IWebElement logo = driver.FindElement(By.ClassName("logo"));
            if (logo.Displayed)
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestSignIn()
        {
            ClickOnSignInLink();

            IWebElement button = driver.FindElement(By.Name("SubmitLogin"));
            if (button.Displayed && button.Enabled)
            {
                IWebElement email = driver.FindElement(By.Name("email"));
                IWebElement password = driver.FindElement(By.Name("passwd"));

                email.SendKeys(TestData_Email);
                password.SendKeys(TestData_Password);

                button.Click();
                Assert.Pass();
            }
        }

        [Test]
        public void TestRegistration()
        {
            ClickOnSignInLink();

            IWebElement createButton = driver.FindElement(By.Name("SubmitCreate"));
            if (createButton.Displayed && createButton.Enabled)
            {
                IWebElement createEmail = driver.FindElement(By.Name("email_create"));
                if (createEmail.Displayed && createEmail.Enabled)
                {
                    createEmail.SendKeys(TestData_Email);
                }
                createButton.Click();
            }

            IWebElement form_firstName = wait.Until(EC.ElementIsVisible(By.Name("customer_firstname")));

            if (form_firstName.Displayed && form_firstName.Enabled)
            {
                form_firstName.SendKeys("Probnoime");
                IWebElement form_lastName = driver.FindElement(By.Name("customer_lastname"));
                if (form_lastName.Enabled) form_lastName.SendKeys("Probnoprezime");

                IWebElement form_password = driver.FindElement(By.Name("passwd"));
                if (form_password.Enabled) form_password.SendKeys(TestData_Password);

                IWebElement form_addrFName = driver.FindElement(By.Name("firstname"));
                if (form_addrFName.Enabled)
                {
                    form_addrFName.Clear();
                    form_addrFName.SendKeys("Probnoime");
                }

                IWebElement form_addrLName = driver.FindElement(By.Name("lastname"));
                if (form_addrLName.Enabled)
                {
                    form_addrLName.Clear();
                    form_addrLName.SendKeys("Probnoprezime");
                }

                IWebElement form_address1 = driver.FindElement(By.Name("address1"));
                if (form_address1.Enabled) form_address1.SendKeys("Adresa Neka 23");

                IWebElement form_city = driver.FindElement(By.Name("city"));
                if (form_city.Enabled) form_city.SendKeys("Grad");

                IWebElement form_state = driver.FindElement(By.Name("id_state"));

                wait.Until(EC.ElementExists(By.XPath("//option[@value='50']")));

                if (form_state.Enabled)
                {
                    SelectElement state = new SelectElement(form_state);
                    //state.SelectByText("Hawaii");
                    state.SelectByValue("11");
                }

                IWebElement form_zip = driver.FindElement(By.Name("postcode"));
                if (form_zip.Enabled) form_zip.SendKeys("12345");

                IWebElement form_mobile = driver.FindElement(By.Name("phone_mobile"));
                if (form_mobile.Enabled) form_mobile.SendKeys("123456");

                IWebElement form_alias = driver.FindElement(By.Name("alias"));
                if (form_alias.Enabled)
                {
                    form_alias.Clear();
                    form_alias.SendKeys("Moja adresa");
                }

                IWebElement registerButton = driver.FindElement(By.Name("submitAccount"));
                if (registerButton.Enabled) registerButton.Click(); ;
            }
        }

        public void ClickOnSignInLink()
        {
            IWebElement signin = wait.Until(EC.ElementIsVisible(By.LinkText("Sign in")));
            if (signin.Displayed && signin.Enabled)
            {
                signin.Click();
            }
        }

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
