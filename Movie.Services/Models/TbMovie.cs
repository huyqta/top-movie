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
        public string PosterUrl { get; set; }
        public string ImageUrl { get; set; }
        //private string image; // This is the backing field
        //public string ImageUrl   // This is your property
        //{
        //    get => image;
        //    set => image = "https://www.mykarateamerica.com/wp-content/uploads/2017/04/default-image.jpg";
        //}
        public string CategoryTag { get; set; }
        public string ActorTag { get; set; }
        public string MovieTag { get; set; }
        public string StudioTag { get; set; }
        public string Description { get; set; }
        public int CountView { get; set; }
        public int CountLike { get; set; }

        public virtual TbCategoryMovie Category { get; set; }
    }

    public class TbMovieOnline : TbMovie
    {

    }
}
