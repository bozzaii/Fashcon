using Fashcon.Pages;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.IO;
using Allure.Commons;

namespace Fashcon
{
    internal class TestBase
    {
        IWebDriver? driver;

        public LandingPage landingPage;
        public LoginPage loginPage;
        public LabelArchivePage labelArchivePage;
        string workingDirectory;


        public TestData testData;

        [SetUp]
        public void SetUp()
        {
            StartBrowser();
            NavigateToPage(testData.Url);
            InitializePages();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            GetWorkingDir();
            AllureConfig();
            GetData();

        }


        void GetWorkingDir()
        {
            workingDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        }

        void GetData()
        {
            testData = JObject.Parse(File.ReadAllText(Path.Combine(workingDirectory, "TestData.json"))).ToObject<TestData>();
        }

        void StartBrowser()
        {
            switch (testData.Browser)
            {
                case "Chrome":
                    driver = new ChromeDriver(); break;
                case "Edge":
                    driver = new EdgeDriver(); break;
            }
            driver.Manage().Window.Maximize();
        }

        void NavigateToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        void InitializePages()
        {
            landingPage = new LandingPage(driver);
            loginPage = new LoginPage(driver);
            labelArchivePage = new LabelArchivePage(driver);
        }

        void AllureConfig()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }



        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }





    }
}
