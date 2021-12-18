using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Allure.Attributes;

namespace Fashcon.Pages
{
    internal class LoginPage
    {

        private static IWebDriver driver;

        public LoginPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }


        //Elements
        static IWebElement emailInput => driver.FindElement(By.Id("edit-mail"));
        static IWebElement passwordInput => driver.FindElement(By.Id("edit-pass"));
        static IWebElement logInButton => driver.FindElement(By.Id("edit-submit"));
        static IWebElement errorMessage => driver.FindElement(By.XPath("//div[@class='messages messages--error']"));


        //Actions
        [AllureStep("Enter UserName/Email")]
        public LoginPage EnterEmail(string email) { emailInput.SendKeys(email); return this; }
        [AllureStep("Enter Password")]
        public LoginPage EnterPassword(string pass) { passwordInput.SendKeys(pass); return this; }
        [AllureStep("Click on Log In Button")]
        public LoginPage ClickOnLogInButton() { logInButton.Click(); return this; }


        [AllureStep("Validate Error Message")]
        public LoginPage ValidateErrorMessage(string expectedMessage)
        {
            errorMessage.Text.Should().Contain(expectedMessage);
            return this;
        }

    }
}
