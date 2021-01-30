using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;
using System.Linq;

// Impeditivos: Nao estou conseguindo salvar a print no diretorio correto
//              Organizar melhor o codigo para que as variaveis sejam acatadas
//              

namespace Avivatest
{
    public class RegisterTest
    {
        IWebDriver driver = new ChromeDriver();
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [SetUp]
        public void Setup()
        {
            //Navega para a pagina principal
            driver.Navigate().GoToUrl("http://eaapp.somee.com");
            Thread.Sleep(1000);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("../../../Screenshots " + DateTime.Now.ToString("dd-MM-yyyy") + " Pagina principal.png", ScreenshotImageFormat.Png);

            //Navega para a pagina de registro
            driver.FindElement(By.Id("registerLink")).Click();
            Thread.Sleep(1000);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("../../../Screenshots " + DateTime.Now.ToString("dd-MM-yyyy") + " Pagina de registro.png", ScreenshotImageFormat.Png);

            //Declara os campos aleatorios
            var username = RandomString(6);
            var email = RandomString(6) + "@avivatec.com";
        }

        [Test]
        public void Register()
        {
            //Inputs
            IWebElement inputUsername = driver.FindElement(By.Name("UserName"));
            IWebElement inputPassword = driver.FindElement(By.Name("Password"));
            IWebElement inputConfirmPassword = driver.FindElement(By.Name("ConfirmPassword"));
            IWebElement inputEmail = driver.FindElement(By.Name("Email"));

            //Botões
            IWebElement btnRegister = driver.FindElement(By.CssSelector("input[value='Register']"));

            //Prenche o formulario de cadastro & submete
            inputUsername.SendKeys(username);
            inputPassword.SendKeys("Senha123@");
            inputConfirmPassword.SendKeys("Senha123@");
            inputEmail.SendKeys(email);
            btnRegister.Click();
            Thread.Sleep(1000);

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("../../../Screenshots " + DateTime.Now.ToString("dd-MM-yyyy") + " Usuario registrado.png", ScreenshotImageFormat.Png);


        }

        [TearDown]
        public void CloseUp()
        {
            driver.Close();
        }
    }
}