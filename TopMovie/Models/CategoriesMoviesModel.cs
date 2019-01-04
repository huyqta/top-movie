using Movie.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopMovie.Models
{
    public class CategoriesMoviesModel
    {
        public List<TbCategoryMovie> categories { get; set; }
        public List<TbMovie> movies { get; set; }
    }
}
