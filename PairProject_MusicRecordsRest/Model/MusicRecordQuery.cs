using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairProject_MusicRecordsRest.Model
{
    public class MusicRecordQuery
    {
        private int _maxDuration;
        private string _title;
        private string _artist;
        private int _yearOfPublication;

        public int MaxDuration
        {
            get => _maxDuration;
            set => _maxDuration = value;
        }

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

        public int YearOfPublication
        {
            get => _yearOfPublication;
            set => _yearOfPublication = value;
        }
    }
}
