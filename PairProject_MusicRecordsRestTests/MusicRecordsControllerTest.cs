using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairProject_MusicRecordsRest.Controllers;
using PairProject_MusicRecordsRest.Model;

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

        [TestMethod]
        public void RestSearchTest()
        {
            MusicRecordQuery query = new MusicRecordQuery();
            query.Title = "Dead";
            MusicRecord record = new MusicRecord("Dead Rock", "Gorm", 500, 1926);
            _controller.List.Add(record);
            IEnumerable<MusicRecord> filteredRecords = _controller.Search(query);

            Assert.AreEqual(record.Title, filteredRecords.ElementAt(0).Title);
            query.YearOfPublication = 1950;
            filteredRecords = _controller.Search(query);
            Assert.AreEqual(0, filteredRecords.Count());
        }


        [TestMethod]
        public void PostTest()
        {
            int arrange = _controller.List.Count;

            _controller.Post(new MusicRecord());

            Assert.AreEqual(arrange + 1, _controller.List.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int arrange = _controller.List.Count;

            _controller.Delete(new MusicRecordQuery(){Title = "Boom"});

            Assert.AreEqual(true, arrange > _controller.List.Count);
        }
        
    }
}
