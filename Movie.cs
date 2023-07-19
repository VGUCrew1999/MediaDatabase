using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDatabase
{
    internal class Movie
    {
        public string MovieId { get; set; }
        public string MovieName { get; set; }
        public double LengthHours { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
