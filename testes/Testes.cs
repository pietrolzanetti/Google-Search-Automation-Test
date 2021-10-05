using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using Selenium;
using testes;
using Xunit;

namespace Testes
{
    public class Testes
    {
        private IConfiguration _configuration;
        public Testes()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }

        [Fact]
        public void TestarFirefox()
        {
            ExecutaTesteGoogle(Browser.Firefox);
        }

        [Fact]
        public void TestarChrome()
        {
            ExecutaTesteGoogle(Browser.Chrome);
        }

        private void ExecutaTesteGoogle(Browser browser)
        {
            TesteGoogle testeGoogle = new TesteGoogle(_configuration, browser);
            testeGoogle.CarregarPagina();
            testeGoogle.BuscaGoogle();
            System.Threading.Thread.Sleep(1000);
            testeGoogle.TesteOrdenacao();
            System.Threading.Thread.Sleep(1000);
            testeGoogle.FuncionamentoNavigation();
            testeGoogle.FecharPagina();
        }
    }
}
