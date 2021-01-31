using OpenQA.Selenium;
using System;
using System.Linq;

namespace Avivatest.Tests
{
    public static class Utils
    {
        private static Random random = new Random();

        //Metodo para gerar uma string aleatoria de tamanho N
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void TakeScreenshot(string name, IWebDriver driver)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@$"..\..\..\Screenshots\{DateTime.Now.ToString("yyyy-MM-dd-HH-mm")} - {name}.png", ScreenshotImageFormat.Png);

        }
    }
}
