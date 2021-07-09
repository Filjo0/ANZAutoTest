using ANZAutomation.Selenium;
using OpenQA.Selenium;

namespace ANZAutomation.Pages
{
    public static class HomePage
    {
        /// <summary>
        /// Uses search to find the 'Rates' page
        /// </summary>
        public static void SearchForRates()
        {
            Driver.Instance.FindElement(By.CssSelector("input#searchinput")).SendKeys("Rates, fees, terms and taxes");
            Driver.Instance.FindElement(By.CssSelector("button#searchsubmit")).Click();
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