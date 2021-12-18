using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashcon.Pages
{
    internal class LabelArchivePage
    {

        private static IWebDriver driver;

        public LabelArchivePage(IWebDriver webDriver)
        {
            driver = webDriver;

        }

        //Elements
        static IWebElement SignOutLnk => driver.FindElement(By.XPath("//a[contains(text(),'Sign out')]"));


        //Actions
        [AllureStep("Validation Redirection and Sign In")]
        public void ValidateRedirection()
        {
            SignOutLnk.Text.Should().Contain("SIGN OUT");
            driver.Url.Should().Contain("labelarchive");
        }
    }
}
