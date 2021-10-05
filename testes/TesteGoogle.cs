using System;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;
using Selenium;
using Xunit;

namespace testes
{
    public class TesteGoogle
    {
        private IConfiguration _configuration;
        private Browser _browser;
        private IWebDriver _driver;

        public TesteGoogle(IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string pathDriver = null;

            if (_browser == Browser.Firefox)
            {
                pathDriver = _configuration.GetSection("Selenium:PathDriverFirefox").Value;
            }
            else if (_browser == Browser.Chrome)
            {
                pathDriver = _configuration.GetSection("Selenium:PathDriverChrome").Value;
            }

            _driver = WebDriverFactory.CreateWebDriver(_browser, pathDriver);
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("https://www.google.com.br");
        }

        public void PrintTela(string caminho)
        {
            ITakesScreenshot takes = _driver as ITakesScreenshot;
            Screenshot print = takes.GetScreenshot();
            print.SaveAsFile(caminho, ScreenshotImageFormat.Png);
        }

        public void BuscaGoogle()
        {
            IWebElement webElement = _driver.FindElement(By.Name("q"));
            webElement.SendKeys("Concert Technologies");
            webElement.SendKeys(Keys.Enter);
            PrintTela(@"C:\selenium\Print\Inicio.png");

            IWebElement resultadoPesquisa = _driver.FindElement(By.Id("search"));
            var resultado = resultadoPesquisa.FindElements(By.XPath(".//a"));

            Assert.True(resultado.Count > 0);

        }

        public void TesteOrdenacao()
        {
            _driver.FindElement(By.Id("hdtb-tls")).Click();
            System.Threading.Thread.Sleep(2000);
            var data = _driver.FindElements(By.ClassName("KTBKoe"))[2];
            data.Click();
            System.Threading.Thread.Sleep(2000);
            var selecionar = _driver.FindElements(By.ClassName("Tlae9d"))[3];
            selecionar.Click();
            System.Threading.Thread.Sleep(2000);
            PrintTela(@"C:\selenium\Print\Ordenacao.png");
        }

        public void FuncionamentoNavigation()
        {
            _driver.FindElement(By.LinkText("Notícias")).Click();
            PrintTela(@"C:\selenium\Print\Noticias.png");
            System.Threading.Thread.Sleep(1000);


            _driver.FindElement(By.LinkText("Maps")).Click();
            PrintTela(@"C:\selenium\Print\Maps.png");
            System.Threading.Thread.Sleep(10000);
            _driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);

            _driver.FindElement(By.LinkText("Imagens")).Click();
            PrintTela(@"C:\selenium\Print\Imagens.png");
            System.Threading.Thread.Sleep(1000);

            _driver.FindElement(By.LinkText("Vídeos")).Click();
            PrintTela(@"C:\selenium\Print\Videos.png");
            System.Threading.Thread.Sleep(1000);

            _driver.FindElement(By.XPath("//div[contains(@class, 'GOE98c')]")).Click();
            _driver.FindElement(By.LinkText("Shopping")).Click();
            PrintTela(@"C:\selenium\Print\Shopping.png");
            System.Threading.Thread.Sleep(1000);
            _driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);

            _driver.FindElement(By.XPath("//div[contains(@class, 'GOE98c')]")).Click();
            _driver.FindElement(By.LinkText("Livros")).Click();
            PrintTela(@"C:\selenium\Print\Livros.png");
            System.Threading.Thread.Sleep(1000);
            _driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);

            _driver.FindElement(By.XPath("//div[contains(@class, 'GOE98c')]")).Click();
            _driver.FindElement(By.LinkText("Voos")).Click();
            PrintTela(@"C:\selenium\Print\Voos.png");
            System.Threading.Thread.Sleep(1000);
            _driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);

            _driver.FindElement(By.XPath("//div[contains(@class, 'GOE98c')]")).Click();
            _driver.FindElement(By.LinkText("Finanças")).Click();
            PrintTela(@"C:\selenium\Print\Financas.png");
            System.Threading.Thread.Sleep(1000);

        }

        public void FecharPagina()
        {
            _driver.Quit();
            _driver = null;
        }

    }
}
