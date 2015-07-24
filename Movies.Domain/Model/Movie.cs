using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public Nullable<int> Rating { get; set; }
    }
}
