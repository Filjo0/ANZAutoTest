using ANZAutomation.Pages;
using ANZAutoTest.Utilities;
using NUnit.Framework;

namespace ANZAutoTest.Tests
{
    [TestFixture]
    public class ExchangeRateTest : BaseSetup
    {
        [Test]
        public void Exchange_Rate_Does_Not_Increase_15_Percents()
        {
            ExchangeRatesPage.GoTo();
            ExchangeRatesPage.CheckCurrencies();
        }
    }
}