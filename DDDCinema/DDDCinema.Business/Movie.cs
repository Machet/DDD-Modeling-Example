using System;
using System.Collections.Generic;

namespace DDDCinema.Movies
{
    public class Movie
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPremiere { get; set; }
        public TimeSpan Length { get; set; }
        public virtual List<Seanse> Seanses { get; set; }
    }
}
