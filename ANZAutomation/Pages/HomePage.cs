using ANZAutomation.Selenium;
using OpenQA.Selenium;

namespace ANZAutomation.Pages
{
    public static class HomePage
    {
        /// <summary>
        /// Uses search to find the 'Rates' page
        /// </summary>
        private static void EnterSearch(string input) => Driver.Instance.FindElement(By.CssSelector("input#searchinput")).SendKeys(input);
        private static void SubmitSearch() => Driver.Instance.FindElement(By.CssSelector("button#searchsubmit")).Click();

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
    }
}