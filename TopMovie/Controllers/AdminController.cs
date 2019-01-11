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
    public class AdminController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index()
        {
            CategoriesMoviesModel cat_mov = new CategoriesMoviesModel();
            cat_mov.movies = context.TbMovie.ToList();
            cat_mov.categories = context.TbCategoryMovie.ToList();
            return View(cat_mov);
        }
    }
}