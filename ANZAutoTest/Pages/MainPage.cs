using ANZAuto.UnitTest.Selenium;

namespace ANZAuto.UnitTest.Pages
{
    internal static class MainPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
        }
    }
}