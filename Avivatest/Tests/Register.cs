using Avivatest.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
             
namespace Avivatest
{
    public class RegisterTest
    {
        IWebDriver driver = new ChromeDriver();

        //Declara os campos para preenchimento do formul�rio
        string username = Utils.RandomString(6);
        string email = Utils.RandomString(6) + "@avivatec.com";
        string password = "Senha123456789@Bisnaguinha.com";

        [SetUp]
        public void Setup()
        {
            //Navega para a pagina principal
            driver.Navigate().GoToUrl("http://eaapp.somee.com");
            Thread.Sleep(1000);

            Utils.TakeScreenshot("Tela principal", driver);

            //Navega para a pagina de registro
            driver.FindElement(By.Id("registerLink")).Click();
            Thread.Sleep(1000);

            Utils.TakeScreenshot("Tela de cadastro", driver);
        }

        [Test]
        public void RegisterAndLogin()
        {
            //Prenche o formulario de cadastro & submete
            driver.FindElement(By.Name("UserName")).SendKeys(username);
            driver.FindElement(By.Name("Password")).SendKeys(password);
            driver.FindElement(By.Name("ConfirmPassword")).SendKeys(password);
            driver.FindElement(By.Name("Email")).SendKeys(email);
            driver.FindElement(By.CssSelector("input[value='Register']")).Click();
            Thread.Sleep(1000);

            Utils.TakeScreenshot("Cadastro efetuado", driver);

            //Efetua o log-out p�s cadastro e faz o login do usu�rio recem cadastrado
            driver.FindElement(By.Id("logoutForm")).Submit();
            driver.FindElement(By.Id("loginLink")).Click();

            Utils.TakeScreenshot("Tela de Login", driver);

            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.CssSelector("input[value='Log in']")).Click();

            Utils.TakeScreenshot("Usu�rio logado com sucesso", driver);

            Assert.AreEqual(@$"Hello {username}!", driver.FindElement(By.CssSelector("a[title='Manage']")).Text);
        }

        [TearDown]
        public void CloseUp()
        {
            driver.Close();
        }
    }
}