using System.Collections.Generic;
using System.Linq;
using ANZAutomation.Model;
using ANZAutomation.Selenium;
using Selenium.WebDriver.Extensions;

namespace ANZAutomation.Pages
{
    public static class ExchangeRatesPage
    {
        private static readonly List<Currency> ListOfCurrencies = new List<Currency>();

        public static void GoTo()
        {
            if (IsAt()) return;
            HomePage.GoTo();
            RatesPage.GoTo();
            RatesPage.SwitchToForeignExchangeRates();
            Driver.TakeScreenshot();
        }

        private static bool IsAt()
        {
            var headerOfTheExchangeRatesPage = Driver.Instance.FindElements(By.JQuerySelector("div#M1Pheader1"));

            var doesHeaderOfTheExchangeRatesPageExist = headerOfTheExchangeRatesPage.Any(element => element.Text.Equals("Foreign Exchange Rates - Australia"));

            return doesHeaderOfTheExchangeRatesPageExist;
        }


        private static IEnumerable<Currency> GetCurrencies()
        {
            GetOddRows();
            GetEvenRows();
            return ListOfCurrencies;
        }

        private static void GetEvenRows()
        {
            var evenRows = Driver.Instance.FindElements(By.JQuerySelector("tr.EvenRow"));

            foreach (var evenRow in evenRows)
            {
                var currBuy = evenRow.FindElements(By.JQuerySelector("td"))[3];
                var currSell = evenRow.FindElements(By.JQuerySelector("td"))[6];

                if (!float.TryParse(currBuy.Text, out _) || !float.TryParse(currSell.Text, out _)) continue;

                var currName = evenRow.FindElements(By.JQuerySelector("td"))[2];
                var curr = new Currency(currName.Text, float.Parse(currBuy.Text), float.Parse(currSell.Text), Currency.GetPercentage(float.Parse(currBuy.Text), float.Parse(currSell.Text)));

                ListOfCurrencies.Add(curr);
            }
        }

        private static void GetOddRows()
        {
            var oddRows = Driver.Instance.FindElements(By.JQuerySelector("tr.OddRow"));

            foreach (var oddRow in oddRows)
            {
                var currBuy = oddRow.FindElements(By.JQuerySelector("td"))[3];
                var currSell = oddRow.FindElements(By.JQuerySelector("td"))[6];

                if (!double.TryParse(currBuy.Text, out _) || !double.TryParse(currSell.Text, out _)) continue;

                var currName = oddRow.FindElements(By.JQuerySelector("td"))[2];
                var curr = new Currency(currName.Text, float.Parse(currBuy.Text), float.Parse(currSell.Text), Currency.GetPercentage(float.Parse(currBuy.Text), float.Parse(currSell.Text)));

                ListOfCurrencies.Add(curr);
            }
        }

        public static void CheckCurrencies()
        {
            foreach (var currency in GetCurrencies())
            {
                Driver.Log.Info(currency);
                if (currency.Percentage > 15.0)
                {
                    Driver.Log.Error(currency + " higher than 15%");
                }
            }
        }
    }
}