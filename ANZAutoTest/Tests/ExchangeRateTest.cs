using System.Reflection;
using ANZAutomation.Pages;
using ANZAutomation.Utilities;
using log4net;
using log4net.Config;
using NUnit.Framework;

namespace ANZAutoTest.Tests
{
    [TestFixture]
    public class ExchangeRateTest : BaseSetup
    {
        private static readonly ILog Logger = LogManager.GetLogger
            (MethodBase.GetCurrentMethod().DeclaringType);

        [Test]
        public void Exchange_Rate_Does_Not_Increase_15_Percents()
        {
            XmlConfigurator.Configure();

            ExchangeRatesPage.GoTo();
            if (!ExchangeRatesPage.IsAt) return;

            Logger.Debug("Starting Exchange_Rate_Does_Not_Increase_15_Percents Test...");

            foreach (var currency in ExchangeRatesPage.GetCurrencies())
            {
                Logger.Info(currency);
                if (currency.Percentage > 15.0)
                {
                    Logger.Error(currency + " higher than 15%");
                }
            }
        }
    }
}