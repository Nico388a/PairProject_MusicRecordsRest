using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PairProject_MusicRecordsRestTests
{
    [TestClass]
    public class MusicRecordsUITest
    {
        private const string DIRECTORY = "C:\\Selenium drive";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _driver = new ChromeDriver(DIRECTORY);
        }

        [ClassCleanup]
        public static void Clean()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void UITest()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            Assert.AreEqual("Hello app", _driver.Title);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            IWebElement musicList = wait.Until(d => d.FindElement(By.Id("musicList")));

            Assert.IsTrue(musicList.Text.Contains("Boom"));

            IWebElement testElement = _driver.FindElement(By.Id("testElement"));
            testElement.Click();

            //IWebElement searchButton = _driver.FindElement(By.Id("search button"));
            //IWebElement inputTitle = _driver.FindElement(By.Id("title"));
            //inputTitle.SendKeys("Boom");
            //searchButton.Click();
            //_driver.
        }
    }
}
