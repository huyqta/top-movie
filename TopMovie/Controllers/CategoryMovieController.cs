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
            return View(model);
        }
    }
}