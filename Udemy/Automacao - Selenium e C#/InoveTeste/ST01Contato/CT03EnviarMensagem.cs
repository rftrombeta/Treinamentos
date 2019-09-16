using System;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ST01Contato
{
    [TestFixture]
    public class CT03EnviarMensagem
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        CT01ValidarLayoutTela ct01;

        [SetUp]
        public void SetupTest()
        {
            //driver = Comandos.GetBrowserMobile(driver, ConfigurationManager.AppSettings["platform"], "Celular Hugo", ConfigurationManager.AppSettings["browser"], "http://localhost:4723/wd/hub");
            //driver = Comandos.GetBrowserRemote(driver, ConfigurationManager.AppSettings["browser"], ConfigurationManager.AppSettings["uri"]);
            //driver = Comandos.GetBrowserLocal(driver, ConfigurationManager.AppSettings["browser"]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            baseURL = "https://livros.inoveteste.com.br/";
            verificationErrors = new StringBuilder();
            ct01 = new CT01ValidarLayoutTela();

        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheCT03EnviarMensagemTest()
        {
            //Pré-Requisito: Validar layout da tela
            /*ct01.SetupTest();
            ct01.TheCT01ValidarLayoutTelaTest();
            ct01.TeardownTest();*/

            // Acessa o site
            driver.Navigate().GoToUrl(baseURL + "/contato");
            
            // Acessa o menu Contato
            //driver.FindElement(By.CssSelector("em.fa.fa-bars")).Click();
            //driver.FindElement(By.CssSelector("div.sidr-inner > #nav-wrap > #primary_menu > #menu-item-80 > a > span")).Click();
            
            // Preenche todos os campos do formulário
            driver.FindElement(By.Name("your-name")).Clear();
            driver.FindElement(By.Name("your-name")).SendKeys("Hugo Peres");
            driver.FindElement(By.Name("your-email")).Clear();
            driver.FindElement(By.Name("your-email")).SendKeys("contato@inoveteste.com.br");
            driver.FindElement(By.Name("your-subject")).Clear();
            driver.FindElement(By.Name("your-subject")).SendKeys("Qual o valor do livro impresso?");
            driver.FindElement(By.Name("your-message")).Clear();
            driver.FindElement(By.Name("your-message")).SendKeys("Gostaria de saber qual o valor do livro impresso + frete para o cep 00000-000");
            
            // Clica no botão Enviar após preencher todos os campos obrigatórios
            driver.FindElement(By.CssSelector("input.wpcf7-form-control.wpcf7-submit")).Click();
            //driver.FindElement(By.CssSelector("input.wpcf7-form-control.wpcf7-submit")).Click();

            // Valida a mensagem de sucesso do envio da mensagem.
            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='wpcf7-f372-p24-o1']/form/div[2]")));
            Thread.Sleep(20000);
            Assert.AreEqual("Agradecemos a sua mensagem. Responderemos em breve.", driver.FindElement(By.XPath("//div[@id='wpcf7-f372-p24-o1']/form/div[2]")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}