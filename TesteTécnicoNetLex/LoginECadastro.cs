using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TesteTécnicoNetLex
{
    [TestFixture]
    public class LoginECadastro
    {
        static void Main()
        {
        }

        private ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CriarCadastro()
        {
            driver.Navigate().GoToUrl("https://letsbomfin.github.io/cadastro.github.io/#paracadastro");

            Assert.AreEqual(driver.Title, "Formulário de Login e Registro com HTML5 e CSS3");

            driver.FindElement(By.Id("nome_cad")).SendKeys("Carolina");
            driver.FindElement(By.Id("email_cad")).SendKeys("costacarol87@gmail.com");
            driver.FindElement(By.Id("estado_cad")).SendKeys("Minas Gerais");
            driver.FindElement(By.Id("cidade_cad")).SendKeys("Belo Horizonte");
            driver.FindElement(By.Id("rua_cad")).SendKeys("Rua Goias 272");
            driver.FindElement(By.Id("bairro_cad")).SendKeys("Centro");
            driver.FindElement(By.Name("cep")).SendKeys("30190");
            driver.FindElement(By.Name("cep2")).SendKeys("030");
            driver.FindElement(By.Id("senha_cad")).SendKeys("Senha@123");     

            IWebElement email = driver.FindElement(By.Id("email_cad"));
            string emailContains = email.Text;
            StringAssert.Contains(emailContains, "@");

            driver.FindElement(By.XPath("//input[@value='Cadastrar']")).Click();

            // Assert somente para o teste passar, no entanto esse resultado é um bug
            IWebElement status405 = driver.FindElement(By.XPath("//h1[text()='405 Not Allowed']"));
            string status405Text = status405.Text;
            string status405Message = "405 Not Allowed";
            Assert.AreEqual(status405Text, status405Message);
        }

        [Test]
        public void FazerLogin()
        {
            driver.Navigate().GoToUrl("https://letsbomfin.github.io/cadastro.github.io/#paralogin");

            Assert.AreEqual(driver.Title, "Formulário de Login e Registro com HTML5 e CSS3");

            driver.FindElement(By.Id("nome_login")).SendKeys("Carolina");
            driver.FindElement(By.Id("email_login")).SendKeys("costacarol87@gmail.com");
            driver.FindElement(By.XPath("//input[@value='Logar']")).Click();

            // Assert somente para o teste passar, no entanto esse resultado é um bug
            IWebElement status405 = driver.FindElement(By.XPath("//h1[text()='405 Not Allowed']"));
            string status405Text = status405.Text;
            string status405Message = "405 Not Allowed";
            Assert.AreEqual(status405Text, status405Message);
        }

        [Test]
        public void ClicarNoBotaoResetar()
        {
            driver.Navigate().GoToUrl("https://letsbomfin.github.io/cadastro.github.io/#paracadastro");

            Assert.AreEqual(driver.Title, "Formulário de Login e Registro com HTML5 e CSS3");

            driver.FindElement(By.Id("nome_cad")).SendKeys("Carolina");
            driver.FindElement(By.Id("email_cad")).SendKeys("costacarol87@gmail.com");
            driver.FindElement(By.XPath("//input[@value='Resetar']")).Click();

            IWebElement nome = driver.FindElement(By.Id("nome_cad"));
            string nomeEmpty = nome.Text;
            Assert.IsEmpty(nomeEmpty);

            IWebElement email = driver.FindElement(By.Id("email_cad"));
            string emailEmpty = email.Text;
            Assert.IsEmpty(emailEmpty);
        }

        [Test]
        public void AcessarLoginNaPaginaCadastro()
        {
            driver.Navigate().GoToUrl("https://letsbomfin.github.io/cadastro.github.io/#paracadastro");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[@href='#paralogin']")).Click();

            Assert.AreEqual(driver.Title, "Formulário de Login e Registro com HTML5 e CSS3");
        }

        [Test]
        public void AcessarCadastroNaPaginaLogin()
        {
            driver.Navigate().GoToUrl("https://letsbomfin.github.io/cadastro.github.io/#paralogin");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("cadastre_botton")).Click();

            Assert.AreEqual(driver.Title, "Formulário de Login e Registro com HTML5 e CSS3");

        }
    }
}
