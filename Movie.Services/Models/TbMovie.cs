using System;
using System.Collections.Generic;

namespace Movie.Services.Models
{
    public partial class TbMovie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int? CategoryId { get; set; }
        public string ImdbId { get; set; }
        public string Country { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string MovieType { get; set; }
        public string Trailer { get; set; }
        public string GoogleDrive { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryTag { get; set; }
        public string ActorTag { get; set; }

        public virtual TbCategoryMovie Category { get; set; }
    }
}
