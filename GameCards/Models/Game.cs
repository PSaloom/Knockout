using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCards.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string BoxArtURL { get; set; }
        private int _releaseDay;
        public int ReleaseDay
        {
            get
            {
                _releaseDay = ReleaseDate.Day;
                return _releaseDay;
            }
        }

        private string _releaseDayOfWeek;
        public string ReleaseDayOfWeek
        {
            get
            {
                _releaseDayOfWeek = ReleaseDate.DayOfWeek.ToString();
                return _releaseDayOfWeek;
            }
        }

        private string _releaseMonth;
        public string ReleaseMonth
        {
            get
            {
                _releaseMonth = ReleaseDate.Month.ToString();
                return _releaseMonth;
            }
        }

        private string _releaseYear;
        public string ReleaseYear
        {
            get
            {
                _releaseYear = ReleaseDate.Year.ToString();
                return _releaseYear;
            }
        }        
    }
}