using ANZAutomation.Selenium;
using Selenium.WebDriver.Extensions;

namespace ANZAutomation.Pages
{
    public static class HomePage
    {
        public static void SearchForRates()
        {
            EnterSearch("Rates, fees, terms and taxes");
            SubmitSearch();
        }

        /// <summary>
        /// Goes to Home page
        /// </summary>
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
        }
        
        /// <summary>
        /// Uses search to find the 'Rates' page
        /// </summary>
        private static void EnterSearch(string input) => Driver.Instance.FindElement(By.JQuerySelector("input#searchinput")).SendKeys(input);

        private static void SubmitSearch() => Driver.Instance.FindElement(By.JQuerySelector("button#searchsubmit")).Click();
    }
}