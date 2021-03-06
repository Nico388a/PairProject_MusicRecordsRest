﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PairProject_MusicRecordsRest.Controllers;

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
            using (HttpClient client = new HttpClient())
            {
                var respnse = client.DeleteAsync(
                    "https://pairprojectmusicrecordsrest20201020113611.azurewebsites.net/api/MusicRecords/clean").Result;
            }
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

            IWebElement inputPutTitle = _driver.FindElement(By.Id("putTitle"));
            IWebElement inputTitle = _driver.FindElement(By.Id("title"));
            IWebElement inputArtist = _driver.FindElement(By.Id("artist"));
            IWebElement inputDuration = _driver.FindElement(By.Id("duration"));
            IWebElement inputYearOfPublication = _driver.FindElement(By.Id("year of publication"));
            IWebElement inputDeleteArtist = _driver.FindElement(By.Id("deleteArtist"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            IWebElement musicList = wait.Until(d => d.FindElement(By.Id("musicList")));

            Assert.IsTrue(musicList.Text.Contains("Boom"));

            IWebElement testElement = _driver.FindElement(By.Id("testElement"));
            testElement.Click();

            IWebElement searchButton = _driver.FindElement(By.Id("search button"));
            inputTitle.SendKeys("Boom");
            searchButton.Click();
            musicList = wait.Until(d => d.FindElement(By.Id("musicList")));

            Assert.IsTrue(musicList.Text.Contains("Boom"));
            Assert.IsFalse(musicList.Text.Contains("My Man"));

            IWebElement addButton = _driver.FindElement(By.Id("add button"));
            inputArtist.SendKeys("Gilan");
            inputDuration.SendKeys("800");
            inputYearOfPublication.SendKeys("2005");
            addButton.Click();
            testElement.Click();
            musicList = wait.Until(d => d.FindElement(By.Id("musicList")));

            Assert.IsTrue(musicList.Text.Contains("Gilan")&& musicList.Text.Contains("800") && musicList.Text.Contains("2005"));

            IWebElement deleteButton = _driver.FindElement(By.Id("deleteButton"));
            inputDeleteArtist.SendKeys("Gilan");
            
            deleteButton.Click();
            IWebElement deleteText = wait.Until(d => d.FindElement(By.Id("deleteText"))); 
            Assert.IsTrue(deleteText.Text.Contains("Deleted items: "));

            IWebElement updateButton = _driver.FindElement(By.Id("update button"));
            IWebElement firsElement = _driver.FindElement(By.Id("titleCol"));
            firsElement.Click();
            inputPutTitle.SendKeys("PUT TEST");
            testElement.Click();
            updateButton.Click();

            musicList = wait.Until(d => d.FindElement(By.Id("musicList")));
            Assert.IsTrue(musicList.Text.Contains("PUT TEST"));
            Assert.IsFalse(musicList.Text.Contains("Boom"));

            
        }
    }
}
