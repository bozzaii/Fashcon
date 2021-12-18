using NUnit.Allure.Attributes;
using OpenQA.Selenium;


namespace Fashcon.Pages
{
    public class LandingPage
    {
        private static IWebDriver driver;

        public LandingPage(IWebDriver webDriver)
        {
            driver = webDriver;

        }

        //Elements
        static IWebElement loginLnk => driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));

        //Actions
        [AllureStep("Click on Log I n Button")]
        public void ClikcOnLoginLink() => loginLnk.Click();

    }



}
