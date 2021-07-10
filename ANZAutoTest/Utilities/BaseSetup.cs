using System.Reflection;
using ANZAutomation.Pages;
using ANZAutomation.Selenium;
using log4net;
using log4net.Config;
using NUnit.Framework;

namespace ANZAutoTest.Utilities
{
    [TestFixture]
    public class BaseSetup
    {
        protected static readonly ILog Log = LogManager.GetLogger
            (MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void Init()
        {
            Driver.Initialize();
            XmlConfigurator.Configure();
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