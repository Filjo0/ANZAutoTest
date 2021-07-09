using ANZAutomation.Pages;
using ANZAutomation.Selenium;
using NUnit.Framework;

namespace ANZAutomation.Utilities
{
    [TestFixture]
    public class BaseSetup
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialize();
        }

        [SetUp]
        public void OpenMainPage()
        {
            HomePage.GoTo();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}