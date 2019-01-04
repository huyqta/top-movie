using System;
using System.Collections.Generic;

namespace Movie.Services.Models
{
    public partial class TbCategoryMovie
    {
        public TbCategoryMovie()
        {
            TbMovie = new HashSet<TbMovie>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }

        public virtual ICollection<TbMovie> TbMovie { get; set; }
    }
}
