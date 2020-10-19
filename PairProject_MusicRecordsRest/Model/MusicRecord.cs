using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairProject_MusicRecordsRest.Model
{
    public class MusicRecord
    {
        private string _title;
        private string _artist;
        private int _duration;
        private int _yearOfPublication;

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Artist
        {
            get => _artist;
            set => _artist = value;
        }

        public int Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public int YearOfPublication
        {
            get => _yearOfPublication;
            set => _yearOfPublication = value;
        }

        public MusicRecord()
        {
            
        }

        public MusicRecord(string title, string artist, int duration, int yearOfPublication)
        {
            _title = title;
            _artist = artist;
            _duration = duration;
            _yearOfPublication = yearOfPublication;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
