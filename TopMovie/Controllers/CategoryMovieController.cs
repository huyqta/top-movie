using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;
using TopMovie.Models;

namespace TopMovie.Controllers
{
    public class CategoryMovieController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index()
        {
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.categories = context.TbCategoryMovie.ToList();
            model.movies = context.TbMovie.ToList();
            return View(model);
        }
    }
}