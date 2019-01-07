using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;
using TopMovie.Helpers;
using TopMovie.Models;

namespace TopMovie.Controllers
{
    public class CategoryMovieController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index()
        {
            GoogleDriveHelpers gdhelper = new GoogleDriveHelpers();
            var service = gdhelper.InitGoogleDriveService();

            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("{0} ({1})", file.Name, file.Id);
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            //Console.Read();

            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.categories = context.TbCategoryMovie.ToList();
            model.movies = context.TbMovie.ToList();
            return PartialView(model);
        }

        [HttpPost]
        public List<TbCategoryMovie> GetAll()
        {
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.categories = context.TbCategoryMovie.ToList();
            model.movies = context.TbMovie.ToList();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = model.categories.ToList() });
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