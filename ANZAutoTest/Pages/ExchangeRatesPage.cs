using System.Collections.Generic;
using System.Linq;
using ANZAutoTest.Model;
using ANZAutoTest.Selenium;
using OpenQA.Selenium;

namespace ANZAutoTest.Pages
{
    public static class ExchangeRatesPage
    {
        private static readonly List<Currency> ListOfCurrencies = new List<Currency>();

        private static IWebElement useSearchToGoToExchangeRatesPage =
            Driver.Instance.FindElement(By.CssSelector("input#searchinput"));

        private static IWebElement buttonSearchToGoToExchangeRatesPage =
            Driver.Instance.FindElement(By.CssSelector("button#searchsubmit"));

        private static void SearchForExchangeRate()
        {
            useSearchToGoToExchangeRatesPage.SendKeys("foreign exchange rate");
            buttonSearchToGoToExchangeRatesPage.Click();
        }

        public static void GoToExchangeRatesPage()
        {
            SearchForExchangeRate();

            Driver.Instance.FindElement(By.LinkText("ANZ Foreign Exchange Rates Page")).Click();
        }

        public static bool IsAtExchangeRatesPage
        {
            get
            {
                var headerOfTheExchangeRatesPage = Driver.Instance.FindElements(By.CssSelector("div#M1Pheader1"));

                var doesHeaderOfTheExchangeRatesPageExist =
                    headerOfTheExchangeRatesPage.Any(element =>
                        element.Text.Equals("Foreign Exchange Rates - Australia"));

                return doesHeaderOfTheExchangeRatesPageExist;
            }
        }


        public static IEnumerable<Currency> GetCurrencies()
        {
            GetOddRows();
            GetEvenRows();
            return ListOfCurrencies;
        }

        private static void GetEvenRows()
        {
            var evenRows =
                Driver.Instance.FindElements(
                    By.CssSelector("tr.EvenRow"));
            foreach (var evenRow in evenRows)
            {
                var currBuy = evenRow.FindElements(By.TagName("td"))[5];
                var currSell = evenRow.FindElements(By.TagName("td"))[8];

                if (!float.TryParse(currBuy.Text, out _) || !float.TryParse(currSell.Text, out _)) continue;

                var currName = evenRow.FindElements(By.TagName("td"))[2];
                var curr = new Currency(currName.Text, float.Parse(currBuy.Text), float.Parse(currSell.Text),
                    Currency.GetPercentage(float.Parse(currBuy.Text), float.Parse(currSell.Text)));
                ListOfCurrencies.Add(curr);
            }
        }

        private static void GetOddRows()
        {
            var oddRows =
                Driver.Instance.FindElements(
                    By.CssSelector("tr.OddRow"));
            foreach (var oddRow in oddRows)
            {
                var currBuy = oddRow.FindElements(By.TagName("td"))[5];
                var currSell = oddRow.FindElements(By.TagName("td"))[8];

                if (!double.TryParse(currBuy.Text, out _) || !double.TryParse(currSell.Text, out _)) continue;

                var currName = oddRow.FindElements(By.TagName("td"))[2];
                var curr = new Currency(currName.Text, float.Parse(currBuy.Text), float.Parse(currSell.Text),
                    Currency.GetPercentage(float.Parse(currBuy.Text), float.Parse(currSell.Text)));
                ListOfCurrencies.Add(curr);
            }
        }
    }
}