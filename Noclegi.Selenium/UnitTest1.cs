using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace Noclegi.Selenium
{/*
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver(@"C:\Users\Penta6ram\source\repos\Noclegi\Noclegi.Selenium\bin\Release\netcoreapp2.0\");
           
        }

        [TestMethod]
        public void RegisterWithNotMatch()
        {

            driver.Navigate().GoToUrl("http://localhost:51324/account/register");
            var email = driver.FindElement(By.Id("Email"));
            email.Click();
            email.SendKeys("test1@example.com");

            var pass = driver.FindElement(By.Id("Password"));
            pass.Click();
            pass.SendKeys("admin1");

            var conPass = driver.FindElement(By.Id("ConfirmPassword"));
            conPass.Click();
            conPass.SendKeys("admin123");
            pass.Click();

            var error = driver.FindElement(By.Id("ConfirmPassword-error")).Text;

            StringAssert.Contains(error, "The password and confirmation password do not match.");

            driver.Quit();
        }

        [TestMethod]
        public void LoginWithCorrectEmailAndPasswordAsAdmin()
        {
            
            driver.Navigate().GoToUrl("http://localhost:51324/account/login");
            var email = driver.FindElement(By.Id("Email"));
            email.Click();
            email.SendKeys("admin@admin.com");

            var pass = driver.FindElement(By.Id("Password"));
            pass.Click();
            pass.SendKeys("admin\n");

            var admin = driver.FindElement(By.LinkText("Hello admin@admin.com!")).Text;

            StringAssert.Contains(admin, "Hello admin@admin.com!");
            driver.Quit();

        }

        [TestMethod]
        public void CreateCategoryTest()
        {

            driver.Navigate().GoToUrl("http://localhost:51324/account/login");
            var email = driver.FindElement(By.Id("Email"));
            email.Click();
            email.SendKeys("admin@admin.com");

            var pass = driver.FindElement(By.Id("Password"));
            pass.Click();
            pass.SendKeys("admin\n");

            driver.Navigate().GoToUrl("http://localhost:51324/categories");

            driver.FindElement(By.XPath("/html/body/div/p/a")).Click();

            var name = driver.FindElement(By.Id("Name"));
            name.Click();
            name.SendKeys("categoryTest");
            
            driver.FindElement(By.XPath("/html/body/div/div[1]/div/form/div[2]/input")).Click();

            var category = driver.FindElement(By.XPath("/html/body/div/table/tbody/tr/td[1]")).Text;

            StringAssert.Contains(category, "categoryTest");

            driver.Quit();

        }
    }
    */
}
