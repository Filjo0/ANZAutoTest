using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ANZAutomation.Selenium
{
    public static class Driver
    {
        public static IWebDriver Instance { get; private set; }

        public static string BaseAddress => "https://www.anz.com.au/";

        public static void Initialize()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int) (timeSpan.TotalSeconds * 1000));
        }

        public static void TakeScreenshot()
        {
            var screenshotDriver = (ITakesScreenshot) Instance;
            var screenshot = screenshotDriver.GetScreenshot();
            Instance.Manage().Window.Maximize();
            screenshot.SaveAsFile(DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".png", ScreenshotImageFormat.Png);
        }
    }
}