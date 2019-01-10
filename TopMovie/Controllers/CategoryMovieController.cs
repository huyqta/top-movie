using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TopMovie.Helpers;
using TopMovie.Models;

namespace TopMovie.Controllers
{
    [AuthorizationAttribute]
    public class CategoryMovieController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index()
        {
            //CategoriesMoviesModel model = new CategoriesMoviesModel();
            //model.categories = context.TbCategoryMovie.ToList();
            //model.movies = context.TbMovie.ToList();
            return View();
        }

        [HttpPost]
        public List<TbCategoryMovie> GetAll()
        {
            //var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //var start = Request.Form.GetValues("start").FirstOrDefault();
            //var length = Request.Form.GetValues("length").FirstOrDefault();
            //var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            //var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


            ////Paging Size (10,20,50,100)    
            //int pageSize = length != null ? Convert.ToInt32(length) : 0;
            //int skip = start != null ? Convert.ToInt32(start) : 0;
            //int recordsTotal = 0;

            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.categories = context.TbCategoryMovie.ToList();
            model.movies = context.TbMovie.ToList();
            return model.categories.ToList();
        }

        [HttpGet]
        public TbCategoryMovie GetById(int id)
        {
            return context.TbCategoryMovie.FirstOrDefault(c=>c.Id == id);
        }

        [HttpPost]
        public int Create([FromBody] TbCategoryMovie categoryData)
        {
            context.TbCategoryMovie.Add(categoryData);
            var result = context.SaveChanges();
            return result;
        }

        [HttpPost]
        public int Update([FromBody] TbCategoryMovie categoryData)
        {
            var oldCategory = context.TbCategoryMovie.FirstOrDefault(c=>c.Id == categoryData.Id);
            context.Entry<TbCategoryMovie>(oldCategory).CurrentValues.SetValues(categoryData);
            var result = context.SaveChanges();
            return result;
        }

        [HttpGet]
        public int Delete(int id)
        {
            var category = context.TbCategoryMovie.FirstOrDefault(c => c.Id == id);
            context.TbCategoryMovie.Remove(category);
            var result = context.SaveChanges();
            return result;
        }
    }
}