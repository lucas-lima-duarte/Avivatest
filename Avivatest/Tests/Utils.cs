using OpenQA.Selenium;
using System;

namespace Avivatest.Tests
{
    public static class Utils
    {
        public static void TakeScreenshot(string name, IWebDriver driver)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@$"..\..\..\Screenshots\{DateTime.Now.ToString("yyyy-MM-dd-HH-mm")} - {name}.png", ScreenshotImageFormat.Png);

        }
    }
}
