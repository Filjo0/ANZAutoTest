using ANZAuto.UnitTest.Selenium;
using NUnit.Framework;

namespace ANZAuto.UnitTest.Utilities
{
    [TestFixture]
    public class BaseSetup
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialize();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}