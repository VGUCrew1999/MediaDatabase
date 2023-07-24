using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDatabase
{
    internal class VideoGame
    {
        public string GameId { get; set; }
        public string GameName { get; set; }
        public string Console { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
