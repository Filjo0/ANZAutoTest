using ANZAutoTest.Selenium;

namespace ANZAutoTest.Pages
{
    internal static class MainPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
        }
    }
}