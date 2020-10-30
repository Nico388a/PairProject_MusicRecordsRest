using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PairProject_MusicRecordsRest.Model;

namespace PairProject_MusicRecordsRest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static List<MusicRecord> GetRecordMockup()
        {
            return new List<MusicRecord>()
            {
                new MusicRecord(1, "Boom", "Slash", 1680, 1997),
                new MusicRecord(2, "My Man", "Christiana", 900, 1986),
                new MusicRecord(3, "Aathma", "Persefone", 4500, 2014),
                new MusicRecord(4, "Jeg har en hund med fire poter albummet", "Shubidua", Int32.MaxValue, Int32.MinValue)
            };
        }
    }
}
