using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairProject_MusicRecordsRest.Controllers;

namespace PairProject_MusicRecordsRestTests
{
    [TestClass]
    public class MusicRecordsControllerTest
    {
        private MusicRecordsController _controller;

        [TestInitialize]
        public void Init()
        {
            _controller = new MusicRecordsController();
        }

        [TestMethod]
        public void RestServiceTest()
        {
            Assert.AreEqual(_controller.List.Count, _controller.Get().Count());
        }

    }
}
