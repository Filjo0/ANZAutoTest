using ANZAutomation.Pages;
using ANZAutomation.Selenium;
using log4net.Config;
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
            XmlConfigurator.Configure();
            Driver.Log.Debug("Starting" + TestContext.CurrentContext.Test.Name);
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