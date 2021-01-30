using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

namespace Avivatest
{
    public class RegisterTest
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            //Navega para a pagina de registro
            driver.Navigate().GoToUrl("http://eaapp.somee.com/Account/Register");
            Thread.Sleep(1000);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(DateTime.Now + "Navigate_to_register_screen.png");
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
            inputUsername.SendKeys("l.aviv");
            inputPassword.SendKeys("Senha123@");
            inputConfirmPassword.SendKeys("Senha123@");
            inputEmail.SendKeys("lucas@avivatec.com.br");
            btnRegister.Click();

        }

        [TearDown]
        public void CloseUp()
        {
            driver.Close();
        }
    }
}