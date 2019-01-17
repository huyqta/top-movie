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
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TopMovie.Controllers
{
    public class HomeController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index(int page = 1)
        {
            //var service = new GoogleDriveHelpers().InitGoogleDriveService();
            ////here is your request file id taken from https://drive.google.com/file/d/0B6zj9fZgMGr7dXl3Z3VxSGRadU0/view
            //FilesResource.GetRequest getRequest = service.Files.Get("1-e5zPzVpwGS-W7Cpnl3ngSEkwMUVmzPY");
            //getRequest.Fields = "webViewLink";
            //Google.Apis.Drive.v3.Data.File file = getRequest.Execute();
            ////here is the video link you wanted
            //string sourceURL = file.WebViewLink;
            ////ViewBag["URL"] = sourceURL;

            //CategoriesMoviesModel model = new CategoriesMoviesModel();
            var model = context.TbMovie.GetPaged<TbMovie>(page, 21);
            //model.categories = context.TbCategoryMovie.ToList();
            return View(model);
        }

        public IActionResult WatchMovie(int id)
        {
            var movie = context.TbMovie.FirstOrDefault(m => m.Id == id);
            return View(movie);

        }

        public IActionResult Actor(string actor)
        {
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.movies = context.TbMovie.Where(m => m.ActorTag.Contains(actor)).ToList();
            return View("ListMovies", model);
        }

        public IActionResult Tag(string tag)
        {
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.movies = context.TbMovie.Where(m => m.MovieTag.Contains(tag)).ToList();
            return View("ListMovies", model);
        }

        public IActionResult Category(string category)
        {
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.movies = context.TbMovie.Where(m => m.CategoryTag.Contains(category)).ToList();
            return View("ListMovies", model);
        }

        public IActionResult Studio(string studio)
        {
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.movies = context.TbMovie.Where(m => m.StudioTag.Contains(studio)).ToList();
            return View("ListMovies", model);
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

        [HttpGet]
        public IActionResult ListTags(string type)
        {
            ListTagModel model = new ListTagModel();
            model.TagType = type;
            return View("ListTags", model);
        }

        [HttpPost]
        public int PostComment([FromBody] TbComment comment)
        {
            comment.Id = Guid.NewGuid().ToString();
            comment.PostedDatetime = DateTime.Now;
            context.TbComment.Add(comment);
            return context.SaveChanges();
        }

        public PartialViewResult GetComment(int movieId)
        {
            var listComment = context.TbComment.Where(c => c.MovieId == movieId).ToList();
            return new PartialViewResult
            {
                ViewName = "_PartialCommentBox",
                ViewData = new ViewDataDictionary<List<TbComment>>(ViewData, listComment)
            };
        }

        [HttpGet]
        public IActionResult Search(int page, string query)
        {
            var result = context.TbMovie.Where(m => m.MovieName.Contains(query));
            if (page == 0) page = 1;
            var model = result.GetPaged<TbMovie>(page, 21);
            return View(model);
        }
    }
}
