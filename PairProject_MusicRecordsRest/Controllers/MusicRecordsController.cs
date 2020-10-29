using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PairProject_MusicRecordsRest.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PairProject_MusicRecordsRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordsController : ControllerBase
    {
        private static List<MusicRecord> list = new List<MusicRecord>()
        {
            new MusicRecord(1, "Boom", "Slash", 1680, 1997),
            new MusicRecord(2, "My Man", "Christiana", 900, 1986),
            new MusicRecord(3, "Aathma", "Persefone", 4500, 2014),
            new MusicRecord(4, "Jeg har en hund med fire poter albummet", "Shubidua", Int32.MaxValue, Int32.MinValue)
        };

        public List<MusicRecord> List
        {
            get { return list; }
        }

        // GET: api/<MusicRecordsController>
        [HttpGet]
        public IEnumerable<MusicRecord> Get()
        {
            return list;
        }

        [HttpGet]
        [Route("{id}")]
        public MusicRecord Get(int id)
        {
            return list.Find(record => record.Id == id);
        }

        // GET api/<MusicRecordsController>/5
        [HttpGet]
        [Route("{search?}")]
        public IEnumerable<MusicRecord> Search([FromQuery] MusicRecordQuery query)
        {
            List<MusicRecord> filteredList = new List<MusicRecord>();

            //if (query.Title == null) query.Title = "";
            //if (query.Artist == null) query.Artist = "";
            //if (query.MaxDuration <= 0) query.MaxDuration = Int32.MaxValue;
            //if (query.YearOfPublication <= 0) query.YearOfPublication = Int32.MinValue;

            //filteredList = list.FindAll(record =>
            //    record.Duration <= query.MaxDuration && record.Artist.StartsWith(query.Artist) &&
            //    record.Title.StartsWith(query.Title) && record.YearOfPublication >= query.YearOfPublication);

            //Still "static", but standardized.

            Predicate<MusicRecord> condTitle, condArtist, condDuration, condYearOfPublication;

            if (query.Title != null) condTitle = m => m.Title.StartsWith(query.Title);
            else condTitle = True;

            if (query.Artist != null) condArtist = m => m.Artist.StartsWith(query.Artist);
            else condArtist = True;

            if (query.MaxDuration > 0) condDuration = m => m.Duration <= query.MaxDuration;
            else condDuration = True;

            if (query.YearOfPublication > 0)
                condYearOfPublication = m => m.YearOfPublication >= query.YearOfPublication;
            else condYearOfPublication = True;

            filteredList = list.FindAll(record =>
                condDuration(record) && condArtist(record) && condTitle(record) && condYearOfPublication(record));

            return filteredList;

            bool True(MusicRecord m)
            {
                return true;
            }
        }

        // POST api/<MusicRecordsController>
        [HttpPost]
        public void Post([FromBody] MusicRecord value)
        {
            int id = list[^1].Id + 1;
            value.Id = id;
            list.Add(value);
        }

        // PUT api/<MusicRecordsController>/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] MusicRecord value)
        {
            MusicRecord record = Get(id);
            if (record != null)
            {
                record.Title = value.Title;
                record.Artist = value.Artist;
                record.Duration = value.Duration;
                record.YearOfPublication = value.YearOfPublication;
            }
        }

        // DELETE api/<MusicRecordsController>/5
        [HttpDelete]
        [Route("{delete?}")]
        public int Delete([FromQuery] MusicRecordQuery query)
        {
            if (query.Artist == null && query.Title == null) return 0;

            Predicate<MusicRecord> condTitle, condArtist;

            if (query.Title != null) condTitle = m => m.Title == query.Title;
            else condTitle = True;

            if (query.Artist != null) condArtist = m => m.Artist == query.Artist;
            else condArtist = True;

            return list.RemoveAll(record => condArtist(record) && condTitle(record));
            

            bool True(MusicRecord m)
            {
                return true;
            }
        }
    }
}
