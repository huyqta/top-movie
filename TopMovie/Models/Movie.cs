using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopMovie.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int CategoryId { get; set; }
        public string ImdbId { get; set; }
        public string Country { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MovieType { get; set; }
        public string Trailer { get; set; }
        public string GoogleDrive { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryTag { get; set; }
        public string ActorTag { get; set; }
    }
}
