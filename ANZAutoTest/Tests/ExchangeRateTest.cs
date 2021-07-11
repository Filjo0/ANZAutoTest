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

            Log.Debug("Starting" + TestContext.CurrentContext.Test.Name);

            foreach (var currency in ExchangeRatesPage.GetCurrencies())
            {
                Log.Info(currency);
                if (currency.Percentage > 15.0)
                {
                    Log.Error(currency + " higher than 15%");
                }
            }
        }
    }
}