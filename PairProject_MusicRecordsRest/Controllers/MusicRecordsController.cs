﻿using System;
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
            new MusicRecord("Boom", "Slash", 1680, 1997),
            new MusicRecord("My Man", "Christiana", 900, 1986),
            new MusicRecord("Aathma", "Persefone", 4500, 2014),
            new MusicRecord("Jeg har en hund med fire poter albummet", "Shubidua", Int32.MaxValue, Int32.MinValue)
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

        // GET api/<MusicRecordsController>/5
        [HttpGet]
        [Route("{search?}")]
        public IEnumerable<MusicRecord> Search([FromQuery] MusicRecordQuery query)
        {
            List<MusicRecord> filteredList = new List<MusicRecord>();

            if (query.Title == null) query.Title = "";
            if (query.Artist == null) query.Artist = "";
            if (query.MaxDuration <= 0) query.MaxDuration = Int32.MaxValue;
            if (query.YearOfPublication <= 0) query.YearOfPublication = Int32.MinValue;

            filteredList = list.FindAll(record =>
                record.Duration <= query.MaxDuration && record.Artist.StartsWith(query.Artist) &&
                record.Title.StartsWith(query.Title) && record.YearOfPublication >= query.YearOfPublication);

            return filteredList;
        }

        // POST api/<MusicRecordsController>
        [HttpPost]
        [Route("")]
        public void Post([FromBody] MusicRecord value)
        {
            
            list.Add(value);

        }

        // PUT api/<MusicRecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicRecordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
