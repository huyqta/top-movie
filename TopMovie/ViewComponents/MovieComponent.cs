using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopMovie.Models;

namespace TopMovie.ViewComponents
{
    public class MovieViewComponent : ViewComponent
    {
        webphimContext context = new webphimContext();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var model = context.TbMovie.ToList();
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.movies = context.TbMovie.ToList();
            model.categories = context.TbCategoryMovie.ToList();
            return await Task.FromResult((IViewComponentResult)View("ListMovie", model));
        }
    }
}
