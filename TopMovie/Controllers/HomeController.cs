using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;
using TopMovie.Helpers;
using TopMovie.Models;

namespace TopMovie.Controllers
{
    public class HomeController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index()
        {
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.movies = context.TbMovie.ToList();
            model.categories = context.TbCategoryMovie.ToList();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
