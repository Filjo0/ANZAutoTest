using ANZAutoTest.Pages;
using ANZAutoTest.Selenium;
using NUnit.Framework;

namespace ANZAutoTest.Utilities
{
    [TestFixture]
    public class BaseSetup
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialize();
            MainPage.GoTo();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}