using System;
using System.Collections.Generic;

namespace Movie.Services.Models
{
    public partial class TbMovie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int CategoryId { get; set; }
        public string ImdbId { get; set; }
    }
}
