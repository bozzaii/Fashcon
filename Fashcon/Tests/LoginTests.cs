using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Fashcon.Tests.LoginTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureOwner("Nedim Hasanagic")]
    internal class LoginTests : TestBase
    {


        [Test]
        [AllureEpic("fash-8652")]
        [AllureStory("fash-8653")]
        [AllureDescription("Test Cases with valid credentials for Log In functionality")]
        public void LogIn()
        {
            landingPage.ClikcOnLoginLink();
            loginPage.EnterEmail(testData.UserName)
                     .EnterPassword(testData.Password)
                     .ClickOnLogInButton();
            labelArchivePage.ValidateRedirection();

        }



        [AllureEpic("fash-8654")]
        [AllureStory("fash-8655")]
        [AllureDescription("Test Cases with Invalid credentials for Log In functionality")]
        [TestCase("xohigeg991@macauvpn.com", "Testpass1", "Incorrect username or password.")]
        [TestCase("xohigeg992@macauvpn.com", "Testpass2", "Incorrect username or password.")]
        [TestCase("xohigeg992@macauvpn.com", "Testpass2", "Failed on purpose")]
       public void LogInInvalidTests(string email, string pass, string expectedResult)
        {
            landingPage.ClikcOnLoginLink();
            loginPage.EnterEmail(email)
                     .EnterPassword(pass)
                     .ClickOnLogInButton()
                     .ValidateErrorMessage(expectedResult);

        }

    }
}
