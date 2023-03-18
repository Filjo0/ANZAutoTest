using ANZAutomation.Selenium;
using OpenQA.Selenium;

namespace ANZAutomation.Pages
{
    public static class RatesPage
    {
        /// <summary>
        /// Goes to the Rates page.
        /// </summary>
        public static void GoTo()
        {
            HomePage.SearchForRates();

            Driver.Instance.FindElement(By.LinkText("Rates, fees, terms and taxes")).Click();

            Driver.SwitchToNewTab();
        }
        
        /// <summary>
        /// Switches to the 'Foreign Exchange Rates' page.
        /// </summary>
        public static void SwitchToForeignExchangeRates()
        {
            Driver.Instance.FindElement(By.LinkText("Foreign exchange rates")).Click();

            Driver.SwitchToNewTab();
        }
    }
}