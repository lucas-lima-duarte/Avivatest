using Avivatest.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
             
namespace Avivatest
{
    public class RegisterTest
    {
        IWebDriver driver = new ChromeDriver();
        private static Random random = new Random();

        //Declara os campos aleatorios
        string username = RandomString(6);
        string email = RandomString(6) + "@avivatec.com";
        string password = "Senha123@";

        //Metodo para gerar uma string aleatoria de tamanho N
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
            Utils.TakeScreenshot("Pagina Inicial", driver);

            //Navega para a pagina de registro
            driver.FindElement(By.Id("registerLink")).Click();
            Thread.Sleep(1000);
            Utils.TakeScreenshot("Pagina de Registro", driver);
        }

        [Test]
        public void RegisterAndLogin()
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
            inputPassword.SendKeys(password);
            inputConfirmPassword.SendKeys(password);
            inputEmail.SendKeys(email);
            btnRegister.Click();
            Thread.Sleep(1000);

            Utils.TakeScreenshot("Teste", driver);

            driver.FindElement(By.Id("logoutForm")).Submit();

            driver.FindElement(By.Id("loginLink")).Click();

            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);

            driver.FindElement(By.CssSelector("input[value='Log in']")).Click();


            Assert.AreEqual(username, "assert");


        }

        [TearDown]
        public void CloseUp()
        {
        }
    }
}