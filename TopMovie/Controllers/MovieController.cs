using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;
using TopMovie.Helpers;
using TopMovie.Models;

namespace TopMovie
{
    [AuthorizationAttribute]
    public class MovieController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<TbMovie> GetAll()
        {
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.categories = context.TbCategoryMovie.ToList();
            model.movies = context.TbMovie.ToList();
            return model.movies.ToList();
        }

        [HttpPost]
        public int Create([FromBody] TbMovie movie)
        {
            context.TbMovie.Add(movie);
            var result = context.SaveChanges();
            return result;
        }

        [HttpPost]
        public int Update([FromBody] TbMovie movie)
        {
            var oldMovie = context.TbMovie.FirstOrDefault(c => c.Id == movie.Id);
            context.Entry<TbMovie>(oldMovie).CurrentValues.SetValues(movie);
            var result = context.SaveChanges();
            return result;
        }

        [HttpGet]
        public int Delete(int id)
        {
            var movie = context.TbMovie.FirstOrDefault(c => c.Id == id);
            context.TbMovie.Remove(movie);
            var result = context.SaveChanges();
            return result;
        }
    }
}